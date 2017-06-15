namespace Presentation_Layer_
{
    partial class History
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(History));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.richTextBox1.Font = new System.Drawing.Font("Cooper Black", 9F);
            this.richTextBox1.Location = new System.Drawing.Point(348, 0);
            this.richTextBox1.MaximumSize = new System.Drawing.Size(10000, 10000);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(657, 549);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button1.Font = new System.Drawing.Font("Cooper Black", 11F);
            this.button1.ForeColor = System.Drawing.Color.SteelBlue;
            this.button1.Location = new System.Drawing.Point(64, 386);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(184, 44);
            this.button1.TabIndex = 1;
            this.button1.Text = "Show History";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.monthCalendar1.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.monthCalendar1.Location = new System.Drawing.Point(18, 147);
            this.monthCalendar1.MaxDate = new System.DateTime(2017, 6, 23, 0, 0, 0, 0);
            this.monthCalendar1.MaxSelectionCount = 120;
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.SelectionRange = new System.Windows.Forms.SelectionRange(new System.DateTime(2017, 1, 1, 0, 0, 0, 0), new System.DateTime(2017, 2, 23, 0, 0, 0, 0));
            this.monthCalendar1.TabIndex = 2;
            this.monthCalendar1.TitleForeColor = System.Drawing.SystemColors.Control;
            this.monthCalendar1.TrailingForeColor = System.Drawing.SystemColors.AppWorkspace;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Cooper Black", 11F);
            this.label1.ForeColor = System.Drawing.Color.Tan;
            this.label1.Location = new System.Drawing.Point(34, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 63);
            this.label1.TabIndex = 3;
            this.label1.Text = "Please choose the starting\r\n date you would like to\r\n view your history from:";
            // 
            // History
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1005, 549);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox1);
            this.Name = "History";
            this.Text = "History";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Label label1;
    }
}