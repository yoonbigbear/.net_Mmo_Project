//using StackExchange.Redis;

//namespace TCPUtil
//{
	

//	public class Redis : Singleton<Redis>
//	{
//		IDatabase db;

//		public void Start(RedisConfig config)
//		{
//			using (ConnectionMultiplexer conn = ConnectionMultiplexer.Connect($"{config.Ip}:{config.Port}"))
//			{
//				if (conn.IsConnected)
//				{
//					db = conn.GetDatabase();
//					return;
//				}
//			}
//		}
//	}
//}