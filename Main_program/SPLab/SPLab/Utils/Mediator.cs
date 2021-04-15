using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPLab.Utils
{
    /// <summary>
    /// Класс реализующий паттерн посредник (или медиатор)
    /// Он необходим чтобы соединять различные виджеты
    /// </summary>
    public static class Mediator
    {
        static IDictionary<string, List<Action<object>>> pl_dict = new Dictionary<string, List<Action<object>>>();

        /// <summary>
        /// Регистрация события (действия) в медиаторе
        /// </summary>
        /// <param name="token">Название действия</param>
        /// <param name="callback">Действие которое должно быть совершенно</param>
        static public void Register(string token, Action<object> callback)
        {
            if (!pl_dict.ContainsKey(token))
            {
                var list = new List<Action<object>>();
                list.Add(callback);
                pl_dict.Add(token, list);
            }
            else
            {
                bool found = false;
                foreach (var item in pl_dict[token])
                {
                    if (item.Method.ToString() == callback.Method.ToString())
                    {
                        found = true;
                    }
                }
                if (!found)
                {
                    pl_dict[token].Add(callback);
                }
            }
        }

        /// <summary>
        /// Удаление действия по его имени
        /// </summary>
        /// <param name="token">Имя действия</param>
        /// <param name="callback">Действие которое должно быть совершенно по имени `token`</param>
        static public void Unregister(string token, Action<object> callback)
        {
            if (pl_dict.ContainsKey(token))
            {
                pl_dict[token].Remove(callback);
            }
        }

        /// <summary>
        /// Выполнить действие по имени `token` с входными параметрами `args`
        /// </summary>
        /// <param name="token">Имя действия</param>
        /// <param name="args">Аргументы для действия</param>
        static public void NotifyColleagues(string token, object args)
        {
            if (pl_dict.ContainsKey(token))
            {
                foreach (var callback in pl_dict[token])
                {
                    callback(args);
                }
            }
        }
    }
}
