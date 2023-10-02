using DI.Lab3.Code.Models;
using Microsoft.VisualBasic.ApplicationServices;

namespace DI.Lab3.Code.Repository
{
    public class InputDataRepository
    {
        private readonly InputData _data = new 
            InputData();

        public InputDataRepository()
        {
            _data.Users = new List<string>() { "Пользователь 1", "Пользователь 2", "Пользователь 3" };
            _data.Objects = new List<string>() { "Объект 1", "Объект 2", "Объект 3" };
            _data.AccessRights = new List<List<int>>()
            {
                new List<int>() { 1, 2, 2, 2 }, // Пользователь 1 может все
                new List<int>() { 0, 2, 2, 2 }, // Пользователь 2 не имеет доступа к редактированию матрицы
                new List<int>() { 0, 0, 1, 2 }  // Пользователь 3 не имеет доступа к ред-ю матрицы,
                                                // не имеет доступа к 1 объекту, может читать 2-ой и имеет полный доступ к 3-му
                // Вывод также зависит не только от матрицы, но и от привилегий, поэтому внимательно
                // (если привилегия пользователя ниже привилегии объекта, то даже если пользователь имеет доступ к объекту,
                // он все равно не сможет получить к нему доступ) 
            };
        }

        public List<string> GetUsers() => _data.Users;
        public List<string> GetObjects() => _data.Objects;
        public List<List<int>> GetAccessRights() => _data.AccessRights;

        // Добавление пользователя
        public void AddUser(string? username, int privilege)
        {
            if (!string.IsNullOrEmpty(username) && privilege >= 0 && privilege <= 3)
            {
                // Добавляем пользователя и привилегии для него
                _data.Users.Add(username);

                var accessRights = new List<int>();         // права доступа для пользователя
                int objectsCount = _data.Objects.Count;     // количество объектов
                for (int i = 0; i <= objectsCount; i++)
                {
                    // По умолчанию сделал так, что прав к редактированию и чтению матрицы и объектов у пользователя нет
                    accessRights.Add(0);
                }

                // Добавляем права добавляемого пользователя в матрицу прав 
                _data.AccessRights.Add(accessRights);
            }
            else
            {
                throw new Exception();
            }
        }

        // Добавление объекта
        public void AddObject(string? objectname, int privilege)
        {
            if (!string.IsNullOrEmpty(objectname) && privilege >= 0 && privilege <= 3)
            {
                // Добавляем объект и привилегии для него
                _data.Objects.Add(objectname);

                // Добавляем объект в матрицу прав
                for (int i = 0; i < _data.AccessRights.Count; i++)
                    _data.AccessRights[i].Add(0); // у всех пользователей по умолчанию нет доступа к объекту
            }
            else
            {
                throw new Exception();
            }
        }

        // Удаление пользователя
        public void DeleteUser(string? username)
        {
            if (!string.IsNullOrEmpty(username))
            {
                var index = _data.Users.IndexOf(username);
                // Удаляем пользователя из списка пользователей
                _data.Users.RemoveAt(index);
                // Удаляем пользователя из матрицы прав
                _data.AccessRights.RemoveAt(index);
            }
            else
            {
                throw new Exception("Пользователь не выбран!");
            }
        }

        // Удаление объекта
        public void DeleteObject(string? objectname)
        {
            if (!string.IsNullOrEmpty(objectname))
            {
                var index = _data.Objects.IndexOf(objectname);
                // Удаляем пользователя из списка пользователей
                _data.Objects.RemoveAt(index);
                // Удаляем пользователя из матрицы прав
                for (int i = 0; i < _data.AccessRights.Count; i++)
                {
                    _data.AccessRights[i].RemoveAt(index + 1); // удаляем из матрицы столбец с индексом index + 1 (т.к 0-й индекс занимают права пользователя по ред-ю матрицы)
                }
            }
            else
            {
                throw new Exception();
            }
        }

        // Возвращает права пользователя (0 - 1) по редактированию матрицы
        public int UserRightsToEditMatrix(string? username)
        {
            if (!string.IsNullOrEmpty(username))
            {
                var index = _data.Users.IndexOf(username);
                return _data.AccessRights[index][0];
            }
            else
            {
                throw new Exception();
            }
        }

        // Возвращает права пользователя на объект (0 - 2)
        public int UserRightsToObject(string? username, string? objectname)
        {
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(objectname))
            {
                var indexUser = _data.Users.IndexOf(username);
                var indexObject = _data.Objects.IndexOf(objectname);
                return _data.AccessRights[indexUser][indexObject + 1];
            }
            else
            {
                throw new Exception();
            }
        }

        // Установка прав пользователя на редактирование матрицы прав (0 - 1)
        public void SetUserRightsToMatrix(string? username, int rights)
        {
            // Права пользователя по редактированию матрицы либо 0 (ничего не может), либо 1 (может редактировать)
            if (!string.IsNullOrEmpty(username) && rights >= 0 && rights <= 1)
            {
                var index = _data.Users.IndexOf(username);
                _data.AccessRights[index][0] = rights;
            }
            else
            {
                throw new Exception();
            }
        }

        // Установка прав пользователя к объекту (0 - 2)
        public void SetUserRightsToObject(string? username, string? objectname, int rights)
        {
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(objectname) && rights >= 0 && rights <= 2)
            {
                var indexUser = _data.Users.IndexOf(username);
                var indexObject = _data.Objects.IndexOf(objectname);
                _data.AccessRights[indexUser][indexObject + 1] = rights;
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
