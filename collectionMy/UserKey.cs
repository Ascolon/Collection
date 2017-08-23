using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace collectionMy
{
    public class UserKey<KeyId, KeyName>
    {
        public KeyId Id { get; set; }
        public KeyName Name { get; set; }

        public UserKey(KeyId Id, KeyName Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
    }
}
