using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;

namespace CrosshairOverlay
{
    public partial class SettingsForm : Form
    {
        private Settings _settings = Settings.Instance;
        private List<Color> _customColors = new List<Color>();

        public SettingsForm()
        {
            InitializeComponent();
            SetStartupLocation();
            LoadSettings();
            this.FormClosing += SettingsForm_FormClosing;
        }

        private void LoadSettings()
        {
            chkDot.Checked = _settings.CrosshairDot;
            chkCross.Checked = _settings.CrosshairCross;

            btnFillColor.BackColor = _settings.FillColor;
            btnFillColor.ForeColor = ContrastTextColor(_settings.FillColor);
            btnClearFillColor.Visible = _settings.FillColor.A > 0;

            btnOutlineColor.BackColor = _settings.OutlineColor;
            btnOutlineColor.ForeColor = ContrastTextColor(_settings.OutlineColor);
            btnClearOutlineColor.Visible = _settings.OutlineColor.A > 0;

            crosshairSize.Value = (int)_settings.CrosshairSize;
            lblSizeValue.Text = crosshairSize.Value.ToString();

            crosshairGap.Value = (int)_settings.CrosshairGap;
            lblGapValue.Text = crosshairGap.Value.ToString();

            crosshairWidth.Value = ConvertSmallToBig(_settings.CrosshairWidth);
            lblWidthValue.Text = TrimDecimals(ConvertBigToSmall(crosshairWidth.Value));

            crosshairOutline.Value = ConvertSmallToBig(_settings.CrosshairOutline);
            lblOutlineValue.Text = TrimDecimals(ConvertBigToSmall(crosshairOutline.Value));
        }

        private void SetStartupLocation()
        {
            Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
            int centerX = workingArea.Width / 2;
            int centerY = workingArea.Height / 2;

            int offsetX = 100;
            int offsetY = -(Height / 2) + 30;

            int startX = centerX + offsetX;
            int startY = centerY + offsetY;

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(startX, startY);
        }

        private float ConvertBigToSmall(int value)
        {
            return value * .5f;
        }

        private int ConvertSmallToBig(float value)
        {
            return (int)(value * 2);
        }

        private string TrimDecimals(float value)
        {
            if (value % 1 == 0)
            {
                return $"{(int)value}";
            }
            return $"{value:F1}";
        }

        private (ColorDialog, DialogResult) SelectColor(Color presetColor)
        {
            var colorDlg = new ColorDialog();
            colorDlg.FullOpen = true;
            colorDlg.Color = presetColor;
            if (_customColors.Count > 0)
            {
                colorDlg.CustomColors = _customColors.Select(color => ColorTranslator.ToOle(color)).ToArray();
            }
            var result = colorDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                _customColors = colorDlg.CustomColors.Select(color => ColorTranslator.FromOle(color)).Where(color => color != Color.White).ToList();
                _customColors.Remove(colorDlg.Color);
                _customColors.Insert(0, colorDlg.Color);
            }
            return (colorDlg, result);
        }

        private void btnFillColor_Click(object sender, EventArgs e)
        {
            var (colorDlg, colorResult) = SelectColor(btnFillColor.BackColor);
            if (colorResult == DialogResult.OK)
            {
                _settings.FillColor = colorDlg.Color;
                btnFillColor.BackColor = colorDlg.Color;
                btnFillColor.ForeColor = ContrastTextColor(colorDlg.Color);
                btnClearFillColor.Visible = true;
            }
        }

        private void btnOutlineColor_Click(object sender, EventArgs e)
        {
            var (colorDlg, colorResult) = SelectColor(btnOutlineColor.BackColor);
            if (colorResult == DialogResult.OK)
            {
                _settings.OutlineColor = colorDlg.Color;
                btnOutlineColor.BackColor = colorDlg.Color;
                btnOutlineColor.ForeColor = ContrastTextColor(colorDlg.Color);
                btnClearOutlineColor.Visible = true;
            }
        }

        private Color ContrastTextColor(Color backgroundColor)
        {
            var brightness = (int)Math.Sqrt(
                backgroundColor.R * backgroundColor.R * .299 +
                backgroundColor.G * backgroundColor.G * .587 +
                backgroundColor.B * backgroundColor.B * .114);

            return brightness > 128 ? Color.Black : Color.White;
        }

        private void crosshairSize_Scroll(object sender, EventArgs e)
        {
            lblSizeValue.Text = crosshairSize.Value.ToString();
            _settings.CrosshairSize = crosshairSize.Value;
        }

        private void crosshairGap_Scroll(object sender, EventArgs e)
        {
            lblGapValue.Text = crosshairGap.Value.ToString();
            _settings.CrosshairGap = crosshairGap.Value;
        }

        private void crosshairWidth_Scroll(object sender, EventArgs e)
        {
            var width = ConvertBigToSmall(crosshairWidth.Value);
            lblWidthValue.Text = TrimDecimals(width);
            _settings.CrosshairWidth = width;
        }

        private void crosshairOutline_Scroll(object sender, EventArgs e)
        {
            var outline = ConvertBigToSmall(crosshairOutline.Value);
            lblOutlineValue.Text = TrimDecimals(outline);
            _settings.CrosshairOutline = outline;
        }

        private void btnClearFillColor_Click(object sender, EventArgs e)
        {
            _settings.FillColor = Color.Empty;
            btnFillColor.BackColor = Color.Empty;
            btnFillColor.ForeColor = ContrastTextColor(Color.Empty);
            btnClearFillColor.Visible = false;
        }

        private void btnClearOutlineColor_Click(object sender, EventArgs e)
        {
            _settings.OutlineColor = Color.Empty;
            btnOutlineColor.BackColor = Color.Empty;
            btnOutlineColor.ForeColor = ContrastTextColor(Color.Empty);
            btnClearOutlineColor.Visible = false;
        }

        protected void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _settings.CrosshairDot = chkDot.Checked;
            _settings.CrosshairCross = chkCross.Checked;
            _settings.FillColor = btnFillColor.BackColor;
            _settings.OutlineColor = btnOutlineColor.BackColor;
            _settings.CrosshairSize = crosshairSize.Value;
            _settings.CrosshairGap = crosshairGap.Value;
            _settings.CrosshairWidth = ConvertBigToSmall(crosshairWidth.Value);
            _settings.CrosshairOutline = ConvertBigToSmall(crosshairOutline.Value);
            _settings.Save();
        }

        private void chkDot_CheckedChanged(object sender, EventArgs e)
        {
            _settings.CrosshairDot = chkDot.Checked;
        }

        private void chkCross_CheckedChanged(object sender, EventArgs e)
        {
            _settings.CrosshairCross = chkCross.Checked;
        }
    }
}
