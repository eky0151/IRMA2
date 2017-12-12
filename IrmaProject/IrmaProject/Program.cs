﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net;

namespace IrmaProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            var host = WebHost.CreateDefaultBuilder(args)
                 .ConfigureLogging(factory =>
                 {
                     factory.AddConsole();
                     factory.AddFilter("Console", level => level >= LogLevel.Information);
                 })
                 .UseKestrel(options =>
                 {
                     options.Listen(IPAddress.Loopback, 44356, listenoptions =>
                     {
                         listenoptions.UseHttps("sslcert/self-signed-cert.pfx", "alma");
                     });
                 })
                 .UseContentRoot(Directory.GetCurrentDirectory())
                 //.UseIISIntegration()
                 .UseStartup<Startup>()
                 .Build();

            return host;
        }
    }
}
