namespace Connectivity_Testing_Tool
{
    partial class SpeedTest
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
            this.speedtest_input = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.speedtest_link = new System.Windows.Forms.LinkLabel();
            this.speedtest_submit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // speedtest_input
            // 
            this.speedtest_input.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.speedtest_input.Location = new System.Drawing.Point(15, 39);
            this.speedtest_input.Name = "speedtest_input";
            this.speedtest_input.Size = new System.Drawing.Size(480, 22);
            this.speedtest_input.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Paste Speedtest Result URL";
            // 
            // speedtest_link
            // 
            this.speedtest_link.AutoSize = true;
            this.speedtest_link.Location = new System.Drawing.Point(12, 88);
            this.speedtest_link.Name = "speedtest_link";
            this.speedtest_link.Size = new System.Drawing.Size(127, 17);
            this.speedtest_link.TabIndex = 2;
            this.speedtest_link.TabStop = true;
            this.speedtest_link.Text = "Speedtest Website";
            this.speedtest_link.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.speedtest_link_LinkClicked);
            // 
            // speedtest_submit
            // 
            this.speedtest_submit.Location = new System.Drawing.Point(349, 79);
            this.speedtest_submit.Name = "speedtest_submit";
            this.speedtest_submit.Size = new System.Drawing.Size(146, 35);
            this.speedtest_submit.TabIndex = 3;
            this.speedtest_submit.Text = "Submit Speedtest";
            this.speedtest_submit.UseVisualStyleBackColor = true;
            this.speedtest_submit.Click += new System.EventHandler(this.speedtest_submit_Click);
            // 
            // SpeedTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 126);
            this.Controls.Add(this.speedtest_submit);
            this.Controls.Add(this.speedtest_link);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.speedtest_input);
            this.MaximumSize = new System.Drawing.Size(525, 173);
            this.MinimumSize = new System.Drawing.Size(525, 173);
            this.Name = "SpeedTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SpeedTest";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.speedtest_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox speedtest_input;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel speedtest_link;
        private System.Windows.Forms.Button speedtest_submit;
    }
}