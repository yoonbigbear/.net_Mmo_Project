//using RabbitMQ.Client;
//using RabbitMQ.Client.Events;
//using TCPCore;

//namespace TCPUtil
//{
//    //TODO
//    //나중에 다시 만들어야함
//    public class RabbitMQConsumer : Singleton<RabbitMQConsumer>
//    {
//        IConnection _connection;
//        IModel _channel;
//        EventingBasicConsumer _consumer;

//        RabbitMQConfig _rabbitMQConfig;

//        ~RabbitMQConsumer()
//        {
//            _connection?.Dispose();
//            _channel?.Dispose();
//        }


//        public void Start(RabbitMQConfig rabbitMQConfig)
//        {
//            _rabbitMQConfig = rabbitMQConfig;
//            try
//            {
//                var factory = new ConnectionFactory()
//                {
//                    HostName = _rabbitMQConfig.Host,
//                    UserName = _rabbitMQConfig.Id,
//                    Password = _rabbitMQConfig.Pw
//                };
//                foreach (var e in _rabbitMQConfig.PubSub)
//                {
//                    _connection = factory.CreateConnection();
//                    _channel = _connection.CreateModel();
//                    {
//                        //exchage 생성
//                        _channel.ExchangeDeclare(exchange: e.Key, type: ExchangeType.Fanout);

//                        //큐 생성
//                        _channel.QueueDeclare(queue: e.Value,
//                            durable: false,
//                            exclusive: false,
//                            autoDelete: false);

//                        _channel.QueueBind(queue: e.Value,
//                                          exchange: e.Key,
//                                          routingKey: "");

//                        // consumer 생성
//                        _consumer = new EventingBasicConsumer(_channel);
//                        _consumer.Received += (model, ea) =>
//                        {
//                            //mq 콜백
//                            var body = ea.Body.ToArray();
//                        };
//                    }
//                }
//            }
//            catch (Exception e)
//            {
//                Logger.DebugError(e.Message);
//                Logger.LogError(e.Message);
//            }
//        }

//        public void Consume()
//        {
//            //mq 수신
//            _channel.BasicConsume(queue: _rabbitMQConfig.PubSub[0].Value,
//                                        autoAck: true,
//                                        consumer: _consumer);
//        }
//    }
//}