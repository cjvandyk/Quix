namespace GUIDGen
{
    partial class GUIDGen
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
            this.txtGUID = new System.Windows.Forms.TextBox();
            this.cmdGenerateGUID = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGUIDStart = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtGUID
            // 
            this.txtGUID.Location = new System.Drawing.Point(16, 112);
            this.txtGUID.Name = "txtGUID";
            this.txtGUID.Size = new System.Drawing.Size(231, 20);
            this.txtGUID.TabIndex = 1;
            // 
            // cmdGenerateGUID
            // 
            this.cmdGenerateGUID.Location = new System.Drawing.Point(16, 73);
            this.cmdGenerateGUID.Name = "cmdGenerateGUID";
            this.cmdGenerateGUID.Size = new System.Drawing.Size(100, 23);
            this.cmdGenerateGUID.TabIndex = 2;
            this.cmdGenerateGUID.Text = "Generate GUID";
            this.cmdGenerateGUID.UseVisualStyleBackColor = true;
            this.cmdGenerateGUID.Click += new System.EventHandler(this.cmdGenerateGUID_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Enter the custom start characters for your GUID:";
            // 
            // txtGUIDStart
            // 
            this.txtGUIDStart.Location = new System.Drawing.Point(16, 40);
            this.txtGUIDStart.Name = "txtGUIDStart";
            this.txtGUIDStart.Size = new System.Drawing.Size(100, 20);
            this.txtGUIDStart.TabIndex = 0;
            this.txtGUIDStart.TextChanged += new System.EventHandler(this.txtGUIDStart_TextChanged);
            // 
            // GUIDGen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 148);
            this.Controls.Add(this.txtGUIDStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdGenerateGUID);
            this.Controls.Add(this.txtGUID);
            this.Name = "GUIDGen";
            this.Text = "GUIDGen";
            this.Load += new System.EventHandler(this.GUIDGen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtGUID;
        private System.Windows.Forms.Button cmdGenerateGUID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGUIDStart;
    }
}

