namespace teht23
{
    partial class FormSpeedTestGame
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonRed = new System.Windows.Forms.Button();
            this.buttonYellow = new System.Windows.Forms.Button();
            this.buttonGreen = new System.Windows.Forms.Button();
            this.buttonBlue = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.timerLight = new System.Windows.Forms.Timer(this.components);
            this.labelP = new System.Windows.Forms.Label();
            this.labelPoints = new System.Windows.Forms.Label();
            this.timerSeconds = new System.Windows.Forms.Timer(this.components);
            this.labelTime = new System.Windows.Forms.Label();
            this.listViewHighScores = new System.Windows.Forms.ListView();
            this.columnHeaderName = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderPoints = new System.Windows.Forms.ColumnHeader();
            this.labelScores = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonRed
            // 
            this.buttonRed.BackColor = System.Drawing.SystemColors.Control;
            this.buttonRed.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonRed.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonRed.Location = new System.Drawing.Point(21, 316);
            this.buttonRed.Name = "buttonRed";
            this.buttonRed.Size = new System.Drawing.Size(152, 95);
            this.buttonRed.TabIndex = 0;
            this.buttonRed.UseVisualStyleBackColor = false;
            this.buttonRed.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // buttonYellow
            // 
            this.buttonYellow.BackColor = System.Drawing.SystemColors.Control;
            this.buttonYellow.Location = new System.Drawing.Point(208, 316);
            this.buttonYellow.Name = "buttonYellow";
            this.buttonYellow.Size = new System.Drawing.Size(159, 95);
            this.buttonYellow.TabIndex = 1;
            this.buttonYellow.UseVisualStyleBackColor = false;
            this.buttonYellow.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // buttonGreen
            // 
            this.buttonGreen.BackColor = System.Drawing.SystemColors.Control;
            this.buttonGreen.Location = new System.Drawing.Point(411, 316);
            this.buttonGreen.Name = "buttonGreen";
            this.buttonGreen.Size = new System.Drawing.Size(159, 95);
            this.buttonGreen.TabIndex = 2;
            this.buttonGreen.UseVisualStyleBackColor = false;
            this.buttonGreen.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // buttonBlue
            // 
            this.buttonBlue.BackColor = System.Drawing.SystemColors.Control;
            this.buttonBlue.Location = new System.Drawing.Point(615, 316);
            this.buttonBlue.Name = "buttonBlue";
            this.buttonBlue.Size = new System.Drawing.Size(149, 95);
            this.buttonBlue.TabIndex = 3;
            this.buttonBlue.UseVisualStyleBackColor = false;
            this.buttonBlue.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.Color.White;
            this.buttonStart.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonStart.Location = new System.Drawing.Point(272, 41);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(226, 102);
            this.buttonStart.TabIndex = 4;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // timerLight
            // 
            this.timerLight.Interval = 3000;
            this.timerLight.Tick += new System.EventHandler(this.timerLight_Tick);
            // 
            // labelP
            // 
            this.labelP.AutoSize = true;
            this.labelP.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelP.Location = new System.Drawing.Point(21, 41);
            this.labelP.Name = "labelP";
            this.labelP.Size = new System.Drawing.Size(74, 28);
            this.labelP.TabIndex = 5;
            this.labelP.Text = "Points :";
            this.labelP.Visible = false;
            // 
            // labelPoints
            // 
            this.labelPoints.AutoSize = true;
            this.labelPoints.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelPoints.Location = new System.Drawing.Point(90, 41);
            this.labelPoints.Name = "labelPoints";
            this.labelPoints.Size = new System.Drawing.Size(133, 28);
            this.labelPoints.TabIndex = 6;
            this.labelPoints.Text = "[points here]";
            this.labelPoints.Visible = false;
            // 
            // timerSeconds
            // 
            this.timerSeconds.Interval = 1000;
            this.timerSeconds.Tick += new System.EventHandler(this.timerSeconds_Tick);
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelTime.Location = new System.Drawing.Point(35, 94);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(60, 28);
            this.labelTime.TabIndex = 7;
            this.labelTime.Text = "00:00";
            this.labelTime.Visible = false;
            // 
            // listViewHighScores
            // 
            this.listViewHighScores.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.columnHeaderPoints});
            this.listViewHighScores.HideSelection = false;
            this.listViewHighScores.Location = new System.Drawing.Point(513, 41);
            this.listViewHighScores.Name = "listViewHighScores";
            this.listViewHighScores.Size = new System.Drawing.Size(260, 255);
            this.listViewHighScores.TabIndex = 8;
            this.listViewHighScores.UseCompatibleStateImageBehavior = false;
            this.listViewHighScores.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Name";
            this.columnHeaderName.Width = 170;
            // 
            // columnHeaderPoints
            // 
            this.columnHeaderPoints.Text = "Points";
            this.columnHeaderPoints.Width = 80;
            // 
            // labelScores
            // 
            this.labelScores.AutoSize = true;
            this.labelScores.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelScores.Location = new System.Drawing.Point(553, 0);
            this.labelScores.Name = "labelScores";
            this.labelScores.Size = new System.Drawing.Size(157, 38);
            this.labelScores.TabIndex = 9;
            this.labelScores.Text = "HighScores";
            // 
            // FormSpeedTestGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelScores);
            this.Controls.Add(this.listViewHighScores);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.labelPoints);
            this.Controls.Add(this.labelP);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonBlue);
            this.Controls.Add(this.buttonGreen);
            this.Controls.Add(this.buttonYellow);
            this.Controls.Add(this.buttonRed);
            this.Name = "FormSpeedTestGame";
            this.Text = "Nopeustestipeli";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonYellow;
        private System.Windows.Forms.Button buttonGreen;
        private System.Windows.Forms.Button buttonBlue;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Timer timerLight;
        private System.Windows.Forms.Label labelP;
        private System.Windows.Forms.Label labelPoints;
        private System.Windows.Forms.Button buttonRed;
        private System.Windows.Forms.Timer timerSeconds;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.ListView listViewHighScores;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderPoints;
        private System.Windows.Forms.Label labelScores;
    }
}

