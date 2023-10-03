namespace Lab4_IP
{
    partial class FormSettings
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxObjectName = new System.Windows.Forms.TextBox();
            this.buttonAddObject = new System.Windows.Forms.Button();
            this.comboBoxObjectPrivilege = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonAddUser = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxUserPrivilege = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.comboBoxObjects = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonDeleteObject = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.buttonDeleteUser = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxUsers = new System.Windows.Forms.ComboBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.buttonEditSettings = new System.Windows.Forms.Button();
            this.textBoxRightsUserToObject = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBoxMatrixObjects = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxUserRights = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxMatrixUsers = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(14, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(774, 232);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Добавление";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.textBoxObjectName);
            this.groupBox3.Controls.Add(this.buttonAddObject);
            this.groupBox3.Controls.Add(this.comboBoxObjectPrivilege);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(408, 28);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(360, 198);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Добавление объектов";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(154, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Привилегия объекта";
            // 
            // textBoxObjectName
            // 
            this.textBoxObjectName.Location = new System.Drawing.Point(6, 60);
            this.textBoxObjectName.Name = "textBoxObjectName";
            this.textBoxObjectName.Size = new System.Drawing.Size(348, 27);
            this.textBoxObjectName.TabIndex = 3;
            // 
            // buttonAddObject
            // 
            this.buttonAddObject.Location = new System.Drawing.Point(6, 149);
            this.buttonAddObject.Name = "buttonAddObject";
            this.buttonAddObject.Size = new System.Drawing.Size(348, 43);
            this.buttonAddObject.TabIndex = 2;
            this.buttonAddObject.Text = "Добавить объект";
            this.buttonAddObject.UseVisualStyleBackColor = true;
            this.buttonAddObject.Click += new System.EventHandler(this.buttonAddObject_Click);
            // 
            // comboBoxObjectPrivilege
            // 
            this.comboBoxObjectPrivilege.FormattingEnabled = true;
            this.comboBoxObjectPrivilege.Location = new System.Drawing.Point(6, 115);
            this.comboBoxObjectPrivilege.Name = "comboBoxObjectPrivilege";
            this.comboBoxObjectPrivilege.Size = new System.Drawing.Size(348, 28);
            this.comboBoxObjectPrivilege.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Имя объекта";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxUserName);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.buttonAddUser);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.comboBoxUserPrivilege);
            this.groupBox2.Location = new System.Drawing.Point(14, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(388, 198);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Добавление пользователей";
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(6, 62);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(376, 27);
            this.textBoxUserName.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Имя пользователя";
            // 
            // buttonAddUser
            // 
            this.buttonAddUser.Location = new System.Drawing.Point(6, 149);
            this.buttonAddUser.Name = "buttonAddUser";
            this.buttonAddUser.Size = new System.Drawing.Size(376, 43);
            this.buttonAddUser.TabIndex = 2;
            this.buttonAddUser.Text = "Добавить пользователя";
            this.buttonAddUser.UseVisualStyleBackColor = true;
            this.buttonAddUser.Click += new System.EventHandler(this.buttonAddUser_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Привилегия пользователя";
            // 
            // comboBoxUserPrivilege
            // 
            this.comboBoxUserPrivilege.FormattingEnabled = true;
            this.comboBoxUserPrivilege.Location = new System.Drawing.Point(6, 115);
            this.comboBoxUserPrivilege.Name = "comboBoxUserPrivilege";
            this.comboBoxUserPrivilege.Size = new System.Drawing.Size(376, 28);
            this.comboBoxUserPrivilege.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox6);
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Location = new System.Drawing.Point(12, 254);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(776, 167);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Удаление";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.comboBoxObjects);
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Controls.Add(this.buttonDeleteObject);
            this.groupBox6.Location = new System.Drawing.Point(410, 26);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(354, 135);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Удаление объектов";
            // 
            // comboBoxObjects
            // 
            this.comboBoxObjects.FormattingEnabled = true;
            this.comboBoxObjects.Location = new System.Drawing.Point(6, 57);
            this.comboBoxObjects.Name = "comboBoxObjects";
            this.comboBoxObjects.Size = new System.Drawing.Size(342, 28);
            this.comboBoxObjects.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 20);
            this.label7.TabIndex = 1;
            this.label7.Text = "Выберите объект";
            // 
            // buttonDeleteObject
            // 
            this.buttonDeleteObject.Location = new System.Drawing.Point(6, 91);
            this.buttonDeleteObject.Name = "buttonDeleteObject";
            this.buttonDeleteObject.Size = new System.Drawing.Size(342, 38);
            this.buttonDeleteObject.TabIndex = 0;
            this.buttonDeleteObject.Text = "Удалить объект";
            this.buttonDeleteObject.UseVisualStyleBackColor = true;
            this.buttonDeleteObject.Click += new System.EventHandler(this.buttonDeleteObject_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.buttonDeleteUser);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.comboBoxUsers);
            this.groupBox5.Location = new System.Drawing.Point(10, 26);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(388, 135);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Удаление пользователей";
            // 
            // buttonDeleteUser
            // 
            this.buttonDeleteUser.Location = new System.Drawing.Point(6, 91);
            this.buttonDeleteUser.Name = "buttonDeleteUser";
            this.buttonDeleteUser.Size = new System.Drawing.Size(376, 38);
            this.buttonDeleteUser.TabIndex = 2;
            this.buttonDeleteUser.Text = "Удалить пользователя";
            this.buttonDeleteUser.UseVisualStyleBackColor = true;
            this.buttonDeleteUser.Click += new System.EventHandler(this.buttonDeleteUser_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(178, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "Выберите пользователя";
            // 
            // comboBoxUsers
            // 
            this.comboBoxUsers.FormattingEnabled = true;
            this.comboBoxUsers.Location = new System.Drawing.Point(8, 57);
            this.comboBoxUsers.Name = "comboBoxUsers";
            this.comboBoxUsers.Size = new System.Drawing.Size(374, 28);
            this.comboBoxUsers.TabIndex = 0;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.buttonEditSettings);
            this.groupBox7.Controls.Add(this.textBoxRightsUserToObject);
            this.groupBox7.Controls.Add(this.label11);
            this.groupBox7.Controls.Add(this.comboBoxMatrixObjects);
            this.groupBox7.Controls.Add(this.label10);
            this.groupBox7.Controls.Add(this.textBoxUserRights);
            this.groupBox7.Controls.Add(this.label9);
            this.groupBox7.Controls.Add(this.label8);
            this.groupBox7.Controls.Add(this.comboBoxMatrixUsers);
            this.groupBox7.Location = new System.Drawing.Point(12, 427);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(776, 232);
            this.groupBox7.TabIndex = 2;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Матрица прав доступа и привилегии";
            // 
            // buttonEditSettings
            // 
            this.buttonEditSettings.Location = new System.Drawing.Point(10, 180);
            this.buttonEditSettings.Name = "buttonEditSettings";
            this.buttonEditSettings.Size = new System.Drawing.Size(748, 46);
            this.buttonEditSettings.TabIndex = 8;
            this.buttonEditSettings.Text = "Редактировать";
            this.buttonEditSettings.UseVisualStyleBackColor = true;
            this.buttonEditSettings.Click += new System.EventHandler(this.buttonEditSettings_Click);
            // 
            // textBoxRightsUserToObject
            // 
            this.textBoxRightsUserToObject.Location = new System.Drawing.Point(594, 127);
            this.textBoxRightsUserToObject.Name = "textBoxRightsUserToObject";
            this.textBoxRightsUserToObject.Size = new System.Drawing.Size(61, 27);
            this.textBoxRightsUserToObject.TabIndex = 7;
            this.textBoxRightsUserToObject.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(284, 130);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(262, 20);
            this.label11.TabIndex = 6;
            this.label11.Text = "Права пользователя к объекту (0-2):";
            this.label11.Visible = false;
            // 
            // comboBoxMatrixObjects
            // 
            this.comboBoxMatrixObjects.FormattingEnabled = true;
            this.comboBoxMatrixObjects.Location = new System.Drawing.Point(10, 127);
            this.comboBoxMatrixObjects.Name = "comboBoxMatrixObjects";
            this.comboBoxMatrixObjects.Size = new System.Drawing.Size(266, 28);
            this.comboBoxMatrixObjects.TabIndex = 5;
            this.comboBoxMatrixObjects.Visible = false;
            this.comboBoxMatrixObjects.SelectedIndexChanged += new System.EventHandler(this.comboBoxMatrixObjects_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 104);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(130, 20);
            this.label10.TabIndex = 4;
            this.label10.Text = "Выберите объект";
            this.label10.Visible = false;
            // 
            // textBoxUserRights
            // 
            this.textBoxUserRights.Location = new System.Drawing.Point(594, 61);
            this.textBoxUserRights.Name = "textBoxUserRights";
            this.textBoxUserRights.Size = new System.Drawing.Size(61, 27);
            this.textBoxUserRights.TabIndex = 3;
            this.textBoxUserRights.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(284, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(304, 20);
            this.label9.TabIndex = 2;
            this.label9.Text = "Права по редактированию матрицы (0-1):";
            this.label9.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(178, 20);
            this.label8.TabIndex = 1;
            this.label8.Text = "Выберите пользователя";
            // 
            // comboBoxMatrixUsers
            // 
            this.comboBoxMatrixUsers.FormattingEnabled = true;
            this.comboBoxMatrixUsers.Location = new System.Drawing.Point(10, 61);
            this.comboBoxMatrixUsers.Name = "comboBoxMatrixUsers";
            this.comboBoxMatrixUsers.Size = new System.Drawing.Size(266, 28);
            this.comboBoxMatrixUsers.TabIndex = 0;
            this.comboBoxMatrixUsers.SelectedIndexChanged += new System.EventHandler(this.comboBoxMatrixUsers_SelectedIndexChanged);
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 671);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormSettings";
            this.Text = "FormSettings";
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox3;
        private Label label5;
        private TextBox textBoxObjectName;
        private Button buttonAddObject;
        private ComboBox comboBoxObjectPrivilege;
        private Label label4;
        private GroupBox groupBox2;
        private TextBox textBoxUserName;
        private Label label3;
        private Button buttonAddUser;
        private Label label2;
        private ComboBox comboBoxUserPrivilege;
        private Label label1;
        private GroupBox groupBox4;
        private GroupBox groupBox6;
        private ComboBox comboBoxObjects;
        private Label label7;
        private Button buttonDeleteObject;
        private GroupBox groupBox5;
        private Button buttonDeleteUser;
        private Label label6;
        private ComboBox comboBoxUsers;
        private GroupBox groupBox7;
        private Label label11;
        private ComboBox comboBoxMatrixObjects;
        private Label label10;
        private TextBox textBoxUserRights;
        private Label label9;
        private Label label8;
        private ComboBox comboBoxMatrixUsers;
        private Button buttonEditSettings;
        private TextBox textBoxRightsUserToObject;
    }
}