
namespace ImageOperation
{
    partial class FormFrameBasedOperation
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
            this.menuFrameBasedOperation = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFirstImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openSecondImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveResultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pointAndAreaBasedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.geometricTransformationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frameBasedCurrentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBoxOriginal1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxResult = new System.Windows.Forms.PictureBox();
            this.pictureBoxOriginal2 = new System.Windows.Forms.PictureBox();
            this.labelOriginal1 = new System.Windows.Forms.Label();
            this.labelOriginal2 = new System.Windows.Forms.Label();
            this.labelResult = new System.Windows.Forms.Label();
            this.comboBoxMode = new System.Windows.Forms.ComboBox();
            this.groupBoxFrameBasedOperation = new System.Windows.Forms.GroupBox();
            this.buttonXOR = new System.Windows.Forms.Button();
            this.buttonOR = new System.Windows.Forms.Button();
            this.buttonAND = new System.Windows.Forms.Button();
            this.buttonAmplitude = new System.Windows.Forms.Button();
            this.buttonCrossFading = new System.Windows.Forms.Button();
            this.buttonMax = new System.Windows.Forms.Button();
            this.buttonMin = new System.Windows.Forms.Button();
            this.buttonAverage = new System.Windows.Forms.Button();
            this.buttonMultiply = new System.Windows.Forms.Button();
            this.buttonDifference = new System.Windows.Forms.Button();
            this.buttonSubstract = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.labelSelectMode = new System.Windows.Forms.Label();
            this.labelProcessingTime = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.menuFrameBasedOperation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginal1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginal2)).BeginInit();
            this.groupBoxFrameBasedOperation.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuFrameBasedOperation
            // 
            this.menuFrameBasedOperation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.operationToolStripMenuItem});
            this.menuFrameBasedOperation.Location = new System.Drawing.Point(0, 0);
            this.menuFrameBasedOperation.Name = "menuFrameBasedOperation";
            this.menuFrameBasedOperation.Size = new System.Drawing.Size(1014, 24);
            this.menuFrameBasedOperation.TabIndex = 0;
            this.menuFrameBasedOperation.Text = "Main Menu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFirstImageToolStripMenuItem,
            this.openSecondImageToolStripMenuItem,
            this.saveResultToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openFirstImageToolStripMenuItem
            // 
            this.openFirstImageToolStripMenuItem.Name = "openFirstImageToolStripMenuItem";
            this.openFirstImageToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.openFirstImageToolStripMenuItem.Text = "Open First Image";
            this.openFirstImageToolStripMenuItem.Click += new System.EventHandler(this.openFirstImageToolStripMenuItem_Click);
            // 
            // openSecondImageToolStripMenuItem
            // 
            this.openSecondImageToolStripMenuItem.Name = "openSecondImageToolStripMenuItem";
            this.openSecondImageToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.openSecondImageToolStripMenuItem.Text = "Open Second Image";
            this.openSecondImageToolStripMenuItem.Click += new System.EventHandler(this.openSecondImageToolStripMenuItem_Click);
            // 
            // saveResultToolStripMenuItem
            // 
            this.saveResultToolStripMenuItem.Name = "saveResultToolStripMenuItem";
            this.saveResultToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.saveResultToolStripMenuItem.Text = "Save Result";
            this.saveResultToolStripMenuItem.Click += new System.EventHandler(this.saveResultToolStripMenuItem_Click);
            // 
            // operationToolStripMenuItem
            // 
            this.operationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pointAndAreaBasedToolStripMenuItem,
            this.geometricTransformationsToolStripMenuItem,
            this.frameBasedCurrentToolStripMenuItem});
            this.operationToolStripMenuItem.Name = "operationToolStripMenuItem";
            this.operationToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.operationToolStripMenuItem.Text = "Operation";
            // 
            // pointAndAreaBasedToolStripMenuItem
            // 
            this.pointAndAreaBasedToolStripMenuItem.Name = "pointAndAreaBasedToolStripMenuItem";
            this.pointAndAreaBasedToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.pointAndAreaBasedToolStripMenuItem.Text = "Point and Area Based";
            this.pointAndAreaBasedToolStripMenuItem.Click += new System.EventHandler(this.pointAndAreaBasedToolStripMenuItem_Click);
            // 
            // geometricTransformationsToolStripMenuItem
            // 
            this.geometricTransformationsToolStripMenuItem.Name = "geometricTransformationsToolStripMenuItem";
            this.geometricTransformationsToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.geometricTransformationsToolStripMenuItem.Text = "Geometric Transformations";
            this.geometricTransformationsToolStripMenuItem.Click += new System.EventHandler(this.geometricTransformationsToolStripMenuItem_Click);
            // 
            // frameBasedCurrentToolStripMenuItem
            // 
            this.frameBasedCurrentToolStripMenuItem.Name = "frameBasedCurrentToolStripMenuItem";
            this.frameBasedCurrentToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.frameBasedCurrentToolStripMenuItem.Text = "Frame Based (Current)";
            // 
            // pictureBoxOriginal1
            // 
            this.pictureBoxOriginal1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBoxOriginal1.Location = new System.Drawing.Point(21, 78);
            this.pictureBoxOriginal1.Name = "pictureBoxOriginal1";
            this.pictureBoxOriginal1.Size = new System.Drawing.Size(250, 250);
            this.pictureBoxOriginal1.TabIndex = 1;
            this.pictureBoxOriginal1.TabStop = false;
            // 
            // pictureBoxResult
            // 
            this.pictureBoxResult.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBoxResult.Location = new System.Drawing.Point(752, 78);
            this.pictureBoxResult.Name = "pictureBoxResult";
            this.pictureBoxResult.Size = new System.Drawing.Size(250, 250);
            this.pictureBoxResult.TabIndex = 2;
            this.pictureBoxResult.TabStop = false;
            // 
            // pictureBoxOriginal2
            // 
            this.pictureBoxOriginal2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBoxOriginal2.Location = new System.Drawing.Point(327, 78);
            this.pictureBoxOriginal2.Name = "pictureBoxOriginal2";
            this.pictureBoxOriginal2.Size = new System.Drawing.Size(250, 250);
            this.pictureBoxOriginal2.TabIndex = 3;
            this.pictureBoxOriginal2.TabStop = false;
            // 
            // labelOriginal1
            // 
            this.labelOriginal1.AutoSize = true;
            this.labelOriginal1.Location = new System.Drawing.Point(111, 62);
            this.labelOriginal1.Name = "labelOriginal1";
            this.labelOriginal1.Size = new System.Drawing.Size(58, 13);
            this.labelOriginal1.TabIndex = 4;
            this.labelOriginal1.Text = "First Image";
            // 
            // labelOriginal2
            // 
            this.labelOriginal2.AutoSize = true;
            this.labelOriginal2.Location = new System.Drawing.Point(415, 62);
            this.labelOriginal2.Name = "labelOriginal2";
            this.labelOriginal2.Size = new System.Drawing.Size(76, 13);
            this.labelOriginal2.TabIndex = 5;
            this.labelOriginal2.Text = "Second Image";
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Location = new System.Drawing.Point(866, 62);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(37, 13);
            this.labelResult.TabIndex = 6;
            this.labelResult.Text = "Result";
            // 
            // comboBoxMode
            // 
            this.comboBoxMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMode.FormattingEnabled = true;
            this.comboBoxMode.Items.AddRange(new object[] {
            "Pointer",
            "GDI+"});
            this.comboBoxMode.Location = new System.Drawing.Point(242, 396);
            this.comboBoxMode.Name = "comboBoxMode";
            this.comboBoxMode.Size = new System.Drawing.Size(121, 21);
            this.comboBoxMode.TabIndex = 7;
            // 
            // groupBoxFrameBasedOperation
            // 
            this.groupBoxFrameBasedOperation.Controls.Add(this.buttonXOR);
            this.groupBoxFrameBasedOperation.Controls.Add(this.buttonOR);
            this.groupBoxFrameBasedOperation.Controls.Add(this.buttonAND);
            this.groupBoxFrameBasedOperation.Controls.Add(this.buttonAmplitude);
            this.groupBoxFrameBasedOperation.Controls.Add(this.buttonCrossFading);
            this.groupBoxFrameBasedOperation.Controls.Add(this.buttonMax);
            this.groupBoxFrameBasedOperation.Controls.Add(this.buttonMin);
            this.groupBoxFrameBasedOperation.Controls.Add(this.buttonAverage);
            this.groupBoxFrameBasedOperation.Controls.Add(this.buttonMultiply);
            this.groupBoxFrameBasedOperation.Controls.Add(this.buttonDifference);
            this.groupBoxFrameBasedOperation.Controls.Add(this.buttonSubstract);
            this.groupBoxFrameBasedOperation.Controls.Add(this.buttonAdd);
            this.groupBoxFrameBasedOperation.Location = new System.Drawing.Point(114, 423);
            this.groupBoxFrameBasedOperation.Name = "groupBoxFrameBasedOperation";
            this.groupBoxFrameBasedOperation.Size = new System.Drawing.Size(363, 148);
            this.groupBoxFrameBasedOperation.TabIndex = 8;
            this.groupBoxFrameBasedOperation.TabStop = false;
            this.groupBoxFrameBasedOperation.Text = "Frame Based Operation";
            // 
            // buttonXOR
            // 
            this.buttonXOR.Location = new System.Drawing.Point(278, 109);
            this.buttonXOR.Name = "buttonXOR";
            this.buttonXOR.Size = new System.Drawing.Size(75, 23);
            this.buttonXOR.TabIndex = 10;
            this.buttonXOR.Text = "XOR";
            this.buttonXOR.UseVisualStyleBackColor = true;
            this.buttonXOR.Click += new System.EventHandler(this.buttonXOR_Click);
            // 
            // buttonOR
            // 
            this.buttonOR.Location = new System.Drawing.Point(187, 109);
            this.buttonOR.Name = "buttonOR";
            this.buttonOR.Size = new System.Drawing.Size(75, 23);
            this.buttonOR.TabIndex = 10;
            this.buttonOR.Text = "OR";
            this.buttonOR.UseVisualStyleBackColor = true;
            this.buttonOR.Click += new System.EventHandler(this.buttonOR_Click);
            // 
            // buttonAND
            // 
            this.buttonAND.Location = new System.Drawing.Point(96, 109);
            this.buttonAND.Name = "buttonAND";
            this.buttonAND.Size = new System.Drawing.Size(75, 23);
            this.buttonAND.TabIndex = 10;
            this.buttonAND.Text = "AND";
            this.buttonAND.UseVisualStyleBackColor = true;
            this.buttonAND.Click += new System.EventHandler(this.buttonAND_Click);
            // 
            // buttonAmplitude
            // 
            this.buttonAmplitude.Location = new System.Drawing.Point(6, 109);
            this.buttonAmplitude.Name = "buttonAmplitude";
            this.buttonAmplitude.Size = new System.Drawing.Size(75, 23);
            this.buttonAmplitude.TabIndex = 10;
            this.buttonAmplitude.Text = "Amplitude";
            this.buttonAmplitude.UseVisualStyleBackColor = true;
            this.buttonAmplitude.Click += new System.EventHandler(this.buttonAmplitude_Click);
            // 
            // buttonCrossFading
            // 
            this.buttonCrossFading.Location = new System.Drawing.Point(278, 57);
            this.buttonCrossFading.Name = "buttonCrossFading";
            this.buttonCrossFading.Size = new System.Drawing.Size(75, 39);
            this.buttonCrossFading.TabIndex = 10;
            this.buttonCrossFading.Text = "Cross Fading";
            this.buttonCrossFading.UseVisualStyleBackColor = true;
            this.buttonCrossFading.Click += new System.EventHandler(this.buttonCrossFading_Click);
            // 
            // buttonMax
            // 
            this.buttonMax.Location = new System.Drawing.Point(187, 65);
            this.buttonMax.Name = "buttonMax";
            this.buttonMax.Size = new System.Drawing.Size(75, 23);
            this.buttonMax.TabIndex = 10;
            this.buttonMax.Text = "Max";
            this.buttonMax.UseVisualStyleBackColor = true;
            this.buttonMax.Click += new System.EventHandler(this.buttonMax_Click);
            // 
            // buttonMin
            // 
            this.buttonMin.Location = new System.Drawing.Point(96, 65);
            this.buttonMin.Name = "buttonMin";
            this.buttonMin.Size = new System.Drawing.Size(75, 23);
            this.buttonMin.TabIndex = 10;
            this.buttonMin.Text = "Min";
            this.buttonMin.UseVisualStyleBackColor = true;
            this.buttonMin.Click += new System.EventHandler(this.buttonMin_Click);
            // 
            // buttonAverage
            // 
            this.buttonAverage.Location = new System.Drawing.Point(6, 65);
            this.buttonAverage.Name = "buttonAverage";
            this.buttonAverage.Size = new System.Drawing.Size(75, 23);
            this.buttonAverage.TabIndex = 10;
            this.buttonAverage.Text = "Average";
            this.buttonAverage.UseVisualStyleBackColor = true;
            this.buttonAverage.Click += new System.EventHandler(this.buttonAverage_Click);
            // 
            // buttonMultiply
            // 
            this.buttonMultiply.Location = new System.Drawing.Point(278, 19);
            this.buttonMultiply.Name = "buttonMultiply";
            this.buttonMultiply.Size = new System.Drawing.Size(75, 23);
            this.buttonMultiply.TabIndex = 10;
            this.buttonMultiply.Text = "Multiply";
            this.buttonMultiply.UseVisualStyleBackColor = true;
            this.buttonMultiply.Click += new System.EventHandler(this.buttonMultiply_Click);
            // 
            // buttonDifference
            // 
            this.buttonDifference.Location = new System.Drawing.Point(187, 19);
            this.buttonDifference.Name = "buttonDifference";
            this.buttonDifference.Size = new System.Drawing.Size(75, 23);
            this.buttonDifference.TabIndex = 10;
            this.buttonDifference.Text = "Difference";
            this.buttonDifference.UseVisualStyleBackColor = true;
            this.buttonDifference.Click += new System.EventHandler(this.buttonDifference_Click);
            // 
            // buttonSubstract
            // 
            this.buttonSubstract.Location = new System.Drawing.Point(96, 19);
            this.buttonSubstract.Name = "buttonSubstract";
            this.buttonSubstract.Size = new System.Drawing.Size(75, 23);
            this.buttonSubstract.TabIndex = 10;
            this.buttonSubstract.Text = "Substract";
            this.buttonSubstract.UseVisualStyleBackColor = true;
            this.buttonSubstract.Click += new System.EventHandler(this.buttonSubstract_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(6, 19);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 9;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // labelSelectMode
            // 
            this.labelSelectMode.AutoSize = true;
            this.labelSelectMode.Location = new System.Drawing.Point(270, 380);
            this.labelSelectMode.Name = "labelSelectMode";
            this.labelSelectMode.Size = new System.Drawing.Size(67, 13);
            this.labelSelectMode.TabIndex = 9;
            this.labelSelectMode.Text = "Select Mode";
            // 
            // labelProcessingTime
            // 
            this.labelProcessingTime.AutoSize = true;
            this.labelProcessingTime.Location = new System.Drawing.Point(618, 127);
            this.labelProcessingTime.Name = "labelProcessingTime";
            this.labelProcessingTime.Size = new System.Drawing.Size(85, 13);
            this.labelProcessingTime.TabIndex = 10;
            this.labelProcessingTime.Text = "Processing Time";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.ForeColor = System.Drawing.Color.Red;
            this.labelTime.Location = new System.Drawing.Point(618, 152);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(56, 13);
            this.labelTime.TabIndex = 11;
            this.labelTime.Text = "0 seconds";
            // 
            // FormFrameBasedOperation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1014, 605);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.labelProcessingTime);
            this.Controls.Add(this.labelSelectMode);
            this.Controls.Add(this.groupBoxFrameBasedOperation);
            this.Controls.Add(this.comboBoxMode);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.labelOriginal2);
            this.Controls.Add(this.labelOriginal1);
            this.Controls.Add(this.pictureBoxOriginal2);
            this.Controls.Add(this.pictureBoxResult);
            this.Controls.Add(this.pictureBoxOriginal1);
            this.Controls.Add(this.menuFrameBasedOperation);
            this.Name = "FormFrameBasedOperation";
            this.Text = "Frame Based Operation";
            this.menuFrameBasedOperation.ResumeLayout(false);
            this.menuFrameBasedOperation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginal1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginal2)).EndInit();
            this.groupBoxFrameBasedOperation.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuFrameBasedOperation;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFirstImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openSecondImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveResultToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem operationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pointAndAreaBasedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem geometricTransformationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem frameBasedCurrentToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBoxOriginal1;
        private System.Windows.Forms.PictureBox pictureBoxResult;
        private System.Windows.Forms.PictureBox pictureBoxOriginal2;
        private System.Windows.Forms.Label labelOriginal1;
        private System.Windows.Forms.Label labelOriginal2;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.ComboBox comboBoxMode;
        private System.Windows.Forms.GroupBox groupBoxFrameBasedOperation;
        private System.Windows.Forms.Button buttonXOR;
        private System.Windows.Forms.Button buttonOR;
        private System.Windows.Forms.Button buttonAND;
        private System.Windows.Forms.Button buttonAmplitude;
        private System.Windows.Forms.Button buttonCrossFading;
        private System.Windows.Forms.Button buttonMax;
        private System.Windows.Forms.Button buttonMin;
        private System.Windows.Forms.Button buttonAverage;
        private System.Windows.Forms.Button buttonMultiply;
        private System.Windows.Forms.Button buttonDifference;
        private System.Windows.Forms.Button buttonSubstract;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Label labelSelectMode;
        private System.Windows.Forms.Label labelProcessingTime;
        private System.Windows.Forms.Label labelTime;
    }
}