
namespace Prim_s_Demonstration
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButton_LoadSlow = new System.Windows.Forms.RadioButton();
            this.radioButton_LoadByRing = new System.Windows.Forms.RadioButton();
            this.radioButton_LoadByClick = new System.Windows.Forms.RadioButton();
            this.radioButton_Default = new System.Windows.Forms.RadioButton();
            this.textBox_MapHeight = new System.Windows.Forms.TextBox();
            this.textBox_MapWidth = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_Generate = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(519, 140);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(45, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(423, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "Prim\'s Maze Generator";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.textBox_MapHeight);
            this.groupBox2.Controls.Add(this.textBox_MapWidth);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 184);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(519, 327);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButton_LoadSlow);
            this.groupBox3.Controls.Add(this.radioButton_LoadByRing);
            this.groupBox3.Controls.Add(this.radioButton_LoadByClick);
            this.groupBox3.Controls.Add(this.radioButton_Default);
            this.groupBox3.Location = new System.Drawing.Point(7, 188);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(506, 106);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Map Type";
            // 
            // radioButton_LoadSlow
            // 
            this.radioButton_LoadSlow.AutoSize = true;
            this.radioButton_LoadSlow.Location = new System.Drawing.Point(308, 72);
            this.radioButton_LoadSlow.Name = "radioButton_LoadSlow";
            this.radioButton_LoadSlow.Size = new System.Drawing.Size(110, 24);
            this.radioButton_LoadSlow.TabIndex = 3;
            this.radioButton_LoadSlow.TabStop = true;
            this.radioButton_LoadSlow.Text = "Load Slowly";
            this.radioButton_LoadSlow.UseVisualStyleBackColor = true;
            // 
            // radioButton_LoadByRing
            // 
            this.radioButton_LoadByRing.AutoSize = true;
            this.radioButton_LoadByRing.Location = new System.Drawing.Point(308, 31);
            this.radioButton_LoadByRing.Name = "radioButton_LoadByRing";
            this.radioButton_LoadByRing.Size = new System.Drawing.Size(117, 24);
            this.radioButton_LoadByRing.TabIndex = 2;
            this.radioButton_LoadByRing.TabStop = true;
            this.radioButton_LoadByRing.Text = "Load By Ring";
            this.radioButton_LoadByRing.UseVisualStyleBackColor = true;
            // 
            // radioButton_LoadByClick
            // 
            this.radioButton_LoadByClick.AutoSize = true;
            this.radioButton_LoadByClick.Location = new System.Drawing.Point(19, 68);
            this.radioButton_LoadByClick.Name = "radioButton_LoadByClick";
            this.radioButton_LoadByClick.Size = new System.Drawing.Size(171, 24);
            this.radioButton_LoadByClick.TabIndex = 1;
            this.radioButton_LoadByClick.TabStop = true;
            this.radioButton_LoadByClick.Text = "Load Section by Click";
            this.radioButton_LoadByClick.UseVisualStyleBackColor = true;
            // 
            // radioButton_Default
            // 
            this.radioButton_Default.AutoSize = true;
            this.radioButton_Default.Checked = true;
            this.radioButton_Default.Location = new System.Drawing.Point(19, 38);
            this.radioButton_Default.Name = "radioButton_Default";
            this.radioButton_Default.Size = new System.Drawing.Size(79, 24);
            this.radioButton_Default.TabIndex = 0;
            this.radioButton_Default.TabStop = true;
            this.radioButton_Default.Text = "Default";
            this.radioButton_Default.UseVisualStyleBackColor = true;
            // 
            // textBox_MapHeight
            // 
            this.textBox_MapHeight.Location = new System.Drawing.Point(122, 116);
            this.textBox_MapHeight.Name = "textBox_MapHeight";
            this.textBox_MapHeight.Size = new System.Drawing.Size(125, 27);
            this.textBox_MapHeight.TabIndex = 3;
            // 
            // textBox_MapWidth
            // 
            this.textBox_MapWidth.Location = new System.Drawing.Point(122, 50);
            this.textBox_MapWidth.Name = "textBox_MapWidth";
            this.textBox_MapWidth.Size = new System.Drawing.Size(125, 27);
            this.textBox_MapWidth.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Map Height";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Map Width";
            // 
            // button_Generate
            // 
            this.button_Generate.Location = new System.Drawing.Point(85, 535);
            this.button_Generate.Name = "button_Generate";
            this.button_Generate.Size = new System.Drawing.Size(376, 93);
            this.button_Generate.TabIndex = 2;
            this.button_Generate.Text = "Generate";
            this.button_Generate.UseVisualStyleBackColor = true;
            this.button_Generate.Click += new System.EventHandler(this.button_Generate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 653);
            this.Controls.Add(this.button_Generate);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox_MapHeight;
        private System.Windows.Forms.TextBox textBox_MapWidth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButton_Default;
        private System.Windows.Forms.RadioButton radioButton_LoadSlow;
        private System.Windows.Forms.RadioButton radioButton_LoadByRing;
        private System.Windows.Forms.RadioButton radioButton_LoadByClick;
        private System.Windows.Forms.Button button_Generate;
    }
}

