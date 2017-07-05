using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace local_functions
{
  class Program
  {
    static void Main(string[] args)
    {
      new IteratorDemo().Demo();

      //new Program().MainAsync().ConfigureAwait(false).GetAwaiter().GetResult(); // we'll have MainAsync as entry point in C# 7.1 hopefully
    }

    public async Task MainAsync()
    {
      const string ip = "a.28.166.97";
      var task = PingDemo.PingIP(ip); // will it throw?
      // var taskImpl = PingDemo.PingIPOldWay(ip); 
      // var taskLocal = PingDemo.PingIPLocalFunction(ip); // will it throw?

      //System.Console.WriteLine(await task);
      //System.Console.WriteLine(await taskImpl); 
      //System.Console.WriteLine(await taskLocal);
      //System.Console.WriteLine("we are already here");
    }
  }
}
