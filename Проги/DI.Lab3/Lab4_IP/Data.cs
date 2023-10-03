using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Lab4_IP
{
    public class Data
    {
        // Список пользователей
        public List<string> Users { get; set; }
        // список объектов
        public List<string> Objects { get; set; }
        // матрица прав доступа
        public List<List<int>> P { get; set; }
        // номер привилегии для пользователя (0 - 3)
        public List<int> PrivilegesUser { get; set; }
        // номер привилегии для объекта (0 - 3)
        public List<int> PrivilegesObject { get; set; }

        public Data()
        {
            Users = new List<string>() { "Пользователь 1", "Пользователь 2", "Пользователь 3" };
            Objects = new List<string>() { "Объект 1", "Объект 2", "Объект 3" };
            PrivilegesUser = new List<int>() { 2, 2, 1 };
            PrivilegesObject = new List<int>() { 0, 0, 2 };
            P = new List<List<int>>()
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

        // Добавление пользователя
        public void AddUser(string? username, int privilege)
        {
            if (!string.IsNullOrEmpty(username) && privilege >= 0 && privilege <= 3)
            {
                // Добавляем пользователя и привилегии для него
                Users.Add(username);
                PrivilegesUser.Add(privilege);

                var accessRights = new List<int>();         // права доступа для пользователя
                int objectsCount = Objects.Count;           // количество объектов
                for (int i = 0; i <= objectsCount; i++)
                {
                    // По умолчанию сделал так, что прав к редактированию и чтению матрицы и объектов у пользователя нет
                    accessRights.Add(0);
                }

                // Добавляем права добавляемого пользователя в матрицу прав 
                P.Add(accessRights);
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
                Objects.Add(objectname);
                PrivilegesObject.Add(privilege);

                // Добавляем объект в матрицу прав
                for(int i = 0; i < P.Count; i++)
                    P[i].Add(0); // у всех пользователей по умолчанию нет доступа к объекту
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
                var index = Users.IndexOf(username);
                // Удаляем пользователя из списка пользователей
                Users.RemoveAt(index);
                // Удаляем пользователя из матрицы прав
                P.RemoveAt(index);
                // Удаляем пользователя из массива привилегий пользователей
                PrivilegesUser.RemoveAt(index);
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
                var index = Objects.IndexOf(objectname);
                // Удаляем пользователя из списка пользователей
                Objects.RemoveAt(index);
                // Удаляем пользователя из массива привилегий пользователей
                PrivilegesObject.RemoveAt(index);
                // Удаляем пользователя из матрицы прав
                for (int i = 0; i < P.Count; i++)
                {
                    P[i].RemoveAt(index + 1); // удаляем из матрицы столбец с индексом index + 1 (т.к 0-й индекс занимают права пользователя по ред-ю матрицы)
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
                var index = Users.IndexOf(username);
                return P[index][0];
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
                var indexUser = Users.IndexOf(username);
                var indexObject = Objects.IndexOf(objectname);
                return P[indexUser][indexObject + 1];
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
                var index = Users.IndexOf(username);
                P[index][0] = rights;
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
                var indexUser = Users.IndexOf(username);
                var indexObject = Objects.IndexOf(objectname);
                P[indexUser][indexObject + 1] = rights;
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
