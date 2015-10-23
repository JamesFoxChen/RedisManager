using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisSingle
{
    class FiveDataType
    {
        public void String()
        {
            var redis = new RedisHelper();

            redis.Set<string>("name", "laowang");
            string userName = redis.Get<string>("name");
            Console.WriteLine(userName);

            //访问次数
            redis.Set<int>("IpAccessCount", 0);
            //次数递增
            redis.Incr("IpAccessCount");
            Console.WriteLine(redis.Get<int>("IpAccessCount"));
        }

        public void Hash()
        {
            //一个hashid可以存储多项信息，每一项信息也有自己的key
            var redis = new RedisHelper();
            redis.SetEntryInHash("userInfoId", "name", "zhangsan");
            redis.SetEntryInHash("userInfoId", "name1", "zhangsan1");
            redis.SetEntryInHash("userInfoId", "name2", "zhangsan2");
            redis.SetEntryInHash("userInfoId", "name3", "zhangsan3");
            redis.GetHashKeys("userInfoId").ForEach(Console.WriteLine);
            redis.GetHashValues("userInfoId").ForEach(Console.WriteLine);
        }

        public void List()
        {
            //应用场景：  
            //Redis list的应用场景非常多，也是Redis最重要的数据结构之一。  
            //我们可以轻松地实现最新消息排行等功能。  
            //Lists的另一个应用就是消息队列，可以利用Lists的PUSH操作，将任务存在Lists中，然后工作线程再用POP操作将任务取出进行执行
            var redis = new RedisHelper();

            #region "List类型"

            redis.AddItemToList("userInfoId1", "123");
            redis.AddItemToList("userInfoId1", "1234");

            Console.WriteLine("List数据项条数:" + redis.GetListCount("userInfoId1"));
            Console.WriteLine("List数据项第一条数据:" + redis.GetItemFromList("userInfoId1", 0));
            Console.WriteLine("List所有数据");
            redis.GetAllItemsFromList("userInfoId1").ForEach(e => Console.WriteLine(e));
            #endregion

            #region "List类型做为队列和栈使用"
            Console.WriteLine(redis.GetListCount("userInfoId1"));
            //队列先进先出
            //Console.WriteLine(redis.DequeueItemFromList("userInfoId1"));
            //Console.WriteLine(redis.DequeueItemFromList("userInfoId1"));

            //栈后进先出
            Console.WriteLine("出栈" + redis.PopItemFromList("userInfoId1"));
            Console.WriteLine("出栈" + redis.PopItemFromList("userInfoId1"));
            #endregion
        }

        public void Set()
        {
            //应用场景：  
            //Redis set对外提供的功能与list类似是一个列表的功能，特殊之处在于set是可以自动排重的，当你需要存储一个列表数据，又不希望出现重复数据时，
            //set是一个很好的选择，并且set提供了判断某个成员是否在一个set集合内的重要接口，这个也是list所不能提供的。  
            //比如在微博应用中，每个人的好友存在一个集合（set）中，这样求两个人的共同好友的操作，可能就只需要用求交集命令即可。  
            //Redis还为集合提供了求交集、并集、差集等操作，可以非常方便的实  

            var redis = new RedisHelper();

            redis.AddItemToSet("A", "B");
            redis.AddItemToSet("A", "C");
            redis.AddItemToSet("A", "D");
            redis.AddItemToSet("A", "E");
            redis.AddItemToSet("A", "F");
            redis.AddItemToSet("A", "F");

            redis.AddItemToSet("B", "C");
            redis.AddItemToSet("B", "F");

            //求差集
            Console.WriteLine("A,B集合差集");
            redis.GetDifferencesFromSet("A", "B").ToList<string>().ForEach(e => Console.Write(e + ","));

            //求集合交集
            Console.WriteLine("\nA,B集合交集");
            redis.GetIntersectFromSets(new string[] { "A", "B" }).ToList<string>().ForEach(e => Console.Write(e + ","));

            //求集合并集
            Console.WriteLine("\nA,B集合并集");
            redis.GetUnionFromSets(new string[] { "A", "B" }).ToList<string>().ForEach(e => Console.Write(e + ","));
        }


        public void SortSet()
        {
            //应用场景：
            //以某个条件为权重，比如按顶的次数排序.  
            //ZREVRANGE命令可以用来按照得分来获取前100名的用户，ZRANK可以用来获取用户排名，非常直接而且操作容易。  
            //Redis sorted set的使用场景与set类似，区别是set不是自动有序的，而sorted set可以通过用户额外提供一个优先级(score)的参数来为成员排序，并且是插入有序的，即自动排序。  
            //比如:twitter 的public timeline可以以发表时间作为score来存储，这样获取时就是自动按时间排好序的。  
            //比如:全班同学成绩的SortedSets，value可以是同学的学号，而score就可以是其考试得分，这样数据插入集合的，就已经进行了天然的排序。  
            //另外还可以用Sorted Sets来做带权重的队列，比如普通消息的score为1，重要消息的score为2，然后工作线程可以选择按score的倒序来获取工作任务。让重要的任务优先执行。  

            var redis = new RedisHelper();

            #region "有序Set操作"
            redis.AddItemToSortedSet("SA", "B", 2);
            redis.AddItemToSortedSet("SA", "C", 1);
            redis.AddItemToSortedSet("SA", "D", 5);
            redis.AddItemToSortedSet("SA", "E", 3);
            redis.AddItemToSortedSet("SA", "F", 4);

            //有序集合降序排列
            Console.WriteLine("\n有序集合降序排列");
            redis.GetAllItemsFromSortedSetDesc("SA").ForEach(e => Console.Write(e + ","));
            Console.WriteLine("\n有序集合升序序排列");
            redis.GetAllItemsFromSortedSet("SA").ForEach(e => Console.Write(e + ","));

            redis.AddItemToSortedSet("SB", "C", 2);
            redis.AddItemToSortedSet("SB", "F", 1);
            redis.AddItemToSortedSet("SB", "D", 3);

            Console.WriteLine("\n获得某个值在有序集合中的排名，按分数的升序排列");
            Console.WriteLine(redis.GetItemIndexInSortedSet("SB", "D"));

            Console.WriteLine("\n获得有序集合中某个值得分数");
            Console.WriteLine(redis.GetItemScoreInSortedSet("SB", "D"));

            Console.WriteLine("\n获得有序集合中，某个排名范围的所有值");
            redis.GetRangeFromSortedSet("SA", 0, 3).ForEach(e => Console.Write(e + ","));

            #endregion
        }
    }
}
