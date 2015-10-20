using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Redis;

namespace RedisHelper
{
    public class RedisKeys
    {

        public const string TestKey = "TestKey";

        /// <summary>
        //  当前用户信息(0}为ID
        /// </summary>
        public const string CurrentUserInfo = "CurrentUser:{0}";
    }
}
