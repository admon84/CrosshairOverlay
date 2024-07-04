using CrosshairOverlay.Settings;
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;

namespace CrosshairOverlay
{
    public partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();

            chkCircle.Checked = ConfigFile.Loaded.ShowCircle;
            chkCross.Checked = ConfigFile.Loaded.ShowCross;
            chkDot.Checked = ConfigFile.Loaded.ShowDot;
            chkPlus.Checked = ConfigFile.Loaded.ShowPlus;

            numSize.Value = (decimal)ConfigFile.Loaded.Size;
            numGap.Value = (decimal)ConfigFile.Loaded.Gap;
            numThickness.Value = (decimal)ConfigFile.Loaded.Thickness;
            numOpacity.Value = (decimal)(ConfigFile.Loaded.Opacity * 100);
            
            btnColor.BackColor = ConfigFile.Loaded.Color;
            btnColor.ForeColor = ContrastTextColor(btnColor.BackColor);
            btnColorReset.Visible = ConfigFile.Loaded.Color != Color.White;
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
                ConfigFile.Loaded.Color = colorDlg.Color;
                btnColor.BackColor = colorDlg.Color;
                btnColor.ForeColor = ContrastTextColor(btnColor.BackColor);
                btnColorReset.Visible = true;
            }
        }

        private void btnColorReset_Click(object sender, EventArgs e)
        {
            ConfigFile.Loaded.Color = Color.White;
            btnColor.BackColor = ConfigFile.Loaded.Color;
            btnColor.ForeColor = ContrastTextColor(btnColor.BackColor);
            btnColorReset.Visible = false;
        }

        private void numSize_ValueChanged(object sender, EventArgs e)
        {
            ConfigFile.Loaded.Size = (float)numSize.Value;
        }

        private void numGap_ValueChanged(object sender, EventArgs e)
        {
            ConfigFile.Loaded.Gap = (float)numGap.Value;
        }

        private void numThickness_ValueChanged(object sender, EventArgs e)
        {
            ConfigFile.Loaded.Thickness = (float)numThickness.Value;
        }

        private void numOpacity_ValueChanged(object sender, EventArgs e)
        {
            ConfigFile.Loaded.Opacity = (float)(numOpacity.Value) * .01f;
        }

        private void chkCircle_CheckedChanged(object sender, EventArgs e)
        {
            ConfigFile.Loaded.ShowCircle = chkCircle.Checked;
        }

        private void chkDot_CheckedChanged(object sender, EventArgs e)
        {
            ConfigFile.Loaded.ShowDot = chkDot.Checked;
        }

        private void chkCross_CheckedChanged(object sender, EventArgs e)
        {
            ConfigFile.Loaded.ShowCross = chkCross.Checked;
        }

        private void chkPlus_CheckedChanged(object sender, EventArgs e)
        {
            ConfigFile.Loaded.ShowPlus = chkPlus.Checked;
        }
    }
}
