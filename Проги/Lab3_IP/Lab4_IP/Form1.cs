namespace Lab4_IP
{
    public partial class Form1 : Form
    {
        private Data _data;
        // Привилегия объекта, который скопирован в буфер
        private int _privilegeBuffer = -1;
        // Событие, которое вызывается при изменении объектов
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
                var indexUser = _data.Users.IndexOf(username);
                var indexObject = _data.Objects.IndexOf(objectname);

                // Тут все как расписано в методичке
                // Если у пользователя нет прав на объект или привилегия пользователя ниже привилегии объекта
                if (_data.P[indexUser][indexObject + 1] == 0 || _data.PrivilegesUser[indexUser] < _data.PrivilegesObject[indexObject])
                {
                    richTextBox1.Enabled = false;                   // делаем поле недоступным
                    richTextBox1.Text = string.Empty;               // ничего не выводим
                }
                else if (_data.P[indexUser][indexObject + 1] == 1)
                {
                    richTextBox1.Enabled = false;                       // делаем поле недоступным
                    richTextBox1.Text = _data.Objects[indexObject];     // выводим значение объекта
                }
                else if (_data.P[indexUser][indexObject + 1] == 2)
                {
                    richTextBox1.Enabled = true;                    // делаем поле доступным для редактирования
                    richTextBox1.Text = _data.Objects[indexObject]; // выводим значение объекта
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
                _data.Objects[indexObject] = newObjectName;

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
            FormSettings formSettings = new FormSettings(_data);
            // Добавляем события в порядке их выполнения
            // Сначала выполняем методы в главной форме, т.к. здесь устанавливаются все данные
            // Затем выполняем методы во 2-ой форме, т.к. из 2-ой формы мы берем данные свойств 1-ой формы

            // События, связанные с заполнением пользователей в комбобоксы и т.п.
            formSettings.ListUsersChanged += HandleListUsersChanged!;               
            formSettings.ListUsersChanged += formSettings.HandleListUsersChanged!;

            // События, связанные с заполнением объектов к комбобоксы и т.п.
            formSettings.ListObjectsChanged += HandleListObjectsChanged!;
            formSettings.ListObjectsChanged += formSettings.HandleListObjectsChanged!;

            formSettings.Show();
        }

        // Кнопка копирования
        private void buttonCopy_Click(object sender, EventArgs e)
        {
            int indexObject = listBoxObjects.SelectedIndex;
            
            // Если объект выбран
            if (indexObject != -1 && !string.IsNullOrEmpty(richTextBox1.Text))
            {
                // Устанавливаем в буфер привилегию
                _privilegeBuffer = _data.PrivilegesObject[indexObject];
                var textToCopy = richTextBox1.Text;
                // Копируем текст в буфер
                Clipboard.SetText(textToCopy);

                MessageBox.Show("Текст скопирован в буфер обмена.", "Успешно скопировано", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Кнопка вставки
        private void buttonPaste_Click(object sender, EventArgs e)
        {
            string clipboardText = Clipboard.GetText();
            richTextBox1.Text = clipboardText;
        }

        // Метод для обработки изменения списка с пользователями
        private void HandleListUsersChanged(object sender, EventArgs e)
        {
            comboBoxUsers.Items.Clear();
            foreach (var user in _data.Users)
            {
                comboBoxUsers.Items.Add(user);
            }
        }

        // Метод для обработки изменения списка с объектами
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