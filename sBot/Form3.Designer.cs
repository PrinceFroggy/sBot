namespace sBot
{
    partial class Form3
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cueTextBox12 = new sBot.CueTextBox();
            this.cueTextBox11 = new sBot.CueTextBox();
            this.cueTextBox10 = new sBot.CueTextBox();
            this.cueTextBox9 = new sBot.CueTextBox();
            this.cueTextBox8 = new sBot.CueTextBox();
            this.cueTextBox7 = new sBot.CueTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cueTextBox6 = new sBot.CueTextBox();
            this.cueTextBox5 = new sBot.CueTextBox();
            this.cueTextBox4 = new sBot.CueTextBox();
            this.cueTextBox3 = new sBot.CueTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cueTextBox2 = new sBot.CueTextBox();
            this.cueTextBox1 = new sBot.CueTextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.groupBox1.Controls.Add(this.cueTextBox12);
            this.groupBox1.Controls.Add(this.cueTextBox11);
            this.groupBox1.Controls.Add(this.cueTextBox10);
            this.groupBox1.Controls.Add(this.cueTextBox9);
            this.groupBox1.Controls.Add(this.cueTextBox8);
            this.groupBox1.Controls.Add(this.cueTextBox7);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cueTextBox6);
            this.groupBox1.Controls.Add(this.cueTextBox5);
            this.groupBox1.Controls.Add(this.cueTextBox4);
            this.groupBox1.Controls.Add(this.cueTextBox3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cueTextBox2);
            this.groupBox1.Controls.Add(this.cueTextBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(139, 404);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.MouseHover += new System.EventHandler(this.groupBox1_MouseHover);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.AutoSize = false;
            this.contextMenuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(71, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.AutoSize = false;
            this.toolStripMenuItem1.Image = global::sBot.Properties.Resources.reset;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(70, 22);
            this.toolStripMenuItem1.Text = "reset";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // cueTextBox12
            // 
            this.cueTextBox12.CueText = "- cvv -";
            this.cueTextBox12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cueTextBox12.Location = new System.Drawing.Point(12, 366);
            this.cueTextBox12.Name = "cueTextBox12";
            this.cueTextBox12.ShortcutsEnabled = false;
            this.cueTextBox12.Size = new System.Drawing.Size(115, 20);
            this.cueTextBox12.TabIndex = 16;
            this.cueTextBox12.TabStop = false;
            this.cueTextBox12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.cueTextBox12, "ex. XXXX");
            this.cueTextBox12.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cueTextBox12_KeyPress);
            // 
            // cueTextBox11
            // 
            this.cueTextBox11.CueText = "- exp. date -";
            this.cueTextBox11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cueTextBox11.Location = new System.Drawing.Point(12, 339);
            this.cueTextBox11.Name = "cueTextBox11";
            this.cueTextBox11.ShortcutsEnabled = false;
            this.cueTextBox11.Size = new System.Drawing.Size(115, 20);
            this.cueTextBox11.TabIndex = 15;
            this.cueTextBox11.TabStop = false;
            this.cueTextBox11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.cueTextBox11, "ex. MM YYYY");
            this.cueTextBox11.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cueTextBox11_KeyPress);
            // 
            // cueTextBox10
            // 
            this.cueTextBox10.CueText = "- number -";
            this.cueTextBox10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cueTextBox10.Location = new System.Drawing.Point(12, 312);
            this.cueTextBox10.Name = "cueTextBox10";
            this.cueTextBox10.ShortcutsEnabled = false;
            this.cueTextBox10.Size = new System.Drawing.Size(115, 20);
            this.cueTextBox10.TabIndex = 14;
            this.cueTextBox10.TabStop = false;
            this.cueTextBox10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.cueTextBox10, "ex. XXXX XXXX XXXX XXXX");
            this.cueTextBox10.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cueTextBox10_KeyPress);
            // 
            // cueTextBox9
            // 
            this.cueTextBox9.CueText = "- type -";
            this.cueTextBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cueTextBox9.Location = new System.Drawing.Point(12, 285);
            this.cueTextBox9.Name = "cueTextBox9";
            this.cueTextBox9.ShortcutsEnabled = false;
            this.cueTextBox9.Size = new System.Drawing.Size(115, 20);
            this.cueTextBox9.TabIndex = 13;
            this.cueTextBox9.TabStop = false;
            this.cueTextBox9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.cueTextBox9, "ex. Visa or American Express or Mastercard or Solo or Paypal");
            // 
            // cueTextBox8
            // 
            this.cueTextBox8.CueText = "- city -";
            this.cueTextBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cueTextBox8.Location = new System.Drawing.Point(12, 229);
            this.cueTextBox8.Name = "cueTextBox8";
            this.cueTextBox8.ShortcutsEnabled = false;
            this.cueTextBox8.Size = new System.Drawing.Size(115, 20);
            this.cueTextBox8.TabIndex = 12;
            this.cueTextBox8.TabStop = false;
            this.cueTextBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.cueTextBox8, "ex. Unknown");
            // 
            // cueTextBox7
            // 
            this.cueTextBox7.CueText = "- state -";
            this.cueTextBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cueTextBox7.Location = new System.Drawing.Point(12, 202);
            this.cueTextBox7.Name = "cueTextBox7";
            this.cueTextBox7.ShortcutsEnabled = false;
            this.cueTextBox7.Size = new System.Drawing.Size(115, 20);
            this.cueTextBox7.TabIndex = 11;
            this.cueTextBox7.TabStop = false;
            this.cueTextBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.cueTextBox7, "ex. XX");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 260);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "credit card information";
            // 
            // cueTextBox6
            // 
            this.cueTextBox6.CueText = "- country -";
            this.cueTextBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cueTextBox6.Location = new System.Drawing.Point(12, 175);
            this.cueTextBox6.Name = "cueTextBox6";
            this.cueTextBox6.ShortcutsEnabled = false;
            this.cueTextBox6.Size = new System.Drawing.Size(115, 20);
            this.cueTextBox6.TabIndex = 6;
            this.cueTextBox6.TabStop = false;
            this.cueTextBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.cueTextBox6, "ex. USA or CANADA or UK");
            // 
            // cueTextBox5
            // 
            this.cueTextBox5.CueText = "- tel -";
            this.cueTextBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cueTextBox5.Location = new System.Drawing.Point(12, 148);
            this.cueTextBox5.Name = "cueTextBox5";
            this.cueTextBox5.ShortcutsEnabled = false;
            this.cueTextBox5.ShowCueTextWithFocus = true;
            this.cueTextBox5.Size = new System.Drawing.Size(115, 20);
            this.cueTextBox5.TabIndex = 5;
            this.cueTextBox5.TabStop = false;
            this.cueTextBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.cueTextBox5, "ex. (XXX) XXX-XXXX");
            // 
            // cueTextBox4
            // 
            this.cueTextBox4.CueText = "- zip -";
            this.cueTextBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cueTextBox4.Location = new System.Drawing.Point(12, 121);
            this.cueTextBox4.Name = "cueTextBox4";
            this.cueTextBox4.ShortcutsEnabled = false;
            this.cueTextBox4.ShowCueTextWithFocus = true;
            this.cueTextBox4.Size = new System.Drawing.Size(115, 20);
            this.cueTextBox4.TabIndex = 4;
            this.cueTextBox4.TabStop = false;
            this.cueTextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.cueTextBox4, "ex. Unknown");
            // 
            // cueTextBox3
            // 
            this.cueTextBox3.CueText = "- address -";
            this.cueTextBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cueTextBox3.Location = new System.Drawing.Point(12, 94);
            this.cueTextBox3.Name = "cueTextBox3";
            this.cueTextBox3.ShortcutsEnabled = false;
            this.cueTextBox3.ShowCueTextWithFocus = true;
            this.cueTextBox3.Size = new System.Drawing.Size(115, 20);
            this.cueTextBox3.TabIndex = 3;
            this.cueTextBox3.TabStop = false;
            this.cueTextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.cueTextBox3, "ex. Unknown");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Help;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "billing/shipping";
            this.toolTip1.SetToolTip(this.label1, "must be the same as your credit card address");
            // 
            // cueTextBox2
            // 
            this.cueTextBox2.CueText = "- email -";
            this.cueTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cueTextBox2.Location = new System.Drawing.Point(12, 67);
            this.cueTextBox2.Name = "cueTextBox2";
            this.cueTextBox2.ShortcutsEnabled = false;
            this.cueTextBox2.ShowCueTextWithFocus = true;
            this.cueTextBox2.Size = new System.Drawing.Size(115, 20);
            this.cueTextBox2.TabIndex = 1;
            this.cueTextBox2.TabStop = false;
            this.cueTextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.cueTextBox2, "ex. asolesa@yahoo.ca");
            // 
            // cueTextBox1
            // 
            this.cueTextBox1.CueText = "- name -";
            this.cueTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cueTextBox1.Location = new System.Drawing.Point(12, 40);
            this.cueTextBox1.Name = "cueTextBox1";
            this.cueTextBox1.ShortcutsEnabled = false;
            this.cueTextBox1.ShowCueTextWithFocus = true;
            this.cueTextBox1.Size = new System.Drawing.Size(115, 20);
            this.cueTextBox1.TabIndex = 0;
            this.cueTextBox1.TabStop = false;
            this.cueTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.cueTextBox1, "ex. Andrew Solesa");
            // 
            // toolTip1
            // 
            this.toolTip1.ShowAlways = true;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(163, 409);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form3";
            this.Opacity = 0.85D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.VisibleChanged += new System.EventHandler(this.Form3_VisibleChanged);
            this.MouseHover += new System.EventHandler(this.Form3_MouseHover);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private CueTextBox cueTextBox1;
        private System.Windows.Forms.Label label1;
        private CueTextBox cueTextBox2;
        private CueTextBox cueTextBox5;
        private CueTextBox cueTextBox4;
        private CueTextBox cueTextBox3;
        private CueTextBox cueTextBox6;
        private System.Windows.Forms.Label label2;
        private CueTextBox cueTextBox9;
        private CueTextBox cueTextBox8;
        private CueTextBox cueTextBox7;
        private CueTextBox cueTextBox12;
        private CueTextBox cueTextBox11;
        private CueTextBox cueTextBox10;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}