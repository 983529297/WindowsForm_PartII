
namespace DrawingForm
{
    partial class Check
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
            this._label1 = new System.Windows.Forms.Label();
            this._button1 = new System.Windows.Forms.Button();
            this._button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _label1
            // 
            this._label1.AutoSize = true;
            this._label1.Font = new System.Drawing.Font("新細明體", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._label1.Location = new System.Drawing.Point(40, 38);
            this._label1.Name = "_label1";
            this._label1.Size = new System.Drawing.Size(220, 25);
            this._label1.TabIndex = 0;
            this._label1.Text = "請問是否確定繼續";
            // 
            // _button1
            // 
            this._button1.Location = new System.Drawing.Point(11, 123);
            this._button1.Name = "_button1";
            this._button1.Size = new System.Drawing.Size(163, 53);
            this._button1.TabIndex = 1;
            this._button1.Text = "No";
            this._button1.UseVisualStyleBackColor = true;
            this._button1.Click += new System.EventHandler(this.ClickButton1);
            // 
            // _button2
            // 
            this._button2.Location = new System.Drawing.Point(180, 123);
            this._button2.Name = "_button2";
            this._button2.Size = new System.Drawing.Size(163, 53);
            this._button2.TabIndex = 2;
            this._button2.Text = "Yes";
            this._button2.UseVisualStyleBackColor = true;
            this._button2.Click += new System.EventHandler(this.ClickButton2);
            // 
            // Check
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 188);
            this.Controls.Add(this._button2);
            this.Controls.Add(this._button1);
            this.Controls.Add(this._label1);
            this.Name = "Check";
            this.Text = "Check";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _label1;
        private System.Windows.Forms.Button _button1;
        private System.Windows.Forms.Button _button2;
    }
}