namespace DI.Lab3.Code.Models
{
    public class InputData
    {
        // Список пользователей
        public List<string> Users { get; set; } = new 
            List<string>();
        // список объектов
        public List<string> Objects { get; set; } = new
            List<string>();
        // матрица прав доступа
        public List<List<int>> AccessRights { get; set; } = new
            List<List<int>>();
    }
}
