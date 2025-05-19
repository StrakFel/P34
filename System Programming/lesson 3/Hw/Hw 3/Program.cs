using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace Hw_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int MemoryLimit = 400;
            string logName = "process_log.txt";

            Process[] processes = Process.GetProcesses();
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            while (true)
            {
                foreach (Process process in processes)
                {
                    try
                    {
                        long memoryUsage = process.PrivateMemorySize64 / (1024 * 1024);
                        string logEntry = $"[{time}] {process.ProcessName} (PID: {process.Id}) - Пам’ять: {memoryUsage} MB";

                        if (memoryUsage > MemoryLimit && memoryUsage !> 900) //Щоб Visual Studio не закривався
                        {
                            process.Kill();
                            logEntry += $"[{time}]⚠️ Процес {process.ProcessName} (PID: {process.Id}) завершено через перевищення пам'яті ({memoryUsage} MB)";
                        }

                            File.AppendAllText(logName, logEntry + Environment.NewLine);
                    }
                    catch (Exception ex)
                    {
                        File.AppendAllText(logName, $"[{time}] Не вдалося виконати процесс: {ex.Message}");
                    }
                }
                Thread.Sleep(5000);
                File.AppendAllText(logName, $"------------------------------------------------------------------------------------{Environment.NewLine}");
            }
        }
    }
}


