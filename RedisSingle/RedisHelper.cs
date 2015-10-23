using System;
using System.Collections.Generic;


namespace RedisSingle
{
    public class RedisHelper
    {
        #region Base
        /// <summary>
        /// 获取值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Get<T>(string key)
        {
            using (var redis = RedisConfig.Redis)
            {
                return redis.Get<T>(key);
            }
        }

        /// <summary>
        /// 设置值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Set<T>(string key, T value)
        {
            using (var redis = RedisConfig.Redis)
            {
                return redis.Set<T>(key, value);
            }
        }

        /// <summary>
        /// 设置值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Set<T>(string key, T value, DateTime dt)
        {
            using (var redis = RedisConfig.Redis)
            {
                return redis.Set<T>(key, value, dt);
            }
        }

        /// <summary>
        /// 移除单个值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Remove(string key)
        {
            using (var redis = RedisConfig.Redis)
            {
                return redis.Remove(key);
            }
        }

        /// <summary>
        /// 移除集合值
        /// </summary>
        /// <param name="keys"></param>
        public void RemoveList(List<string> keys)
        {
            using (var redis = RedisConfig.Redis)
            {
                foreach (var key in keys)
                {
                    redis.Remove(key);
                }
            }
        }
        #endregion

        #region String
        /// <summary>
        /// 自增长
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public long Incr(string key)
        {
            using (var redis = RedisConfig.Redis)
            {
                return redis.Incr(key);
            }
        }
        #endregion

        #region Hash
        /// <summary>
        /// 设置Hash值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool SetEntryInHash(string hashId, string key, string value)
        {
            using (var redis = RedisConfig.Redis)
            {
                return redis.SetEntryInHash(hashId, key, value);
            }
        }

        /// <summary>
        /// 获取Hash的Key
        /// </summary>
        /// <param name="hashId"></param>
        /// <returns></returns>
        public List<string> GetHashKeys(string hashId)
        {
            using (var redis = RedisConfig.Redis)
            {
                return redis.GetHashKeys(hashId);
            }
        }

        /// <summary>
        /// 获取Hash的Value
        /// </summary>
        /// <param name="hashId"></param>
        /// <returns></returns>
        public List<string> GetHashValues(string hashId)
        {
            using (var redis = RedisConfig.Redis)
            {
                return redis.GetHashValues(hashId);
            }
        }
        #endregion

        #region List
        /// <summary>
        /// 添加值到List
        /// </summary>
        /// <param name="listId"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public void AddItemToList(string listId, string value)
        {
            using (var redis = RedisConfig.Redis)
            {
                redis.AddItemToList(listId, value);
            }
        }

        /// <summary>
        /// 获取List的值
        /// </summary>
        /// <param name="listId"></param>
        /// <returns></returns>
        public List<string> GetAllItemsFromList(string listId)
        {
            using (var redis = RedisConfig.Redis)
            {
                return redis.GetAllItemsFromList(listId);
            }
        }

        /// <summary>
        /// 获取List的长度
        /// </summary>
        /// <param name="listId"></param>
        /// <returns></returns>
        public long GetListCount(string listId)
        {
            using (var redis = RedisConfig.Redis)
            {
                return redis.GetListCount(listId);
            }
        }

        /// <summary>
        /// 获取List的值
        /// </summary>
        /// <param name="listId"></param>
        /// <param name="listIndex"></param>
        /// <returns></returns>
        public string GetItemFromList(string listId, int listIndex)
        {
            using (var redis = RedisConfig.Redis)
            {
                return redis.GetItemFromList(listId, listIndex);
            }
        }

        /// <summary>
        /// 从List获取Pop一个值
        /// </summary>
        /// <param name="listId"></param>
        /// <returns></returns>
        public string PopItemFromList(string listId)
        {
            using (var redis = RedisConfig.Redis)
            {
                return redis.PopItemFromList(listId);
            }
        }
        #endregion

        #region Set
        /// <summary>
        /// 添加元素到集合
        /// </summary>
        /// <param name="setId"></param>
        /// <param name="item"></param>
        public void AddItemToSet(string setId, string item)
        {
            using (var redis = RedisConfig.Redis)
            {
                redis.AddItemToSet(setId, item);
            }
        }

        /// <summary>
        /// 求差集
        /// </summary>
        /// <param name="fromSetId"></param>
        /// <param name="withSetIds"></param>
        /// <returns></returns>
        public HashSet<string> GetDifferencesFromSet(string fromSetId, params string[] withSetIds)
        {
            using (var redis = RedisConfig.Redis)
            {
                return redis.GetDifferencesFromSet(fromSetId, withSetIds);
            }
        }

        /// <summary>
        /// 求集合交集
        /// </summary>
        /// <param name="setIds"></param>
        /// <returns></returns>
        public HashSet<string> GetIntersectFromSets(params string[] setIds)
        {
            using (var redis = RedisConfig.Redis)
            {
                return redis.GetIntersectFromSets(setIds);
            }
        }

        /// <summary>
        /// 求集合并集
        /// </summary>
        /// <param name="setIds"></param>
        /// <returns></returns>
        public HashSet<string> GetUnionFromSets(params string[] setIds)
        {
            using (var redis = RedisConfig.Redis)
            {
                return redis.GetUnionFromSets(setIds);
            }
        }
        #endregion

        #region SortSet
        /// <summary>
        /// 有序Set操作
        /// </summary>
        /// <param name="setId"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool AddItemToSortedSet(string setId, string value, long score)
        {
            using (var redis = RedisConfig.Redis)
            {
                return redis.AddItemToSortedSet(setId, value, score);
            }
        }

        /// <summary>
        /// 有序集合降序排列
        /// </summary>
        /// <param name="setId"></param>
        /// <returns></returns>
        public List<string> GetAllItemsFromSortedSetDesc(string setId)
        {
            using (var redis = RedisConfig.Redis)
            {
                return redis.GetAllItemsFromSortedSetDesc(setId);
            }
        }

        /// <summary>
        /// 有序集合升序排列
        /// </summary>
        /// <param name="setId"></param>
        /// <returns></returns>
        public List<string> GetAllItemsFromSortedSet(string setId)
        {
            using (var redis = RedisConfig.Redis)
            {
                return redis.GetAllItemsFromSortedSet(setId);
            }
        }

        /// <summary>
        /// 获得某个值在有序集合中的排名，按分数的升序排列
        /// </summary>
        /// <param name="setId"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public long GetItemIndexInSortedSet(string setId, string value)
        {
            using (var redis = RedisConfig.Redis)
            {
                return redis.GetItemIndexInSortedSet(setId, value);
            }
        }

        /// <summary>
        /// 获得有序集合中某个值得分数
        /// </summary>
        /// <param name="setId"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public double GetItemScoreInSortedSet(string setId, string value)
        {
            using (var redis = RedisConfig.Redis)
            {
                return redis.GetItemScoreInSortedSet(setId, value);
            }
        }

        /// <summary>
        /// 获得有序集合中，某个排名范围的所有值
        /// </summary>
        /// <param name="setId"></param>
        /// <param name="fromRank"></param>
        /// <param name="toRank"></param>
        /// <returns></returns>
        public List<string> GetRangeFromSortedSet(string setId, int fromRank, int toRank)
        {
            using (var redis = RedisConfig.Redis)
            {
                return redis.GetRangeFromSortedSet(setId, fromRank, toRank);
            }
        }
        #endregion
    }
}
