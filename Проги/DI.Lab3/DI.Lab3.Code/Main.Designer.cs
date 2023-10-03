namespace DI.Lab3.Code
{
    partial class Main
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
            buttonEditAccessRights = new Button();
            comboBoxUsers = new ComboBox();
            label1 = new Label();
            groupBox1 = new GroupBox();
            richTextBox1 = new RichTextBox();
            listBoxObjects = new ListBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // buttonEditAccessRights
            // 
            buttonEditAccessRights.Enabled = false;
            buttonEditAccessRights.Location = new Point(405, 22);
            buttonEditAccessRights.Margin = new Padding(3, 2, 3, 2);
            buttonEditAccessRights.Name = "buttonEditAccessRights";
            buttonEditAccessRights.Size = new Size(282, 22);
            buttonEditAccessRights.TabIndex = 8;
            buttonEditAccessRights.Text = "Редактировать права доступа";
            buttonEditAccessRights.UseVisualStyleBackColor = true;
            buttonEditAccessRights.Click += buttonEditAccessRights_Click;
            // 
            // comboBoxUsers
            // 
            comboBoxUsers.FormattingEnabled = true;
            comboBoxUsers.Location = new Point(171, 22);
            comboBoxUsers.Margin = new Padding(3, 2, 3, 2);
            comboBoxUsers.Name = "comboBoxUsers";
            comboBoxUsers.Size = new Size(216, 23);
            comboBoxUsers.TabIndex = 7;
            comboBoxUsers.SelectedIndexChanged += comboBoxUsers_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(19, 19);
            label1.Name = "label1";
            label1.Size = new Size(122, 21);
            label1.TabIndex = 6;
            label1.Text = "Пользователь";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(richTextBox1);
            groupBox1.Controls.Add(listBoxObjects);
            groupBox1.Location = new Point(12, 70);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(679, 275);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Объект";
            // 
            // richTextBox1
            // 
            richTextBox1.Enabled = false;
            richTextBox1.Location = new Point(214, 20);
            richTextBox1.Margin = new Padding(3, 2, 3, 2);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(461, 244);
            richTextBox1.TabIndex = 2;
            richTextBox1.Text = "";
            richTextBox1.TextChanged += richTextBox1_TextChanged;
            // 
            // listBoxObjects
            // 
            listBoxObjects.FormattingEnabled = true;
            listBoxObjects.ItemHeight = 15;
            listBoxObjects.Location = new Point(5, 20);
            listBoxObjects.Margin = new Padding(3, 2, 3, 2);
            listBoxObjects.Name = "listBoxObjects";
            listBoxObjects.Size = new Size(190, 244);
            listBoxObjects.TabIndex = 0;
            listBoxObjects.SelectedIndexChanged += listBoxObjects_SelectedIndexChanged;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(811, 455);
            Controls.Add(buttonEditAccessRights);
            Controls.Add(comboBoxUsers);
            Controls.Add(label1);
            Controls.Add(groupBox1);
            Name = "Main";
            Text = "Просмотр пользователей и объектов";
            Load += Main_Load;
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonEditAccessRights;
        private ComboBox comboBoxUsers;
        private Label label1;
        private GroupBox groupBox1;
        private RichTextBox richTextBox1;
        private ListBox listBoxObjects;
    }
}