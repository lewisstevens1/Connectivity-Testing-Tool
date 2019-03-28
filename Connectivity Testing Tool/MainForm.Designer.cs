namespace Connectivity_Testing_Tool
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.ctt_export_button = new System.Windows.Forms.Button();
            this.ctt_note_disconnection = new System.Windows.Forms.Button();
            this.ctt_timer = new System.Windows.Forms.Timer(this.components);
            this.ctt_stats_timer = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctt_export_button
            // 
            this.ctt_export_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ctt_export_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctt_export_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctt_export_button.Location = new System.Drawing.Point(0, 0);
            this.ctt_export_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ctt_export_button.Name = "ctt_export_button";
            this.ctt_export_button.Size = new System.Drawing.Size(359, 53);
            this.ctt_export_button.TabIndex = 0;
            this.ctt_export_button.Text = "EXPORT DATA";
            this.ctt_export_button.UseVisualStyleBackColor = true;
            this.ctt_export_button.Click += new System.EventHandler(this.ctt_export_button_Click);
            // 
            // ctt_note_disconnection
            // 
            this.ctt_note_disconnection.AutoSize = true;
            this.ctt_note_disconnection.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ctt_note_disconnection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctt_note_disconnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctt_note_disconnection.Location = new System.Drawing.Point(0, 0);
            this.ctt_note_disconnection.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ctt_note_disconnection.Name = "ctt_note_disconnection";
            this.ctt_note_disconnection.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ctt_note_disconnection.Size = new System.Drawing.Size(359, 59);
            this.ctt_note_disconnection.TabIndex = 3;
            this.ctt_note_disconnection.Text = "NOTE DISCONNECTION";
            this.ctt_note_disconnection.UseVisualStyleBackColor = true;
            this.ctt_note_disconnection.Click += new System.EventHandler(this.ctt_note_disconnection_Click);
            // 
            // ctt_timer
            // 
            this.ctt_timer.Enabled = true;
            this.ctt_timer.Interval = 2000;
            this.ctt_timer.Tick += new System.EventHandler(this.ctt_timer_Tick);
            // 
            // ctt_stats_timer
            // 
            this.ctt_stats_timer.Enabled = true;
            this.ctt_stats_timer.Interval = 10000;
            this.ctt_stats_timer.Tick += new System.EventHandler(this.ctt_stats_timer_Tick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(11, 10);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ctt_note_disconnection);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ctt_export_button);
            this.splitContainer1.Size = new System.Drawing.Size(359, 122);
            this.splitContainer1.SplitterDistance = 59;
            this.splitContainer1.SplitterWidth = 10;
            this.splitContainer1.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(381, 142);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(399, 189);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(399, 189);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connectivity Testing Tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ctt_export_button;
        private System.Windows.Forms.Button ctt_note_disconnection;
        private System.Windows.Forms.Timer ctt_timer;
        private System.Windows.Forms.Timer ctt_stats_timer;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}

