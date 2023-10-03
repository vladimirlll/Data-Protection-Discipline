using DI.Lab3.Code.Repository;

namespace DI.Lab3.Code
{
    public partial class Main : Form
    {
        private InputDataRepository _repository;
        // Привилегия объекта, который скопирован в буфер
        private int _privilegeBuffer = -1;
        // Событие, которое вызывается при изменении объектов
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
                // Если у пользователя есть права для редактирования матрицы, делаем кнопку активной
                buttonEditAccessRights.Enabled = (rightsToEditMatrix == 1);
                // Обнуляем данные в списке объектов и текстовом поле
                listBoxObjects.SelectedIndex = -1;
                richTextBox1.Text = string.Empty;
            }
        }

        private void listBoxObjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            var username = comboBoxUsers.SelectedItem?.ToString();
            var objectname = listBoxObjects.SelectedItem?.ToString();
            // Если пользователь и объект выбраны
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(objectname))
            {
                var indexUser = _repository.GetUsers().IndexOf(username);
                var indexObject = _repository.GetObjects().IndexOf(objectname);

                // Тут все как расписано в методичке
                // Если у пользователя нет прав на объект или привилегия пользователя ниже привилегии объекта
                if (_repository.GetAccessRights()[indexUser][indexObject + 1] == 0)
                {
                    richTextBox1.Enabled = false;                   // делаем поле недоступным
                    richTextBox1.Text = string.Empty;               // ничего не выводим
                }
                else if (_repository.GetAccessRights()[indexUser][indexObject + 1] == 1)
                {
                    richTextBox1.Enabled = false;                       // делаем поле недоступным
                    richTextBox1.Text = _repository.GetObjects()[indexObject];     // выводим значение объекта
                }
                else if (_repository.GetAccessRights()[indexUser][indexObject + 1] == 2)
                {
                    richTextBox1.Enabled = true;                    // делаем поле доступным для редактирования
                    richTextBox1.Text = _repository.GetObjects()[indexObject]; // выводим значение объекта
                }
            }
        }

        // Метод, который при изменении объекта в поле изменяет его везде в реальном времени
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            int indexObject = listBoxObjects.SelectedIndex;

            // Если объект выбран и richTextBox активен (т.к если он не активен, нет смысла брать оттуда данные, ведь изменить текст нельзя)
            if (indexObject != -1 && richTextBox1.Enabled)
            {
                var newObjectName = richTextBox1.Text;
                // Устанавливаем новое название объекта
                _repository.GetObjects()[indexObject] = newObjectName;

                // После того, как обновили, обновляем списки объектов
                ListObjectsChanged?.Invoke(this, EventArgs.Empty);

                // Устанавливаем выбранный индекс, чтобы в панели был снова выбранный объект
                listBoxObjects.SelectedIndex = indexObject;

                // Устанавливаем курсор в конец текста
                richTextBox1.Select(richTextBox1.Text.Length, 0);
            }
        }

        // Кнопка "Редактировать права доступа"
        private void buttonEditAccessRights_Click(object sender, EventArgs e)
        {
            MatrixSettings settings = new MatrixSettings(_repository);
            // Добавляем события в порядке их выполнения
            // Сначала выполняем методы в главной форме, т.к. здесь устанавливаются все данные
            // Затем выполняем методы во 2-ой форме, т.к. из 2-ой формы мы берем данные свойств 1-ой формы

            // События, связанные с заполнением пользователей в комбобоксы и т.п.
            settings.ListUsersChanged += HandleListUsersChanged!;
            settings.ListUsersChanged += settings.HandleListUsersChanged!;

            // События, связанные с заполнением объектов к комбобоксы и т.п.
            settings.ListObjectsChanged += HandleListObjectsChanged!;
            settings.ListObjectsChanged += settings.HandleListObjectsChanged!;
            ListObjectsChanged += settings.HandleListObjectsChanged!;

            settings.Show();
        }

        // Метод для обработки изменения списка с пользователями
        private void HandleListUsersChanged(object sender, EventArgs e)
        {
            comboBoxUsers.Items.Clear();
            foreach (var user in _repository.GetUsers())
            {
                comboBoxUsers.Items.Add(user);
            }
        }

        // Метод для обработки изменения списка с объектами
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