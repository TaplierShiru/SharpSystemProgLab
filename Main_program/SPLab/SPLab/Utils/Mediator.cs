using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPLab.Utils
{
    /// <summary>
    /// Class which implements The mediator pattern
    /// In order to connect certain controls
    /// </summary>
    public static class Mediator
    {
        static IDictionary<string, List<Action<object>>> pl_dict = new Dictionary<string, List<Action<object>>>();

        /// <summary>
        /// Register some action in Mediator
        /// </summary>
        /// <param name="token">Name of the action</param>
        /// <param name="callback">Action that would be perfermed by certain `token`</param>
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
        /// Remove action from Mediator by `token`
        /// </summary>
        /// <param name="token">Name of the action</param>
        /// <param name="callback">Action that would be perfermed by certain `token`</param>
        static public void Unregister(string token, Action<object> callback)
        {
            if (pl_dict.ContainsKey(token))
            {
                pl_dict[token].Remove(callback);
            }
        }

        /// <summary>
        /// Performe action by certain name, i.e. `token`
        /// </summary>
        /// <param name="token">Name of the action</param>
        /// <param name="args">Arguments into action</param>
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
