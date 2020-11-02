namespace DarkModeEnabler
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
            this.queryButton = new System.Windows.Forms.Button();
            this.windowsListBox = new System.Windows.Forms.ListBox();
            this.setButton = new System.Windows.Forms.Button();
            this.unsetButton = new System.Windows.Forms.Button();
            this.mainToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.aboutButton = new DarkModeEnabler.IconButton();
            this.mainLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.setUnsetButtonsLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.toggleLogButton = new System.Windows.Forms.Button();
            this.mainLayoutPanel.SuspendLayout();
            this.setUnsetButtonsLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // queryButton
            // 
            this.queryButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.queryButton.Location = new System.Drawing.Point(3, 3);
            this.queryButton.Name = "queryButton";
            this.queryButton.Size = new System.Drawing.Size(126, 24);
            this.queryButton.TabIndex = 0;
            this.queryButton.Text = "&Query open windows";
            this.queryButton.UseVisualStyleBackColor = true;
            this.queryButton.Click += new System.EventHandler(this.queryButton_Click);
            // 
            // windowsListBox
            // 
            this.windowsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainLayoutPanel.SetColumnSpan(this.windowsListBox, 2);
            this.windowsListBox.FormattingEnabled = true;
            this.windowsListBox.IntegralHeight = false;
            this.windowsListBox.Location = new System.Drawing.Point(3, 35);
            this.windowsListBox.Name = "windowsListBox";
            this.windowsListBox.Size = new System.Drawing.Size(620, 295);
            this.windowsListBox.TabIndex = 2;
            // 
            // setButton
            // 
            this.setButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.setButton.Enabled = false;
            this.setButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.setButton.Location = new System.Drawing.Point(3, 3);
            this.setButton.Name = "setButton";
            this.setButton.Size = new System.Drawing.Size(75, 24);
            this.setButton.TabIndex = 0;
            this.setButton.Text = "&Set";
            this.setButton.UseVisualStyleBackColor = true;
            this.setButton.Click += new System.EventHandler(this.setButton_Click);
            // 
            // unsetButton
            // 
            this.unsetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.unsetButton.Enabled = false;
            this.unsetButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.unsetButton.Location = new System.Drawing.Point(84, 3);
            this.unsetButton.Name = "unsetButton";
            this.unsetButton.Size = new System.Drawing.Size(75, 24);
            this.unsetButton.TabIndex = 1;
            this.unsetButton.Text = "&Unset";
            this.unsetButton.UseVisualStyleBackColor = true;
            this.unsetButton.Click += new System.EventHandler(this.unsetButton_Click);
            // 
            // aboutButton
            // 
            this.aboutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.aboutButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.aboutButton.Icon = null;
            this.aboutButton.Location = new System.Drawing.Point(599, 338);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(24, 24);
            this.aboutButton.TabIndex = 4;
            this.aboutButton.Text = "&i";
            this.mainToolTip.SetToolTip(this.aboutButton, "About...");
            this.aboutButton.UseVisualStyleBackColor = true;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // mainLayoutPanel
            // 
            this.mainLayoutPanel.ColumnCount = 2;
            this.mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainLayoutPanel.Controls.Add(this.setUnsetButtonsLayoutPanel, 0, 2);
            this.mainLayoutPanel.Controls.Add(this.aboutButton, 1, 2);
            this.mainLayoutPanel.Controls.Add(this.queryButton, 0, 0);
            this.mainLayoutPanel.Controls.Add(this.windowsListBox, 0, 1);
            this.mainLayoutPanel.Controls.Add(this.toggleLogButton, 1, 0);
            this.mainLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayoutPanel.Location = new System.Drawing.Point(12, 12);
            this.mainLayoutPanel.Name = "mainLayoutPanel";
            this.mainLayoutPanel.RowCount = 3;
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mainLayoutPanel.Size = new System.Drawing.Size(626, 365);
            this.mainLayoutPanel.TabIndex = 6;
            // 
            // setUnsetButtonsLayoutPanel
            // 
            this.setUnsetButtonsLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.setUnsetButtonsLayoutPanel.AutoSize = true;
            this.setUnsetButtonsLayoutPanel.Controls.Add(this.setButton);
            this.setUnsetButtonsLayoutPanel.Controls.Add(this.unsetButton);
            this.setUnsetButtonsLayoutPanel.Location = new System.Drawing.Point(0, 335);
            this.setUnsetButtonsLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.setUnsetButtonsLayoutPanel.Name = "setUnsetButtonsLayoutPanel";
            this.setUnsetButtonsLayoutPanel.Size = new System.Drawing.Size(162, 30);
            this.setUnsetButtonsLayoutPanel.TabIndex = 3;
            // 
            // toggleLogButton
            // 
            this.toggleLogButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.toggleLogButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.toggleLogButton.Location = new System.Drawing.Point(548, 3);
            this.toggleLogButton.Name = "toggleLogButton";
            this.toggleLogButton.Size = new System.Drawing.Size(75, 24);
            this.toggleLogButton.TabIndex = 1;
            this.toggleLogButton.Text = "Hide &log";
            this.toggleLogButton.UseVisualStyleBackColor = true;
            this.toggleLogButton.Click += new System.EventHandler(this.toggleLogButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(650, 389);
            this.Controls.Add(this.mainLayoutPanel);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(380, 260);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(12);
            this.Text = "Dark mode setter";
            this.mainLayoutPanel.ResumeLayout(false);
            this.mainLayoutPanel.PerformLayout();
            this.setUnsetButtonsLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button queryButton;
        private System.Windows.Forms.ListBox windowsListBox;
        private System.Windows.Forms.Button setButton;
        private System.Windows.Forms.Button unsetButton;
        private IconButton aboutButton;
        private System.Windows.Forms.ToolTip mainToolTip;
        private System.Windows.Forms.TableLayoutPanel mainLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel setUnsetButtonsLayoutPanel;
        private System.Windows.Forms.Button toggleLogButton;
    }
}

