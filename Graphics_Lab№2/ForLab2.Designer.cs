namespace Graphics_Lab_2
{
    partial class ForLab2
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.IsEllipse = new System.Windows.Forms.RadioButton();
            this.IsArc = new System.Windows.Forms.RadioButton();
            this.IsPie = new System.Windows.Forms.RadioButton();
            this.startAngleNumeric = new System.Windows.Forms.NumericUpDown();
            this.sweepAngleNumeric = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.startAngleNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sweepAngleNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // IsEllipse
            // 
            this.IsEllipse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.IsEllipse.AutoSize = true;
            this.IsEllipse.Checked = true;
            this.IsEllipse.Location = new System.Drawing.Point(12, 588);
            this.IsEllipse.Name = "IsEllipse";
            this.IsEllipse.Size = new System.Drawing.Size(55, 17);
            this.IsEllipse.TabIndex = 0;
            this.IsEllipse.TabStop = true;
            this.IsEllipse.Text = "Ellipse";
            this.IsEllipse.UseVisualStyleBackColor = true;
            // 
            // IsArc
            // 
            this.IsArc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.IsArc.AutoSize = true;
            this.IsArc.Location = new System.Drawing.Point(73, 588);
            this.IsArc.Name = "IsArc";
            this.IsArc.Size = new System.Drawing.Size(41, 17);
            this.IsArc.TabIndex = 1;
            this.IsArc.Text = "Arc";
            this.IsArc.UseVisualStyleBackColor = true;
            // 
            // IsPie
            // 
            this.IsPie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.IsPie.AutoSize = true;
            this.IsPie.Location = new System.Drawing.Point(120, 588);
            this.IsPie.Name = "IsPie";
            this.IsPie.Size = new System.Drawing.Size(40, 17);
            this.IsPie.TabIndex = 2;
            this.IsPie.Text = "Pie";
            this.IsPie.UseVisualStyleBackColor = true;
            // 
            // startAngleNumeric
            // 
            this.startAngleNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.startAngleNumeric.Location = new System.Drawing.Point(720, 13);
            this.startAngleNumeric.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.startAngleNumeric.Name = "startAngleNumeric";
            this.startAngleNumeric.Size = new System.Drawing.Size(55, 20);
            this.startAngleNumeric.TabIndex = 3;
            this.startAngleNumeric.Visible = false;
            // 
            // sweepAngleNumeric
            // 
            this.sweepAngleNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sweepAngleNumeric.Location = new System.Drawing.Point(720, 40);
            this.sweepAngleNumeric.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.sweepAngleNumeric.Name = "sweepAngleNumeric";
            this.sweepAngleNumeric.Size = new System.Drawing.Size(54, 20);
            this.sweepAngleNumeric.TabIndex = 4;
            this.sweepAngleNumeric.Value = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.sweepAngleNumeric.Visible = false;
            // 
            // ForLab2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 617);
            this.Controls.Add(this.sweepAngleNumeric);
            this.Controls.Add(this.startAngleNumeric);
            this.Controls.Add(this.IsPie);
            this.Controls.Add(this.IsArc);
            this.Controls.Add(this.IsEllipse);
            this.Name = "ForLab2";
            this.Text = "ForLab2";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ForLab2_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ForLab2_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.startAngleNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sweepAngleNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton IsEllipse;
        private System.Windows.Forms.RadioButton IsArc;
        private System.Windows.Forms.RadioButton IsPie;
        private System.Windows.Forms.NumericUpDown startAngleNumeric;
        private System.Windows.Forms.NumericUpDown sweepAngleNumeric;
    }
}

