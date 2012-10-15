using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YoeJoyHelper
{
    /// <summary>
    /// 缓存对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CacheObj<T>
    {
        /// <summary>
        /// 获取缓存对象
        /// </summary>
        /// <param name="key"></param>
        /// <param name="duration"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T GetCachedObj(string key, int duration, T obj)
        {
            if (CacheHelper.IsAlive(key))
            {
                return (T)CacheHelper.Get(key);
            }
            else
            {
                CacheHelper helper = new CacheHelper(key, obj, duration);
                helper.Add();
                return obj;
            }
        }

    }
}
