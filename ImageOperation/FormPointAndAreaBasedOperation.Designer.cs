
namespace ImageOperation
{
    partial class FormPointAndAreaBasedOperation
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
            this.menuPointAndAreaBasedOperation = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveResultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pointAndAreaBasedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.geometricTransformationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frameBasedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBoxOriginal = new System.Windows.Forms.PictureBox();
            this.pictureBoxResult = new System.Windows.Forms.PictureBox();
            this.labelOriginal = new System.Windows.Forms.Label();
            this.labelResult = new System.Windows.Forms.Label();
            this.buttonBrightness = new System.Windows.Forms.Button();
            this.buttonInvert = new System.Windows.Forms.Button();
            this.buttonGrayscaleAverage = new System.Windows.Forms.Button();
            this.buttonGrayscaleWeight = new System.Windows.Forms.Button();
            this.buttonThreshold = new System.Windows.Forms.Button();
            this.groupBoxPointBasedOperation = new System.Windows.Forms.GroupBox();
            this.buttonBlurring = new System.Windows.Forms.Button();
            this.buttonSharpening = new System.Windows.Forms.Button();
            this.buttonEmbossing = new System.Windows.Forms.Button();
            this.buttonEdging = new System.Windows.Forms.Button();
            this.buttonMedianFiltering = new System.Windows.Forms.Button();
            this.buttonMinimumFiltering = new System.Windows.Forms.Button();
            this.buttonMaximumFiltering = new System.Windows.Forms.Button();
            this.buttonDilation = new System.Windows.Forms.Button();
            this.groupBoxAreaBasedOperation = new System.Windows.Forms.GroupBox();
            this.buttonErosion = new System.Windows.Forms.Button();
            this.labelProcessingTime = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.buttonMoveResultToOriginal = new System.Windows.Forms.Button();
            this.menuPointAndAreaBasedOperation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResult)).BeginInit();
            this.groupBoxPointBasedOperation.SuspendLayout();
            this.groupBoxAreaBasedOperation.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuPointAndAreaBasedOperation
            // 
            this.menuPointAndAreaBasedOperation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.operationToolStripMenuItem});
            this.menuPointAndAreaBasedOperation.Location = new System.Drawing.Point(0, 0);
            this.menuPointAndAreaBasedOperation.Name = "menuPointAndAreaBasedOperation";
            this.menuPointAndAreaBasedOperation.Size = new System.Drawing.Size(1014, 24);
            this.menuPointAndAreaBasedOperation.TabIndex = 0;
            this.menuPointAndAreaBasedOperation.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveResultToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveResultToolStripMenuItem
            // 
            this.saveResultToolStripMenuItem.Name = "saveResultToolStripMenuItem";
            this.saveResultToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveResultToolStripMenuItem.Text = "Save Result";
            this.saveResultToolStripMenuItem.Click += new System.EventHandler(this.saveResultToolStripMenuItem_Click);
            // 
            // operationToolStripMenuItem
            // 
            this.operationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pointAndAreaBasedToolStripMenuItem,
            this.geometricTransformationsToolStripMenuItem,
            this.frameBasedToolStripMenuItem});
            this.operationToolStripMenuItem.Name = "operationToolStripMenuItem";
            this.operationToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.operationToolStripMenuItem.Text = "Operation";
            // 
            // pointAndAreaBasedToolStripMenuItem
            // 
            this.pointAndAreaBasedToolStripMenuItem.Name = "pointAndAreaBasedToolStripMenuItem";
            this.pointAndAreaBasedToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.pointAndAreaBasedToolStripMenuItem.Text = "Point and Area Based (Current)";
            // 
            // geometricTransformationsToolStripMenuItem
            // 
            this.geometricTransformationsToolStripMenuItem.Name = "geometricTransformationsToolStripMenuItem";
            this.geometricTransformationsToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.geometricTransformationsToolStripMenuItem.Text = "Geometric Transformations";
            this.geometricTransformationsToolStripMenuItem.Click += new System.EventHandler(this.geometricTransformationsToolStripMenuItem_Click);
            // 
            // frameBasedToolStripMenuItem
            // 
            this.frameBasedToolStripMenuItem.Name = "frameBasedToolStripMenuItem";
            this.frameBasedToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.frameBasedToolStripMenuItem.Text = "Frame Based";
            this.frameBasedToolStripMenuItem.Click += new System.EventHandler(this.frameBasedToolStripMenuItem_Click);
            // 
            // pictureBoxOriginal
            // 
            this.pictureBoxOriginal.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBoxOriginal.Location = new System.Drawing.Point(77, 55);
            this.pictureBoxOriginal.Name = "pictureBoxOriginal";
            this.pictureBoxOriginal.Size = new System.Drawing.Size(300, 300);
            this.pictureBoxOriginal.TabIndex = 1;
            this.pictureBoxOriginal.TabStop = false;
            // 
            // pictureBoxResult
            // 
            this.pictureBoxResult.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBoxResult.Location = new System.Drawing.Point(632, 55);
            this.pictureBoxResult.Name = "pictureBoxResult";
            this.pictureBoxResult.Size = new System.Drawing.Size(300, 300);
            this.pictureBoxResult.TabIndex = 2;
            this.pictureBoxResult.TabStop = false;
            // 
            // labelOriginal
            // 
            this.labelOriginal.AutoSize = true;
            this.labelOriginal.Location = new System.Drawing.Point(203, 39);
            this.labelOriginal.Name = "labelOriginal";
            this.labelOriginal.Size = new System.Drawing.Size(42, 13);
            this.labelOriginal.TabIndex = 3;
            this.labelOriginal.Text = "Original";
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Location = new System.Drawing.Point(773, 39);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(37, 13);
            this.labelResult.TabIndex = 4;
            this.labelResult.Text = "Result";
            // 
            // buttonBrightness
            // 
            this.buttonBrightness.Location = new System.Drawing.Point(48, 19);
            this.buttonBrightness.Name = "buttonBrightness";
            this.buttonBrightness.Size = new System.Drawing.Size(75, 34);
            this.buttonBrightness.TabIndex = 5;
            this.buttonBrightness.Text = "Brightness";
            this.buttonBrightness.UseVisualStyleBackColor = true;
            this.buttonBrightness.Click += new System.EventHandler(this.buttonBrightness_Click);
            // 
            // buttonInvert
            // 
            this.buttonInvert.Location = new System.Drawing.Point(87, 109);
            this.buttonInvert.Name = "buttonInvert";
            this.buttonInvert.Size = new System.Drawing.Size(75, 34);
            this.buttonInvert.TabIndex = 6;
            this.buttonInvert.Text = "Invert";
            this.buttonInvert.UseVisualStyleBackColor = true;
            this.buttonInvert.Click += new System.EventHandler(this.buttonInvert_Click);
            // 
            // buttonGrayscaleAverage
            // 
            this.buttonGrayscaleAverage.Location = new System.Drawing.Point(6, 59);
            this.buttonGrayscaleAverage.Name = "buttonGrayscaleAverage";
            this.buttonGrayscaleAverage.Size = new System.Drawing.Size(75, 34);
            this.buttonGrayscaleAverage.TabIndex = 7;
            this.buttonGrayscaleAverage.Text = "Grayscale (Average)";
            this.buttonGrayscaleAverage.UseVisualStyleBackColor = true;
            this.buttonGrayscaleAverage.Click += new System.EventHandler(this.buttonGrayscaleAverage_Click);
            // 
            // buttonGrayscaleWeight
            // 
            this.buttonGrayscaleWeight.Location = new System.Drawing.Point(87, 59);
            this.buttonGrayscaleWeight.Name = "buttonGrayscaleWeight";
            this.buttonGrayscaleWeight.Size = new System.Drawing.Size(75, 34);
            this.buttonGrayscaleWeight.TabIndex = 8;
            this.buttonGrayscaleWeight.Text = "Grayscale (Weight)";
            this.buttonGrayscaleWeight.UseVisualStyleBackColor = true;
            this.buttonGrayscaleWeight.Click += new System.EventHandler(this.buttonGrayscaleWeight_Click);
            // 
            // buttonThreshold
            // 
            this.buttonThreshold.Location = new System.Drawing.Point(6, 109);
            this.buttonThreshold.Name = "buttonThreshold";
            this.buttonThreshold.Size = new System.Drawing.Size(75, 34);
            this.buttonThreshold.TabIndex = 9;
            this.buttonThreshold.Text = "Threshold (Binary)";
            this.buttonThreshold.UseVisualStyleBackColor = true;
            this.buttonThreshold.Click += new System.EventHandler(this.buttonThreshold_Click);
            // 
            // groupBoxPointBasedOperation
            // 
            this.groupBoxPointBasedOperation.Controls.Add(this.buttonBrightness);
            this.groupBoxPointBasedOperation.Controls.Add(this.buttonInvert);
            this.groupBoxPointBasedOperation.Controls.Add(this.buttonGrayscaleWeight);
            this.groupBoxPointBasedOperation.Controls.Add(this.buttonThreshold);
            this.groupBoxPointBasedOperation.Controls.Add(this.buttonGrayscaleAverage);
            this.groupBoxPointBasedOperation.Location = new System.Drawing.Point(141, 375);
            this.groupBoxPointBasedOperation.Name = "groupBoxPointBasedOperation";
            this.groupBoxPointBasedOperation.Size = new System.Drawing.Size(169, 160);
            this.groupBoxPointBasedOperation.TabIndex = 10;
            this.groupBoxPointBasedOperation.TabStop = false;
            this.groupBoxPointBasedOperation.Text = "Point Based Operation";
            // 
            // buttonBlurring
            // 
            this.buttonBlurring.Location = new System.Drawing.Point(6, 19);
            this.buttonBlurring.Name = "buttonBlurring";
            this.buttonBlurring.Size = new System.Drawing.Size(84, 34);
            this.buttonBlurring.TabIndex = 10;
            this.buttonBlurring.Text = "Blurring";
            this.buttonBlurring.UseVisualStyleBackColor = true;
            this.buttonBlurring.Click += new System.EventHandler(this.buttonBlurring_Click);
            // 
            // buttonSharpening
            // 
            this.buttonSharpening.Location = new System.Drawing.Point(111, 19);
            this.buttonSharpening.Name = "buttonSharpening";
            this.buttonSharpening.Size = new System.Drawing.Size(84, 34);
            this.buttonSharpening.TabIndex = 11;
            this.buttonSharpening.Text = "Sharpening";
            this.buttonSharpening.UseVisualStyleBackColor = true;
            this.buttonSharpening.Click += new System.EventHandler(this.buttonSharpening_Click);
            // 
            // buttonEmbossing
            // 
            this.buttonEmbossing.Location = new System.Drawing.Point(6, 59);
            this.buttonEmbossing.Name = "buttonEmbossing";
            this.buttonEmbossing.Size = new System.Drawing.Size(84, 34);
            this.buttonEmbossing.TabIndex = 12;
            this.buttonEmbossing.Text = "Embossing";
            this.buttonEmbossing.UseVisualStyleBackColor = true;
            this.buttonEmbossing.Click += new System.EventHandler(this.buttonEmbossing_Click);
            // 
            // buttonEdging
            // 
            this.buttonEdging.Location = new System.Drawing.Point(210, 19);
            this.buttonEdging.Name = "buttonEdging";
            this.buttonEdging.Size = new System.Drawing.Size(84, 34);
            this.buttonEdging.TabIndex = 13;
            this.buttonEdging.Text = "Edging";
            this.buttonEdging.UseVisualStyleBackColor = true;
            this.buttonEdging.Click += new System.EventHandler(this.buttonEdging_Click);
            // 
            // buttonMedianFiltering
            // 
            this.buttonMedianFiltering.Location = new System.Drawing.Point(210, 59);
            this.buttonMedianFiltering.Name = "buttonMedianFiltering";
            this.buttonMedianFiltering.Size = new System.Drawing.Size(84, 34);
            this.buttonMedianFiltering.TabIndex = 14;
            this.buttonMedianFiltering.Text = "Median Filtering";
            this.buttonMedianFiltering.UseVisualStyleBackColor = true;
            this.buttonMedianFiltering.Click += new System.EventHandler(this.buttonMedianFiltering_Click);
            // 
            // buttonMinimumFiltering
            // 
            this.buttonMinimumFiltering.Location = new System.Drawing.Point(111, 59);
            this.buttonMinimumFiltering.Name = "buttonMinimumFiltering";
            this.buttonMinimumFiltering.Size = new System.Drawing.Size(84, 34);
            this.buttonMinimumFiltering.TabIndex = 15;
            this.buttonMinimumFiltering.Text = "Minimum Filtering";
            this.buttonMinimumFiltering.UseVisualStyleBackColor = true;
            this.buttonMinimumFiltering.Click += new System.EventHandler(this.buttonMinimumFiltering_Click);
            // 
            // buttonMaximumFiltering
            // 
            this.buttonMaximumFiltering.Location = new System.Drawing.Point(6, 99);
            this.buttonMaximumFiltering.Name = "buttonMaximumFiltering";
            this.buttonMaximumFiltering.Size = new System.Drawing.Size(84, 34);
            this.buttonMaximumFiltering.TabIndex = 16;
            this.buttonMaximumFiltering.Text = "Maximum Filtering";
            this.buttonMaximumFiltering.UseVisualStyleBackColor = true;
            this.buttonMaximumFiltering.Click += new System.EventHandler(this.buttonMaximumFiltering_Click);
            // 
            // buttonDilation
            // 
            this.buttonDilation.Location = new System.Drawing.Point(111, 99);
            this.buttonDilation.Name = "buttonDilation";
            this.buttonDilation.Size = new System.Drawing.Size(84, 34);
            this.buttonDilation.TabIndex = 17;
            this.buttonDilation.Text = "Dilation";
            this.buttonDilation.UseVisualStyleBackColor = true;
            this.buttonDilation.Click += new System.EventHandler(this.buttonDilation_Click);
            // 
            // groupBoxAreaBasedOperation
            // 
            this.groupBoxAreaBasedOperation.Controls.Add(this.buttonErosion);
            this.groupBoxAreaBasedOperation.Controls.Add(this.buttonSharpening);
            this.groupBoxAreaBasedOperation.Controls.Add(this.buttonDilation);
            this.groupBoxAreaBasedOperation.Controls.Add(this.buttonBlurring);
            this.groupBoxAreaBasedOperation.Controls.Add(this.buttonEmbossing);
            this.groupBoxAreaBasedOperation.Controls.Add(this.buttonMaximumFiltering);
            this.groupBoxAreaBasedOperation.Controls.Add(this.buttonEdging);
            this.groupBoxAreaBasedOperation.Controls.Add(this.buttonMedianFiltering);
            this.groupBoxAreaBasedOperation.Controls.Add(this.buttonMinimumFiltering);
            this.groupBoxAreaBasedOperation.Location = new System.Drawing.Point(632, 375);
            this.groupBoxAreaBasedOperation.Name = "groupBoxAreaBasedOperation";
            this.groupBoxAreaBasedOperation.Size = new System.Drawing.Size(300, 143);
            this.groupBoxAreaBasedOperation.TabIndex = 18;
            this.groupBoxAreaBasedOperation.TabStop = false;
            this.groupBoxAreaBasedOperation.Text = "Area Based Operation";
            // 
            // buttonErosion
            // 
            this.buttonErosion.Location = new System.Drawing.Point(210, 99);
            this.buttonErosion.Name = "buttonErosion";
            this.buttonErosion.Size = new System.Drawing.Size(84, 34);
            this.buttonErosion.TabIndex = 18;
            this.buttonErosion.Text = "Erosion";
            this.buttonErosion.UseVisualStyleBackColor = true;
            this.buttonErosion.Click += new System.EventHandler(this.buttonErosion_Click);
            // 
            // labelProcessingTime
            // 
            this.labelProcessingTime.AutoSize = true;
            this.labelProcessingTime.Location = new System.Drawing.Point(455, 133);
            this.labelProcessingTime.Name = "labelProcessingTime";
            this.labelProcessingTime.Size = new System.Drawing.Size(85, 13);
            this.labelProcessingTime.TabIndex = 19;
            this.labelProcessingTime.Text = "Processing Time";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.ForeColor = System.Drawing.Color.Red;
            this.labelTime.Location = new System.Drawing.Point(455, 157);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(56, 13);
            this.labelTime.TabIndex = 20;
            this.labelTime.Text = "0 seconds";
            // 
            // buttonMoveResultToOriginal
            // 
            this.buttonMoveResultToOriginal.Location = new System.Drawing.Point(435, 311);
            this.buttonMoveResultToOriginal.Name = "buttonMoveResultToOriginal";
            this.buttonMoveResultToOriginal.Size = new System.Drawing.Size(131, 44);
            this.buttonMoveResultToOriginal.TabIndex = 21;
            this.buttonMoveResultToOriginal.Text = "Move Result to Original";
            this.buttonMoveResultToOriginal.UseVisualStyleBackColor = true;
            this.buttonMoveResultToOriginal.Click += new System.EventHandler(this.buttonMoveResultToOriginal_Click);
            // 
            // FormPointAndAreaBasedOperation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1014, 605);
            this.Controls.Add(this.buttonMoveResultToOriginal);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.labelProcessingTime);
            this.Controls.Add(this.groupBoxAreaBasedOperation);
            this.Controls.Add(this.groupBoxPointBasedOperation);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.labelOriginal);
            this.Controls.Add(this.pictureBoxResult);
            this.Controls.Add(this.pictureBoxOriginal);
            this.Controls.Add(this.menuPointAndAreaBasedOperation);
            this.MainMenuStrip = this.menuPointAndAreaBasedOperation;
            this.Name = "FormPointAndAreaBasedOperation";
            this.Text = "Point and Area Based Operation";
            this.menuPointAndAreaBasedOperation.ResumeLayout(false);
            this.menuPointAndAreaBasedOperation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResult)).EndInit();
            this.groupBoxPointBasedOperation.ResumeLayout(false);
            this.groupBoxAreaBasedOperation.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuPointAndAreaBasedOperation;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveResultToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem operationToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBoxOriginal;
        private System.Windows.Forms.PictureBox pictureBoxResult;
        private System.Windows.Forms.Label labelOriginal;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.ToolStripMenuItem pointAndAreaBasedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem geometricTransformationsToolStripMenuItem;
        private System.Windows.Forms.Button buttonBrightness;
        private System.Windows.Forms.Button buttonInvert;
        private System.Windows.Forms.Button buttonGrayscaleAverage;
        private System.Windows.Forms.Button buttonGrayscaleWeight;
        private System.Windows.Forms.Button buttonThreshold;
        private System.Windows.Forms.GroupBox groupBoxPointBasedOperation;
        private System.Windows.Forms.Button buttonBlurring;
        private System.Windows.Forms.Button buttonSharpening;
        private System.Windows.Forms.Button buttonEmbossing;
        private System.Windows.Forms.Button buttonEdging;
        private System.Windows.Forms.Button buttonMedianFiltering;
        private System.Windows.Forms.Button buttonMinimumFiltering;
        private System.Windows.Forms.Button buttonMaximumFiltering;
        private System.Windows.Forms.Button buttonDilation;
        private System.Windows.Forms.GroupBox groupBoxAreaBasedOperation;
        private System.Windows.Forms.Label labelProcessingTime;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Button buttonErosion;
        private System.Windows.Forms.ToolStripMenuItem frameBasedToolStripMenuItem;
        private System.Windows.Forms.Button buttonMoveResultToOriginal;
    }
}

