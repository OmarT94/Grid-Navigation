using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace WindowsFormsSimu
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            bool DoIt = true;
            if (DoIt)
            {
                this.textBox1 = new System.Windows.Forms.TextBox();
                this.AnzWorker = new System.Windows.Forms.Label();
                this.Export = new System.Windows.Forms.Button();
                this.Start = new System.Windows.Forms.Button();
            }
            this.SuspendLayout();
            if (DoIt)
            {
                // 
                // textBox1
                // 
                this.textBox1.Location = new System.Drawing.Point(720, 449);
                this.textBox1.Name = "textBox1";
                this.textBox1.Size = new System.Drawing.Size(100, 20);
                this.textBox1.TabIndex = 0;
                // 
                // AnzWorker
                // 
                this.AnzWorker.AutoSize = true;
                this.AnzWorker.Location = new System.Drawing.Point(638, 455);
                this.AnzWorker.Name = "AnzWorker";
                this.AnzWorker.Size = new System.Drawing.Size(60, 13);
                this.AnzWorker.TabIndex = 2;
                this.AnzWorker.Text = "AnzWorker";                
                // 
                // Export
                // 
                this.Export.Location = new System.Drawing.Point(634, 532);
                this.Export.Name = "Export";
                this.Export.Size = new System.Drawing.Size(75, 23);
                this.Export.TabIndex = 3;
                this.Export.Text = "Export";
                this.Export.UseVisualStyleBackColor = true;
                this.Export.Click += Export_click;

                // MyHandler1 onClicked = new MyHandler1(clicked);
                // listBox1.Click += new EventHandler(onClicked);

                // 
                // Start
                // 
                this.Start.Location = new System.Drawing.Point(634, 562);
                this.Start.Name = "Start";
                this.Start.Size = new System.Drawing.Size(75, 23);
                this.Start.TabIndex = 4;
                this.Start.Text = "Start";
                this.Start.UseVisualStyleBackColor = true;
                this.Start.Click += Start_click;
            }
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 822);
            if (DoIt)
            {
                this.Controls.Add(this.Start);
                this.Controls.Add(this.Export);
                // this.Controls.Add(this.AnzWorker);
                // this.Controls.Add(this.textBox1);
            }
            this.Name = "Form1";
            this.Text = "Form1";
            
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);

            this.ResumeLayout(false);
            this.PerformLayout();

            if (true)
            {
                // 03.02.2021
                // Flicker             
                this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                             ControlStyles.UserPaint |
                             ControlStyles.OptimizedDoubleBuffer, true);

                MethodInfo objMethodInfo = typeof(Control).GetMethod("SetStyle", BindingFlags.NonPublic | BindingFlags.Instance);

                object[] objArgs = new object[] { ControlStyles.AllPaintingInWmPaint |
                        ControlStyles.UserPaint |
                        ControlStyles.OptimizedDoubleBuffer, true };

                if (DoIt)
                {
                    objMethodInfo.Invoke(this.Start, objArgs);
                    objMethodInfo.Invoke(this.Export, objArgs);
                    objMethodInfo.Invoke(this.AnzWorker, objArgs);
                    objMethodInfo.Invoke(this.textBox1, objArgs);
                }
            }



        }
        public void Start_click(object sender, EventArgs e)
        {
            Start2_click();
            // label1.ResetText();
            // label1.Text = listBox1.SelectedItem.ToString();
        }
        public void Export_click(object sender, EventArgs e)
        {
        }

#endregion

        private TextBox textBox1;
        private Label AnzWorker;
        private Button Export;
        private Button Start;
    }
}

