//using RabbitMQ.Client;
//using TCPCore;

//namespace TCPUtil
//{
    


//    public class RabbitMQProducer : Singleton<RabbitMQProducer>
//    {
//        IConnection connection;
//        IModel channel;

//        RabbitMQConfig _rabbitMQConfig;
//        ~RabbitMQProducer()
//        {
//            connection?.Dispose();
//            channel?.Dispose();
//        }

//        public void Start(RabbitMQConfig config)
//        {
//            _rabbitMQConfig = config;
//            try
//            {
//                var factory = new ConnectionFactory()
//                {
//                    HostName = _rabbitMQConfig.Host,
//                    UserName = _rabbitMQConfig.Id,
//                    Password = _rabbitMQConfig.Pw
//                };
//                connection = factory.CreateConnection();
//                channel = connection.CreateModel();
//                channel.ExchangeDeclare(exchange: _rabbitMQConfig.PubSub[0].Key, type: ExchangeType.Fanout);
//            }
//            catch (Exception e)
//            {
//                Logger.DebugError(e.Message);
//                Logger.LogError(e.Message);
//            }
//        }

//        public void Publish(byte[] data)
//        {
//            // mq 데이터 전송
//            channel.BasicPublish(exchange: _rabbitMQConfig.PubSub[0].Key,
//                                 routingKey: "",
//                                 basicProperties: null,
//                                 body: data);
//        }
//    }
//}