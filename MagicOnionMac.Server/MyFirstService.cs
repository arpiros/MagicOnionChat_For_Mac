using System;
using MagicOnion;
using MagicOnion.Server;
using ServerShared.Services;

namespace MagicOnionMac.Server
{
    public class MyFirstService : ServiceBase<IMyFirstService>, IMyFirstService
    {
        public async UnaryResult<int> SumAsync(int x, int y)
        {
            Console.WriteLine($"Received:{x}, {y}");
            return x + y;
        }
    }
}