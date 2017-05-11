namespace Presentation_Layer_
{
    partial class HelpWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpWindow));
            this.HelpTabs = new System.Windows.Forms.TabControl();
            this.General = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.CancelRequest = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.HelpTabs.SuspendLayout();
            this.General.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // HelpTabs
            // 
            this.HelpTabs.Controls.Add(this.General);
            this.HelpTabs.Controls.Add(this.tabPage2);
            this.HelpTabs.Controls.Add(this.CancelRequest);
            this.HelpTabs.Font = new System.Drawing.Font("Cooper Black", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelpTabs.Location = new System.Drawing.Point(1, 2);
            this.HelpTabs.Name = "HelpTabs";
            this.HelpTabs.SelectedIndex = 0;
            this.HelpTabs.Size = new System.Drawing.Size(975, 443);
            this.HelpTabs.TabIndex = 0;
            // 
            // General
            // 
            this.General.BackColor = System.Drawing.Color.Wheat;
            this.General.Controls.Add(this.button1);
            this.General.Controls.Add(this.label2);
            this.General.Controls.Add(this.label1);
            this.General.Location = new System.Drawing.Point(4, 24);
            this.General.Name = "General";
            this.General.Padding = new System.Windows.Forms.Padding(3);
            this.General.Size = new System.Drawing.Size(938, 415);
            this.General.TabIndex = 0;
            this.General.Text = "General";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Wheat;
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(967, 415);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Buy/Sell Commodities";
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // CancelRequest
            // 
            this.CancelRequest.BackColor = System.Drawing.Color.Wheat;
            this.CancelRequest.Location = new System.Drawing.Point(4, 24);
            this.CancelRequest.Name = "CancelRequest";
            this.CancelRequest.Padding = new System.Windows.Forms.Padding(3);
            this.CancelRequest.Size = new System.Drawing.Size(938, 415);
            this.CancelRequest.TabIndex = 2;
            this.CancelRequest.Text = "CancelRequest";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cooper Black", 15F);
            this.label1.Location = new System.Drawing.Point(35, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(449, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome to the Algo-Trading App!";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cooper Black", 9.5F);
            this.label2.Location = new System.Drawing.Point(7, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(827, 228);
            this.label2.TabIndex = 1;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Cooper Black", 14.8F);
            this.button1.Location = new System.Drawing.Point(346, 334);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 42);
            this.button1.TabIndex = 2;
            this.button1.Text = "Got it!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cooper Black", 8.5F);
            this.label3.Location = new System.Drawing.Point(-3, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1457, 255);
            this.label3.TabIndex = 0;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cooper Black", 15F);
            this.label4.Location = new System.Drawing.Point(288, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(295, 29);
            this.label4.TabIndex = 1;
            this.label4.Text = "Buy/Sell Commodities";
            // 
            // HelpWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 449);
            this.Controls.Add(this.HelpTabs);
            this.Name = "HelpWindow";
            this.Text = "HelpWindow";
            this.HelpTabs.ResumeLayout(false);
            this.General.ResumeLayout(false);
            this.General.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl HelpTabs;
        private System.Windows.Forms.TabPage General;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage CancelRequest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}