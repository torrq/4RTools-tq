using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _4RTools.Utils
{
    public static class DebugLogger
    {
        private static readonly object _logLock = new object();
        private static readonly string _logFilePath = "4rtools_debug.txt";
        private static readonly System.Timers.Timer _flushTimer;
        private static readonly Queue<string> _messageQueue = new Queue<string>();
        private static bool _isInitialized = false;
        private static readonly int _flushIntervalMs = 1000; // Flush to file every second

        // Log levels
        public enum LogLevel
        {
            INFO,
            WARNING,
            ERROR,
            DEBUG
        }

        static DebugLogger()
        {
            try
            {
                // Create log file with header if it doesn't exist
                if (!File.Exists(_logFilePath))
                {
                    using (StreamWriter writer = new StreamWriter(_logFilePath, false, Encoding.UTF8))
                    {
                        writer.WriteLine($"=== 4RTOOLS DEBUG LOG === Started on {DateTime.Now} ===");
                        writer.WriteLine("============================================");
                    }
                }
                else
                {
                    // Add separation for new session
                    using (StreamWriter writer = new StreamWriter(_logFilePath, true, Encoding.UTF8))
                    {
                        writer.WriteLine("");
                        writer.WriteLine($"=== NEW SESSION STARTED {DateTime.Now} ===");
                        writer.WriteLine("============================================");
                    }
                }

                // Initialize flush timer
                _flushTimer = new System.Timers.Timer(_flushIntervalMs);
                _flushTimer.Elapsed += (s, e) => FlushQueue();
                _flushTimer.AutoReset = true;
                _flushTimer.Start();

                _isInitialized = true;
                Log(LogLevel.INFO, "DebugLogger initialized successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to initialize DebugLogger: {ex.Message}");
            }
        }

        // Main logging method
        public static void Log(LogLevel level, string message)
        {
            try
            {
                string formattedMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}] [{level}] {message}";

                // Also output to console for visibility during development
                Console.WriteLine(formattedMessage);

                // Add to queue for file writing
                lock (_logLock)
                {
                    _messageQueue.Enqueue(formattedMessage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DebugLogger.Log: {ex.Message}");
            }
        }

        // Various helper methods for different log levels
        public static void Info(string message) => Log(LogLevel.INFO, message);
        public static void Warning(string message) => Log(LogLevel.WARNING, message);
        public static void Error(string message) => Log(LogLevel.ERROR, message);
        public static void Error(Exception ex, string context = "")
        {
            string message = string.IsNullOrEmpty(context) ?
                $"Exception: {ex.Message}" :
                $"{context}: {ex.Message}";

            Log(LogLevel.ERROR, message);
            Log(LogLevel.DEBUG, $"Stack trace: {ex.StackTrace}");
        }
        public static void Debug(string message) => Log(LogLevel.DEBUG, message);

        // Method to log memory values with addresses
        public static void LogMemoryValue(string description, IntPtr address, object value)
        {
            Log(LogLevel.DEBUG, $"Memory {description}: Address={address.ToInt64():X8}, Value={value}");
        }

        // Method to flush queue to disk
        private static void FlushQueue()
        {
            if (!_isInitialized)
                return;

            try
            {
                List<string> messagesToWrite = null;

                lock (_logLock)
                {
                    if (_messageQueue.Count == 0)
                        return;

                    messagesToWrite = _messageQueue.ToList();
                    _messageQueue.Clear();
                }

                if (messagesToWrite != null && messagesToWrite.Count > 0)
                {
                    using (StreamWriter writer = new StreamWriter(_logFilePath, true, Encoding.UTF8))
                    {
                        foreach (string msg in messagesToWrite)
                        {
                            writer.WriteLine(msg);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error flushing log queue: {ex.Message}");
            }
        }

        // Call this on application exit to ensure all logs are written
        public static void Shutdown()
        {
            if (!_isInitialized)
                return;

            try
            {
                _flushTimer.Stop();
                FlushQueue();

                using (StreamWriter writer = new StreamWriter(_logFilePath, true, Encoding.UTF8))
                {
                    writer.WriteLine($"=== SESSION ENDED {DateTime.Now} ===");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during DebugLogger shutdown: {ex.Message}");
            }
        }
    }
}