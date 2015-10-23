using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RedisHelper;

namespace RedisMessageQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            var key = "queue";
            using (var redis = RedisConfig.Redis)
            {
                redis.LPush(key, "task1".ToBytes());
                redis.LPush(key, "task2".ToBytes());
                redis.LPush(key, "task3".ToBytes());

                Console.WriteLine(redis.LLen(key));

                //while (true)
                //{
                //    //RPop 没有值，返回null
                //    string str = redis.RPop(key).ToStr();
                //    Console.WriteLine(str);
                //    Thread.Sleep(1000);
                //}

                while (true)
                {
                    Console.WriteLine("start");

                    //RPop 没有值，阻塞(0表示一直阻塞，具体数字表示阻塞时间，单位为秒)
                    //str第一个表示Key、第二个表示值
                    string[] str = redis.BRPop(key, 0).ToStrArray();
                    if (str != null)
                    {
                        Console.WriteLine("key:" + str[0] + " value:" + str[1]);
                    }
                   
                }
            }
        }
    }
}
