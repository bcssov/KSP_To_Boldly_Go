using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace MaterialSkin.Controls
{
    public class MaterialMenuStrip : MenuStrip, IMaterialControl
    {
        #region Constructors

        public MaterialMenuStrip()
        {
            Renderer = new MaterialMenuStripRender();

            if (DesignMode)
            {
                Dock = DockStyle.None;
                Anchor |= AnchorStyles.Right;
                AutoSize = false;
                Location = new Point(0, 28);
            }
        }

        #endregion Constructors

        #region Properties

        public int Depth { get; set; }
        public MouseState MouseState { get; set; }
        public MaterialSkinManager SkinManager { get { return MaterialSkinManager.Instance; } }

        #endregion Properties

        #region Methods

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            Font = SkinManager.ROBOTO_MEDIUM_10;
            BackColor = SkinManager.GetApplicationBackgroundColor();
            BackColorChanged += MaterialMenuStrip_BackColorChanged;
        }

        private void MaterialMenuStrip_BackColorChanged(object sender, EventArgs e)
        {
            BackColor = SkinManager.GetApplicationBackgroundColor();
        }

        #endregion Methods
    }

    internal class MaterialMenuStripRender : ToolStripProfessionalRenderer, IMaterialControl
    {
        #region Properties

        //Properties for managing the material design properties
        public int Depth { get; set; }

        public MouseState MouseState { get; set; }
        public MaterialSkinManager SkinManager { get { return MaterialSkinManager.Instance; } }

        #endregion Properties

        #region Methods

        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            var g = e.Graphics;
            const int ARROW_SIZE = 4;

            var arrowMiddle = new Point(e.ArrowRectangle.X + e.ArrowRectangle.Width / 2, e.ArrowRectangle.Y + e.ArrowRectangle.Height / 2);
            var arrowBrush = e.Item.Enabled ? SkinManager.GetPrimaryTextBrush() : SkinManager.GetDisabledOrHintBrush();
            using (var arrowPath = new GraphicsPath())
            {
                arrowPath.AddLines(new[] { new Point(arrowMiddle.X - ARROW_SIZE, arrowMiddle.Y - ARROW_SIZE), new Point(arrowMiddle.X, arrowMiddle.Y), new Point(arrowMiddle.X - ARROW_SIZE, arrowMiddle.Y + ARROW_SIZE) });
                arrowPath.CloseFigure();

                g.FillPath(arrowBrush, arrowPath);
            }
        }

        protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
        {
        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            var renderingText = e.Text == e.Item.Text || (string.IsNullOrWhiteSpace(e.Text)) || string.IsNullOrWhiteSpace(e.Item.Text);
            var g = e.Graphics;
            g.TextRenderingHint = TextRenderingHint.AntiAlias;

            if (e.Item.IsOnDropDown)
            {
                var itemRect = GetItemRect(e.Item);
                var textRect = new Rectangle(24, itemRect.Y, itemRect.Width - (24 + 16), itemRect.Height);
                if (renderingText)
                {
                    e.TextRectangle = textRect;
                    g.DrawString(e.Text, SkinManager.ROBOTO_MEDIUM_10, e.Item.Enabled ? SkinManager.GetPrimaryTextBrush() : SkinManager.GetDisabledOrHintBrush(), textRect, new StringFormat() { LineAlignment = StringAlignment.Center });
                }
                else
                {
                    var shortcutRect = new Rectangle(e.TextRectangle.X + e.TextRectangle.Width / 2, itemRect.Y, e.TextRectangle.Width, e.TextRectangle.Height);
                    g.DrawString(e.Text, SkinManager.ROBOTO_MEDIUM_10, e.Item.Enabled ? SkinManager.GetPrimaryTextBrush() : SkinManager.GetDisabledOrHintBrush(), shortcutRect, new StringFormat() { LineAlignment = StringAlignment.Center });
                }
            }
            else
            {
                g.DrawString(e.Text, SkinManager.ROBOTO_MEDIUM_10, Brushes.White, e.TextRectangle, new StringFormat() { LineAlignment = StringAlignment.Center });
            }
        }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(SkinManager.GetApplicationBackgroundColor());

            //Draw background
            var itemRect = GetItemRect(e.Item);
            if (e.Item.IsOnDropDown)
            {
                g.FillRectangle(e.Item.Selected && e.Item.Enabled ? SkinManager.GetCmsSelectedItemBrush() : new SolidBrush(SkinManager.GetApplicationBackgroundColor()), itemRect);
            }
            else
            {
                g.FillRectangle(e.Item.Selected ? SkinManager.GetFlatButtonPressedBackgroundBrush() : SkinManager.ColorScheme.PrimaryBrush, itemRect);
            }

            //Ripple animation
            var toolStrip = e.ToolStrip as MaterialContextMenuStrip;
            if (toolStrip != null)
            {
                var animationManager = toolStrip.AnimationManager;
                var animationSource = toolStrip.AnimationSource;
                if (toolStrip.AnimationManager.IsAnimating() && e.Item.Bounds.Contains(animationSource))
                {
                    for (int i = 0; i < animationManager.GetAnimationCount(); i++)
                    {
                        var animationValue = animationManager.GetProgress(i);
                        var rippleBrush = new SolidBrush(Color.FromArgb((int)(51 - (animationValue * 50)), Color.Black));
                        var rippleSize = (int)(animationValue * itemRect.Width * 2.5);
                        g.FillEllipse(rippleBrush, new Rectangle(animationSource.X - rippleSize / 2, itemRect.Y - itemRect.Height, rippleSize, itemRect.Height * 3));
                    }
                }
            }
        }

        protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        {
            var g = e.Graphics;

            g.FillRectangle(new SolidBrush(SkinManager.GetApplicationBackgroundColor()), e.Item.Bounds);
            g.DrawLine(new Pen(SkinManager.GetDividersColor()), new Point(e.Item.Bounds.Left, e.Item.Bounds.Height / 2), new Point(e.Item.Bounds.Right, e.Item.Bounds.Height / 2));
        }

        private Rectangle GetItemRect(ToolStripItem item)
        {
            return new Rectangle(0, item.ContentRectangle.Y, item.ContentRectangle.Width + 4, item.ContentRectangle.Height);
        }

        #endregion Methods
    }
}