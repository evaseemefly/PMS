using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSFactory
{
    /// <summary>
    /// 使用单例模式创建一个保存短信息的队列
    /// </summary>
    public sealed class SMSSessionFactory<T>
    {
        private static Queue<T> smsQueue;

        private static SMSSessionFactory<T> _instance;

        private static readonly object locker = new object();

        private SMSSessionFactory()
        {
            smsQueue = new Queue<T>();
        }

        public static SMSSessionFactory<T> GetInstance()
        {
            if (_instance == null)
            {
                lock (locker)
                {
                    if (_instance == null)
                    {
                        _instance = new SMSSessionFactory<T>();
                    }
                }
            }
            return _instance;
        }

        public int GetqueueCount()
        {
            return smsQueue.Count();
        }

        public T Dequeue()
        {
            var temp= smsQueue.Dequeue();
            return temp;
        }

        public bool Enqueue(T temp)
        {
            bool result = false;
            try
            {
                smsQueue.Enqueue(temp);
                result = true;
            }
            catch (Exception)
            {
                
            }
            return result;
        }
    }
}
