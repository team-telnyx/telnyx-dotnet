// <copyright file="TelnyxMockHandler.cs" company="Telnyx">
// Copyright (c) Telnyx. All rights reserved.
// </copyright>

namespace TelnyxTests
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;

    public static class TelnyxMockHandler
    {
        private static Process process;

        private static int port = -1;

        /// <summary>
        /// Gets the port on which Telnyx-mock is listening, or -1 if no Telnyx-mock process was started.
        /// </summary>
        public static int Port { get => port; }

        /// <summary>
        /// Starts a Telnyx-mock process on an available port, if necessary.
        /// </summary>
        /// <returns>True if a Telnyx-mock process was started, false otherwise.</returns>
        public static bool StartTelnyxMock()
        {
            var specPath = Path.GetFullPath("openapi/spec3.json");
            var fixturesPath = Path.GetFullPath("openapi/fixtures3.json");

            if (!File.Exists(specPath))
            {
                return false;
            }

            if ((process != null) && !process.HasExited)
            {
                Console.WriteLine($"Telnyx-mock is already running on port #{port}");
                return true;
            }

            port = FindAvailablePort();

            Console.WriteLine($"Starting Telnyx-mock on port #{port}...");

            process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "Telnyx-mock",
                    Arguments = $"-http-port {port} -spec {specPath} -fixtures {fixturesPath}",
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                },
            };
            try
            {
                process.Start();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine($"Error while starting Telnyx-mock, error message = {e.Message}");
                Environment.Exit(1);
            }

            process.BeginOutputReadLine();
            Thread.Sleep(1000);

            if (process.HasExited)
            {
                Console.Error.WriteLine($"Telnyx-mock terminated early, status code = {process.ExitCode}");
                Environment.Exit(1);
            }

            Console.WriteLine($"Started Telnyx-mock, PID = #{process.Id}");

            return true;
        }

        /// <summary>
        /// Stop the Telnyx-mock process if one was started.
        /// </summary>
        public static void StopTelnyxMock()
        {
            if ((process == null) || process.HasExited)
            {
                return;
            }

            Console.WriteLine("Stopping Telnyx-mock...");
            process.Kill();
            process = null;
            port = -1;
            Console.WriteLine("Stopped Telnyx-mock");
        }

        /// <summary>Finds an available TCP port.</summary>
        /// <returns>The available port.</returns>
        private static int FindAvailablePort()
        {
            TcpListener l = new TcpListener(IPAddress.Loopback, 0);
            l.Start();
            int availablePort = ((IPEndPoint)l.LocalEndpoint).Port;
            l.Stop();
            return availablePort;
        }
    }
}
