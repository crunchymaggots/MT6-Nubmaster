namespace WindowsFormsApp1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnGenerate = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOpenOriginal = new System.Windows.Forms.Button();
            this.btnOpenSND = new System.Windows.Forms.Button();
            this.lbNewPath = new System.Windows.Forms.Label();
            this.lbOriginalPath = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbLoop = new System.Windows.Forms.TextBox();
            this.btnLoopWhole = new System.Windows.Forms.Button();
            this.btnNoLoop = new System.Windows.Forms.Button();
            this.btnLoopUseFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(15, 196);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(113, 23);
            this.btnGenerate.TabIndex = 4;
            this.btnGenerate.Text = "Generate new .nub";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Loop Point - in samples:";
            // 
            // btnOpenOriginal
            // 
            this.btnOpenOriginal.Location = new System.Drawing.Point(15, 25);
            this.btnOpenOriginal.Name = "btnOpenOriginal";
            this.btnOpenOriginal.Size = new System.Drawing.Size(75, 23);
            this.btnOpenOriginal.TabIndex = 7;
            this.btnOpenOriginal.Text = "Open";
            this.btnOpenOriginal.UseVisualStyleBackColor = true;
            this.btnOpenOriginal.Click += new System.EventHandler(this.btnOpenOriginal_Click);
            // 
            // btnOpenSND
            // 
            this.btnOpenSND.Location = new System.Drawing.Point(15, 88);
            this.btnOpenSND.Name = "btnOpenSND";
            this.btnOpenSND.Size = new System.Drawing.Size(75, 23);
            this.btnOpenSND.TabIndex = 9;
            this.btnOpenSND.Text = "Open";
            this.btnOpenSND.UseVisualStyleBackColor = true;
            this.btnOpenSND.Click += new System.EventHandler(this.btnOpenSND_Click);
            // 
            // lbNewPath
            // 
            this.lbNewPath.AutoSize = true;
            this.lbNewPath.Location = new System.Drawing.Point(96, 93);
            this.lbNewPath.Name = "lbNewPath";
            this.lbNewPath.Size = new System.Drawing.Size(32, 13);
            this.lbNewPath.TabIndex = 10;
            this.lbNewPath.Text = "Path:";
            // 
            // lbOriginalPath
            // 
            this.lbOriginalPath.AutoSize = true;
            this.lbOriginalPath.Location = new System.Drawing.Point(96, 30);
            this.lbOriginalPath.Name = "lbOriginalPath";
            this.lbOriginalPath.Size = new System.Drawing.Size(35, 13);
            this.lbOriginalPath.TabIndex = 8;
            this.lbOriginalPath.Text = "Path: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(239, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Original .nub file (track to copy header data from):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "New .snd file:";
            // 
            // tbLoop
            // 
            this.tbLoop.Location = new System.Drawing.Point(15, 154);
            this.tbLoop.Name = "tbLoop";
            this.tbLoop.Size = new System.Drawing.Size(168, 20);
            this.tbLoop.TabIndex = 15;
            // 
            // btnLoopWhole
            // 
            this.btnLoopWhole.Location = new System.Drawing.Point(270, 152);
            this.btnLoopWhole.Name = "btnLoopWhole";
            this.btnLoopWhole.Size = new System.Drawing.Size(115, 23);
            this.btnLoopWhole.TabIndex = 16;
            this.btnLoopWhole.Text = "Loop Whole Track";
            this.btnLoopWhole.UseVisualStyleBackColor = true;
            this.btnLoopWhole.Click += new System.EventHandler(this.btnLoopWhole_Click);
            // 
            // btnNoLoop
            // 
            this.btnNoLoop.Location = new System.Drawing.Point(391, 152);
            this.btnNoLoop.Name = "btnNoLoop";
            this.btnNoLoop.Size = new System.Drawing.Size(75, 23);
            this.btnNoLoop.TabIndex = 17;
            this.btnNoLoop.Text = "No Loop";
            this.btnNoLoop.UseVisualStyleBackColor = true;
            this.btnNoLoop.Click += new System.EventHandler(this.btnNoLoop_Click);
            // 
            // btnLoopUseFile
            // 
            this.btnLoopUseFile.Location = new System.Drawing.Point(189, 152);
            this.btnLoopUseFile.Name = "btnLoopUseFile";
            this.btnLoopUseFile.Size = new System.Drawing.Size(75, 23);
            this.btnLoopUseFile.TabIndex = 18;
            this.btnLoopUseFile.Text = "Use File";
            this.btnLoopUseFile.UseVisualStyleBackColor = true;
            this.btnLoopUseFile.Click += new System.EventHandler(this.btnLoopUseFile_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 246);
            this.Controls.Add(this.btnLoopUseFile);
            this.Controls.Add(this.btnNoLoop);
            this.Controls.Add(this.btnLoopWhole);
            this.Controls.Add(this.tbLoop);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbNewPath);
            this.Controls.Add(this.btnOpenSND);
            this.Controls.Add(this.lbOriginalPath);
            this.Controls.Add(this.btnOpenOriginal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnGenerate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "MT6 Nubmaster";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOpenOriginal;
        private System.Windows.Forms.Button btnOpenSND;
        private System.Windows.Forms.Label lbNewPath;
        private System.Windows.Forms.Label lbOriginalPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbLoop;
        private System.Windows.Forms.Button btnLoopWhole;
        private System.Windows.Forms.Button btnNoLoop;
        private System.Windows.Forms.Button btnLoopUseFile;
    }
}

