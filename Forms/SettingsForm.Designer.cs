namespace CrosshairOverlay
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.grpColor = new System.Windows.Forms.GroupBox();
            this.btnOutlineColor = new System.Windows.Forms.Button();
            this.btnClearOutlineColor = new System.Windows.Forms.Button();
            this.btnFillColor = new System.Windows.Forms.Button();
            this.btnClearFillColor = new System.Windows.Forms.Button();
            this.grpShape = new System.Windows.Forms.GroupBox();
            this.chkCross = new System.Windows.Forms.CheckBox();
            this.chkDot = new System.Windows.Forms.CheckBox();
            this.grpSize = new System.Windows.Forms.GroupBox();
            this.lblOutlineValue = new System.Windows.Forms.Label();
            this.lblWidthValue = new System.Windows.Forms.Label();
            this.lblGapValue = new System.Windows.Forms.Label();
            this.lblSizeValue = new System.Windows.Forms.Label();
            this.lblOutline = new System.Windows.Forms.Label();
            this.crosshairOutline = new System.Windows.Forms.TrackBar();
            this.lblWidth = new System.Windows.Forms.Label();
            this.crosshairWidth = new System.Windows.Forms.TrackBar();
            this.lblGap = new System.Windows.Forms.Label();
            this.crosshairGap = new System.Windows.Forms.TrackBar();
            this.lblSize = new System.Windows.Forms.Label();
            this.crosshairSize = new System.Windows.Forms.TrackBar();
            this.grpColor.SuspendLayout();
            this.grpShape.SuspendLayout();
            this.grpSize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.crosshairOutline)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.crosshairWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.crosshairGap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.crosshairSize)).BeginInit();
            this.SuspendLayout();
            // 
            // grpColor
            // 
            this.grpColor.Controls.Add(this.btnOutlineColor);
            this.grpColor.Controls.Add(this.btnClearOutlineColor);
            this.grpColor.Controls.Add(this.btnFillColor);
            this.grpColor.Controls.Add(this.btnClearFillColor);
            this.grpColor.Location = new System.Drawing.Point(12, 10);
            this.grpColor.Name = "grpColor";
            this.grpColor.Size = new System.Drawing.Size(297, 61);
            this.grpColor.TabIndex = 32;
            this.grpColor.TabStop = false;
            this.grpColor.Text = "Color";
            // 
            // btnOutlineColor
            // 
            this.btnOutlineColor.BackColor = System.Drawing.Color.Transparent;
            this.btnOutlineColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOutlineColor.Location = new System.Drawing.Point(157, 22);
            this.btnOutlineColor.Name = "btnOutlineColor";
            this.btnOutlineColor.Size = new System.Drawing.Size(85, 23);
            this.btnOutlineColor.TabIndex = 48;
            this.btnOutlineColor.Text = "Outline Color";
            this.btnOutlineColor.UseVisualStyleBackColor = false;
            this.btnOutlineColor.Click += new System.EventHandler(this.btnOutlineColor_Click);
            // 
            // btnClearOutlineColor
            // 
            this.btnClearOutlineColor.FlatAppearance.BorderSize = 0;
            this.btnClearOutlineColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearOutlineColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.btnClearOutlineColor.Location = new System.Drawing.Point(242, 22);
            this.btnClearOutlineColor.Name = "btnClearOutlineColor";
            this.btnClearOutlineColor.Size = new System.Drawing.Size(23, 23);
            this.btnClearOutlineColor.TabIndex = 49;
            this.btnClearOutlineColor.Text = "X";
            this.btnClearOutlineColor.UseVisualStyleBackColor = true;
            this.btnClearOutlineColor.Click += new System.EventHandler(this.btnClearOutlineColor_Click);
            // 
            // btnFillColor
            // 
            this.btnFillColor.BackColor = System.Drawing.Color.Transparent;
            this.btnFillColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFillColor.Location = new System.Drawing.Point(44, 22);
            this.btnFillColor.Name = "btnFillColor";
            this.btnFillColor.Size = new System.Drawing.Size(85, 23);
            this.btnFillColor.TabIndex = 46;
            this.btnFillColor.Text = "Fill Color";
            this.btnFillColor.UseVisualStyleBackColor = false;
            this.btnFillColor.Click += new System.EventHandler(this.btnFillColor_Click);
            // 
            // btnClearFillColor
            // 
            this.btnClearFillColor.FlatAppearance.BorderSize = 0;
            this.btnClearFillColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearFillColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.btnClearFillColor.Location = new System.Drawing.Point(129, 22);
            this.btnClearFillColor.Name = "btnClearFillColor";
            this.btnClearFillColor.Size = new System.Drawing.Size(23, 23);
            this.btnClearFillColor.TabIndex = 47;
            this.btnClearFillColor.Text = "X";
            this.btnClearFillColor.UseVisualStyleBackColor = true;
            this.btnClearFillColor.Click += new System.EventHandler(this.btnClearFillColor_Click);
            // 
            // grpShape
            // 
            this.grpShape.Controls.Add(this.chkCross);
            this.grpShape.Controls.Add(this.chkDot);
            this.grpShape.Location = new System.Drawing.Point(12, 77);
            this.grpShape.Name = "grpShape";
            this.grpShape.Size = new System.Drawing.Size(297, 52);
            this.grpShape.TabIndex = 33;
            this.grpShape.TabStop = false;
            this.grpShape.Text = "Shape";
            // 
            // chkCross
            // 
            this.chkCross.AutoSize = true;
            this.chkCross.Location = new System.Drawing.Point(175, 22);
            this.chkCross.Name = "chkCross";
            this.chkCross.Size = new System.Drawing.Size(52, 17);
            this.chkCross.TabIndex = 49;
            this.chkCross.Text = "Cross";
            this.chkCross.UseVisualStyleBackColor = true;
            this.chkCross.CheckedChanged += new System.EventHandler(this.chkCross_CheckedChanged);
            // 
            // chkDot
            // 
            this.chkDot.AutoSize = true;
            this.chkDot.Location = new System.Drawing.Point(66, 22);
            this.chkDot.Name = "chkDot";
            this.chkDot.Size = new System.Drawing.Size(43, 17);
            this.chkDot.TabIndex = 48;
            this.chkDot.Text = "Dot";
            this.chkDot.UseVisualStyleBackColor = true;
            this.chkDot.CheckedChanged += new System.EventHandler(this.chkDot_CheckedChanged);
            // 
            // grpSize
            // 
            this.grpSize.Controls.Add(this.lblOutlineValue);
            this.grpSize.Controls.Add(this.lblWidthValue);
            this.grpSize.Controls.Add(this.lblGapValue);
            this.grpSize.Controls.Add(this.lblSizeValue);
            this.grpSize.Controls.Add(this.lblOutline);
            this.grpSize.Controls.Add(this.crosshairOutline);
            this.grpSize.Controls.Add(this.lblWidth);
            this.grpSize.Controls.Add(this.crosshairWidth);
            this.grpSize.Controls.Add(this.lblGap);
            this.grpSize.Controls.Add(this.crosshairGap);
            this.grpSize.Controls.Add(this.lblSize);
            this.grpSize.Controls.Add(this.crosshairSize);
            this.grpSize.Location = new System.Drawing.Point(12, 135);
            this.grpSize.Name = "grpSize";
            this.grpSize.Size = new System.Drawing.Size(297, 229);
            this.grpSize.TabIndex = 34;
            this.grpSize.TabStop = false;
            this.grpSize.Text = "Size";
            // 
            // lblOutlineValue
            // 
            this.lblOutlineValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOutlineValue.AutoSize = true;
            this.lblOutlineValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutlineValue.Location = new System.Drawing.Point(264, 190);
            this.lblOutlineValue.Name = "lblOutlineValue";
            this.lblOutlineValue.Size = new System.Drawing.Size(22, 13);
            this.lblOutlineValue.TabIndex = 54;
            this.lblOutlineValue.Text = "0.0";
            this.lblOutlineValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWidthValue
            // 
            this.lblWidthValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWidthValue.AutoSize = true;
            this.lblWidthValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWidthValue.Location = new System.Drawing.Point(264, 139);
            this.lblWidthValue.Name = "lblWidthValue";
            this.lblWidthValue.Size = new System.Drawing.Size(22, 13);
            this.lblWidthValue.TabIndex = 53;
            this.lblWidthValue.Text = "0.0";
            this.lblWidthValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGapValue
            // 
            this.lblGapValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGapValue.AutoSize = true;
            this.lblGapValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGapValue.Location = new System.Drawing.Point(264, 88);
            this.lblGapValue.Name = "lblGapValue";
            this.lblGapValue.Size = new System.Drawing.Size(22, 13);
            this.lblGapValue.TabIndex = 52;
            this.lblGapValue.Text = "0.0";
            this.lblGapValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSizeValue
            // 
            this.lblSizeValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSizeValue.AutoSize = true;
            this.lblSizeValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSizeValue.Location = new System.Drawing.Point(264, 37);
            this.lblSizeValue.Name = "lblSizeValue";
            this.lblSizeValue.Size = new System.Drawing.Size(22, 13);
            this.lblSizeValue.TabIndex = 51;
            this.lblSizeValue.Text = "0.0";
            this.lblSizeValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOutline
            // 
            this.lblOutline.AutoSize = true;
            this.lblOutline.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutline.Location = new System.Drawing.Point(16, 190);
            this.lblOutline.Name = "lblOutline";
            this.lblOutline.Size = new System.Drawing.Size(40, 13);
            this.lblOutline.TabIndex = 50;
            this.lblOutline.Text = "Outline";
            this.lblOutline.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // crosshairOutline
            // 
            this.crosshairOutline.LargeChange = 1;
            this.crosshairOutline.Location = new System.Drawing.Point(59, 175);
            this.crosshairOutline.Name = "crosshairOutline";
            this.crosshairOutline.Size = new System.Drawing.Size(199, 45);
            this.crosshairOutline.TabIndex = 49;
            this.crosshairOutline.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.crosshairOutline.Scroll += new System.EventHandler(this.crosshairOutline_Scroll);
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWidth.Location = new System.Drawing.Point(16, 139);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(35, 13);
            this.lblWidth.TabIndex = 48;
            this.lblWidth.Text = "Width";
            this.lblWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // crosshairWidth
            // 
            this.crosshairWidth.LargeChange = 1;
            this.crosshairWidth.Location = new System.Drawing.Point(59, 124);
            this.crosshairWidth.Name = "crosshairWidth";
            this.crosshairWidth.Size = new System.Drawing.Size(199, 45);
            this.crosshairWidth.TabIndex = 47;
            this.crosshairWidth.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.crosshairWidth.Scroll += new System.EventHandler(this.crosshairWidth_Scroll);
            // 
            // lblGap
            // 
            this.lblGap.AutoSize = true;
            this.lblGap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGap.Location = new System.Drawing.Point(16, 88);
            this.lblGap.Name = "lblGap";
            this.lblGap.Size = new System.Drawing.Size(27, 13);
            this.lblGap.TabIndex = 46;
            this.lblGap.Text = "Gap";
            this.lblGap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // crosshairGap
            // 
            this.crosshairGap.Location = new System.Drawing.Point(59, 73);
            this.crosshairGap.Maximum = 50;
            this.crosshairGap.Name = "crosshairGap";
            this.crosshairGap.Size = new System.Drawing.Size(199, 45);
            this.crosshairGap.TabIndex = 45;
            this.crosshairGap.TickFrequency = 5;
            this.crosshairGap.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.crosshairGap.Scroll += new System.EventHandler(this.crosshairGap_Scroll);
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize.Location = new System.Drawing.Point(16, 37);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(27, 13);
            this.lblSize.TabIndex = 44;
            this.lblSize.Text = "Size";
            this.lblSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // crosshairSize
            // 
            this.crosshairSize.Location = new System.Drawing.Point(59, 22);
            this.crosshairSize.Maximum = 50;
            this.crosshairSize.Name = "crosshairSize";
            this.crosshairSize.Size = new System.Drawing.Size(199, 45);
            this.crosshairSize.TabIndex = 43;
            this.crosshairSize.TickFrequency = 5;
            this.crosshairSize.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.crosshairSize.Scroll += new System.EventHandler(this.crosshairSize_Scroll);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(320, 375);
            this.Controls.Add(this.grpSize);
            this.Controls.Add(this.grpShape);
            this.Controls.Add(this.grpColor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Crosshair Overlay";
            this.grpColor.ResumeLayout(false);
            this.grpShape.ResumeLayout(false);
            this.grpShape.PerformLayout();
            this.grpSize.ResumeLayout(false);
            this.grpSize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.crosshairOutline)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.crosshairWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.crosshairGap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.crosshairSize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.GroupBox grpColor;
        private System.Windows.Forms.Button btnOutlineColor;
        private System.Windows.Forms.Button btnClearOutlineColor;
        private System.Windows.Forms.Button btnFillColor;
        private System.Windows.Forms.Button btnClearFillColor;
        private System.Windows.Forms.GroupBox grpShape;
        private System.Windows.Forms.GroupBox grpSize;
        private System.Windows.Forms.CheckBox chkCross;
        private System.Windows.Forms.CheckBox chkDot;
        private System.Windows.Forms.Label lblOutlineValue;
        private System.Windows.Forms.Label lblWidthValue;
        private System.Windows.Forms.Label lblGapValue;
        private System.Windows.Forms.Label lblSizeValue;
        private System.Windows.Forms.Label lblOutline;
        private System.Windows.Forms.TrackBar crosshairOutline;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.TrackBar crosshairWidth;
        private System.Windows.Forms.Label lblGap;
        private System.Windows.Forms.TrackBar crosshairGap;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.TrackBar crosshairSize;
    }
}