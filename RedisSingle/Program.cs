﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedisHelper;

namespace RedisSingle
{
    class Program
    {
        static void Main(string[] args)
        {
            fiveDataTypeTest();
        }

        private static void baseTest()
        {
            var redis = new RedisHelper();

            redis.Set<string>(RedisKeys.TestKey, DateTime.Now.ToString());

            var d = redis.Get<string>(RedisKeys.TestKey);

            redis.Remove(RedisKeys.TestKey);

            d = redis.Get<string>(RedisKeys.TestKey);
        }

        private static void fiveDataTypeTest()
        {
            var test = new FiveDataType();
            test.String();
            test.Hash();
            test.List();
            test.Set();
            test.SortSet();
        }
    }
}
