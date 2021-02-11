using Grpc.Core;
using MagicOnion.Client;
using ServerShared.Services;
using UnityEngine;

namespace Component
{
    public class TestComponent : MonoBehaviour
    {
        // Start is called before the first frame update
        private async void Start()
        {
            var channel = new Channel("localhost", 5000, ChannelCredentials.Insecure);

            var client = MagicOnionClient.Create<IMyFirstService>(channel);

            var result = await client.SumAsync(123, 456);
            Debug.Log($"Result: {result}");
        }
    }
}
