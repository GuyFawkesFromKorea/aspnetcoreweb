using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.Collections.Specialized;

namespace JWLibrary.Helpers
{
    public class ParameterHelper
    {
        private Dictionary<string, object> _map = new Dictionary<string, object>();
        public ParameterHelper(params KeyValuePair<string, object>[] kvps)
        {
            foreach(var item in kvps){
                _map.Add(item.Key, item.Value);

            }
        }

        public void Add(KeyValuePair<string, object> kvp)
        {
            _map.Add(kvp.Key, kvp.Value);
        }        

        public JObject ToJObject()
        {
            return JObject.FromObject(_map);
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(_map);
        }
        
        public string ToParam()
        {
            string ret = string.Empty;

            int idx = 0;
            foreach(var kvp in _map)
            {
                if (idx == 0) ret += "?" + kvp.Key + "=" + kvp.Value;
                else ret += "&" + kvp.Key + "=" + kvp.Value;
            }

            return ret;
        }

        public NameValueCollection ToNameValueCollection()
        {
            var nvc = new NameValueCollection();

            foreach(var kvp in _map)
            {
                string value = null;
                if(kvp.Value != null)
                {
                    value = kvp.Value.ToString();
                }

                nvc.Add(kvp.Key.ToString(), value);
            }

            return nvc;
        }
    }
}
