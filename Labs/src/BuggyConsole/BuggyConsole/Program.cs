// procgov64.exe -m 100M bin\Release\net7.0\vmmapdemo.exe


using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using vmmapdemo;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;

internal class Program
{
    static void wait()
    {
        try
        {
            Console.WriteLine("Press any key to start");
            Console.ReadKey();
        }
        catch (System.InvalidOperationException)
        { }
    }


    static async Task<int> Main(string[] args)
    {
        wait();



        var descriptionText = "Use --Option Memory ,--Option Objects, --Option MemoryUsage, " +
                         "--Option Access, --Option Div0, --Option Stack, --Option Exception --Option SilentException";


        var option = new Option<string?>(
            name: "--Option",
            description: descriptionText);

        var rootCommand = new RootCommand("Sample .NET Apps");
        rootCommand.AddOption(option);

        rootCommand.SetHandler((option) =>
        {
            if (option is null)
            {
                Console.WriteLine("Please provide an option.");
                Console.WriteLine($"{descriptionText}");
                return;
            }
            
            if (option.Equals("Memory", StringComparison.InvariantCultureIgnoreCase))
            {
                MemoryScenario memory_usage = new();
                memory_usage.allocate();
            }
            else if (option.Equals("Objects", StringComparison.InvariantCultureIgnoreCase))
            {
                ObjectsScenarios objectsScenarios = new();
                objectsScenarios.Execute();
            }
            else if (option.Equals("MemoryUsage", StringComparison.InvariantCultureIgnoreCase))
            {
                MemoryUsage memoryusage = new();
                memoryusage.Execute();
            }
            else if (option.Equals("Finalizers", StringComparison.InvariantCultureIgnoreCase))
            {
                FinalizersScenario finalizersscenario = new();
                finalizersscenario.Execute();
            }
            else if (option.Equals("Access", StringComparison.InvariantCultureIgnoreCase))
            {
                CrashScenario crashScenario = new();
                crashScenario.AccessViolation();
            }
            else if (option.Equals("Div0", StringComparison.InvariantCultureIgnoreCase))
            {
                CrashScenario crashScenario = new();
                crashScenario.DivisionByZero();
            }
            else if (option.Equals("Stack", StringComparison.InvariantCultureIgnoreCase))
            {
                CrashScenario crashScenario = new();
                crashScenario.StackOverflow();
            }
            else if (option.Equals("Exception", StringComparison.InvariantCultureIgnoreCase))
            {
                CrashScenario crashScenario = new();
                crashScenario.UnhandledException();
            }
            else if (option.Equals("SilentException", StringComparison.InvariantCultureIgnoreCase))
            {
                CrashScenario crashScenario = new();
                crashScenario.SilentException();
            }
            else
            {
                Console.WriteLine("Please provide a valid option.");
                Console.WriteLine($"{descriptionText}");
                return;
            }

            Console.WriteLine("Press any key to exit");
            Console.Read();
            return;
        },
            option);

        return await rootCommand.InvokeAsync(args);
    }

}



