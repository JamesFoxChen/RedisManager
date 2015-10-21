using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedisHelper;

namespace RedisReadWrite
{
    class Program
    {
        static void Main(string[] args)
        {
            var redis = new RedisHelper();

            redis.Set<string>(RedisKeys.TestKey, DateTime.Now.ToString());

            var d = redis.Get<string>(RedisKeys.TestKey);

            redis.Remove(RedisKeys.TestKey);

            d = redis.Get<string>(RedisKeys.TestKey);
        }
    }
}
