using System;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class PingDemo
{
  private const string ipRegex = @"\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b";

  public static Task<bool> PingIPLocalFunction(string ip)
  {
    // lets make sure we've really got an IP here
    if (!IsValidIP(ip)) throw new ArgumentException($"{ip} is not an IP my friend");

    return pingIP(ip); // note that we do not await the task to avoid state machine creation

    async Task<bool> pingIP(string target)
    {
      using (var ping = new Ping())
      {
        var result = await ping.SendPingAsync(target);

        return result.Status == IPStatus.Success;
      }
    }

  }

  public static Task<bool> PingIPOldWay(string ip)
  {
    // lets make sure we've really got an IP here
    if (!IsValidIP(ip)) throw new ArgumentException($"{ip} is not an IP my friend");

    return PingIPOldWayImpl(ip);
  }
  private static async Task<bool> PingIPOldWayImpl(string ip)
  {
    using (var ping = new Ping())
    {
      var result = await ping.SendPingAsync(ip);

      return result.Status == IPStatus.Success;
    }
  }

  public static async Task<bool> PingIP(string ip)
  {
    // lets make sure we've really got an IP here
    if (!IsValidIP(ip)) throw new ArgumentException($"{ip} is not an IP my friend");

    using (var ping = new Ping())
    {
      var result = await ping.SendPingAsync(ip);

      return result.Status == IPStatus.Success;
    }
  }

  private static bool IsValidIP(string ip) => Regex.IsMatch(ip, ipRegex);
}