using CrosshairOverlay.Settings;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CrosshairOverlay
{
    public partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();

            chkCircle.Checked = Config.Current.ShowCircle;
            chkCross.Checked = Config.Current.ShowCross;
            chkDot.Checked = Config.Current.ShowDot;
            chkPlus.Checked = Config.Current.ShowPlus;

            numSize.Value = (decimal)Config.Current.Size;
            numGap.Value = (decimal)Config.Current.Gap;
            numThickness.Value = (decimal)Config.Current.Thickness;
            numOpacity.Value = (decimal)(Config.Current.Opacity * 100);
            
            btnColor.BackColor = Config.Current.Color;
            btnColor.ForeColor = ContrastTextColor(btnColor.BackColor);
            btnColorReset.Visible = Config.Current.Color != Color.White;
        }

        private List<Color> customColors = new List<Color>();

        private Color ContrastTextColor(Color backgroundColor)
        {
            var brightness = (int)Math.Sqrt(
                backgroundColor.R * backgroundColor.R * .299 +
                backgroundColor.G * backgroundColor.G * .587 +
                backgroundColor.B * backgroundColor.B * .114
            );

            return brightness > 128 ? Color.Black : Color.White;
        }

        private (ColorDialog, DialogResult) SelectColor(Color presetColor)
        {
            var colorDlg = new ColorDialog();
            colorDlg.FullOpen = true;
            colorDlg.Color = presetColor;
            if (customColors.Count > 0)
            {
                colorDlg.CustomColors = customColors.Select(color => ColorTranslator.ToOle(color)).ToArray();
            }
            var result = colorDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                customColors = colorDlg.CustomColors.Select(color => ColorTranslator.FromOle(color)).Where(color => color != Color.White).ToList();
                customColors.Remove(colorDlg.Color);
                customColors.Insert(0, colorDlg.Color);
            }
            return (colorDlg, result);
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            var (colorDlg, colorResult) = SelectColor(btnColor.BackColor);
            if (colorResult == DialogResult.OK)
            {
                Config.Current.Color = colorDlg.Color;
                btnColor.BackColor = colorDlg.Color;
                btnColor.ForeColor = ContrastTextColor(btnColor.BackColor);
                btnColorReset.Visible = true;
            }
        }

        private void btnColorReset_Click(object sender, EventArgs e)
        {
            Config.Current.Color = Color.White;
            btnColor.BackColor = Config.Current.Color;
            btnColor.ForeColor = ContrastTextColor(btnColor.BackColor);
            btnColorReset.Visible = false;
        }

        private void numSize_ValueChanged(object sender, EventArgs e)
        {
            Config.Current.Size = (float)numSize.Value;
        }

        private void numGap_ValueChanged(object sender, EventArgs e)
        {
            Config.Current.Gap = (float)numGap.Value;
        }

        private void numThickness_ValueChanged(object sender, EventArgs e)
        {
            Config.Current.Thickness = (float)numThickness.Value;
        }

        private void numOpacity_ValueChanged(object sender, EventArgs e)
        {
            Config.Current.Opacity = (float)(numOpacity.Value) * .01f;
        }

        private void chkCircle_CheckedChanged(object sender, EventArgs e)
        {
            Config.Current.ShowCircle = chkCircle.Checked;
            DisableUnusedControls();
        }

        private void chkDot_CheckedChanged(object sender, EventArgs e)
        {
            Config.Current.ShowDot = chkDot.Checked;
            DisableUnusedControls();
        }

        private void chkCross_CheckedChanged(object sender, EventArgs e)
        {
            Config.Current.ShowCross = chkCross.Checked;
            DisableUnusedControls();
        }

        private void chkPlus_CheckedChanged(object sender, EventArgs e)
        {
            Config.Current.ShowPlus = chkPlus.Checked;
            DisableUnusedControls();
        }

        private void DisableUnusedControls()
        {
            numGap.Enabled = true;
            numSize.Enabled = true;
            numThickness.Enabled = true;
            numOpacity.Enabled = true;
            btnColor.Enabled = true;

            if (!Config.Current.ShowCross && !Config.Current.ShowPlus)
            {
                numGap.Enabled = false;

                if (!Config.Current.ShowCircle)
                {
                    numSize.Enabled = false;

                    if (!Config.Current.ShowDot)
                    {
                        numThickness.Enabled = false;
                        numOpacity.Enabled = false;
                        btnColor.Enabled = false;
                    }
                }
            }
        }
    }
}
