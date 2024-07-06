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

            btnFillColor.BackColor = _settings.GlobalSettings.GetFillColor();
            btnFillColor.ForeColor = ContrastForeColor(btnFillColor.BackColor);

            btnOutlineColor.BackColor = _settings.GlobalSettings.GetOutlineColor();
            btnOutlineColor.ForeColor = ContrastForeColor(btnOutlineColor.BackColor);

            fillColorAlpha.Value = (int)Math.Round(_settings.GlobalSettings.FillColorAlpha * fillColorAlpha.Maximum);
            lblFillColorAlpha.Text = fillColorAlpha.Value.ToString();

            outlineColorAlpha.Value = (int)Math.Round(_settings.GlobalSettings.OutlineColorAlpha * outlineColorAlpha.Maximum);
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

            dotFillColorAlpha.Value = ConvertAlphaToSliderValue(_settings.DotSettings.GetFillColorAlpha(), dotFillColorAlpha.Maximum);
            lblDotFillColorAlpha.Text = dotFillColorAlpha.Value.ToString();

            dotOutlineColorAlpha.Value = ConvertAlphaToSliderValue(_settings.DotSettings.GetOutlineColorAlpha(), dotOutlineColorAlpha.Maximum);
            lblDotOutlineColorAlpha.Text = dotOutlineColorAlpha.Value.ToString();

            LoadDotCrosshairOutline();
            LoadDotCrosshairWidth();

            // Cross settings

            crossFillColorAlpha.Value = ConvertAlphaToSliderValue(_settings.CrossSettings.GetFillColorAlpha(), crossFillColorAlpha.Maximum);
            lblCrossFillColorAlpha.Text = crossFillColorAlpha.Value.ToString();

            crossOutlineColorAlpha.Value = ConvertAlphaToSliderValue(_settings.CrossSettings.GetOutlineColorAlpha(), crossOutlineColorAlpha.Maximum);
            lblCrossOutlineColorAlpha.Text = crossOutlineColorAlpha.Value.ToString();

            LoadCrossCrosshairSize();
            LoadCrossCrosshairGap();
            LoadCrossCrosshairWidth();
            LoadCrossCrosshairOutline();
        
            // Circle settings

            circleFillColorAlpha.Value = ConvertAlphaToSliderValue(_settings.CircleSettings.GetFillColorAlpha(), circleFillColorAlpha.Maximum);
            lblCircleFillColorAlpha.Text = circleFillColorAlpha.Value.ToString();

            circleOutlineColorAlpha.Value = ConvertAlphaToSliderValue(_settings.CircleSettings.GetOutlineColorAlpha(), circleOutlineColorAlpha.Maximum);
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
            crossCrosshairSize.Value = (int)_settings.CrossSettings.GetCrosshairSize();
            lblCrossSizeValue.Text = crossCrosshairSize.Value.ToString();
        }

        private void LoadCrossCrosshairGap()
        {
            crossCrosshairGap.Value = (int)_settings.CrossSettings.GetCrosshairGap();
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
            circleCrosshairSize.Value = (int)_settings.CircleSettings.GetCrosshairSize();
            lblCircleSizeValue.Text = circleCrosshairSize.Value.ToString();
        }

        private void LoadCircleCrosshairGap()
           {
            circleCrosshairGap.Value = (int)_settings.CircleSettings.GetCrosshairGap();
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
            return (float)value * .5f;
        }

        private int ConvertSmallToBig(float value)
        {
            return (int)Math.Round(value * 2f);
        }

        private int ConvertAlphaToSliderValue(int value, int sliderMax)
        {
            return (int)Math.Round((float)value / 255f * (float)sliderMax);
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
            fillColorButton.ForeColor = enabled ? ContrastForeColor(fillColorButton.BackColor) : Color.DarkGray;
            checkFillColor.Checked = settings.FillColor.HasValue;

            var outlineColor = enabled ? settings.GetOutlineColor() : Color.Empty;
            outlineColorButton.BackColor = outlineColor;
            outlineColorButton.ForeColor = enabled ? ContrastForeColor(outlineColorButton.BackColor) : Color.DarkGray;
            checkOutlineColor.Checked = settings.OutlineColor.HasValue;
        }

        private void UpdateFillColorSetting(ShapeSettings settings, Color newColor, Button button, CheckBox check, bool enabled)
        {
            if (settings.FillColor.HasValue && settings.FillColor == newColor)
            {
                settings.FillColor = null;
                check.Checked = false;
                return;
            }

            if (!settings.FillColor.HasValue)
            {
                if (enabled)
                {
                    button.BackColor = _settings.GlobalSettings.GetFillColor();
                    button.ForeColor = ContrastForeColor(button.BackColor);
                }
                check.Checked = false;
            }
        }

        private void UpdateOutlineColorSetting(ShapeSettings settings, Color newColor, Button button, CheckBox check, bool enabled)
        {
            if (settings.OutlineColor.HasValue && settings.OutlineColor == newColor)
            {
                settings.OutlineColor = null;
                check.Checked = false;
                return;
            }

            if (!settings.OutlineColor.HasValue)
            {
                if (enabled)
                {
                    button.BackColor = _settings.GlobalSettings.GetOutlineColor();
                    button.ForeColor = ContrastForeColor(button.BackColor);
                }
                check.Checked = false;
            }
        }

        private void UpdateFillColorAlphaSetting(ShapeSettings settings, float newAlpha, TrackBar slider, Label label, Button button, bool enabled)
        {
            if (settings.FillColorAlpha.HasValue && settings.FillColorAlpha == newAlpha)
            {
                settings.FillColorAlpha = null;
                return;
            }

            if (!settings.FillColorAlpha.HasValue)
            {
                var intAlpha = (int)(newAlpha * 100f);
                slider.Value = intAlpha;
                label.Text = intAlpha.ToString();
                if (enabled)
                {
                    button.BackColor = settings.GetFillColor();
                    button.ForeColor = ContrastForeColor(button.BackColor);
                }
            }
        }

        private void UpdateOutlineColorAlphaSetting(ShapeSettings settings, float newAlpha, TrackBar slider, Label label, Button button, bool enabled)
        {
            if (settings.OutlineColorAlpha.HasValue && settings.OutlineColorAlpha == newAlpha)
            {
                settings.OutlineColorAlpha = null;
                return;
            }
            
            if (!settings.OutlineColorAlpha.HasValue)
            {
                var intAlpha = (int)(newAlpha * 100f);
                slider.Value = intAlpha;
                label.Text = intAlpha.ToString();
                if (enabled)
                {
                    button.BackColor = settings.GetOutlineColor();
                    button.ForeColor = ContrastForeColor(button.BackColor);
                }
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
                btnFillColor.BackColor = _settings.GlobalSettings.GetFillColor();
                btnFillColor.ForeColor = ContrastForeColor(btnFillColor.BackColor);

                UpdateFillColorSetting(_settings.DotSettings, newColor, btnDotFillColor, chkDotFillColor, _settings.GlobalSettings.CrosshairDot);
                UpdateFillColorSetting(_settings.CrossSettings, newColor, btnCrossFillColor, chkCrossFillColor, _settings.GlobalSettings.CrosshairCross);
                UpdateFillColorSetting(_settings.CircleSettings, newColor, btnCircleFillColor, chkCircleFillColor, _settings.GlobalSettings.CrosshairCircle);
            }
        }

        private void btnOutlineColor_Click(object sender, EventArgs e)
        {
            var (colorDlg, colorResult) = SelectColor(btnOutlineColor.BackColor);
            if (colorResult == DialogResult.OK)
            {
                var newColor = colorDlg.Color;
                _settings.GlobalSettings.OutlineColor = newColor;
                btnOutlineColor.BackColor = _settings.GlobalSettings.GetOutlineColor();
                btnOutlineColor.ForeColor = ContrastForeColor(btnOutlineColor.BackColor);

                UpdateOutlineColorSetting(_settings.DotSettings, newColor, btnDotOutlineColor, chkDotOutlineColor, _settings.GlobalSettings.CrosshairDot);
                UpdateOutlineColorSetting(_settings.CrossSettings, newColor, btnCrossOutlineColor, chkCrossOutlineColor, _settings.GlobalSettings.CrosshairCross);
                UpdateOutlineColorSetting(_settings.CircleSettings, newColor, btnCircleOutlineColor, chkCircleOutlineColor, _settings.GlobalSettings.CrosshairCircle);
            }
        }

        private Color ContrastForeColor(Color backgroundColor)
        {
            var darkGray = Color.FromArgb(32, 32, 32);
            return darkGray;

            //var brightness = (int)Math.Sqrt(
            //    backgroundColor.R * backgroundColor.R * .299 +
            //    backgroundColor.G * backgroundColor.G * .587 +
            //    backgroundColor.B * backgroundColor.B * .114);

            //return brightness >= 128 ? darkGray : (backgroundColor.A >= 128 ? Color.WhiteSmoke : darkGray);
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

        private void crosshairOutline_Scroll(object sender, EventArgs e)
        {
            var outline = ConvertBigToSmall(crosshairOutline.Value);
            lblOutlineValue.Text = TrimDecimals(outline);
            _settings.GlobalSettings.CrosshairOutline = outline;

            UpdateSmallCrosshairSetting(_settings.DotSettings.CrosshairOutline, _settings.GlobalSettings.CrosshairOutline, outline, dotCrosshairOutline, lblDotOutlineValue);
            UpdateSmallCrosshairSetting(_settings.CrossSettings.CrosshairOutline, _settings.GlobalSettings.CrosshairOutline, outline, crossCrosshairOutline, lblCrossOutlineValue);
            UpdateSmallCrosshairSetting(_settings.CircleSettings.CrosshairOutline, _settings.GlobalSettings.CrosshairOutline, outline, circleCrosshairOutline, lblCircleOutlineValue);
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
            var newAlpha = (float)fillColorAlpha.Value / (float)fillColorAlpha.Maximum;
            lblFillColorAlpha.Text = fillColorAlpha.Value.ToString();
            _settings.GlobalSettings.FillColorAlpha = newAlpha;
            btnFillColor.BackColor = _settings.GlobalSettings.GetFillColor();
            btnFillColor.ForeColor = ContrastForeColor(btnFillColor.BackColor);

            UpdateFillColorAlphaSetting(_settings.DotSettings, newAlpha, dotFillColorAlpha, lblDotFillColorAlpha, btnDotFillColor, _settings.GlobalSettings.CrosshairDot);
            UpdateFillColorAlphaSetting(_settings.CrossSettings, newAlpha, crossFillColorAlpha, lblCrossFillColorAlpha, btnCrossFillColor, _settings.GlobalSettings.CrosshairCross);
            UpdateFillColorAlphaSetting(_settings.CircleSettings, newAlpha, circleFillColorAlpha, lblCircleFillColorAlpha, btnCircleFillColor, _settings.GlobalSettings.CrosshairCircle);
        }

        private void outlineColorAlpha_Scroll(object sender, EventArgs e)
        {
            var newAlpha = (float)outlineColorAlpha.Value / (float)outlineColorAlpha.Maximum;
            lblOutlineColorAlpha.Text = outlineColorAlpha.Value.ToString();
            _settings.GlobalSettings.OutlineColorAlpha = newAlpha;
            btnOutlineColor.BackColor = _settings.GlobalSettings.GetOutlineColor();
            btnOutlineColor.ForeColor = ContrastForeColor(btnOutlineColor.BackColor);

            UpdateOutlineColorAlphaSetting(_settings.DotSettings, newAlpha, dotOutlineColorAlpha, lblDotOutlineColorAlpha, btnDotOutlineColor, _settings.GlobalSettings.CrosshairDot);
            UpdateOutlineColorAlphaSetting(_settings.CrossSettings, newAlpha, crossOutlineColorAlpha, lblCrossOutlineColorAlpha, btnCrossOutlineColor, _settings.GlobalSettings.CrosshairCross);
            UpdateOutlineColorAlphaSetting(_settings.CircleSettings, newAlpha, circleOutlineColorAlpha, lblCircleOutlineColorAlpha, btnCircleOutlineColor, _settings.GlobalSettings.CrosshairCircle);
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
                chkCrossSize.Checked = false;
            }
            else
            {
                _settings.CrossSettings.CrosshairSize = crossCrosshairSize.Value;
                chkCrossSize.Checked = true;
            }
        }

        private void crossCrosshairGap_Scroll(object sender, EventArgs e)
        {
            lblCrossGapValue.Text = crossCrosshairGap.Value.ToString();

            if (_settings.GlobalSettings.CrosshairGap == crossCrosshairGap.Value)
            {
                _settings.CrossSettings.CrosshairGap = null;
                chkCrossGap.Checked = false;
            }
            else
            {
                _settings.CrossSettings.CrosshairGap = crossCrosshairGap.Value;
                chkCrossGap.Checked = true;
            }
        }

        private void crossCrosshairWidth_Scroll(object sender, EventArgs e)
        {
            var width = ConvertBigToSmall(crossCrosshairWidth.Value);
            lblCrossWidthValue.Text = TrimDecimals(width);

            if (_settings.GlobalSettings.CrosshairWidth == width)
            {
                _settings.CrossSettings.CrosshairWidth = null;
                chkCrossWidth.Checked = false;
            }
            else
            {
                _settings.CrossSettings.CrosshairWidth = width;
                chkCrossWidth.Checked = true;
            }
        }

        private void crossCrosshairOutline_Scroll(object sender, EventArgs e)
        {
            var outline = ConvertBigToSmall(crossCrosshairOutline.Value);
            lblCrossOutlineValue.Text = TrimDecimals(outline);

            if (_settings.GlobalSettings.CrosshairOutline == outline)
            {
                _settings.CrossSettings.CrosshairOutline = null;
                chkCrossOutline.Checked = false;
            }
            else
            {
                _settings.CrossSettings.CrosshairOutline = outline;
                chkCrossOutline.Checked = true;
            }
        }

        private void circleCrosshairSize_Scroll(object sender, EventArgs e)
        {
            lblCircleSizeValue.Text = circleCrosshairSize.Value.ToString();

            if (_settings.GlobalSettings.CrosshairSize == circleCrosshairSize.Value)
            {
                _settings.CircleSettings.CrosshairSize = null;
                chkCircleSize.Checked = false;
            }
            else
            {
                _settings.CircleSettings.CrosshairSize = circleCrosshairSize.Value;
                chkCircleSize.Checked = true;
            }
        }

        private void circleCrosshairGap_Scroll(object sender, EventArgs e)
        {
            lblCircleGapValue.Text = circleCrosshairGap.Value.ToString();

            if (_settings.GlobalSettings.CrosshairGap == circleCrosshairGap.Value)
            {
                _settings.CircleSettings.CrosshairGap = null;
                chkCircleGap.Checked = false;
            }
            else
            {
                _settings.CircleSettings.CrosshairGap = circleCrosshairGap.Value;
                chkCircleGap.Checked = true;
            }
        }

        private void circleCrosshairWidth_Scroll(object sender, EventArgs e)
        {
            var width = ConvertBigToSmall(circleCrosshairWidth.Value);
            lblCircleWidthValue.Text = TrimDecimals(width);

            if (_settings.GlobalSettings.CrosshairWidth == width)
            {
                _settings.CircleSettings.CrosshairWidth = null;
                chkCircleWidth.Checked = false;
            }
            else
            {
                _settings.CircleSettings.CrosshairWidth = width;
                chkCircleWidth.Checked = true;
            }
        }

        private void circleCrosshairOutline_Scroll(object sender, EventArgs e)
        {
            var outline = ConvertBigToSmall(circleCrosshairOutline.Value);
            lblCircleOutlineValue.Text = TrimDecimals(outline);

            if (_settings.GlobalSettings.CrosshairOutline == outline)
            {
                _settings.CircleSettings.CrosshairOutline = null;
                chkCircleOutline.Checked = false;
            }
            else
            {
                _settings.CircleSettings.CrosshairOutline = outline;
                chkCircleOutline.Checked = true;
            }
        }

        private void dotFillColorAlpha_Scroll(object sender, EventArgs e)
        {
            var newAlpha = (float)dotFillColorAlpha.Value / (float)dotFillColorAlpha.Maximum;
            lblDotFillColorAlpha.Text = dotFillColorAlpha.Value.ToString();

            if (_settings.GlobalSettings.FillColorAlpha == newAlpha)
            {
                _settings.DotSettings.FillColorAlpha = null;
                if (!_settings.DotSettings.FillColor.HasValue)
                    chkDotFillColor.Checked = false;
            }
            else
            {
                _settings.DotSettings.FillColorAlpha = newAlpha;
                chkDotFillColor.Checked = true;
            }

            btnDotFillColor.BackColor = _settings.DotSettings.GetFillColor();
            btnDotFillColor.ForeColor = ContrastForeColor(btnDotFillColor.BackColor);
        }

        private void dotOutlineColorAlpha_Scroll(object sender, EventArgs e)
        {
            var newAlpha = (float)dotOutlineColorAlpha.Value / (float)dotOutlineColorAlpha.Maximum;
            lblDotOutlineColorAlpha.Text = dotOutlineColorAlpha.Value.ToString();

            if (_settings.GlobalSettings.OutlineColorAlpha == newAlpha)
            {
                _settings.DotSettings.OutlineColorAlpha = null;
                if (!_settings.DotSettings.OutlineColor.HasValue)
                    chkDotOutlineColor.Checked = false;
            }
            else
            {
                _settings.DotSettings.OutlineColorAlpha = newAlpha;
                chkDotOutlineColor.Checked = true;
            }

            btnDotOutlineColor.BackColor = _settings.DotSettings.GetOutlineColor();
            btnDotOutlineColor.ForeColor = ContrastForeColor(btnDotOutlineColor.BackColor);
        }

        private void crossFillColorAlpha_Scroll(object sender, EventArgs e)
        {
            var newAlpha = (float)crossFillColorAlpha.Value / (float)crossFillColorAlpha.Maximum;
            lblCrossFillColorAlpha.Text = crossFillColorAlpha.Value.ToString();

            if (_settings.GlobalSettings.FillColorAlpha == newAlpha)
            {
                _settings.CrossSettings.FillColorAlpha = null;
                if (!_settings.CrossSettings.FillColor.HasValue)
                    chkCrossFillColor.Checked = false;
            }
            else
            {
                _settings.CrossSettings.FillColorAlpha = newAlpha;
                chkCrossFillColor.Checked = true;
            }

            btnCrossFillColor.BackColor = _settings.CrossSettings.GetFillColor();
            btnCrossFillColor.ForeColor = ContrastForeColor(btnCrossFillColor.BackColor);
        }

        private void crossOutlineColorAlpha_Scroll(object sender, EventArgs e)
        {
            var newAlpha = (float)crossOutlineColorAlpha.Value / (float)crossOutlineColorAlpha.Maximum;
            lblCrossOutlineColorAlpha.Text = crossOutlineColorAlpha.Value.ToString();

            if (_settings.GlobalSettings.OutlineColorAlpha == newAlpha)
            {
                _settings.CrossSettings.OutlineColorAlpha = null;
                if (!_settings.CrossSettings.OutlineColor.HasValue)
                    chkCrossOutlineColor.Checked = false;
            }
            else
            {
                _settings.CrossSettings.OutlineColorAlpha = newAlpha;
                chkCrossOutlineColor.Checked = true;
            }

            btnCrossOutlineColor.BackColor = _settings.CrossSettings.GetOutlineColor();
            btnCrossOutlineColor.ForeColor = ContrastForeColor(btnCrossOutlineColor.BackColor);
        }

        private void circleFillColorAlpha_Scroll(object sender, EventArgs e)
        {
            var newAlpha = (float)circleFillColorAlpha.Value / (float)circleFillColorAlpha.Maximum;
            lblCircleFillColorAlpha.Text = circleFillColorAlpha.Value.ToString();

            if (_settings.GlobalSettings.FillColorAlpha == newAlpha)
            {
                _settings.CircleSettings.FillColorAlpha = null;
                if (!_settings.CircleSettings.FillColor.HasValue)
                    chkCircleFillColor.Checked = false;
            }
            else
            {
                _settings.CircleSettings.FillColorAlpha = newAlpha;
                chkCircleFillColor.Checked = true;
            }

            btnCircleFillColor.BackColor = _settings.CircleSettings.GetFillColor();
            btnCircleFillColor.ForeColor = ContrastForeColor(btnCircleFillColor.BackColor);
        }

        private void circleOutlineColorAlpha_Scroll(object sender, EventArgs e)
        {
            var newAlpha = (float)circleOutlineColorAlpha.Value / (float)circleOutlineColorAlpha.Maximum;
            lblCircleOutlineColorAlpha.Text = circleOutlineColorAlpha.Value.ToString();

            if (_settings.GlobalSettings.OutlineColorAlpha == newAlpha)
            {
                _settings.CircleSettings.OutlineColorAlpha = null;
                if (!_settings.CircleSettings.OutlineColor.HasValue)
                    chkCircleOutlineColor.Checked = false;
            }
            else
            {
                _settings.CircleSettings.OutlineColorAlpha = newAlpha;
                chkCircleOutlineColor.Checked = true;
            }

            btnCircleOutlineColor.BackColor = _settings.CircleSettings.GetOutlineColor();
            btnCircleOutlineColor.ForeColor = ContrastForeColor(btnCircleOutlineColor.BackColor);
        }

        private void btnDotFillColor_Click(object sender, EventArgs e)
        {
            var (colorDlg, colorResult) = SelectColor(btnDotFillColor.BackColor);
            if (colorResult == DialogResult.OK)
            {
                if (_settings.GlobalSettings.FillColor == colorDlg.Color)
                {
                    _settings.DotSettings.FillColor = null;
                    if (!_settings.DotSettings.FillColorAlpha.HasValue)
                        chkDotFillColor.Checked = false;
                }
                else
                {
                    _settings.DotSettings.FillColor = colorDlg.Color;
                    chkDotFillColor.Checked = true;
                }

                btnDotFillColor.BackColor =  _settings.DotSettings.GetFillColor();
                btnDotFillColor.ForeColor = ContrastForeColor(btnDotFillColor.BackColor);
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
                    if (!_settings.DotSettings.OutlineColorAlpha.HasValue)
                        chkDotOutlineColor.Checked = false;
                }
                else
                {
                    _settings.DotSettings.OutlineColor = colorDlg.Color;
                    chkDotOutlineColor.Checked = true;
                }

                btnDotOutlineColor.BackColor = _settings.DotSettings.GetOutlineColor();
                btnDotOutlineColor.ForeColor = ContrastForeColor(btnDotOutlineColor.BackColor);
            }
        }

        private void btnCrossFillColor_Click(object sender, EventArgs e)
        {
            var (colorDlg, colorResult) = SelectColor(btnCrossFillColor.BackColor);
            if (colorResult == DialogResult.OK)
            {

                if (_settings.GlobalSettings.FillColor == colorDlg.Color)
                {
                    _settings.CrossSettings.FillColor = null;
                    if (!_settings.CrossSettings.FillColorAlpha.HasValue)
                        chkCrossFillColor.Checked = false;
                }
                else
                {
                    _settings.CrossSettings.FillColor = colorDlg.Color;
                    chkCrossFillColor.Checked = true;
                }

                btnCrossFillColor.BackColor = _settings.CrossSettings.GetFillColor();
                btnCrossFillColor.ForeColor = btnCrossFillColor.BackColor;
            }
        }

        private void btnCrossOutlineColor_Click(object sender, EventArgs e)
        {
            var (colorDlg, colorResult) = SelectColor(btnCrossOutlineColor.BackColor);
            if (colorResult == DialogResult.OK)
            {
                if (_settings.GlobalSettings.OutlineColor == colorDlg.Color)
                {
                    _settings.CrossSettings.OutlineColor = null;
                    if (!_settings.CrossSettings.OutlineColorAlpha.HasValue)
                        chkCrossOutlineColor.Checked = false;
                }
                else
                {
                    _settings.CrossSettings.OutlineColor = colorDlg.Color;
                    chkCrossOutlineColor.Checked = true;
                }

                btnCrossOutlineColor.BackColor = _settings.CrossSettings.GetOutlineColor();
                btnCrossOutlineColor.ForeColor = ContrastForeColor(btnCrossOutlineColor.BackColor);
            }
        }

        private void btnCircleFillColor_Click(object sender, EventArgs e)
        {
            var (colorDlg, colorResult) = SelectColor(btnCircleFillColor.BackColor);
            if (colorResult == DialogResult.OK)
            {
                if (_settings.GlobalSettings.FillColor == colorDlg.Color)
                {
                    _settings.CircleSettings.FillColor = null;
                    if (!_settings.CircleSettings.FillColorAlpha.HasValue)
                        chkCircleFillColor.Checked = false;
                }
                else
                {
                    _settings.CircleSettings.FillColor = colorDlg.Color;
                    chkCircleFillColor.Checked = true;
                }

                btnCircleFillColor.BackColor = _settings.CircleSettings.GetFillColor();
                btnCircleFillColor.ForeColor = ContrastForeColor(btnCircleFillColor.BackColor);
            }
        }

        private void btnCircleOutlineColor_Click(object sender, EventArgs e)
        {
            var (colorDlg, colorResult) = SelectColor(btnCircleOutlineColor.BackColor);
            if (colorResult == DialogResult.OK)
            {
                if (_settings.GlobalSettings.OutlineColor == colorDlg.Color)
                {
                    _settings.CircleSettings.OutlineColor = null;
                    if (!_settings.CircleSettings.OutlineColorAlpha.HasValue)
                        chkCircleOutlineColor.Checked = false;
                }
                else
                {
                    _settings.CircleSettings.OutlineColor = colorDlg.Color;
                    chkCircleOutlineColor.Checked = true;
                }

                btnCircleOutlineColor.BackColor = _settings.CircleSettings.GetOutlineColor();
                btnCircleOutlineColor.ForeColor = ContrastForeColor(btnCircleOutlineColor.BackColor);
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
                btnDotFillColor.BackColor = _settings.GlobalSettings.GetFillColor();
                btnDotFillColor.ForeColor = ContrastForeColor(btnDotFillColor.BackColor);

                _settings.DotSettings.FillColorAlpha = null;
                dotFillColorAlpha.Value = ConvertAlphaToSliderValue(_settings.DotSettings.GetFillColorAlpha(), dotFillColorAlpha.Maximum);
                lblDotFillColorAlpha.Text = dotFillColorAlpha.Value.ToString();
            }
        }

        private void chkDotOutlineColor_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkDotOutlineColor.Checked)
            {
                _settings.DotSettings.OutlineColor = null;
                btnDotOutlineColor.BackColor = _settings.GlobalSettings.GetOutlineColor();
                btnDotOutlineColor.ForeColor = ContrastForeColor(btnDotOutlineColor.BackColor);

                _settings.DotSettings.OutlineColorAlpha = null;
                dotOutlineColorAlpha.Value = ConvertAlphaToSliderValue(_settings.DotSettings.GetOutlineColorAlpha(), dotOutlineColorAlpha.Maximum);
                lblDotOutlineColorAlpha.Text = dotOutlineColorAlpha.Value.ToString();
            }
        }

        private void chkCrossFillColor_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkCrossFillColor.Checked)
            {
                _settings.CrossSettings.FillColor = null;
                btnCrossFillColor.BackColor = _settings.GlobalSettings.GetFillColor();
                btnCrossFillColor.ForeColor = ContrastForeColor(btnCrossFillColor.BackColor);

                _settings.CrossSettings.FillColorAlpha = null;
                crossFillColorAlpha.Value = ConvertAlphaToSliderValue(_settings.CrossSettings.GetFillColorAlpha(), crossFillColorAlpha.Maximum);
                lblCrossFillColorAlpha.Text = crossFillColorAlpha.Value.ToString();
            }
        }

        private void chkCrossOutlineColor_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkCrossOutlineColor.Checked)
            {
                _settings.CrossSettings.OutlineColor = null;
                btnCrossOutlineColor.BackColor = _settings.GlobalSettings.GetOutlineColor();
                btnCrossOutlineColor.ForeColor = ContrastForeColor(btnCrossOutlineColor.BackColor);

                _settings.CrossSettings.OutlineColorAlpha = null;
                crossOutlineColorAlpha.Value = ConvertAlphaToSliderValue(_settings.CrossSettings.GetOutlineColorAlpha(), crossOutlineColorAlpha.Maximum);
                lblCrossOutlineColorAlpha.Text = crossOutlineColorAlpha.Value.ToString();
            }
        }

        private void chkCircleFillColor_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkCircleFillColor.Checked)
            {
                _settings.CircleSettings.FillColor = null;
                btnCircleFillColor.BackColor = _settings.GlobalSettings.GetFillColor();
                btnCircleFillColor.ForeColor = ContrastForeColor(btnCircleFillColor.BackColor);

                _settings.CircleSettings.FillColorAlpha = null;
                circleFillColorAlpha.Value = ConvertAlphaToSliderValue(_settings.CircleSettings.GetFillColorAlpha(), circleFillColorAlpha.Maximum);
                lblCircleFillColorAlpha.Text = circleFillColorAlpha.Value.ToString();
            }
        }

        private void chkCircleOutlineColor_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkCircleOutlineColor.Checked)
            {
                _settings.CircleSettings.OutlineColor = null;
                btnCircleOutlineColor.BackColor = _settings.GlobalSettings.GetOutlineColor();
                btnCircleOutlineColor.ForeColor = ContrastForeColor(btnCircleOutlineColor.BackColor);

                _settings.CircleSettings.OutlineColorAlpha = null;
                circleOutlineColorAlpha.Value = ConvertAlphaToSliderValue(_settings.CircleSettings.GetOutlineColorAlpha(), circleOutlineColorAlpha.Maximum);
                lblCircleOutlineColorAlpha.Text = circleOutlineColorAlpha.Value.ToString();
            }
        }
    }
}
