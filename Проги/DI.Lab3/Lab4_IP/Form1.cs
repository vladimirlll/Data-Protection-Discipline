namespace Lab4_IP
{
    public partial class Form1 : Form
    {
        private Data _data;
        // ���������� �������, ������� ���������� � �����
        private int _privilegeBuffer = -1;
        // �������, ������� ���������� ��� ��������� ��������
        public event EventHandler? ListObjectsChanged;

        public Form1()
        {
            _data = new Data();
            ListObjectsChanged += HandleListObjectsChanged!;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var user in _data.Users)
                comboBoxUsers.Items.Add(user);
            foreach (var obj in _data.Objects)
                listBoxObjects.Items.Add(obj);
        }


        private void comboBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            var username = comboBoxUsers.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(username))
            {
                var rightsToEditMatrix = _data.UserRightsToEditMatrix(username);
                // ���� � ������������ ���� ����� ��� �������������� �������, ������ ������ ��������
                buttonEditAccessRights.Enabled = (rightsToEditMatrix == 1);
                // �������� ������ � ������ �������� � ��������� ����
                listBoxObjects.SelectedIndex = -1;
                richTextBox1.Text = string.Empty;
            }
        }

        private void listBoxObjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            var username = comboBoxUsers.SelectedItem?.ToString();
            var objectname = listBoxObjects.SelectedItem?.ToString();
            // ���� ������������ � ������ �������
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(objectname))
            {
                var indexUser = _data.Users.IndexOf(username);
                var indexObject = _data.Objects.IndexOf(objectname);

                // ��� ��� ��� ��������� � ���������
                // ���� � ������������ ��� ���� �� ������ ��� ���������� ������������ ���� ���������� �������
                if (_data.P[indexUser][indexObject + 1] == 0 || _data.PrivilegesUser[indexUser] < _data.PrivilegesObject[indexObject])
                {
                    richTextBox1.Enabled = false;                   // ������ ���� �����������
                    richTextBox1.Text = string.Empty;               // ������ �� �������
                }
                else if (_data.P[indexUser][indexObject + 1] == 1)
                {
                    richTextBox1.Enabled = false;                       // ������ ���� �����������
                    richTextBox1.Text = _data.Objects[indexObject];     // ������� �������� �������
                }
                else if (_data.P[indexUser][indexObject + 1] == 2)
                {
                    richTextBox1.Enabled = true;                    // ������ ���� ��������� ��� ��������������
                    richTextBox1.Text = _data.Objects[indexObject]; // ������� �������� �������
                }
            }
        }

        // �����, ������� ��� ��������� ������� � ���� �������� ��� ����� � �������� �������
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            int indexObject = listBoxObjects.SelectedIndex;

            // ���� ������ ������ � richTextBox ������� (�.� ���� �� �� �������, ��� ������ ����� ������ ������, ���� �������� ����� ������)
            if (indexObject != -1 && richTextBox1.Enabled)
            {
                var newObjectName = richTextBox1.Text;
                // ������������� ����� �������� �������
                _data.Objects[indexObject] = newObjectName;

                // ����� ����, ��� ��������, ��������� ������ ��������
                ListObjectsChanged?.Invoke(this, EventArgs.Empty);

                // ������������� ��������� ������, ����� � ������ ��� ����� ��������� ������
                listBoxObjects.SelectedIndex = indexObject;

                // ������������� ������ � ����� ������
                richTextBox1.Select(richTextBox1.Text.Length, 0);
            }
        }

        // ������ "������������� ����� �������"
        private void buttonEditAccessRights_Click(object sender, EventArgs e)
        {
            FormSettings formSettings = new FormSettings(_data);
            // ��������� ������� � ������� �� ����������
            // ������� ��������� ������ � ������� �����, �.�. ����� ��������������� ��� ������
            // ����� ��������� ������ �� 2-�� �����, �.�. �� 2-�� ����� �� ����� ������ ������� 1-�� �����

            // �������, ��������� � ����������� ������������� � ���������� � �.�.
            formSettings.ListUsersChanged += HandleListUsersChanged!;               
            formSettings.ListUsersChanged += formSettings.HandleListUsersChanged!;

            // �������, ��������� � ����������� �������� � ���������� � �.�.
            formSettings.ListObjectsChanged += HandleListObjectsChanged!;
            formSettings.ListObjectsChanged += formSettings.HandleListObjectsChanged!;

            formSettings.Show();
        }

        // ������ �����������
        private void buttonCopy_Click(object sender, EventArgs e)
        {
            int indexObject = listBoxObjects.SelectedIndex;
            
            // ���� ������ ������
            if (indexObject != -1 && !string.IsNullOrEmpty(richTextBox1.Text))
            {
                // ������������� � ����� ����������
                _privilegeBuffer = _data.PrivilegesObject[indexObject];
                var textToCopy = richTextBox1.Text;
                // �������� ����� � �����
                Clipboard.SetText(textToCopy);

                MessageBox.Show("����� ���������� � ����� ������.", "������� �����������", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ������ �������
        private void buttonPaste_Click(object sender, EventArgs e)
        {
            string clipboardText = Clipboard.GetText();
            richTextBox1.Text = clipboardText;
        }

        // ����� ��� ��������� ��������� ������ � ��������������
        private void HandleListUsersChanged(object sender, EventArgs e)
        {
            comboBoxUsers.Items.Clear();
            foreach (var user in _data.Users)
            {
                comboBoxUsers.Items.Add(user);
            }
        }

        // ����� ��� ��������� ��������� ������ � ���������
        private void HandleListObjectsChanged(object sender, EventArgs e)
        {
            listBoxObjects.Items.Clear();
            foreach (var obj in _data.Objects)
            {
                listBoxObjects.Items.Add(obj);
            }
        }
    }
}