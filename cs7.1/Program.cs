using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace CS
{
    class Program
    {
        // async main
        static async Task Main(string[] args)
        {
            // defult expression
            int a = default; // default(int) == 0
            System.Console.WriteLine(a);
            
            // tuple name inference
            double? b = default; // default(double?) == null
            var t = (a, b);
            System.Console.WriteLine($"({t.a}, {t.b})");

            // we are in an async main - did i say that already?
            await PingMe("google.com");

            // generics pattern matching
            System.Console.WriteLine($"IsString(\"yeah!\")? {IsString("yeah!")}");
            System.Console.WriteLine($"IsString(4)? {IsString(4)}");
        }
        
        private static (string fn, string ln) GetFullName() => ("Eugene", "Krapivin");

        private static async Task PingMe(string hostName)
        {
            var host = Dns.GetHostEntry(hostName);

            using (var ping = new Ping())
            {
                var result = await ping.SendPingAsync(host.AddressList[0]);
                if (result.Status == IPStatus.Success)
                {
                    System.Console.WriteLine($"ping {hostName} ({host.AddressList[0]}), RTT: {result.RoundtripTime}ms");
                }
                else
                {
                    System.Console.WriteLine($"ping {hostName} ({host.AddressList[0]}) failed: {result.Status}");
                }
            }
        }

        // generics pattern matching
        static bool IsString<T>(T t) => t is string s;
    }
}
