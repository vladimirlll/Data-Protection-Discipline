namespace DI.Lab3.Code
{
    partial class MatrixSettings
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
            groupBox7 = new GroupBox();
            buttonEditSettings = new Button();
            textBoxRightsUserToObject = new TextBox();
            label11 = new Label();
            comboBoxMatrixObjects = new ComboBox();
            label10 = new Label();
            textBoxUserRights = new TextBox();
            label9 = new Label();
            label8 = new Label();
            comboBoxMatrixUsers = new ComboBox();
            groupBox4 = new GroupBox();
            groupBox6 = new GroupBox();
            comboBoxObjects = new ComboBox();
            label7 = new Label();
            buttonDeleteObject = new Button();
            groupBox5 = new GroupBox();
            buttonDeleteUser = new Button();
            label6 = new Label();
            comboBoxUsers = new ComboBox();
            groupBox1 = new GroupBox();
            groupBox3 = new GroupBox();
            textBoxObjectName = new TextBox();
            buttonAddObject = new Button();
            label4 = new Label();
            groupBox2 = new GroupBox();
            textBoxUserName = new TextBox();
            label3 = new Label();
            buttonAddUser = new Button();
            label1 = new Label();
            groupBox7.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(buttonEditSettings);
            groupBox7.Controls.Add(textBoxRightsUserToObject);
            groupBox7.Controls.Add(label11);
            groupBox7.Controls.Add(comboBoxMatrixObjects);
            groupBox7.Controls.Add(label10);
            groupBox7.Controls.Add(textBoxUserRights);
            groupBox7.Controls.Add(label9);
            groupBox7.Controls.Add(label8);
            groupBox7.Controls.Add(comboBoxMatrixUsers);
            groupBox7.Location = new Point(10, 319);
            groupBox7.Margin = new Padding(3, 2, 3, 2);
            groupBox7.Name = "groupBox7";
            groupBox7.Padding = new Padding(3, 2, 3, 2);
            groupBox7.Size = new Size(679, 174);
            groupBox7.TabIndex = 5;
            groupBox7.TabStop = false;
            groupBox7.Text = "Матрица прав доступа и привилегии";
            // 
            // buttonEditSettings
            // 
            buttonEditSettings.Location = new Point(9, 135);
            buttonEditSettings.Margin = new Padding(3, 2, 3, 2);
            buttonEditSettings.Name = "buttonEditSettings";
            buttonEditSettings.Size = new Size(654, 34);
            buttonEditSettings.TabIndex = 8;
            buttonEditSettings.Text = "Редактировать";
            buttonEditSettings.UseVisualStyleBackColor = true;
            buttonEditSettings.Click += buttonEditSettings_Click;
            // 
            // textBoxRightsUserToObject
            // 
            textBoxRightsUserToObject.Location = new Point(520, 95);
            textBoxRightsUserToObject.Margin = new Padding(3, 2, 3, 2);
            textBoxRightsUserToObject.Name = "textBoxRightsUserToObject";
            textBoxRightsUserToObject.Size = new Size(54, 23);
            textBoxRightsUserToObject.TabIndex = 7;
            textBoxRightsUserToObject.Visible = false;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(248, 97);
            label11.Name = "label11";
            label11.Size = new Size(206, 15);
            label11.TabIndex = 6;
            label11.Text = "Права пользователя к объекту (0-2):";
            label11.Visible = false;
            // 
            // comboBoxMatrixObjects
            // 
            comboBoxMatrixObjects.FormattingEnabled = true;
            comboBoxMatrixObjects.Location = new Point(9, 95);
            comboBoxMatrixObjects.Margin = new Padding(3, 2, 3, 2);
            comboBoxMatrixObjects.Name = "comboBoxMatrixObjects";
            comboBoxMatrixObjects.Size = new Size(233, 23);
            comboBoxMatrixObjects.TabIndex = 5;
            comboBoxMatrixObjects.Visible = false;
            comboBoxMatrixObjects.SelectedIndexChanged += comboBoxMatrixObjects_SelectedIndexChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(9, 77);
            label10.Name = "label10";
            label10.Size = new Size(102, 15);
            label10.TabIndex = 4;
            label10.Text = "Выберите объект";
            label10.Visible = false;
            // 
            // textBoxUserRights
            // 
            textBoxUserRights.Location = new Point(520, 46);
            textBoxUserRights.Margin = new Padding(3, 2, 3, 2);
            textBoxUserRights.Name = "textBoxUserRights";
            textBoxUserRights.Size = new Size(54, 23);
            textBoxUserRights.TabIndex = 3;
            textBoxUserRights.Visible = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(248, 47);
            label9.Name = "label9";
            label9.Size = new Size(238, 15);
            label9.TabIndex = 2;
            label9.Text = "Права по редактированию матрицы (0-1):";
            label9.Visible = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(7, 27);
            label8.Name = "label8";
            label8.Size = new Size(139, 15);
            label8.TabIndex = 1;
            label8.Text = "Выберите пользователя";
            // 
            // comboBoxMatrixUsers
            // 
            comboBoxMatrixUsers.FormattingEnabled = true;
            comboBoxMatrixUsers.Location = new Point(9, 46);
            comboBoxMatrixUsers.Margin = new Padding(3, 2, 3, 2);
            comboBoxMatrixUsers.Name = "comboBoxMatrixUsers";
            comboBoxMatrixUsers.Size = new Size(233, 23);
            comboBoxMatrixUsers.TabIndex = 0;
            comboBoxMatrixUsers.SelectedIndexChanged += comboBoxMatrixUsers_SelectedIndexChanged;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(groupBox6);
            groupBox4.Controls.Add(groupBox5);
            groupBox4.Location = new Point(10, 189);
            groupBox4.Margin = new Padding(3, 2, 3, 2);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(3, 2, 3, 2);
            groupBox4.Size = new Size(679, 125);
            groupBox4.TabIndex = 4;
            groupBox4.TabStop = false;
            groupBox4.Text = "Удаление";
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(comboBoxObjects);
            groupBox6.Controls.Add(label7);
            groupBox6.Controls.Add(buttonDeleteObject);
            groupBox6.Location = new Point(359, 20);
            groupBox6.Margin = new Padding(3, 2, 3, 2);
            groupBox6.Name = "groupBox6";
            groupBox6.Padding = new Padding(3, 2, 3, 2);
            groupBox6.Size = new Size(310, 101);
            groupBox6.TabIndex = 1;
            groupBox6.TabStop = false;
            groupBox6.Text = "Удаление объектов";
            // 
            // comboBoxObjects
            // 
            comboBoxObjects.FormattingEnabled = true;
            comboBoxObjects.Location = new Point(5, 43);
            comboBoxObjects.Margin = new Padding(3, 2, 3, 2);
            comboBoxObjects.Name = "comboBoxObjects";
            comboBoxObjects.Size = new Size(300, 23);
            comboBoxObjects.TabIndex = 2;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(5, 25);
            label7.Name = "label7";
            label7.Size = new Size(102, 15);
            label7.TabIndex = 1;
            label7.Text = "Выберите объект";
            // 
            // buttonDeleteObject
            // 
            buttonDeleteObject.Location = new Point(5, 68);
            buttonDeleteObject.Margin = new Padding(3, 2, 3, 2);
            buttonDeleteObject.Name = "buttonDeleteObject";
            buttonDeleteObject.Size = new Size(299, 28);
            buttonDeleteObject.TabIndex = 0;
            buttonDeleteObject.Text = "Удалить объект";
            buttonDeleteObject.UseVisualStyleBackColor = true;
            buttonDeleteObject.Click += buttonDeleteObject_Click;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(buttonDeleteUser);
            groupBox5.Controls.Add(label6);
            groupBox5.Controls.Add(comboBoxUsers);
            groupBox5.Location = new Point(9, 20);
            groupBox5.Margin = new Padding(3, 2, 3, 2);
            groupBox5.Name = "groupBox5";
            groupBox5.Padding = new Padding(3, 2, 3, 2);
            groupBox5.Size = new Size(340, 101);
            groupBox5.TabIndex = 0;
            groupBox5.TabStop = false;
            groupBox5.Text = "Удаление пользователей";
            // 
            // buttonDeleteUser
            // 
            buttonDeleteUser.Location = new Point(5, 68);
            buttonDeleteUser.Margin = new Padding(3, 2, 3, 2);
            buttonDeleteUser.Name = "buttonDeleteUser";
            buttonDeleteUser.Size = new Size(329, 28);
            buttonDeleteUser.TabIndex = 2;
            buttonDeleteUser.Text = "Удалить пользователя";
            buttonDeleteUser.UseVisualStyleBackColor = true;
            buttonDeleteUser.Click += buttonDeleteUser_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(5, 25);
            label6.Name = "label6";
            label6.Size = new Size(139, 15);
            label6.TabIndex = 1;
            label6.Text = "Выберите пользователя";
            // 
            // comboBoxUsers
            // 
            comboBoxUsers.FormattingEnabled = true;
            comboBoxUsers.Location = new Point(7, 43);
            comboBoxUsers.Margin = new Padding(3, 2, 3, 2);
            comboBoxUsers.Name = "comboBoxUsers";
            comboBoxUsers.Size = new Size(328, 23);
            comboBoxUsers.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(groupBox3);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 11);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(677, 174);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Добавление";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(textBoxObjectName);
            groupBox3.Controls.Add(buttonAddObject);
            groupBox3.Controls.Add(label4);
            groupBox3.Location = new Point(357, 21);
            groupBox3.Margin = new Padding(3, 2, 3, 2);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 2, 3, 2);
            groupBox3.Size = new Size(315, 148);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Добавление объектов";
            // 
            // textBoxObjectName
            // 
            textBoxObjectName.Location = new Point(5, 45);
            textBoxObjectName.Margin = new Padding(3, 2, 3, 2);
            textBoxObjectName.Name = "textBoxObjectName";
            textBoxObjectName.Size = new Size(305, 23);
            textBoxObjectName.TabIndex = 3;
            // 
            // buttonAddObject
            // 
            buttonAddObject.Location = new Point(5, 112);
            buttonAddObject.Margin = new Padding(3, 2, 3, 2);
            buttonAddObject.Name = "buttonAddObject";
            buttonAddObject.Size = new Size(304, 32);
            buttonAddObject.TabIndex = 2;
            buttonAddObject.Text = "Добавить объект";
            buttonAddObject.UseVisualStyleBackColor = true;
            buttonAddObject.Click += buttonAddObject_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(5, 27);
            label4.Name = "label4";
            label4.Size = new Size(78, 15);
            label4.TabIndex = 0;
            label4.Text = "Имя объекта";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(textBoxUserName);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(buttonAddUser);
            groupBox2.Location = new Point(12, 21);
            groupBox2.Margin = new Padding(3, 2, 3, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 2, 3, 2);
            groupBox2.Size = new Size(340, 148);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Добавление пользователей";
            // 
            // textBoxUserName
            // 
            textBoxUserName.Location = new Point(5, 46);
            textBoxUserName.Margin = new Padding(3, 2, 3, 2);
            textBoxUserName.Name = "textBoxUserName";
            textBoxUserName.Size = new Size(330, 23);
            textBoxUserName.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(5, 27);
            label3.Name = "label3";
            label3.Size = new Size(109, 15);
            label3.TabIndex = 3;
            label3.Text = "Имя пользователя";
            // 
            // buttonAddUser
            // 
            buttonAddUser.Location = new Point(5, 112);
            buttonAddUser.Margin = new Padding(3, 2, 3, 2);
            buttonAddUser.Name = "buttonAddUser";
            buttonAddUser.Size = new Size(329, 32);
            buttonAddUser.TabIndex = 2;
            buttonAddUser.Text = "Добавить пользователя";
            buttonAddUser.UseVisualStyleBackColor = true;
            buttonAddUser.Click += buttonAddUser_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 20);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 1;
            // 
            // MatrixSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(763, 526);
            Controls.Add(groupBox7);
            Controls.Add(groupBox4);
            Controls.Add(groupBox1);
            Name = "MatrixSettings";
            Text = "Редактирование матрицы";
            Load += MatrixSettings_Load;
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox7;
        private Button buttonEditSettings;
        private TextBox textBoxRightsUserToObject;
        private Label label11;
        private ComboBox comboBoxMatrixObjects;
        private Label label10;
        private TextBox textBoxUserRights;
        private Label label9;
        private Label label8;
        private ComboBox comboBoxMatrixUsers;
        private GroupBox groupBox4;
        private GroupBox groupBox6;
        private ComboBox comboBoxObjects;
        private Label label7;
        private Button buttonDeleteObject;
        private GroupBox groupBox5;
        private Button buttonDeleteUser;
        private Label label6;
        private ComboBox comboBoxUsers;
        private GroupBox groupBox1;
        private GroupBox groupBox3;
        private TextBox textBoxObjectName;
        private Button buttonAddObject;
        private Label label4;
        private GroupBox groupBox2;
        private TextBox textBoxUserName;
        private Label label3;
        private Button buttonAddUser;
        private Label label1;
    }
}