using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;

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

        protected void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _settings.Save();
        }

        private void LoadSettings()
        {
            ToggleDotEnabled(_settings.GlobalSettings.CrosshairDot);
            ToggleCrossEnabled(_settings.GlobalSettings.CrosshairCross);
            ToggleCircleEnabled(_settings.GlobalSettings.CrosshairCircle);

            // Global settings

            btnFillColor.BackColor = _settings.GlobalSettings.FillColor;
            btnFillColor.ForeColor = ContrastTextColor(btnFillColor.BackColor);

            btnOutlineColor.BackColor = _settings.GlobalSettings.OutlineColor;
            btnOutlineColor.ForeColor = ContrastTextColor(btnOutlineColor.BackColor);

            fillColorAlpha.Value = _settings.GlobalSettings.FillColorAlpha;
            lblFillColorAlpha.Text = fillColorAlpha.Value.ToString();

            outlineColorAlpha.Value = _settings.GlobalSettings.OutlineColorAlpha;
            lblOutlineColorAlpha.Text = outlineColorAlpha.Value.ToString();

            crosshairSize.Value = (int)_settings.GlobalSettings.CrosshairSize;
            lblSizeValue.Text = crosshairSize.Value.ToString();

            crosshairGap.Value = (int)_settings.GlobalSettings.CrosshairGap;
            lblGapValue.Text = crosshairGap.Value.ToString();

            crosshairWidth.Value = ConvertSmallToBig(_settings.GlobalSettings.CrosshairWidth);
            lblWidthValue.Text = TrimDecimals(ConvertBigToSmall(crosshairWidth.Value));

            crosshairOutline.Value = ConvertSmallToBig(_settings.GlobalSettings.CrosshairOutline);
            lblOutlineValue.Text = TrimDecimals(ConvertBigToSmall(crosshairOutline.Value));

            // Dot settings

            dotFillColorAlpha.Value = _settings.DotSettings.GetFillColorAlpha();
            lblDotFillColorAlpha.Text = dotFillColorAlpha.Value.ToString();

            dotOutlineColorAlpha.Value = _settings.DotSettings.GetOutlineColorAlpha();
            lblDotOutlineColorAlpha.Text = dotOutlineColorAlpha.Value.ToString();

            LoadDotCrosshairOutline();
            LoadDotCrosshairWidth();

            // Cross settings

            crossFillColorAlpha.Value = _settings.CrossSettings.GetFillColorAlpha();
            lblCrossFillColorAlpha.Text = crossFillColorAlpha.Value.ToString();

            crossOutlineColorAlpha.Value = _settings.CrossSettings.GetOutlineColorAlpha();
            lblCrossOutlineColorAlpha.Text = crossOutlineColorAlpha.Value.ToString();

            LoadCrossCrosshairSize();
            LoadCrossCrosshairGap();
            LoadCrossCrosshairWidth();
            LoadCrossCrosshairOutline();
        
            // Circle settings

            circleFillColorAlpha.Value = _settings.CircleSettings.GetFillColorAlpha();
            lblCircleFillColorAlpha.Text = circleFillColorAlpha.Value.ToString();

            circleOutlineColorAlpha.Value = _settings.CircleSettings.GetOutlineColorAlpha();
            lblCircleOutlineColorAlpha.Text = circleOutlineColorAlpha.Value.ToString();

            LoadCircleCrosshairSize();
            LoadCircleCrosshairGap();
            LoadCircleCrosshairWidth();
            LoadCircleCrosshairOutline();
        }

        private void LoadDotCrosshairWidth()
        {
            dotCrosshairWidth.Value = ConvertSmallToBig(_settings.DotSettings.GetCrosshairWidth());
            lblDotWidthValue.Text = TrimDecimals(ConvertBigToSmall(dotCrosshairWidth.Value));
        }

        private void LoadDotCrosshairOutline()
        {
            dotCrosshairOutline.Value = ConvertSmallToBig(_settings.DotSettings.GetCrosshairOutline());
             lblDotOutlineValue.Text = TrimDecimals(ConvertBigToSmall(dotCrosshairOutline.Value));
        }

        private void LoadCrossCrosshairSize()
        {
            crossCrosshairSize.Value = (int) _settings.CrossSettings.GetCrosshairSize();
            lblCrossSizeValue.Text = crossCrosshairSize.Value.ToString();
        }

        private void LoadCrossCrosshairGap()
        {
            crossCrosshairGap.Value = (int) _settings.CrossSettings.GetCrosshairGap();
            lblCrossGapValue.Text = crossCrosshairGap.Value.ToString();
        }

        private void LoadCrossCrosshairWidth()
        {
            crossCrosshairWidth.Value = ConvertSmallToBig(_settings.CrossSettings.GetCrosshairWidth());
            lblCrossWidthValue.Text = TrimDecimals(ConvertBigToSmall(crossCrosshairWidth.Value));
        }

        private void LoadCrossCrosshairOutline()
        {
            crossCrosshairOutline.Value = ConvertSmallToBig(_settings.CrossSettings.GetCrosshairOutline());
            lblCrossOutlineValue.Text = TrimDecimals(ConvertBigToSmall(crossCrosshairOutline.Value));
        }

        private void LoadCircleCrosshairSize()
        {
            circleCrosshairSize.Value = (int) _settings.CircleSettings.GetCrosshairSize();
            lblCircleSizeValue.Text = circleCrosshairSize.Value.ToString();
        }

        private void LoadCircleCrosshairGap()
           {
            circleCrosshairGap.Value = (int) _settings.CircleSettings.GetCrosshairGap();
            lblCircleGapValue.Text = circleCrosshairGap.Value.ToString();
        }

        private void LoadCircleCrosshairWidth()
        {
            circleCrosshairWidth.Value = ConvertSmallToBig(_settings.CircleSettings.GetCrosshairWidth());
            lblCircleWidthValue.Text = TrimDecimals(ConvertBigToSmall(circleCrosshairWidth.Value));
        }

        private void LoadCircleCrosshairOutline()
        {
            circleCrosshairOutline.Value = ConvertSmallToBig(_settings.CircleSettings.GetCrosshairOutline());
            lblCircleOutlineValue.Text = TrimDecimals(ConvertBigToSmall(circleCrosshairOutline.Value));
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

        private void ToggleDotEnabled(bool enabled)
        {
            _settings.GlobalSettings.CrosshairDot = enabled;
            chkDot.Checked = enabled;
            chkDotEnable.Checked = enabled;
            grpDotFillColor.Enabled = enabled;
            grpDotOutlineColor.Enabled = enabled;
            grpDotSize.Enabled = enabled;

            UpdateShapeColorButtons(enabled, _settings.DotSettings, btnDotFillColor, btnDotOutlineColor, chkDotFillColor, chkDotOutlineColor);
        }

        private void ToggleCrossEnabled(bool enabled)
        {
            _settings.GlobalSettings.CrosshairCross = enabled;
            chkCross.Checked = enabled;
            chkCrossEnable.Checked = enabled;
            grpCrossFillColor.Enabled = enabled;
            grpCrossOutlineColor.Enabled = enabled;
            grpCrossSize.Enabled = enabled;

            UpdateShapeColorButtons(enabled, _settings.CrossSettings, btnCrossFillColor, btnCrossOutlineColor, chkCrossFillColor, chkCrossOutlineColor);
        }

        private void ToggleCircleEnabled(bool enabled)
        {
            _settings.GlobalSettings.CrosshairCircle = enabled;
            chkCircle.Checked = enabled;
            chkCircleEnable.Checked = enabled;
            grpCircleFillColor.Enabled = enabled;
            grpCircleOutlineColor.Enabled = enabled;
            grpCircleSize.Enabled = enabled;

            UpdateShapeColorButtons(enabled, _settings.CircleSettings, btnCircleFillColor, btnCircleOutlineColor, chkCircleFillColor, chkCircleOutlineColor);
        }

        private void UpdateShapeColorButtons(bool enabled, ShapeSettings settings, Button fillColorButton, Button outlineColorButton, CheckBox checkFillColor, CheckBox checkOutlineColor)
        {
            var fillColor = enabled ? settings.GetFillColor() : Color.Empty;
            fillColorButton.BackColor = fillColor;
            fillColorButton.ForeColor = ContrastTextColor(fillColor);
            checkFillColor.Checked = settings.FillColor.HasValue;

            var outlineColor = enabled ? settings.GetOutlineColor() : Color.Empty;
            outlineColorButton.BackColor = outlineColor;
            outlineColorButton.ForeColor = ContrastTextColor(outlineColor);
            checkOutlineColor.Checked = settings.OutlineColor.HasValue;
        }

        private void UpdateFillColorSetting(ShapeSettings settings, Color newColor, Button button, CheckBox check)
        {
            if (settings.FillColor.HasValue && settings.FillColor == newColor)
            {
                settings.FillColor = null;
                check.Checked = false;
                return;
            }

            if (!settings.FillColor.HasValue)
            {
                button.BackColor = newColor;
                button.ForeColor = ContrastTextColor(newColor);
                check.Checked = settings.FillColor.HasValue;
            }
        }

        private void UpdateOutlineColorSetting(ShapeSettings settings, Color newColor, Button button, CheckBox check)
        {
            if (settings.OutlineColor.HasValue && settings.OutlineColor == newColor)
            {
                settings.OutlineColor = null;
                check.Checked = false;
                return;
            }

            if (!settings.OutlineColor.HasValue)
            {
                button.BackColor = newColor;
                button.ForeColor = ContrastTextColor(newColor);
                check.Checked = settings.OutlineColor.HasValue;
            }
        }

        private void UpdateFillColorAlphaSetting(ShapeSettings settings, int newAlpha, TrackBar slider, Label label)
        {
            if (settings.FillColorAlpha.HasValue)
            {
                if (_settings.GlobalSettings.FillColorAlpha == newAlpha)
                {
                    settings.FillColorAlpha = null;
                }
            }
            else
            {
                slider.Value = newAlpha;
                label.Text = newAlpha.ToString();
            }
        }

        private void UpdateOutlineColorAlphaSetting(ShapeSettings settings, int newAlpha, TrackBar slider, Label label)
        {
            if (settings.OutlineColorAlpha.HasValue)
            {
                if (_settings.GlobalSettings.OutlineColorAlpha == newAlpha)
                {
                    settings.OutlineColorAlpha = null;
                }
            }
            else
            {
                slider.Value = newAlpha;
                label.Text = newAlpha.ToString();
            }
        }

        private void UpdateCrosshairSizeSetting(ShapeSettings settings, int newSize, TrackBar slider, Label label)
        {
            if (settings.CrosshairSize.HasValue)
            {
                if (_settings.GlobalSettings.CrosshairSize == newSize)
                {
                    settings.CrosshairSize = null;
                }
            }
            else
            {
                slider.Value = newSize;
                label.Text = newSize.ToString();
            }
        }

        private void UpdateCrosshairSetting(float? setting, float globalSetting, int newValue, TrackBar slider, Label label)
        {
            if (setting.HasValue)
            {
                if (globalSetting == newValue)
                {
                    setting = null;
                }
            }
            else
            {
                slider.Value = newValue;
                label.Text = newValue.ToString();
            }
        }

        private void UpdateSmallCrosshairSetting(float? setting, float globalSetting, float smallValue, TrackBar slider, Label label)
        {
            if (setting.HasValue)
            {
                if (globalSetting == smallValue)
                {
                    setting = null;
                }
            }
            else
            {
                slider.Value = ConvertSmallToBig(smallValue);
                label.Text = TrimDecimals(smallValue);
            }
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
                var newColor = colorDlg.Color;
                _settings.GlobalSettings.FillColor = newColor;
                btnFillColor.BackColor = newColor;
                btnFillColor.ForeColor = ContrastTextColor(newColor);

                UpdateFillColorSetting(_settings.DotSettings, newColor, btnDotFillColor, chkDotFillColor);
                UpdateFillColorSetting(_settings.CrossSettings, newColor, btnCrossFillColor, chkCrossFillColor);
                UpdateFillColorSetting(_settings.CircleSettings, newColor, btnCircleFillColor, chkCircleFillColor);
            }
        }

        private void btnOutlineColor_Click(object sender, EventArgs e)
        {
            var (colorDlg, colorResult) = SelectColor(btnOutlineColor.BackColor);
            if (colorResult == DialogResult.OK)
            {
                var newColor = colorDlg.Color;
                _settings.GlobalSettings.OutlineColor = newColor;
                btnOutlineColor.BackColor = newColor;
                btnOutlineColor.ForeColor = ContrastTextColor(newColor);

                UpdateOutlineColorSetting(_settings.DotSettings, newColor, btnDotOutlineColor, chkDotOutlineColor);
                UpdateOutlineColorSetting(_settings.CrossSettings, newColor, btnCrossOutlineColor, chkCrossOutlineColor);
                UpdateOutlineColorSetting(_settings.CircleSettings, newColor, btnCircleOutlineColor, chkCircleOutlineColor);
            }
        }

        private Color ContrastTextColor(Color color)
        {
            var backgroundColor = color == Color.Empty ? Color.White : color;

            var brightness = (int)Math.Sqrt(
                backgroundColor.R * backgroundColor.R * .299 +
                backgroundColor.G * backgroundColor.G * .587 +
                backgroundColor.B * backgroundColor.B * .114);

            return brightness > 128 ? Color.Black : Color.White;
        }

        private void crosshairSize_Scroll(object sender, EventArgs e)
        {
            lblSizeValue.Text = crosshairSize.Value.ToString();
            _settings.GlobalSettings.CrosshairSize = crosshairSize.Value;

            UpdateCrosshairSetting(_settings.CrossSettings.CrosshairSize, _settings.GlobalSettings.CrosshairSize, crosshairSize.Value, crossCrosshairSize, lblCrossSizeValue);
            UpdateCrosshairSetting(_settings.CircleSettings.CrosshairSize, _settings.GlobalSettings.CrosshairSize, crosshairSize.Value, circleCrosshairSize, lblCircleSizeValue);
        }

        private void crosshairGap_Scroll(object sender, EventArgs e)
        {
            lblGapValue.Text = crosshairGap.Value.ToString();
            _settings.GlobalSettings.CrosshairGap = crosshairGap.Value;

            UpdateCrosshairSetting(_settings.CrossSettings.CrosshairGap, _settings.GlobalSettings.CrosshairGap, crosshairGap.Value, crossCrosshairGap, lblCrossGapValue);
            UpdateCrosshairSetting(_settings.CircleSettings.CrosshairGap, _settings.GlobalSettings.CrosshairGap, crosshairGap.Value, circleCrosshairGap, lblCircleGapValue);
        }

        private void crosshairWidth_Scroll(object sender, EventArgs e)
        {
            var width = ConvertBigToSmall(crosshairWidth.Value);
            lblWidthValue.Text = TrimDecimals(width);
            _settings.GlobalSettings.CrosshairWidth = width;

            UpdateSmallCrosshairSetting(_settings.DotSettings.CrosshairWidth, _settings.GlobalSettings.CrosshairWidth, width, dotCrosshairWidth, lblDotWidthValue);
            UpdateSmallCrosshairSetting(_settings.CrossSettings.CrosshairWidth, _settings.GlobalSettings.CrosshairWidth, width, crossCrosshairWidth, lblCrossWidthValue);
            UpdateSmallCrosshairSetting(_settings.CircleSettings.CrosshairWidth, _settings.GlobalSettings.CrosshairWidth, width, circleCrosshairWidth, lblCircleWidthValue);
        }

        private void chkDot_CheckedChanged(object sender, EventArgs e)
        {
            ToggleDotEnabled(chkDot.Checked);
        }

        private void chkCross_CheckedChanged(object sender, EventArgs e)
        {
            ToggleCrossEnabled(chkCross.Checked);
        }

        private void chkCircle_CheckedChanged(object sender, EventArgs e)
        {
            ToggleCircleEnabled(chkCircle.Checked);
        }

        private void fillColorAlpha_Scroll(object sender, EventArgs e)
        {
            lblFillColorAlpha.Text = fillColorAlpha.Value.ToString();
            _settings.GlobalSettings.FillColorAlpha = fillColorAlpha.Value;

            UpdateFillColorAlphaSetting(_settings.DotSettings, fillColorAlpha.Value, dotFillColorAlpha, lblDotFillColorAlpha);
            UpdateFillColorAlphaSetting(_settings.CrossSettings, fillColorAlpha.Value, crossFillColorAlpha, lblCrossFillColorAlpha);
            UpdateFillColorAlphaSetting(_settings.CircleSettings, fillColorAlpha.Value, circleFillColorAlpha, lblCircleFillColorAlpha);
        }

        private void outlineColorAlpha_Scroll(object sender, EventArgs e)
        {
            lblOutlineColorAlpha.Text = outlineColorAlpha.Value.ToString();
            _settings.GlobalSettings.OutlineColorAlpha = outlineColorAlpha.Value;

            UpdateOutlineColorAlphaSetting(_settings.DotSettings, outlineColorAlpha.Value, dotOutlineColorAlpha, lblDotOutlineColorAlpha);
            UpdateOutlineColorAlphaSetting(_settings.CrossSettings, outlineColorAlpha.Value, crossOutlineColorAlpha, lblCrossOutlineColorAlpha);
            UpdateOutlineColorAlphaSetting(_settings.CircleSettings, outlineColorAlpha.Value, circleOutlineColorAlpha, lblCircleOutlineColorAlpha);
        }

        private void chkDotEnable_CheckedChanged(object sender, EventArgs e)
        {
            ToggleDotEnabled(chkDotEnable.Checked);
        }

        private void chkCrossEnable_CheckedChanged(object sender, EventArgs e)
        {
            ToggleCrossEnabled(chkCrossEnable.Checked);
        }

        private void chkCircleEnable_CheckedChanged(object sender, EventArgs e)
        {
            ToggleCircleEnabled(chkCircleEnable.Checked);
        }

        private void dotCrosshairWidth_Scroll(object sender, EventArgs e)
        {
            var width = ConvertBigToSmall(dotCrosshairWidth.Value);
            lblDotWidthValue.Text = TrimDecimals(width);

            if (_settings.GlobalSettings.CrosshairWidth == width)
            {
                _settings.DotSettings.CrosshairWidth = null;
                chkDotWidth.Checked = false;
            }
            else
            {
                _settings.DotSettings.CrosshairWidth = width;
                chkDotWidth.Checked = true;
            }
        }

        private void dotCrosshairOutline_Scroll(object sender, EventArgs e)
        {
            var outline = ConvertBigToSmall(dotCrosshairOutline.Value);
            lblDotOutlineValue.Text = TrimDecimals(outline);

            if (_settings.GlobalSettings.CrosshairOutline == outline)
            {
                _settings.DotSettings.CrosshairOutline = null;
                chkDotOutline.Checked = false;
            }
            else
            {
                _settings.DotSettings.CrosshairOutline = outline;
                chkDotOutline.Checked = true;
            }
        }

        private void crossCrosshairSize_Scroll(object sender, EventArgs e)
        {
            lblCrossSizeValue.Text = crossCrosshairSize.Value.ToString();

            if (_settings.GlobalSettings.CrosshairSize == crossCrosshairSize.Value)
            {
                _settings.CrossSettings.CrosshairSize = null;
            }
            else
            {
                _settings.CrossSettings.CrosshairSize = crossCrosshairSize.Value;
            }
        }

        private void crossCrosshairGap_Scroll(object sender, EventArgs e)
        {
            lblCrossGapValue.Text = crossCrosshairGap.Value.ToString();

            if (_settings.GlobalSettings.CrosshairGap == crossCrosshairGap.Value)
            {
                _settings.CrossSettings.CrosshairGap = null;
            }
            else
            {
                _settings.CrossSettings.CrosshairGap = crossCrosshairGap.Value;
            }
        }

        private void crossCrosshairWidth_Scroll(object sender, EventArgs e)
        {
            var width = ConvertBigToSmall(crossCrosshairWidth.Value);
            lblCrossWidthValue.Text = TrimDecimals(width);

            if (_settings.GlobalSettings.CrosshairWidth == width)
            {
                _settings.CrossSettings.CrosshairWidth = null;
            }
            else
            {
                _settings.CrossSettings.CrosshairWidth = width;
            }
        }

        private void crossCrosshairOutline_Scroll(object sender, EventArgs e)
        {
            var outline = ConvertBigToSmall(crossCrosshairOutline.Value);
            lblCrossOutlineValue.Text = TrimDecimals(outline);

            if (_settings.GlobalSettings.CrosshairOutline == outline)
            {
                _settings.CrossSettings.CrosshairOutline = null;
            }
            else
            {
                _settings.CrossSettings.CrosshairOutline = outline;
            }
        }

        private void circleCrosshairSize_Scroll(object sender, EventArgs e)
        {
            lblCircleSizeValue.Text = circleCrosshairSize.Value.ToString();

            if (_settings.GlobalSettings.CrosshairSize == circleCrosshairSize.Value)
            {
                _settings.CircleSettings.CrosshairSize = null;
            }
            else
            {
                _settings.CircleSettings.CrosshairSize = circleCrosshairSize.Value;
            }
        }

        private void circleCrosshairGap_Scroll(object sender, EventArgs e)
        {
            lblCircleGapValue.Text = circleCrosshairGap.Value.ToString();

            if (_settings.GlobalSettings.CrosshairGap == circleCrosshairGap.Value)
            {
                _settings.CircleSettings.CrosshairGap = null;
            }
            else
            {
                _settings.CircleSettings.CrosshairGap = circleCrosshairGap.Value;
            }
        }

        private void circleCrosshairWidth_Scroll(object sender, EventArgs e)
        {
            var width = ConvertBigToSmall(circleCrosshairWidth.Value);
            lblCircleWidthValue.Text = TrimDecimals(width);

            if (_settings.GlobalSettings.CrosshairWidth == width)
            {
                _settings.CircleSettings.CrosshairWidth = null;
            }
            else
            {
                _settings.CircleSettings.CrosshairWidth = width;
            }
        }

        private void circleCrosshairOutline_Scroll(object sender, EventArgs e)
        {
            var outline = ConvertBigToSmall(circleCrosshairOutline.Value);
            lblCircleOutlineValue.Text = TrimDecimals(outline);

            if (_settings.GlobalSettings.CrosshairOutline == outline)
            {
                _settings.CircleSettings.CrosshairOutline = null;
            }
            else
            {
                _settings.CircleSettings.CrosshairOutline = outline;
            }
        }

        private void dotFillColorAlpha_Scroll(object sender, EventArgs e)
        {
            lblDotFillColorAlpha.Text = dotFillColorAlpha.Value.ToString();

            if (_settings.GlobalSettings.FillColorAlpha == dotFillColorAlpha.Value)
            {
                _settings.DotSettings.FillColorAlpha = null;
            }
            else
            {
                _settings.DotSettings.FillColorAlpha = dotFillColorAlpha.Value;
            }
        }

        private void dotOutlineColorAlpha_Scroll(object sender, EventArgs e)
        {
            lblDotOutlineColorAlpha.Text = dotOutlineColorAlpha.Value.ToString();

            if (_settings.GlobalSettings.OutlineColorAlpha == dotOutlineColorAlpha.Value)
            {
                _settings.DotSettings.OutlineColorAlpha = null;
            }
            else
            {
                _settings.DotSettings.OutlineColorAlpha = dotOutlineColorAlpha.Value;
            }
        }

        private void crossFillColorAlpha_Scroll(object sender, EventArgs e)
        {
            lblCrossFillColorAlpha.Text = crossFillColorAlpha.Value.ToString();

            if (_settings.GlobalSettings.FillColorAlpha == crossFillColorAlpha.Value)
            {
                _settings.CrossSettings.FillColorAlpha = null;
            }
            else
            {
                _settings.CrossSettings.FillColorAlpha = crossFillColorAlpha.Value;
            }
        }

        private void crossOutlineColorAlpha_Scroll(object sender, EventArgs e)
        {
            lblCrossOutlineColorAlpha.Text = crossOutlineColorAlpha.Value.ToString();

            if (_settings.GlobalSettings.OutlineColorAlpha == crossOutlineColorAlpha.Value)
            {
                _settings.CrossSettings.OutlineColorAlpha = null;
            }
            else
            {
                _settings.CrossSettings.OutlineColorAlpha = crossOutlineColorAlpha.Value;
            }
        }

        private void circleFillColorAlpha_Scroll(object sender, EventArgs e)
        {
            lblCircleFillColorAlpha.Text = circleFillColorAlpha.Value.ToString();

            if (_settings.GlobalSettings.FillColorAlpha == circleFillColorAlpha.Value)
            {
                _settings.CircleSettings.FillColorAlpha = null;
            }
            else
            {
                _settings.CircleSettings.FillColorAlpha = circleFillColorAlpha.Value;
            }
        }

        private void circleOutlineColorAlpha_Scroll(object sender, EventArgs e)
        {
            lblCircleOutlineColorAlpha.Text = circleOutlineColorAlpha.Value.ToString();

            if (_settings.GlobalSettings.OutlineColorAlpha == circleOutlineColorAlpha.Value)
            {
                _settings.CircleSettings.OutlineColorAlpha = null;
            }
            else
            {
                _settings.CircleSettings.OutlineColorAlpha = circleOutlineColorAlpha.Value;
            }
        }

        private void btnDotFillColor_Click(object sender, EventArgs e)
        {
            var (colorDlg, colorResult) = SelectColor(btnDotFillColor.BackColor);
            if (colorResult == DialogResult.OK)
            {
                if (_settings.GlobalSettings.FillColor == colorDlg.Color)
                {
                    _settings.DotSettings.FillColor = null;
                    chkDotFillColor.Checked = false;
                }
                else
                {
                    _settings.DotSettings.FillColor = colorDlg.Color;
                    chkDotFillColor.Checked = true;
                }

                btnDotFillColor.BackColor = colorDlg.Color;
                btnDotFillColor.ForeColor = ContrastTextColor(colorDlg.Color);
            }
        }

        private void btnDotOutlineColor_Click(object sender, EventArgs e)
        {
            var (colorDlg, colorResult) = SelectColor(btnDotOutlineColor.BackColor);
            if (colorResult == DialogResult.OK)
            {
                if (_settings.GlobalSettings.OutlineColor == colorDlg.Color)
                {
                    _settings.DotSettings.OutlineColor = null;
                    chkDotOutlineColor.Checked = false;
                }
                else
                {
                    _settings.DotSettings.OutlineColor = colorDlg.Color;
                    chkDotOutlineColor.Checked = true;
                }

                btnDotOutlineColor.BackColor = colorDlg.Color;
                btnDotOutlineColor.ForeColor = ContrastTextColor(colorDlg.Color);
            }
        }

        private void btnCrossFillColor_Click(object sender, EventArgs e)
        {
            var (colorDlg, colorResult) = SelectColor(btnCrossFillColor.BackColor);
            if (colorResult == DialogResult.OK)
            {
                btnCrossFillColor.BackColor = colorDlg.Color;
                btnCrossFillColor.ForeColor = ContrastTextColor(colorDlg.Color);
                chkCrossFillColor.Checked = true;

                if (_settings.GlobalSettings.FillColor == colorDlg.Color)
                {
                    _settings.CrossSettings.FillColor = null;
                }
                else
                {
                    _settings.CrossSettings.FillColor = colorDlg.Color;
                }
            }
        }

        private void btnCrossOutlineColor_Click(object sender, EventArgs e)
        {
            var (colorDlg, colorResult) = SelectColor(btnCrossOutlineColor.BackColor);
            if (colorResult == DialogResult.OK)
            {
                btnCrossOutlineColor.BackColor = colorDlg.Color;
                btnCrossOutlineColor.ForeColor = ContrastTextColor(colorDlg.Color);
                chkCrossOutlineColor.Checked = true;

                if (_settings.GlobalSettings.OutlineColor == colorDlg.Color)
                {
                    _settings.CrossSettings.OutlineColor = null;
                }
                else
                {
                    _settings.CrossSettings.OutlineColor = colorDlg.Color;
                }
            }
        }

        private void btnCircleFillColor_Click(object sender, EventArgs e)
        {
            var (colorDlg, colorResult) = SelectColor(btnCircleFillColor.BackColor);
            if (colorResult == DialogResult.OK)
            {
                btnCircleFillColor.BackColor = colorDlg.Color;
                btnCircleFillColor.ForeColor = ContrastTextColor(colorDlg.Color);
                chkCircleFillColor.Checked = true;

                if (_settings.GlobalSettings.FillColor == colorDlg.Color)
                {
                    _settings.CircleSettings.FillColor = null;
                }
                else
                {
                    _settings.CircleSettings.FillColor = colorDlg.Color;
                }
            }
        }

        private void btnCircleOutlineColor_Click(object sender, EventArgs e)
        {
            var (colorDlg, colorResult) = SelectColor(btnCircleOutlineColor.BackColor);
            if (colorResult == DialogResult.OK)
            {
                btnCircleOutlineColor.BackColor = colorDlg.Color;
                btnCircleOutlineColor.ForeColor = ContrastTextColor(colorDlg.Color);
                chkCircleOutlineColor.Checked = true;

                if (_settings.GlobalSettings.OutlineColor == colorDlg.Color)
                {
                    _settings.CircleSettings.OutlineColor = null;
                }
                else
                {
                    _settings.CircleSettings.OutlineColor = colorDlg.Color;
                }
            }
        }

        private void chkDotWidth_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkDotWidth.Checked)
            {
                _settings.DotSettings.CrosshairWidth = null;
                LoadDotCrosshairWidth();
            }
        }

        private void chkDotOutline_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkDotOutline.Checked)
            {
                _settings.DotSettings.CrosshairOutline = null;
                LoadDotCrosshairOutline();
            }
        }

        private void chkCrossSize_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkCrossSize.Checked)
            {
                _settings.CrossSettings.CrosshairSize = null;
                LoadCrossCrosshairSize();
            }
        }

        private void chkCrossGap_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkCrossGap.Checked)
            {
                _settings.CrossSettings.CrosshairGap = null;
                LoadCrossCrosshairGap();
            }
        }

        private void chkCrossWidth_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkCrossWidth.Checked)
            {
                _settings.CrossSettings.CrosshairWidth = null;
                LoadCrossCrosshairWidth();
            }
        }

        private void chkCrossOutline_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkCrossOutline.Checked)
            {
                _settings.CrossSettings.CrosshairOutline = null;
                LoadCrossCrosshairOutline();
            }
        }

        private void chkCircleSize_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkCircleSize.Checked)
            {
                _settings.CircleSettings.CrosshairSize = null;
                LoadCircleCrosshairSize();
            }
        }

        private void chkCircleGap_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkCircleGap.Checked)
            {
                _settings.CircleSettings.CrosshairGap = null;
                LoadCircleCrosshairGap();
            }
        }

        private void chkCircleWidth_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkCircleWidth.Checked)
            {
                _settings.CircleSettings.CrosshairWidth = null;
                LoadCircleCrosshairWidth();
            }
        }

        private void chkCircleOutline_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkCircleOutline.Checked)
            {
                _settings.CircleSettings.CrosshairOutline = null;
                LoadCircleCrosshairOutline();
            }
        }

        private void chkDotFillColor_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkDotFillColor.Checked)
            {
                _settings.DotSettings.FillColor = null;
                btnDotFillColor.BackColor = _settings.GlobalSettings.FillColor;
                btnDotFillColor.ForeColor = ContrastTextColor(_settings.GlobalSettings.FillColor);
            }
        }

        private void chkDotOutlineColor_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkDotOutlineColor.Checked)
            {
                _settings.DotSettings.OutlineColor = null;
                btnDotOutlineColor.BackColor = _settings.GlobalSettings.OutlineColor;
                btnDotOutlineColor.ForeColor = ContrastTextColor(_settings.GlobalSettings.OutlineColor);
            }
        }

        private void chkCrossFillColor_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkCrossFillColor.Checked)
            {
                _settings.CrossSettings.FillColor = null;
                btnCrossFillColor.BackColor = _settings.GlobalSettings.FillColor;
                btnCrossFillColor.ForeColor = ContrastTextColor(_settings.GlobalSettings.FillColor);
            }
        }

        private void chkCrossOutlineColor_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkCrossOutlineColor.Checked)
            {
                _settings.CrossSettings.OutlineColor = null;
                btnCrossOutlineColor.BackColor = _settings.GlobalSettings.OutlineColor;
                btnCrossOutlineColor.ForeColor = ContrastTextColor(_settings.GlobalSettings.OutlineColor);
            }
        }

        private void chkCircleFillColor_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkCircleFillColor.Checked)
            {
                _settings.CircleSettings.FillColor = null;
                btnCircleFillColor.BackColor = _settings.GlobalSettings.FillColor;
                btnCircleFillColor.ForeColor = ContrastTextColor(_settings.GlobalSettings.FillColor);
            }
        }

        private void chkCircleOutlineColor_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkCircleOutlineColor.Checked)
            {
                _settings.CircleSettings.OutlineColor = null;
                btnCircleOutlineColor.BackColor = _settings.GlobalSettings.OutlineColor;
                btnCircleOutlineColor.ForeColor = ContrastTextColor(_settings.GlobalSettings.OutlineColor);
            }
        }
    }
}
