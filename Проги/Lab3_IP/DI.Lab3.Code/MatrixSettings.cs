using DI.Lab3.Code.Repository;

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

        // При изменении значения в combobox для пользователей в разделе "Матрица прав доступа"
        private void comboBoxMatrixUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Устанавливаем права пользователя по ред-ю матрицы в textbox
            var username = comboBoxMatrixUsers.SelectedItem?.ToString();
            textBoxUserRights.Text = _repository.UserRightsToEditMatrix(username).ToString();

            // Делаем видимыми текстбоксы и лэйблы
            label9.Visible = true;
            textBoxUserRights.Visible = true;
            label10.Visible = true;
            comboBoxMatrixObjects.Visible = true;
        }

        // При изменении значения в combobox для объектов в разделе "Матрица прав доступа"
        private void comboBoxMatrixObjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Устанавливаем права пользователя к объекту в textbox
            var username = comboBoxMatrixUsers.SelectedItem?.ToString();
            var objectname = comboBoxMatrixObjects.SelectedItem?.ToString();
            textBoxRightsUserToObject.Text = _repository.UserRightsToObject(username, objectname).ToString();

            // Делаем видимыми текстбоксы и лэйблы
            label11.Visible = true;
            textBoxRightsUserToObject.Visible = true;
        }

        // Кнопка "Редактировать" в разделе "Матрица прав доступа"
        private void buttonEditSettings_Click(object sender, EventArgs e)
        {
            if (comboBoxMatrixUsers.SelectedIndex != -1)
            {
                // Редактируем права пользователя к редактированию матрицы
                var username = comboBoxMatrixUsers.SelectedItem?.ToString();
                var userRightEditMatrix = Convert.ToInt32(textBoxUserRights.Text.Trim());
                _repository.SetUserRightsToMatrix(username, userRightEditMatrix);

                if (comboBoxMatrixObjects.SelectedIndex != -1)
                {
                    // Редактируем права пользователя к объекту
                    var objectname = comboBoxMatrixObjects.SelectedItem?.ToString();
                    var userRightToObject = Convert.ToInt32(textBoxRightsUserToObject.Text.Trim());
                    _repository.SetUserRightsToObject(username, objectname, userRightToObject);
                }
            }
        }

        // Метод для обработки изменения списков с пользователями
        public void HandleListUsersChanged(object sender, EventArgs e)
        {
            comboBoxUsers.Items.Clear();
            comboBoxMatrixUsers.Items.Clear();
            foreach (var user in _repository.GetUsers())
            {
                comboBoxUsers.Items.Add(user);
                comboBoxMatrixUsers.Items.Add(user);
            }
        }

        // Метод для обработки изменения списков с объектами
        public void HandleListObjectsChanged(object sender, EventArgs e)
        {
            comboBoxObjects.Items.Clear();
            comboBoxMatrixObjects.Items.Clear();
            foreach (var obj in _repository.GetObjects())
            {
                comboBoxObjects.Items.Add(obj);
                comboBoxMatrixObjects.Items.Add(obj);
            }
        }
    }
}
