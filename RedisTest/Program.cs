using StackExchange.Redis;
using System;

namespace RedisTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");

            IDatabase db = redis.GetDatabase();

            ISubscriber sub = redis.GetSubscriber();
            sub.Subscribe("messages", (channel, message) => {
                Console.WriteLine((string)message);
            });

            sub.Publish("messages", "hello");


            string value = "abcdefg";
            db.StringSet("mykey", value);

            value = "";

            value = db.StringGet("mykey");
            Console.WriteLine(value); // writes: "abcdefg

            

        }
    }
}
