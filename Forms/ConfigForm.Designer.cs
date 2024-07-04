
namespace CrosshairOverlay
{
    partial class ConfigForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
            this.gbShape = new System.Windows.Forms.GroupBox();
            this.chkPlus = new System.Windows.Forms.CheckBox();
            this.chkCross = new System.Windows.Forms.CheckBox();
            this.chkDot = new System.Windows.Forms.CheckBox();
            this.chkCircle = new System.Windows.Forms.CheckBox();
            this.btnColorReset = new System.Windows.Forms.Button();
            this.btnColor = new System.Windows.Forms.Button();
            this.gbSettings = new System.Windows.Forms.GroupBox();
            this.lblOpacity = new System.Windows.Forms.Label();
            this.numOpacity = new System.Windows.Forms.NumericUpDown();
            this.lblGap = new System.Windows.Forms.Label();
            this.numThickness = new System.Windows.Forms.NumericUpDown();
            this.lblThickness = new System.Windows.Forms.Label();
            this.numGap = new System.Windows.Forms.NumericUpDown();
            this.lblSize = new System.Windows.Forms.Label();
            this.numSize = new System.Windows.Forms.NumericUpDown();
            this.gbColor = new System.Windows.Forms.GroupBox();
            this.gbShape.SuspendLayout();
            this.gbSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOpacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numThickness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSize)).BeginInit();
            this.gbColor.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbShape
            // 
            this.gbShape.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbShape.Controls.Add(this.chkPlus);
            this.gbShape.Controls.Add(this.chkCross);
            this.gbShape.Controls.Add(this.chkDot);
            this.gbShape.Controls.Add(this.chkCircle);
            this.gbShape.Location = new System.Drawing.Point(14, 15);
            this.gbShape.Margin = new System.Windows.Forms.Padding(4);
            this.gbShape.Name = "gbShape";
            this.gbShape.Padding = new System.Windows.Forms.Padding(4);
            this.gbShape.Size = new System.Drawing.Size(217, 86);
            this.gbShape.TabIndex = 3;
            this.gbShape.TabStop = false;
            this.gbShape.Text = "Crosshair Style";
            // 
            // chkPlus
            // 
            this.chkPlus.AutoSize = true;
            this.chkPlus.Location = new System.Drawing.Point(121, 55);
            this.chkPlus.Margin = new System.Windows.Forms.Padding(4);
            this.chkPlus.Name = "chkPlus";
            this.chkPlus.Size = new System.Drawing.Size(50, 21);
            this.chkPlus.TabIndex = 3;
            this.chkPlus.Text = "Plus";
            this.chkPlus.UseVisualStyleBackColor = true;
            this.chkPlus.CheckedChanged += new System.EventHandler(this.chkPlus_CheckedChanged);
            // 
            // chkCross
            // 
            this.chkCross.AutoSize = true;
            this.chkCross.Location = new System.Drawing.Point(121, 26);
            this.chkCross.Margin = new System.Windows.Forms.Padding(4);
            this.chkCross.Name = "chkCross";
            this.chkCross.Size = new System.Drawing.Size(60, 21);
            this.chkCross.TabIndex = 2;
            this.chkCross.Text = "Cross";
            this.chkCross.UseVisualStyleBackColor = true;
            this.chkCross.CheckedChanged += new System.EventHandler(this.chkCross_CheckedChanged);
            // 
            // chkDot
            // 
            this.chkDot.AutoSize = true;
            this.chkDot.Location = new System.Drawing.Point(23, 55);
            this.chkDot.Margin = new System.Windows.Forms.Padding(4);
            this.chkDot.Name = "chkDot";
            this.chkDot.Size = new System.Drawing.Size(48, 21);
            this.chkDot.TabIndex = 1;
            this.chkDot.Text = "Dot";
            this.chkDot.UseVisualStyleBackColor = true;
            this.chkDot.CheckedChanged += new System.EventHandler(this.chkDot_CheckedChanged);
            // 
            // chkCircle
            // 
            this.chkCircle.AutoSize = true;
            this.chkCircle.Location = new System.Drawing.Point(23, 26);
            this.chkCircle.Margin = new System.Windows.Forms.Padding(4);
            this.chkCircle.Name = "chkCircle";
            this.chkCircle.Size = new System.Drawing.Size(59, 21);
            this.chkCircle.TabIndex = 0;
            this.chkCircle.Text = "Circle";
            this.chkCircle.UseVisualStyleBackColor = true;
            this.chkCircle.CheckedChanged += new System.EventHandler(this.chkCircle_CheckedChanged);
            // 
            // btnColorReset
            // 
            this.btnColorReset.BackColor = System.Drawing.Color.Transparent;
            this.btnColorReset.FlatAppearance.BorderSize = 0;
            this.btnColorReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColorReset.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColorReset.Location = new System.Drawing.Point(172, 23);
            this.btnColorReset.Margin = new System.Windows.Forms.Padding(4);
            this.btnColorReset.Name = "btnColorReset";
            this.btnColorReset.Size = new System.Drawing.Size(26, 30);
            this.btnColorReset.TabIndex = 1;
            this.btnColorReset.TabStop = false;
            this.btnColorReset.Text = "X";
            this.btnColorReset.UseVisualStyleBackColor = false;
            this.btnColorReset.Click += new System.EventHandler(this.btnColorReset_Click);
            // 
            // btnColor
            // 
            this.btnColor.BackColor = System.Drawing.Color.Transparent;
            this.btnColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColor.Location = new System.Drawing.Point(38, 23);
            this.btnColor.Margin = new System.Windows.Forms.Padding(4);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(133, 30);
            this.btnColor.TabIndex = 0;
            this.btnColor.Text = "Color";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // gbSettings
            // 
            this.gbSettings.Controls.Add(this.lblOpacity);
            this.gbSettings.Controls.Add(this.numOpacity);
            this.gbSettings.Controls.Add(this.lblGap);
            this.gbSettings.Controls.Add(this.numThickness);
            this.gbSettings.Controls.Add(this.lblThickness);
            this.gbSettings.Controls.Add(this.numGap);
            this.gbSettings.Controls.Add(this.lblSize);
            this.gbSettings.Controls.Add(this.numSize);
            this.gbSettings.Location = new System.Drawing.Point(14, 109);
            this.gbSettings.Margin = new System.Windows.Forms.Padding(4);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Padding = new System.Windows.Forms.Padding(4);
            this.gbSettings.Size = new System.Drawing.Size(217, 163);
            this.gbSettings.TabIndex = 5;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "Settings";
            // 
            // lblOpacity
            // 
            this.lblOpacity.AutoSize = true;
            this.lblOpacity.Location = new System.Drawing.Point(20, 127);
            this.lblOpacity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOpacity.Name = "lblOpacity";
            this.lblOpacity.Size = new System.Drawing.Size(52, 17);
            this.lblOpacity.TabIndex = 10;
            this.lblOpacity.Text = "Opacity";
            // 
            // numOpacity
            // 
            this.numOpacity.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numOpacity.Location = new System.Drawing.Point(121, 125);
            this.numOpacity.Margin = new System.Windows.Forms.Padding(4);
            this.numOpacity.Name = "numOpacity";
            this.numOpacity.Size = new System.Drawing.Size(75, 25);
            this.numOpacity.TabIndex = 9;
            this.numOpacity.ValueChanged += new System.EventHandler(this.numOpacity_ValueChanged);
            // 
            // lblGap
            // 
            this.lblGap.AutoSize = true;
            this.lblGap.Location = new System.Drawing.Point(19, 61);
            this.lblGap.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGap.Name = "lblGap";
            this.lblGap.Size = new System.Drawing.Size(32, 17);
            this.lblGap.TabIndex = 8;
            this.lblGap.Text = "Gap";
            // 
            // numThickness
            // 
            this.numThickness.DecimalPlaces = 1;
            this.numThickness.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numThickness.Location = new System.Drawing.Point(121, 92);
            this.numThickness.Margin = new System.Windows.Forms.Padding(4);
            this.numThickness.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numThickness.Name = "numThickness";
            this.numThickness.Size = new System.Drawing.Size(75, 25);
            this.numThickness.TabIndex = 7;
            this.numThickness.ValueChanged += new System.EventHandler(this.numThickness_ValueChanged);
            // 
            // lblThickness
            // 
            this.lblThickness.AutoSize = true;
            this.lblThickness.Location = new System.Drawing.Point(20, 94);
            this.lblThickness.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblThickness.Name = "lblThickness";
            this.lblThickness.Size = new System.Drawing.Size(63, 17);
            this.lblThickness.TabIndex = 6;
            this.lblThickness.Text = "Thickness";
            // 
            // numGap
            // 
            this.numGap.DecimalPlaces = 1;
            this.numGap.Location = new System.Drawing.Point(121, 59);
            this.numGap.Margin = new System.Windows.Forms.Padding(4);
            this.numGap.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.numGap.Name = "numGap";
            this.numGap.Size = new System.Drawing.Size(75, 25);
            this.numGap.TabIndex = 5;
            this.numGap.ValueChanged += new System.EventHandler(this.numGap_ValueChanged);
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(20, 28);
            this.lblSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(31, 17);
            this.lblSize.TabIndex = 4;
            this.lblSize.Text = "Size";
            // 
            // numSize
            // 
            this.numSize.DecimalPlaces = 1;
            this.numSize.Location = new System.Drawing.Point(121, 26);
            this.numSize.Margin = new System.Windows.Forms.Padding(4);
            this.numSize.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numSize.Name = "numSize";
            this.numSize.Size = new System.Drawing.Size(75, 25);
            this.numSize.TabIndex = 3;
            this.numSize.ValueChanged += new System.EventHandler(this.numSize_ValueChanged);
            // 
            // gbColor
            // 
            this.gbColor.Controls.Add(this.btnColor);
            this.gbColor.Controls.Add(this.btnColorReset);
            this.gbColor.Location = new System.Drawing.Point(14, 280);
            this.gbColor.Margin = new System.Windows.Forms.Padding(4);
            this.gbColor.Name = "gbColor";
            this.gbColor.Padding = new System.Windows.Forms.Padding(4);
            this.gbColor.Size = new System.Drawing.Size(217, 70);
            this.gbColor.TabIndex = 6;
            this.gbColor.TabStop = false;
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 364);
            this.Controls.Add(this.gbColor);
            this.Controls.Add(this.gbSettings);
            this.Controls.Add(this.gbShape);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crosshair Overlay Configuration";
            this.gbShape.ResumeLayout(false);
            this.gbShape.PerformLayout();
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOpacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numThickness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSize)).EndInit();
            this.gbColor.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gbShape;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Button btnColorReset;
        private System.Windows.Forms.GroupBox gbSettings;
        private System.Windows.Forms.Label lblOpacity;
        private System.Windows.Forms.NumericUpDown numOpacity;
        private System.Windows.Forms.Label lblGap;
        private System.Windows.Forms.NumericUpDown numThickness;
        private System.Windows.Forms.Label lblThickness;
        private System.Windows.Forms.NumericUpDown numGap;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.NumericUpDown numSize;
        private System.Windows.Forms.CheckBox chkPlus;
        private System.Windows.Forms.CheckBox chkCross;
        private System.Windows.Forms.CheckBox chkDot;
        private System.Windows.Forms.CheckBox chkCircle;
        private System.Windows.Forms.GroupBox gbColor;
    }
}