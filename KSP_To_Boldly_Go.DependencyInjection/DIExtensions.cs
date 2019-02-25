// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.DependencyInjection
// Author           : Mario
// Created          : 02-23-2019
//
// Last Modified By : Mario
// Last Modified On : 02-25-2019
// ***********************************************************************
// <copyright file="DIExtensions.cs" company="Mario">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using SimpleInjector;

/// <summary>
/// The DependencyInjection namespace.
/// </summary>
namespace KSP_To_Boldly_Go.DependencyInjection
{
    /// <summary>
    /// Class DIExtensions.
    /// </summary>
    public static class DIExtensions
    {
        #region Methods

        //Src: https://stackoverflow.com/questions/21905058/factory-interface-in-simple-injector
        /// <summary>
        /// Registers the factory.
        /// </summary>
        /// <typeparam name="TFactory">The type of the t factory.</typeparam>
        /// <param name="container">The container.</param>
        /// <exception cref="ArgumentException"></exception>
        public static void RegisterFactory<TFactory>(this Container container)
        {
            if (!typeof(TFactory).IsInterface)
                throw new ArgumentException(typeof(TFactory).Name + " is no interface");

            container.ResolveUnregisteredType += (s, e) =>
            {
                if (e.UnregisteredServiceType == typeof(TFactory))
                {
                    e.Register(Expression.Constant(
                        value: CreateFactory(typeof(TFactory), container),
                        type: typeof(TFactory)));
                }
            };
        }

        /// <summary>
        /// Registers the without transient warning.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="container">The container.</param>
        public static void RegisterWithoutTransientWarning<T>(this Container container) where T : class
        {
            container.Register<T>();
            var registration = container.GetRegistration(typeof(T)).Registration;
            registration.SuppressDiagnosticWarning(SimpleInjector.Diagnostics.DiagnosticType.DisposableTransientComponent, "Using WinForms.");
        }

        /// <summary>
        /// Creates the factory.
        /// </summary>
        /// <param name="factoryType">Type of the factory.</param>
        /// <param name="container">The container.</param>
        /// <returns>System.Object.</returns>
        private static object CreateFactory(Type factoryType, Container container)
        {
            var proxy = new AutomaticFactoryProxy(factoryType, container);
            return proxy.GetTransparentProxy();
        }

        #endregion Methods

        #region Classes

        /// <summary>
        /// Class AutomaticFactoryProxy. This class cannot be inherited.
        /// </summary>
        /// <seealso cref="System.Runtime.Remoting.Proxies.RealProxy" />
        private sealed class AutomaticFactoryProxy : RealProxy
        {
            #region Fields

            /// <summary>
            /// The container
            /// </summary>
            private readonly Container container;

            /// <summary>
            /// The factory type
            /// </summary>
            private readonly Type factoryType;

            #endregion Fields

            #region Constructors

            /// <summary>
            /// Initializes a new instance of the <see cref="AutomaticFactoryProxy" /> class.
            /// </summary>
            /// <param name="factoryType">Type of the factory.</param>
            /// <param name="container">The container.</param>
            public AutomaticFactoryProxy(Type factoryType, Container container)
                : base(factoryType)
            {
                this.factoryType = factoryType;
                this.container = container;
            }

            #endregion Constructors

            #region Methods

            /// <summary>
            /// When overridden in a derived class, invokes the method that is specified in the provided <see cref="T:System.Runtime.Remoting.Messaging.IMessage" /> on the remote object that is represented by the current instance.
            /// </summary>
            /// <param name="msg">A <see cref="T:System.Runtime.Remoting.Messaging.IMessage" /> that contains a <see cref="T:System.Collections.IDictionary" /> of information about the method call.</param>
            /// <returns>The message returned by the invoked method, containing the return value and any <see langword="out" /> or <see langword="ref" /> parameters.</returns>
            public override IMessage Invoke(IMessage msg)
            {
                if (msg is IMethodCallMessage)
                {
                    return InvokeFactory(msg as IMethodCallMessage);
                }

                return msg;
            }

            /// <summary>
            /// Invokes the factory.
            /// </summary>
            /// <param name="msg">The MSG.</param>
            /// <returns>IMessage.</returns>
            private IMessage InvokeFactory(IMethodCallMessage msg)
            {
                if (msg.MethodName == "GetType")
                    return new ReturnMessage(this.factoryType, null, 0, null, msg);

                if (msg.MethodName == "ToString")
                    return new ReturnMessage(this.factoryType.Name, null, 0, null, msg);

                var method = (MethodInfo)msg.MethodBase;
                object instance = this.container.GetInstance(method.ReturnType);
                return new ReturnMessage(instance, null, 0, null, msg);
            }

            #endregion Methods
        }

        #endregion Classes
    }
}