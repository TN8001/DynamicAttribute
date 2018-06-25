namespace DynamicAttribute
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        private void InitializeComponent()
        {
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.controlListBox = new System.Windows.Forms.ListBox();
            this.hideButton = new System.Windows.Forms.Button();
            this.hidePropertyListBox = new System.Windows.Forms.ListBox();
            this.showButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyGrid1.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.propertyGrid1.Location = new System.Drawing.Point(514, 12);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(323, 431);
            this.propertyGrid1.TabIndex = 0;
            // 
            // controlListBox
            // 
            this.controlListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.controlListBox.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.controlListBox.FormattingEnabled = true;
            this.controlListBox.ItemHeight = 24;
            this.controlListBox.Location = new System.Drawing.Point(12, 12);
            this.controlListBox.Name = "controlListBox";
            this.controlListBox.Size = new System.Drawing.Size(215, 436);
            this.controlListBox.TabIndex = 1;
            this.controlListBox.SelectedIndexChanged += new System.EventHandler(this.ControlListBox_SelectedIndexChanged);
            // 
            // hideButton
            // 
            this.hideButton.Location = new System.Drawing.Point(463, 87);
            this.hideButton.Name = "hideButton";
            this.hideButton.Size = new System.Drawing.Size(45, 47);
            this.hideButton.TabIndex = 2;
            this.hideButton.Text = "←\r\nDel";
            this.hideButton.UseVisualStyleBackColor = true;
            this.hideButton.Click += new System.EventHandler(this.HideButton_Click);
            // 
            // hidePropertyListBox
            // 
            this.hidePropertyListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.hidePropertyListBox.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.hidePropertyListBox.FormattingEnabled = true;
            this.hidePropertyListBox.ItemHeight = 24;
            this.hidePropertyListBox.Location = new System.Drawing.Point(233, 12);
            this.hidePropertyListBox.Name = "hidePropertyListBox";
            this.hidePropertyListBox.Size = new System.Drawing.Size(224, 436);
            this.hidePropertyListBox.TabIndex = 3;
            // 
            // showButton
            // 
            this.showButton.Location = new System.Drawing.Point(463, 201);
            this.showButton.Name = "showButton";
            this.showButton.Size = new System.Drawing.Size(45, 51);
            this.showButton.TabIndex = 4;
            this.showButton.Text = "→\r\nAdd";
            this.showButton.UseVisualStyleBackColor = true;
            this.showButton.Click += new System.EventHandler(this.ShowButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 455);
            this.Controls.Add(this.showButton);
            this.Controls.Add(this.hidePropertyListBox);
            this.Controls.Add(this.hideButton);
            this.Controls.Add(this.controlListBox);
            this.Controls.Add(this.propertyGrid1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.ListBox controlListBox;
        private System.Windows.Forms.Button hideButton;
        private System.Windows.Forms.ListBox hidePropertyListBox;
        private System.Windows.Forms.Button showButton;
    }
}

