// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go_Test
// Author           : Mario
// Created          : 01-20-2017
//
// Last Modified By : Mario
// Last Modified On : 01-20-2017
// ***********************************************************************
// <copyright file="KopernicusBody.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using KSP_To_Boldly_Go_Common;
using System;
using System.Drawing;

namespace KSP_To_Boldly_Go_Test
{
    /// <summary>
    /// Class KopernicusBody.
    /// </summary>
    /// <seealso cref="KSP_To_Boldly_Go_Common.IKopernicusObject" />
    public class KopernicusBody : IKopernicusObject
    {
        #region Properties

        /// <summary>
        /// Gets the cb name later.
        /// </summary>
        /// <value>The cb name later.</value>
        public string cbNameLater
        {
            get
            {
                return "Sun";
            }
            set
            {
            }
        }

        /// <summary>
        /// Gets or sets the header.
        /// </summary>
        /// <value>The header.</value>
        public KopernicusHeader Header
        {
            get
            {
                return null;
            }
            set
            {
            }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string name
        {
            get
            {
                return "Kerbol";
            }
            set
            {
            }
        }

        /// <summary>
        /// Gets or sets the orbit.
        /// </summary>
        /// <value>The orbit.</value>
        public KopernicusOrbit Orbit
        {
            get
            {
                return new KopernicusOrbit();
            }
        }

        /// <summary>
        /// Gets or sets the propereties.
        /// </summary>
        /// <value>The propereties.</value>
        public KopernicusProperties Propereties
        {
            get
            {
                return new KopernicusProperties();
            }
        }

        /// <summary>
        /// Gets the scaled version.
        /// </summary>
        /// <value>The scaled version.</value>
        public KopernicusScaledVersion ScaledVersion
        {
            get
            {
                return new KopernicusScaledVersion();
            }
        }

        /// <summary>
        /// Gets or sets the template.
        /// </summary>
        /// <value>The template.</value>
        public KopernicusTemplate Template
        {
            get
            {
                return new KopernicusTemplate();
            }
        }

        #endregion Properties
    }

    /// <summary>
    /// Class KopernicusLight.
    /// </summary>
    /// <seealso cref="KSP_To_Boldly_Go_Common.IKopernicusObject" />
    public class KopernicusLight : IKopernicusObject
    {
        #region Properties

        /// <summary>
        /// Gets the color of the ambient light.
        /// </summary>
        /// <value>The color of the ambient light.</value>
        public Color ambientLightColor
        {
            get
            {
                return Color.FromArgb(0, 0, 0, 255);
            }
        }

        /// <summary>
        /// Gets or sets the header.
        /// </summary>
        /// <value>The header.</value>
        public KopernicusHeader Header
        {
            get;

            set;
        }

        /// <summary>
        /// Gets the color of the iva sun.
        /// </summary>
        /// <value>The color of the iva sun.</value>
        public Color IVASunColor
        {
            get
            {
                return Color.FromArgb(255, 255, 255, 255);
            }
        }

        /// <summary>
        /// Gets the iva sun intensity.
        /// </summary>
        /// <value>The iva sun intensity.</value>
        public double IVASunIntensity
        {
            get
            {
                return 0.75;
            }
        }

        /// <summary>
        /// Gets the luminosity.
        /// </summary>
        /// <value>The luminosity.</value>
        public long luminosity
        {
            get
            {
                return 1350;
            }
        }

        /// <summary>
        /// Gets the color of the scaled sunlight.
        /// </summary>
        /// <value>The color of the scaled sunlight.</value>
        public Color scaledSunlightColor
        {
            get
            {
                return Color.FromArgb(255, 255, 255, 255);
            }
        }

        /// <summary>
        /// Gets the scaled sunlight intensity.
        /// </summary>
        /// <value>The scaled sunlight intensity.</value>
        public double scaledSunlightIntensity
        {
            get
            {
                return 0.75;
            }
        }

        /// <summary>
        /// Gets the color of the sun lens flare.
        /// </summary>
        /// <value>The color of the sun lens flare.</value>
        public Color sunLensFlareColor
        {
            get
            {
                return Color.FromArgb(0, 0, 0, 0);
            }
        }

        /// <summary>
        /// Gets the color of the sunlight.
        /// </summary>
        /// <value>The color of the sunlight.</value>
        public Color sunlightColor
        {
            get
            {
                return Color.FromArgb(255, 255, 255, 255);
            }
        }

        /// <summary>
        /// Gets the sunlight intensity.
        /// </summary>
        /// <value>The sunlight intensity.</value>
        public double sunlightIntensity
        {
            get
            {
                return 0.75;
            }
        }

        /// <summary>
        /// Gets the sunlight shadow strength.
        /// </summary>
        /// <value>The sunlight shadow strength.</value>
        public double sunlightShadowStrength
        {
            get
            {
                return 0.95;
            }
        }

        #endregion Properties
    }

    /// <summary>
    /// Class KopernicusMain.
    /// </summary>
    /// <seealso cref="KSP_To_Boldly_Go_Common.IKopernicusObject" />
    public class KopernicusMain : IKopernicusObject
    {
        #region Properties

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>The body.</value>
        public KopernicusBody Body
        {
            get
            {
                return new KopernicusBody();
            }
        }

        /// <summary>
        /// Gets the file header.
        /// </summary>
        /// <value>The file header.</value>
        public KopernicusHeader Header
        {
            get
            {
                return "@Kopernicus";
            }
            set
            {
            }
        }

        #endregion Properties
    }

    /// <summary>
    /// Class KopernicusMaterial.
    /// </summary>
    /// <seealso cref="KSP_To_Boldly_Go_Common.IKopernicusObject" />
    public class KopernicusMaterial : IKopernicusObject
    {
        #region Properties

        /// <summary>
        /// Gets the emit color0.
        /// </summary>
        /// <value>The emit color0.</value>
        public Color emitColor0
        {
            get
            {
                return Color.FromArgb(255, 255, 255, 255);
            }
        }

        /// <summary>
        /// Gets the emit color1.
        /// </summary>
        /// <value>The emit color1.</value>
        public Color emitColor1
        {
            get
            {
                return Color.FromArgb(255, 255, 255, 255);
            }
        }

        /// <summary>
        /// Gets or sets the header.
        /// </summary>
        /// <value>The header.</value>
        public KopernicusHeader Header
        {
            get;

            set;
        }

        /// <summary>
        /// Gets the color of the rim.
        /// </summary>
        /// <value>The color of the rim.</value>
        public Color rimColor
        {
            get
            {
                return Color.FromArgb(255, 255, 255, 255);
            }
        }

        /// <summary>
        /// Gets the sunspot colors.
        /// </summary>
        /// <value>The sunspot colors.</value>
        public Color sunspotColors
        {
            get
            {
                return Color.FromArgb(255, 255, 255, 255);
            }
        }

        #endregion Properties
    }

    /// <summary>
    /// Class KopernicusOrbit.
    /// </summary>
    /// <seealso cref="KSP_To_Boldly_Go_Common.IKopernicusObject" />
    public class KopernicusOrbit : IKopernicusObject
    {
        #region Properties

        /// <summary>
        /// Gets the argument of periapsis.
        /// </summary>
        /// <value>The argument of periapsis.</value>
        public long argumentOfPeriapsis
        {
            get
            {
                return 125;
            }
        }

        /// <summary>
        /// Gets the color.
        /// </summary>
        /// <value>The color.</value>
        public Color color
        {
            get
            {
                return Color.FromArgb(255, 20, 255, 0);
            }
        }

        /// <summary>
        /// Gets or sets the header.
        /// </summary>
        /// <value>The header.</value>
        public KopernicusHeader Header
        {
            get
            {
                return null;
            }
            set
            {
            }
        }

        /// <summary>
        /// Gets the inclination.
        /// </summary>
        /// <value>The inclination.</value>
        public long inclination
        {
            get
            {
                return 124;
            }
        }

        /// <summary>
        /// Gets the mode.
        /// </summary>
        /// <value>The mode.</value>
        public long mode
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// Gets the reference body.
        /// </summary>
        /// <value>The reference body.</value>
        public string referenceBody
        {
            get
            {
                return "Sun";
            }
        }

        /// <summary>
        /// Gets the semi major axis.
        /// </summary>
        /// <value>The semi major axis.</value>
        public long semiMajorAxis
        {
            get
            {
                return 4386767840385437;
            }
        }

        #endregion Properties
    }

    /// <summary>
    /// Class KopernicusProperties.
    /// </summary>
    /// <seealso cref="KSP_To_Boldly_Go_Common.IKopernicusObject" />
    public class KopernicusProperties : IKopernicusObject
    {
        #region Properties

        /// <summary>
        /// Gets or sets the header.
        /// </summary>
        /// <value>The header.</value>
        public KopernicusHeader Header
        {
            get
            {
                return null;
            }
            set
            {
            }
        }

        /// <summary>
        /// Gets the sphere of influence.
        /// </summary>
        /// <value>The sphere of influence.</value>
        public long sphereOfInfluence
        {
            get
            {
                return 220118820000;
            }
        }

        #endregion Properties
    }

    /// <summary>
    /// Class KopernicusScaledVerson.
    /// </summary>
    /// <seealso cref="KSP_To_Boldly_Go_Common.IKopernicusObject" />
    public class KopernicusScaledVersion : IKopernicusObject
    {
        #region Properties

        /// <summary>
        /// Gets or sets the header.
        /// </summary>
        /// <value>The header.</value>
        public KopernicusHeader Header
        {
            get
            {
                return null;
            }

            set
            {
            }
        }

        /// <summary>
        /// Gets or sets the light.
        /// </summary>
        /// <value>The light.</value>
        public KopernicusLight Light
        {
            get
            {
                return new KopernicusLight();
            }
        }

        /// <summary>
        /// Gets or sets the material.
        /// </summary>
        /// <value>The material.</value>
        public KopernicusMaterial Material
        {
            get
            {
                return new KopernicusMaterial();
            }
        }

        #endregion Properties
    }

    /// <summary>
    /// Class KopernicusTemplate.
    /// </summary>
    /// <seealso cref="KSP_To_Boldly_Go_Common.IKopernicusObject" />
    public class KopernicusTemplate : IKopernicusObject
    {
        #region Properties

        /// <summary>
        /// Gets or sets the header.
        /// </summary>
        /// <value>The header.</value>
        public KopernicusHeader Header
        {
            get;
            set;            
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string name
        {
            get
            {
                return "Sun";
            }
        }

        #endregion Properties
    }
}