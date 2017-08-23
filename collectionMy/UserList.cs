using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace collectionMy
{
    /// <summary>
    /// Новая коллекция с пользовательским составным ключом
    /// </summary>
    /// <typeparam name="TkeyId">Тип Id ключа</typeparam>
    /// <typeparam name="TkeyName">Тип Name ключа</typeparam>
    /// <typeparam name="Tvalue">Тип Данных коллекции</typeparam>
    public class UserList<TkeyId, TkeyName, Tvalue> : Dictionary<UserKey<TkeyId, TkeyName>, Tvalue>
    {
        private object sync = new object();
        public UserList()
        {

        }

        /// <summary>
        /// Добавление новой записи в коллекцию
        /// </summary>
        /// <param name="id">id ключа коллекции</param>
        /// <param name="keyName">name ключа коллекции</param>
        /// <param name="value">значение коллекции</param>
        public void Add(TkeyId keyId, TkeyName keyName, Tvalue value)
        {
            lock(sync)
            {
                if (this.Where(g => g.Key.Name.Equals(keyName) && g.Key.Id.Equals(keyId)).Count() > 0)
                    return;
                this.Add(new UserKey<TkeyId, TkeyName>(keyId, keyName), value);
            }
        }

        public IList GetById(TkeyId id)
        {
            var items = this.Where(g => g.Key.Id.Equals(id)).ToList();
            return items.ToList();
        }

        public IList GetByName(TkeyName name)
        {
            var items = this.Where(g => g.Key.Name.Equals(name)).ToList();
            return items;
        }
    }
}
