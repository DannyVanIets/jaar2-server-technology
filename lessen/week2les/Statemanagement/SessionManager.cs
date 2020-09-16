using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Statemanagement
{
    public class SessionManager
    {
        public T Get<T>(ISession session, string sessionkey)
        {
            var value = session.GetString(sessionkey);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }

        public void Set<T>(ISession session, string sessionkey, T value)
        {
            session.SetString(sessionkey, JsonConvert.SerializeObject(value));
        }
    }
}
