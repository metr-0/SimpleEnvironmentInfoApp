using System;
using System.Security;

namespace SimpleEnvironmentInfoApp
{
    class Program
    {
        static void Main()
        {
            ConfigureConsole();

            PrintMachineData();
            PrintOSData();
            PrintLaunchAppData();

            Console.Read();
        }

        static void ConfigureConsole()
        {
            try { Console.SetWindowSize(160, 40); }
            catch (PlatformNotSupportedException) { }
            catch (ArgumentOutOfRangeException) { }
            catch (SecurityException) { }

            try { Console.ForegroundColor = ConsoleColor.Green; }
            catch (SecurityException) { }
        }

        static void PrintMachineData()
        {
            Console.WriteLine("<--- Информация о компьютере: --->");

            try { Console.WriteLine($"Имя компьютера: {Environment.MachineName}"); }
            catch (InvalidOperationException) { Console.WriteLine("! Не удалось получить имя компьютера..."); }

            Console.WriteLine($"Количество доступных процессоров: {Environment.ProcessorCount}");

            try { Console.WriteLine($"Список логических дисков: {string.Join("; ", Environment.GetLogicalDrives())}"); }
            catch (SecurityException) { Console.WriteLine("! Не удалось получить список логических дисков - отсутствуют разрешения..."); }
        }

        static void PrintOSData()
        {
            Console.WriteLine("<--- Иформацфия об операционной системе: --->");

            try { Console.WriteLine($"Версия ОС: {Environment.OSVersion}"); }
            catch (InvalidOperationException) { Console.WriteLine("! Не удалось получить версию ОС..."); }

            Console.WriteLine($"Разрядность ОС: {(Environment.Is64BitOperatingSystem ? "x64" : "x86")}");
            Console.WriteLine($"Системная папка: {Environment.SystemDirectory}");
        }

        static void PrintLaunchAppData()
        {
            Console.WriteLine("<--- Информация о запуске приложения: --->");

            string[] args = Environment.GetCommandLineArgs();
            if (args.Length != 0)
            {
                Console.WriteLine("Аргументы командной строки:");

                for (int i = 0; i < args.Length; i++)
                    Console.WriteLine($" {i + 1}. {args[i]}");
            }
            else { Console.WriteLine("Аргументы командной строки отсутствуют"); }

            try { Console.WriteLine($"Рабочая директория: {Environment.CurrentDirectory}"); }
            catch (SecurityException) { Console.WriteLine("! Не удалось получить рабочую директорию - отсутствуют разрешения..."); }

            Console.WriteLine($"Имя запустившего пользователя: {Environment.UserName}");

            try { Console.WriteLine($"Сетевой домен пользователя: {Environment.UserDomainName}"); }
            catch (PlatformNotSupportedException) { Console.WriteLine("! Не удалось получить сетевой домен пользователя - платформа не поддерживает сетевые домены..."); }
            catch (InvalidOperationException) { Console.WriteLine("! Не удалось получить сетевой домен пользователя..."); }

            Console.WriteLine($"Версия среды CLR: {Environment.Version}");
        }
    }
}
