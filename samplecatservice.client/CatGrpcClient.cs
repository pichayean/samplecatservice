using Grpc.Core;
using Grpc.Net.Client;
using Grpc.Net.Client.Configuration;

namespace samplecatservice.client
{
    public class CatGrpcClient
    {
        public readonly GrpcChannel channel;
        public CatGrpcClient()
        {
            channel = GrpcChannel.ForAddress("http://localhost:5161", new GrpcChannelOptions
            {
                Credentials = ChannelCredentials.Insecure,
                ServiceConfig = new ServiceConfig
                {
                    LoadBalancingConfigs = { new RoundRobinConfig() },
                    MethodConfigs = { new MethodConfig {
                        Names = { MethodName.Default },
                        RetryPolicy = new RetryPolicy
                        {
                            MaxAttempts = 5,
                            InitialBackoff = TimeSpan.FromSeconds(1),
                            MaxBackoff = TimeSpan.FromSeconds(5),
                            BackoffMultiplier = 1.5,
                            RetryableStatusCodes = { StatusCode.Unavailable }
                        }
                    } }
                }
            });
        }

        public void AddCats(string[] cats)
        {
            var client = new grpc.Cats.CatsClient(channel);
            foreach (var item in cats)
            {
                var cat = client.CreateCatAsync(new grpc.CreateCatRequest
                {
                    Name = item,
                    Color = "Red"
                }).GetAwaiter().GetResult();
            }
        }

        public grpc.CatsReply GetCats()
        {
            var client = new grpc.Cats.CatsClient(channel);
            return client.GetCatsAsync(new grpc.EmptyRequest()).GetAwaiter().GetResult();
        }
        public void DeleteCats(string id)
        {
            var client = new grpc.Cats.CatsClient(channel);
            client.RemoveCatAsync(new grpc.CatIdRequest{Id=id}).GetAwaiter().GetResult();
        }
    }
}
