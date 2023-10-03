using DI.Lab3.Code.Repository;
using Microsoft.VisualBasic.ApplicationServices;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DI.Lab3.Code
{
    public partial class MatrixSettings : Form
    {
        private InputDataRepository _repository;

        // События, которые вызываются при изменении списка пользователей и объектов
        public event EventHandler? ListUsersChanged;
        public event EventHandler? ListObjectsChanged;

        public MatrixSettings()
        {
            InitializeComponent();
            _repository = new InputDataRepository();
        }

        public MatrixSettings(InputDataRepository repository)
        {
            InitializeComponent();
            _repository = repository;
        }

        // Загружаем в комбобоксы исходные данные
        private void MatrixSettings_Load(object sender, EventArgs e)
        {
            // Вызываю события, при котором обновляются данные на всех формах
            ListUsersChanged?.Invoke(this, EventArgs.Empty);        // списки пользователей
            ListObjectsChanged?.Invoke(this, EventArgs.Empty);      // списки объектов
        }

        // Кнопка добавления пользователя
        private void buttonAddUser_Click(object sender, EventArgs e)
        {
            var username = textBoxUserName.Text.Trim();

            try
            {
                _repository.AddUser(username);
                ListUsersChanged?.Invoke(this, EventArgs.Empty);    // Вызываю событие, при котором обновляются данные на всех формах
            }
            catch
            {
                // Вывод на экран сообщения об ошибке мне лень делать, да и необязательно думаю, поэтому пофиг
            }
        }

        // Кнопка добавления объекта
        private void buttonAddObject_Click(object sender, EventArgs e)
        {
            var objectname = textBoxObjectName.Text.Trim();

            try
            {
                _repository.AddObject(objectname);
                ListObjectsChanged?.Invoke(this, EventArgs.Empty);
            }
            catch
            {
                // Вывод на экран сообщения об ошибке мне лень делать, да и необязательно думаю, поэтому пофиг
            }
        }

        // Кнопка удаления пользователя
        private void buttonDeleteUser_Click(object sender, EventArgs e)
        {
            var username = comboBoxUsers.SelectedItem?.ToString();

            try
            {
                _repository.DeleteUser(username);
                ListUsersChanged?.Invoke(this, EventArgs.Empty);    // Вызываю событие, при котором обновляются данные на 1-ой и 2-ой форме
            }
            catch
            {
                // Вывод на экран сообщения об ошибке мне лень делать, да и необязательно думаю, поэтому пофиг
            }
        }

        // Кнопка удаления объекта
        private void buttonDeleteObject_Click(object sender, EventArgs e)
        {
            var objectname = comboBoxObjects.SelectedItem?.ToString();

            try
            {
                _repository.DeleteObject(objectname);
                ListObjectsChanged?.Invoke(this, EventArgs.Empty);
            }
            catch
            {

            }
        }

        private void UpdateDataGrid()
        {
            dgvMatrix.Rows.Clear();
            dgvMatrix.Columns.Clear();
            dgvMatrix.Columns.Add("matSet", "Редактирование матрицы");

            foreach (var obj in _repository.GetObjects())
            {
                dgvMatrix.Columns.Add(obj, obj);
            }

            var users = _repository.GetUsers();
            for (int i = 0; i < users.Count; i++)
            {
                var index = dgvMatrix.Rows.Add();
                dgvMatrix.Rows[i].HeaderCell.Value = users[i];

            }

            var matrix = _repository.GetAccessRights();

            for (int ui = 0; ui < matrix.Count; ui++)
            {
                for (int oi = 0; oi < matrix[ui].Count; oi++)
                {
                    dgvMatrix[oi, ui].Value = matrix[ui][oi].ToString();
                }
            }

            dgvMatrix.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            dgvMatrix.AllowUserToAddRows = false;
        }

        // Метод для обработки изменения списков с пользователями
        public void HandleListUsersChanged(object sender, EventArgs e)
        {
            comboBoxUsers.Items.Clear();
            foreach (var user in _repository.GetUsers())
            {
                comboBoxUsers.Items.Add(user);
            }
            UpdateDataGrid();
        }

        // Метод для обработки изменения списков с объектами
        public void HandleListObjectsChanged(object sender, EventArgs e)
        {
            comboBoxObjects.Items.Clear();
            foreach (var obj in _repository.GetObjects())
            {
                comboBoxObjects.Items.Add(obj);
            }
            UpdateDataGrid();
        }

        private void dgvMatrix_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            void GetBackOldValue()
            {
                dgvMatrix[e.ColumnIndex, e.RowIndex].Value =
                        _repository.GetAccessRights()[e.RowIndex][e.ColumnIndex].ToString();
            }

            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                if (int.TryParse(dgvMatrix[e.ColumnIndex, e.RowIndex].Value.ToString(), out int newVal))
                {
                    if (e.ColumnIndex == 0)
                    {
                        if ((newVal < 0 || newVal > 1))
                        {
                            MessageBox.Show("В колонке редактирования матрицы значения должны быть 0 или 1");
                            GetBackOldValue();
                        }
                        else
                        {
                            // Редактируем права пользователя к редактированию матрицы
                            var username = dgvMatrix.Rows[e.RowIndex].HeaderCell.Value as string;
                            var userRightEditMatrix = int.Parse(dgvMatrix[e.ColumnIndex, e.RowIndex].Value.ToString()!);
                            _repository.SetUserRightsToMatrix(username, userRightEditMatrix);
                        }
                    }
                    else if (e.ColumnIndex > 0)
                    {
                        if (newVal < 0 || newVal > 2)
                        {
                            MessageBox.Show("В колонках матрицы значения должны быть >= 0 и <= 2");
                            GetBackOldValue();
                        }
                        else
                        {
                            // Редактируем права пользователя к объекту
                            var username = dgvMatrix.Rows[e.RowIndex].HeaderCell.Value as string;
                            var objectname = dgvMatrix.Columns[e.ColumnIndex].HeaderText;
                            var userRightToObject = int.Parse(dgvMatrix[e.ColumnIndex, e.RowIndex].Value.ToString()!);
                            _repository.SetUserRightsToObject(username, objectname, userRightToObject);
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Значение элементов матрицы должно быть числом");
                    GetBackOldValue();
                }

            }

        }
    }
}
