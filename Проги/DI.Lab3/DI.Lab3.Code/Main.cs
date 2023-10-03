using DI.Lab3.Code.Repository;

namespace DI.Lab3.Code
{
    public partial class Main : Form
    {
        private InputDataRepository _repository;
        // ���������� �������, ������� ���������� � �����
        private int _privilegeBuffer = -1;
        // �������, ������� ���������� ��� ��������� ��������
        public event EventHandler? ListObjectsChanged;

        public Main()
        {
            _repository = new InputDataRepository();
            ListObjectsChanged += HandleListObjectsChanged!;
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            foreach (var user in _repository.GetUsers())
                comboBoxUsers.Items.Add(user);
            foreach (var obj in _repository.GetObjects())
                listBoxObjects.Items.Add(obj);
        }


        private void comboBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            var username = comboBoxUsers.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(username))
            {
                var rightsToEditMatrix = _repository.UserRightsToEditMatrix(username);
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
                var indexUser = _repository.GetUsers().IndexOf(username);
                var indexObject = _repository.GetObjects().IndexOf(objectname);

                // ��� ��� ��� ��������� � ���������
                // ���� � ������������ ��� ���� �� ������ ��� ���������� ������������ ���� ���������� �������
                if (_repository.GetAccessRights()[indexUser][indexObject + 1] == 0)
                {
                    richTextBox1.Enabled = false;                   // ������ ���� �����������
                    richTextBox1.Text = string.Empty;               // ������ �� �������
                }
                else if (_repository.GetAccessRights()[indexUser][indexObject + 1] == 1)
                {
                    richTextBox1.Enabled = false;                       // ������ ���� �����������
                    richTextBox1.Text = _repository.GetObjects()[indexObject];     // ������� �������� �������
                }
                else if (_repository.GetAccessRights()[indexUser][indexObject + 1] == 2)
                {
                    richTextBox1.Enabled = true;                    // ������ ���� ��������� ��� ��������������
                    richTextBox1.Text = _repository.GetObjects()[indexObject]; // ������� �������� �������
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
                _repository.GetObjects()[indexObject] = newObjectName;

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
            MatrixSettings settings = new MatrixSettings(_repository);
            // ��������� ������� � ������� �� ����������
            // ������� ��������� ������ � ������� �����, �.�. ����� ��������������� ��� ������
            // ����� ��������� ������ �� 2-�� �����, �.�. �� 2-�� ����� �� ����� ������ ������� 1-�� �����

            // �������, ��������� � ����������� ������������� � ���������� � �.�.
            settings.ListUsersChanged += HandleListUsersChanged!;
            settings.ListUsersChanged += settings.HandleListUsersChanged!;

            // �������, ��������� � ����������� �������� � ���������� � �.�.
            settings.ListObjectsChanged += HandleListObjectsChanged!;
            settings.ListObjectsChanged += settings.HandleListObjectsChanged!;
            ListObjectsChanged += settings.HandleListObjectsChanged!;

            settings.Show();
        }

        // ����� ��� ��������� ��������� ������ � ��������������
        private void HandleListUsersChanged(object sender, EventArgs e)
        {
            comboBoxUsers.Items.Clear();
            foreach (var user in _repository.GetUsers())
            {
                comboBoxUsers.Items.Add(user);
            }
        }

        // ����� ��� ��������� ��������� ������ � ���������
        private void HandleListObjectsChanged(object sender, EventArgs e)
        {
            listBoxObjects.Items.Clear();
            foreach (var obj in _repository.GetObjects())
            {
                listBoxObjects.Items.Add(obj);
            }
        }
    }
}