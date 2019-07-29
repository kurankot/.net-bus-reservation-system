namespace Bus_reservation_system
{
    partial class Form1
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
            this.input_time = new System.Windows.Forms.DateTimePicker();
            this.label_time = new System.Windows.Forms.Label();
            this.input_date = new System.Windows.Forms.DateTimePicker();
            this.labe_date = new System.Windows.Forms.Label();
            this.search_button = new System.Windows.Forms.Button();
            this.input_to = new System.Windows.Forms.TextBox();
            this.input_from = new System.Windows.Forms.TextBox();
            this.label_to = new System.Windows.Forms.Label();
            this.label_from = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // input_time
            // 
            this.input_time.Checked = false;
            this.input_time.CustomFormat = "HH:mm";
            this.input_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.input_time.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.input_time.Location = new System.Drawing.Point(106, 95);
            this.input_time.Name = "input_time";
            this.input_time.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.input_time.ShowUpDown = true;
            this.input_time.Size = new System.Drawing.Size(208, 23);
            this.input_time.TabIndex = 17;
            // 
            // label_time
            // 
            this.label_time.AutoSize = true;
            this.label_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_time.Location = new System.Drawing.Point(25, 98);
            this.label_time.Name = "label_time";
            this.label_time.Size = new System.Drawing.Size(41, 20);
            this.label_time.TabIndex = 16;
            this.label_time.Text = "Čas:";
            // 
            // input_date
            // 
            this.input_date.CustomFormat = "d.M.yyyy";
            this.input_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.input_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.input_date.Location = new System.Drawing.Point(106, 134);
            this.input_date.Name = "input_date";
            this.input_date.Size = new System.Drawing.Size(208, 23);
            this.input_date.TabIndex = 15;
            // 
            // labe_date
            // 
            this.labe_date.AutoSize = true;
            this.labe_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labe_date.Location = new System.Drawing.Point(25, 134);
            this.labe_date.Name = "labe_date";
            this.labe_date.Size = new System.Drawing.Size(61, 20);
            this.labe_date.TabIndex = 14;
            this.labe_date.Text = "Dátum:";
            // 
            // search_button
            // 
            this.search_button.Location = new System.Drawing.Point(219, 174);
            this.search_button.Name = "search_button";
            this.search_button.Size = new System.Drawing.Size(95, 29);
            this.search_button.TabIndex = 13;
            this.search_button.Text = "Vyhľadať";
            this.search_button.UseVisualStyleBackColor = true;
            // 
            // input_to
            // 
            this.input_to.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.input_to.Location = new System.Drawing.Point(106, 60);
            this.input_to.Name = "input_to";
            this.input_to.Size = new System.Drawing.Size(208, 23);
            this.input_to.TabIndex = 12;
            // 
            // input_from
            // 
            this.input_from.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.input_from.Location = new System.Drawing.Point(106, 23);
            this.input_from.Name = "input_from";
            this.input_from.Size = new System.Drawing.Size(208, 23);
            this.input_from.TabIndex = 11;
            // 
            // label_to
            // 
            this.label_to.AutoSize = true;
            this.label_to.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_to.Location = new System.Drawing.Point(25, 60);
            this.label_to.Name = "label_to";
            this.label_to.Size = new System.Drawing.Size(45, 20);
            this.label_to.TabIndex = 10;
            this.label_to.Text = "Kam:";
            // 
            // label_from
            // 
            this.label_from.AutoSize = true;
            this.label_from.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_from.Location = new System.Drawing.Point(25, 26);
            this.label_from.Name = "label_from";
            this.label_from.Size = new System.Drawing.Size(59, 20);
            this.label_from.TabIndex = 9;
            this.label_from.Text = "Odkiaľ:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.input_time);
            this.Controls.Add(this.label_time);
            this.Controls.Add(this.input_date);
            this.Controls.Add(this.labe_date);
            this.Controls.Add(this.search_button);
            this.Controls.Add(this.input_to);
            this.Controls.Add(this.input_from);
            this.Controls.Add(this.label_to);
            this.Controls.Add(this.label_from);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker input_time;
        private System.Windows.Forms.Label label_time;
        private System.Windows.Forms.DateTimePicker input_date;
        private System.Windows.Forms.Label labe_date;
        private System.Windows.Forms.Button search_button;
        private System.Windows.Forms.TextBox input_to;
        private System.Windows.Forms.TextBox input_from;
        private System.Windows.Forms.Label label_to;
        private System.Windows.Forms.Label label_from;
    }
}

