using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Redis;

namespace RedisReadWrite
{
    class RedisConfig
    {
        public static RedisClient Redis
        {
            get
            {
                return (RedisClient)reidsPools.GetClient();
            }
        }

        private static string[] hosts;
        private static PooledRedisClientManager reidsPools;
        static RedisConfig()
        {
            var readWriteHosts = ConfigurationManager.AppSettings["ReadWriteHosts"].Split(',');
            var readOnlyHosts = ConfigurationManager.AppSettings["ReadOnlyHosts"].Split(',');

            reidsPools = new PooledRedisClientManager(readWriteHosts, readOnlyHosts, new RedisClientManagerConfig
            {
                MaxWritePoolSize = 100,//“写”链接池链接数
                MaxReadPoolSize = 200,//“读”链接池链接数
                AutoStart = true,
                DefaultDb = 0
            });
        }
    }
}
