
namespace ImageOperation
{
    partial class FormGeometricTransformationsOperation
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
            this.pictureBoxOriginal = new System.Windows.Forms.PictureBox();
            this.labelOriginal = new System.Windows.Forms.Label();
            this.labelResult = new System.Windows.Forms.Label();
            this.labelProcessingTime = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.groupBoxGeometricTransformations = new System.Windows.Forms.GroupBox();
            this.buttonReflectionY = new System.Windows.Forms.Button();
            this.buttonShearing = new System.Windows.Forms.Button();
            this.buttonReflectionX = new System.Windows.Forms.Button();
            this.buttonScaling = new System.Windows.Forms.Button();
            this.buttonRotation = new System.Windows.Forms.Button();
            this.buttonTranslation = new System.Windows.Forms.Button();
            this.menuStripGeometricTransformationsOperation = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveResultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pointAndAreaBasedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.geometricTransformationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frameBasedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBoxResult = new System.Windows.Forms.PictureBox();
            this.buttonMoveResultToOriginal = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginal)).BeginInit();
            this.groupBoxGeometricTransformations.SuspendLayout();
            this.menuStripGeometricTransformationsOperation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResult)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxOriginal
            // 
            this.pictureBoxOriginal.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBoxOriginal.Location = new System.Drawing.Point(91, 70);
            this.pictureBoxOriginal.Name = "pictureBoxOriginal";
            this.pictureBoxOriginal.Size = new System.Drawing.Size(300, 300);
            this.pictureBoxOriginal.TabIndex = 0;
            this.pictureBoxOriginal.TabStop = false;
            // 
            // labelOriginal
            // 
            this.labelOriginal.AutoSize = true;
            this.labelOriginal.Location = new System.Drawing.Point(218, 45);
            this.labelOriginal.Name = "labelOriginal";
            this.labelOriginal.Size = new System.Drawing.Size(42, 13);
            this.labelOriginal.TabIndex = 2;
            this.labelOriginal.Text = "Original";
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Location = new System.Drawing.Point(777, 45);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(37, 13);
            this.labelResult.TabIndex = 3;
            this.labelResult.Text = "Result";
            // 
            // labelProcessingTime
            // 
            this.labelProcessingTime.AutoSize = true;
            this.labelProcessingTime.Location = new System.Drawing.Point(475, 106);
            this.labelProcessingTime.Name = "labelProcessingTime";
            this.labelProcessingTime.Size = new System.Drawing.Size(85, 13);
            this.labelProcessingTime.TabIndex = 4;
            this.labelProcessingTime.Text = "Processing Time";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.ForeColor = System.Drawing.Color.Red;
            this.labelTime.Location = new System.Drawing.Point(475, 132);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(56, 13);
            this.labelTime.TabIndex = 5;
            this.labelTime.Text = "0 seconds";
            // 
            // groupBoxGeometricTransformations
            // 
            this.groupBoxGeometricTransformations.Controls.Add(this.buttonReflectionY);
            this.groupBoxGeometricTransformations.Controls.Add(this.buttonShearing);
            this.groupBoxGeometricTransformations.Controls.Add(this.buttonReflectionX);
            this.groupBoxGeometricTransformations.Controls.Add(this.buttonScaling);
            this.groupBoxGeometricTransformations.Controls.Add(this.buttonRotation);
            this.groupBoxGeometricTransformations.Controls.Add(this.buttonTranslation);
            this.groupBoxGeometricTransformations.Location = new System.Drawing.Point(396, 427);
            this.groupBoxGeometricTransformations.Name = "groupBoxGeometricTransformations";
            this.groupBoxGeometricTransformations.Size = new System.Drawing.Size(250, 99);
            this.groupBoxGeometricTransformations.TabIndex = 6;
            this.groupBoxGeometricTransformations.TabStop = false;
            this.groupBoxGeometricTransformations.Text = "Geometric Transformations";
            // 
            // buttonReflectionY
            // 
            this.buttonReflectionY.Location = new System.Drawing.Point(87, 57);
            this.buttonReflectionY.Name = "buttonReflectionY";
            this.buttonReflectionY.Size = new System.Drawing.Size(75, 23);
            this.buttonReflectionY.TabIndex = 12;
            this.buttonReflectionY.Text = "Reflection Y";
            this.buttonReflectionY.UseVisualStyleBackColor = true;
            this.buttonReflectionY.Click += new System.EventHandler(this.buttonReflectionY_Click);
            // 
            // buttonShearing
            // 
            this.buttonShearing.Location = new System.Drawing.Point(168, 57);
            this.buttonShearing.Name = "buttonShearing";
            this.buttonShearing.Size = new System.Drawing.Size(75, 23);
            this.buttonShearing.TabIndex = 11;
            this.buttonShearing.Text = "Shearing";
            this.buttonShearing.UseVisualStyleBackColor = true;
            this.buttonShearing.Click += new System.EventHandler(this.buttonShearing_Click);
            // 
            // buttonReflectionX
            // 
            this.buttonReflectionX.Location = new System.Drawing.Point(6, 57);
            this.buttonReflectionX.Name = "buttonReflectionX";
            this.buttonReflectionX.Size = new System.Drawing.Size(75, 23);
            this.buttonReflectionX.TabIndex = 10;
            this.buttonReflectionX.Text = "Reflection X";
            this.buttonReflectionX.UseVisualStyleBackColor = true;
            this.buttonReflectionX.Click += new System.EventHandler(this.buttonReflectionX_Click);
            // 
            // buttonScaling
            // 
            this.buttonScaling.Location = new System.Drawing.Point(168, 28);
            this.buttonScaling.Name = "buttonScaling";
            this.buttonScaling.Size = new System.Drawing.Size(75, 23);
            this.buttonScaling.TabIndex = 9;
            this.buttonScaling.Text = "Scaling";
            this.buttonScaling.UseVisualStyleBackColor = true;
            this.buttonScaling.Click += new System.EventHandler(this.buttonScaling_Click);
            // 
            // buttonRotation
            // 
            this.buttonRotation.Location = new System.Drawing.Point(87, 28);
            this.buttonRotation.Name = "buttonRotation";
            this.buttonRotation.Size = new System.Drawing.Size(75, 23);
            this.buttonRotation.TabIndex = 8;
            this.buttonRotation.Text = "Rotation";
            this.buttonRotation.UseVisualStyleBackColor = true;
            this.buttonRotation.Click += new System.EventHandler(this.buttonRotation_Click);
            // 
            // buttonTranslation
            // 
            this.buttonTranslation.Location = new System.Drawing.Point(6, 28);
            this.buttonTranslation.Name = "buttonTranslation";
            this.buttonTranslation.Size = new System.Drawing.Size(75, 23);
            this.buttonTranslation.TabIndex = 7;
            this.buttonTranslation.Text = "Translation";
            this.buttonTranslation.UseVisualStyleBackColor = true;
            this.buttonTranslation.Click += new System.EventHandler(this.buttonTranslation_Click);
            // 
            // menuStripGeometricTransformationsOperation
            // 
            this.menuStripGeometricTransformationsOperation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.operationToolStripMenuItem});
            this.menuStripGeometricTransformationsOperation.Location = new System.Drawing.Point(0, 0);
            this.menuStripGeometricTransformationsOperation.Name = "menuStripGeometricTransformationsOperation";
            this.menuStripGeometricTransformationsOperation.Size = new System.Drawing.Size(1014, 24);
            this.menuStripGeometricTransformationsOperation.TabIndex = 7;
            this.menuStripGeometricTransformationsOperation.Text = "Main Menu";
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
            this.pointAndAreaBasedToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.pointAndAreaBasedToolStripMenuItem.Text = "Point and Area Based";
            this.pointAndAreaBasedToolStripMenuItem.Click += new System.EventHandler(this.pointAndAreaBasedToolStripMenuItem_Click);
            // 
            // geometricTransformationsToolStripMenuItem
            // 
            this.geometricTransformationsToolStripMenuItem.Name = "geometricTransformationsToolStripMenuItem";
            this.geometricTransformationsToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.geometricTransformationsToolStripMenuItem.Text = "Geometric Transformations (Current)";
            // 
            // frameBasedToolStripMenuItem
            // 
            this.frameBasedToolStripMenuItem.Name = "frameBasedToolStripMenuItem";
            this.frameBasedToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.frameBasedToolStripMenuItem.Text = "Frame Based";
            this.frameBasedToolStripMenuItem.Click += new System.EventHandler(this.frameBasedToolStripMenuItem_Click);
            // 
            // pictureBoxResult
            // 
            this.pictureBoxResult.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBoxResult.Location = new System.Drawing.Point(651, 70);
            this.pictureBoxResult.Name = "pictureBoxResult";
            this.pictureBoxResult.Size = new System.Drawing.Size(300, 300);
            this.pictureBoxResult.TabIndex = 8;
            this.pictureBoxResult.TabStop = false;
            // 
            // buttonMoveResultToOriginal
            // 
            this.buttonMoveResultToOriginal.Location = new System.Drawing.Point(459, 326);
            this.buttonMoveResultToOriginal.Name = "buttonMoveResultToOriginal";
            this.buttonMoveResultToOriginal.Size = new System.Drawing.Size(131, 44);
            this.buttonMoveResultToOriginal.TabIndex = 22;
            this.buttonMoveResultToOriginal.Text = "Move Result to Original";
            this.buttonMoveResultToOriginal.UseVisualStyleBackColor = true;
            this.buttonMoveResultToOriginal.Click += new System.EventHandler(this.buttonMoveResultToOriginal_Click);
            // 
            // FormGeometricTransformationsOperation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1014, 605);
            this.Controls.Add(this.buttonMoveResultToOriginal);
            this.Controls.Add(this.pictureBoxResult);
            this.Controls.Add(this.groupBoxGeometricTransformations);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.labelProcessingTime);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.labelOriginal);
            this.Controls.Add(this.pictureBoxOriginal);
            this.Controls.Add(this.menuStripGeometricTransformationsOperation);
            this.MainMenuStrip = this.menuStripGeometricTransformationsOperation;
            this.Name = "FormGeometricTransformationsOperation";
            this.Text = "Geometric Transformations Operation";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginal)).EndInit();
            this.groupBoxGeometricTransformations.ResumeLayout(false);
            this.menuStripGeometricTransformationsOperation.ResumeLayout(false);
            this.menuStripGeometricTransformationsOperation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxOriginal;
        private System.Windows.Forms.Label labelOriginal;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.Label labelProcessingTime;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.GroupBox groupBoxGeometricTransformations;
        private System.Windows.Forms.Button buttonShearing;
        private System.Windows.Forms.Button buttonReflectionX;
        private System.Windows.Forms.Button buttonScaling;
        private System.Windows.Forms.Button buttonRotation;
        private System.Windows.Forms.Button buttonTranslation;
        private System.Windows.Forms.MenuStrip menuStripGeometricTransformationsOperation;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveResultToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem operationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pointAndAreaBasedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem geometricTransformationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem frameBasedToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBoxResult;
        private System.Windows.Forms.Button buttonReflectionY;
        private System.Windows.Forms.Button buttonMoveResultToOriginal;
    }
}