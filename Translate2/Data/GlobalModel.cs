using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translate2.Data
{
    internal class GlobalModel
    {
        public static GlobalModel Instance
        {
            get
            {
                if(m_Instance is null)
                    m_Instance = new GlobalModel();
                return m_Instance;
            }
        }
        public static GlobalModel m_Instance;
        private static Dictionary<string, object> m_Dict=new Dictionary<string, object>();
        public void RegisterAttribute<T>(string name, T value)
        {
            m_Dict.Add(name, value);
        }
        public void SetAttribute<T>(string name, T value, Dictionary<string, object> m_Dict)
        {
            if(!m_Dict.ContainsKey(name) )
            {
                m_Dict.Add(name, value);
                return;
            }
            m_Dict[name] = value;   
        }
        public bool TryGetAttribute<T>(string name, out T value)
        {
            value = default(T);
            bool ret = m_Dict.TryGetValue(name, out var obj);
            if (!ret) return false;
            if (!(obj is T)) return false;
            value= (T)obj;
            return true;
           
        }
    }
}
