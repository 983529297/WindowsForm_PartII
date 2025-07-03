
namespace DrawingForm
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this._rectangle = new System.Windows.Forms.Button();
            this._ellipse = new System.Windows.Forms.Button();
            this._clear = new System.Windows.Forms.Button();
            this._line = new System.Windows.Forms.Button();
            this._redo = new System.Windows.Forms.ToolStripButton();
            this._undo = new System.Windows.Forms.ToolStripButton();
            this._toolStrip1 = new System.Windows.Forms.ToolStrip();
            this._position = new System.Windows.Forms.Label();
            this._save = new System.Windows.Forms.Button();
            this._load = new System.Windows.Forms.Button();
            this._toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _rectangle
            // 
            this._rectangle.Location = new System.Drawing.Point(12, 40);
            this._rectangle.Name = "_rectangle";
            this._rectangle.Size = new System.Drawing.Size(130, 52);
            this._rectangle.TabIndex = 0;
            this._rectangle.Text = "Rectangle";
            this._rectangle.UseVisualStyleBackColor = true;
            this._rectangle.Click += new System.EventHandler(this.ClickRectangle);
            // 
            // _ellipse
            // 
            this._ellipse.Location = new System.Drawing.Point(308, 40);
            this._ellipse.Name = "_ellipse";
            this._ellipse.Size = new System.Drawing.Size(130, 52);
            this._ellipse.TabIndex = 1;
            this._ellipse.Text = "Ellipse";
            this._ellipse.UseVisualStyleBackColor = true;
            this._ellipse.Click += new System.EventHandler(this.ClickEllipse);
            // 
            // _clear
            // 
            this._clear.Location = new System.Drawing.Point(444, 40);
            this._clear.Name = "_clear";
            this._clear.Size = new System.Drawing.Size(130, 52);
            this._clear.TabIndex = 2;
            this._clear.Text = "Clear";
            this._clear.UseVisualStyleBackColor = true;
            this._clear.Click += new System.EventHandler(this.HandleClearButtonClick);
            // 
            // _line
            // 
            this._line.Location = new System.Drawing.Point(148, 40);
            this._line.Name = "_line";
            this._line.Size = new System.Drawing.Size(130, 52);
            this._line.TabIndex = 4;
            this._line.Text = "Line";
            this._line.UseVisualStyleBackColor = true;
            this._line.Click += new System.EventHandler(this.ClickLine);
            // 
            // _redo
            // 
            this._redo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._redo.Image = ((System.Drawing.Image)(resources.GetObject("_redo.Image")));
            this._redo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._redo.Name = "_redo";
            this._redo.Size = new System.Drawing.Size(50, 28);
            this._redo.Text = "Redo";
            this._redo.Click += new System.EventHandler(this.ClickRedo);
            // 
            // _undo
            // 
            this._undo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._undo.Image = ((System.Drawing.Image)(resources.GetObject("_undo.Image")));
            this._undo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._undo.Name = "_undo";
            this._undo.Size = new System.Drawing.Size(52, 23);
            this._undo.Text = "Undo";
            this._undo.Click += new System.EventHandler(this.ClickUndo);
            // 
            // _toolStrip1
            // 
            this._toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._redo,
            this._undo});
            this._toolStrip1.Location = new System.Drawing.Point(0, 0);
            this._toolStrip1.Name = "_toolStrip1";
            this._toolStrip1.Size = new System.Drawing.Size(882, 31);
            this._toolStrip1.TabIndex = 3;
            this._toolStrip1.Text = "toolStrip1";
            // 
            // _position
            // 
            this._position.AutoSize = true;
            this._position.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._position.Location = new System.Drawing.Point(800, 420);
            this._position.Name = "_position";
            this._position.Size = new System.Drawing.Size(47, 17);
            this._position.TabIndex = 5;
            this._position.Text = "None";
            this._position.Visible = false;
            // 
            // _save
            // 
            this._save.Location = new System.Drawing.Point(740, 40);
            this._save.Name = "_save";
            this._save.Size = new System.Drawing.Size(130, 52);
            this._save.TabIndex = 6;
            this._save.Text = "Save";
            this._save.UseVisualStyleBackColor = true;
            this._save.Click += new System.EventHandler(this.ClickSave);
            this._save.Enabled = false;
            // 
            // _load
            // 
            this._load.Location = new System.Drawing.Point(604, 40);
            this._load.Name = "_load";
            this._load.Size = new System.Drawing.Size(130, 52);
            this._load.TabIndex = 7;
            this._load.Text = "Load";
            this._load.UseVisualStyleBackColor = true;
            this._load.Click += new System.EventHandler(this.ClickLoad);
            this._load.Enabled = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 453);
            this.Controls.Add(this._load);
            this.Controls.Add(this._save);
            this.Controls.Add(this._position);
            this.Controls.Add(this._line);
            this.Controls.Add(this._toolStrip1);
            this.Controls.Add(this._clear);
            this.Controls.Add(this._ellipse);
            this.Controls.Add(this._rectangle);
            this.Name = "Form1";
            this.Text = "Draw";
            this._toolStrip1.ResumeLayout(false);
            this._toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _rectangle;
        private System.Windows.Forms.Button _ellipse;
        private System.Windows.Forms.Button _clear;
        private System.Windows.Forms.Button _line;
        private System.Windows.Forms.ToolStripButton _redo;
        private System.Windows.Forms.ToolStripButton _undo;
        private System.Windows.Forms.ToolStrip _toolStrip1;
        private System.Windows.Forms.Label _position;
        private System.Windows.Forms.Button _save;
        private System.Windows.Forms.Button _load;
    }
}

