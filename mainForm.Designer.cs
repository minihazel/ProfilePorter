namespace SelfDestruct
{
    partial class mainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.oldProfilePanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.oldProfilePlaceholder = new System.Windows.Forms.Label();
            this.placeholderTitle = new System.Windows.Forms.Label();
            this.displayProfileCounter = new System.Windows.Forms.Label();
            this.profileTimer = new System.Windows.Forms.Timer(this.components);
            this.bBrowse = new System.Windows.Forms.Button();
            this.pathBrowse = new System.Windows.Forms.Label();
            this.placeholderLbl = new System.Windows.Forms.Label();
            this.bBrowse2 = new System.Windows.Forms.Label();
            this.bClearList = new System.Windows.Forms.Label();
            this.oldProfilePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // oldProfilePanel
            // 
            this.oldProfilePanel.AllowDrop = true;
            this.oldProfilePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.oldProfilePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.oldProfilePanel.Controls.Add(this.oldProfilePlaceholder);
            this.oldProfilePanel.Location = new System.Drawing.Point(47, 88);
            this.oldProfilePanel.Name = "oldProfilePanel";
            this.oldProfilePanel.Size = new System.Drawing.Size(688, 227);
            this.oldProfilePanel.TabIndex = 0;
            this.oldProfilePanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.oldProfilePanel_DragDrop);
            this.oldProfilePanel.DragEnter += new System.Windows.Forms.DragEventHandler(this.oldProfilePanel_DragEnter);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Bahnschrift Light", 10F);
            this.label1.Location = new System.Drawing.Point(47, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "Drag and drop your profile(s) below:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // oldProfilePlaceholder
            // 
            this.oldProfilePlaceholder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.oldProfilePlaceholder.Font = new System.Drawing.Font("Bahnschrift Light", 8F);
            this.oldProfilePlaceholder.Location = new System.Drawing.Point(-1, 0);
            this.oldProfilePlaceholder.Name = "oldProfilePlaceholder";
            this.oldProfilePlaceholder.Size = new System.Drawing.Size(688, 26);
            this.oldProfilePlaceholder.TabIndex = 2;
            this.oldProfilePlaceholder.Text = "440eb7fa4f98f14894176bb8.json";
            this.oldProfilePlaceholder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.oldProfilePlaceholder.Visible = false;
            // 
            // placeholderTitle
            // 
            this.placeholderTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.placeholderTitle.Font = new System.Drawing.Font("Courier New", 14F);
            this.placeholderTitle.Location = new System.Drawing.Point(47, 9);
            this.placeholderTitle.Name = "placeholderTitle";
            this.placeholderTitle.Size = new System.Drawing.Size(688, 50);
            this.placeholderTitle.TabIndex = 2;
            this.placeholderTitle.Text = "SPT-AKI Profile Porter";
            this.placeholderTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // displayProfileCounter
            // 
            this.displayProfileCounter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.displayProfileCounter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.displayProfileCounter.Font = new System.Drawing.Font("Bahnschrift Light", 10F);
            this.displayProfileCounter.Location = new System.Drawing.Point(599, 49);
            this.displayProfileCounter.Name = "displayProfileCounter";
            this.displayProfileCounter.Size = new System.Drawing.Size(136, 36);
            this.displayProfileCounter.TabIndex = 3;
            this.displayProfileCounter.Text = "Browse for profiles";
            this.displayProfileCounter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.displayProfileCounter.Click += new System.EventHandler(this.displayProfileCounter_Click);
            this.displayProfileCounter.MouseEnter += new System.EventHandler(this.displayProfileCounter_MouseEnter);
            this.displayProfileCounter.MouseLeave += new System.EventHandler(this.displayProfileCounter_MouseLeave);
            // 
            // profileTimer
            // 
            this.profileTimer.Interval = 300;
            // 
            // bBrowse
            // 
            this.bBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bBrowse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bBrowse.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.bBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bBrowse.Location = new System.Drawing.Point(47, 334);
            this.bBrowse.Name = "bBrowse";
            this.bBrowse.Size = new System.Drawing.Size(688, 40);
            this.bBrowse.TabIndex = 4;
            this.bBrowse.Text = "Select SPT folder to install to";
            this.bBrowse.UseVisualStyleBackColor = true;
            this.bBrowse.Visible = false;
            this.bBrowse.Click += new System.EventHandler(this.bBrowse_Click);
            // 
            // pathBrowse
            // 
            this.pathBrowse.AutoSize = true;
            this.pathBrowse.Font = new System.Drawing.Font("Bahnschrift Light", 8F);
            this.pathBrowse.Location = new System.Drawing.Point(44, 386);
            this.pathBrowse.Name = "pathBrowse";
            this.pathBrowse.Size = new System.Drawing.Size(66, 13);
            this.pathBrowse.TabIndex = 6;
            this.pathBrowse.Text = "Placeholder";
            this.pathBrowse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.pathBrowse.Visible = false;
            // 
            // placeholderLbl
            // 
            this.placeholderLbl.AutoSize = true;
            this.placeholderLbl.Font = new System.Drawing.Font("Bahnschrift Light", 10F);
            this.placeholderLbl.Location = new System.Drawing.Point(44, 408);
            this.placeholderLbl.Name = "placeholderLbl";
            this.placeholderLbl.Size = new System.Drawing.Size(23, 17);
            this.placeholderLbl.TabIndex = 7;
            this.placeholderLbl.Text = "Or";
            this.placeholderLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.placeholderLbl.Visible = false;
            // 
            // bBrowse2
            // 
            this.bBrowse2.AutoSize = true;
            this.bBrowse2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bBrowse2.Font = new System.Drawing.Font("Bahnschrift Light", 10F, System.Drawing.FontStyle.Underline);
            this.bBrowse2.Location = new System.Drawing.Point(64, 408);
            this.bBrowse2.Name = "bBrowse2";
            this.bBrowse2.Size = new System.Drawing.Size(138, 17);
            this.bBrowse2.TabIndex = 8;
            this.bBrowse2.Text = "try a different folder";
            this.bBrowse2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bBrowse2.Visible = false;
            this.bBrowse2.Click += new System.EventHandler(this.bBrowse2_Click);
            this.bBrowse2.MouseEnter += new System.EventHandler(this.bBrowse2_MouseEnter);
            this.bBrowse2.MouseLeave += new System.EventHandler(this.bBrowse2_MouseLeave);
            // 
            // bClearList
            // 
            this.bClearList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bClearList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bClearList.Font = new System.Drawing.Font("Bahnschrift Light", 10F);
            this.bClearList.Location = new System.Drawing.Point(341, 49);
            this.bClearList.Name = "bClearList";
            this.bClearList.Size = new System.Drawing.Size(252, 36);
            this.bClearList.TabIndex = 9;
            this.bClearList.Text = "Clear list";
            this.bClearList.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bClearList.Click += new System.EventHandler(this.bClearList_Click);
            this.bClearList.MouseEnter += new System.EventHandler(this.bClearList_MouseEnter);
            this.bClearList.MouseLeave += new System.EventHandler(this.bClearList_MouseLeave);
            // 
            // mainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(782, 461);
            this.Controls.Add(this.bClearList);
            this.Controls.Add(this.bBrowse2);
            this.Controls.Add(this.placeholderLbl);
            this.Controls.Add(this.oldProfilePanel);
            this.Controls.Add(this.pathBrowse);
            this.Controls.Add(this.bBrowse);
            this.Controls.Add(this.displayProfileCounter);
            this.Controls.Add(this.placeholderTitle);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Bahnschrift Light", 10F);
            this.ForeColor = System.Drawing.Color.LightGray;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Port SPT Profile";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.oldProfilePanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel oldProfilePanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label oldProfilePlaceholder;
        private System.Windows.Forms.Label placeholderTitle;
        private System.Windows.Forms.Label displayProfileCounter;
        private System.Windows.Forms.Timer profileTimer;
        private System.Windows.Forms.Button bBrowse;
        private System.Windows.Forms.Label pathBrowse;
        private System.Windows.Forms.Label placeholderLbl;
        private System.Windows.Forms.Label bBrowse2;
        private System.Windows.Forms.Label bClearList;
    }
}

