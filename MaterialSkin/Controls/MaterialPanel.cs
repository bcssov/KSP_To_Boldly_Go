using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace MaterialSkin.Controls
{
    public partial class MaterialPanel : Panel, IMaterialControl
    {
        #region Constructors

        public MaterialPanel()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Properties

        [Browsable(false)]
        public int Depth { get; set; }

        [Browsable(false)]
        public MouseState MouseState { get; set; }

        [Browsable(false)]
        public MaterialSkinManager SkinManager => MaterialSkinManager.Instance;

        #endregion Properties

        #region Methods

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            ForeColor = SkinManager.GetPrimaryTextColor();
            Font = SkinManager.ROBOTO_REGULAR_11;
            BackColor = SkinManager.GetApplicationBackgroundColor();
            BackColorChanged += MaterialPanel_BackColorChanged;
        }

        private void MaterialPanel_BackColorChanged(object sender, EventArgs e)
        {
            ForeColor = SkinManager.GetPrimaryTextColor();
            BackColor = SkinManager.GetApplicationBackgroundColor();
        }

        #endregion Methods
    }
}