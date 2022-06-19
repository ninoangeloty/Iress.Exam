using Iress.Application;
using Iress.Application.Robot.Commands;
using Iress.Domain;
using Iress.Infrastrcuture;
using Iress.Infrastrcuture.Commands;
using Iress.Infrastrcuture.Reporter;
using System;
using System.Threading;

namespace Iress.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var acceptInput = true;

            // setup dependency injection
            ServiceCollection.Add<IConsoleReporter, ConsoleReporter>();

            // setup context data
            var (table, robot) = SetupData();
            SetupContext(table, robot);

            // intialize command aggregator
            var aggregator = new CommandAggregator();
            aggregator.Initialize(typeof(CacheContext).Assembly);

            var commandHelper = new RobotCommandHelper(robot.Id);

            // start reading input
            while (acceptInput)
            {
                Console.Write("Enter command (type 'exit' to terminate): ");
                var input = Console.ReadLine();

                if (input.ToLower().Trim() == "exit")
                {
                    acceptInput = false;
                }
                else
                {                    
                    try
                    {
                        var command = commandHelper.CreateCommand(input);
                        aggregator.Invoke(command);
                    }
                    catch (CommandException)
                    {
                        Console.WriteLine("Bad command or parameter.");
                    }
                }
            }
        }

        private static(Table Table, Robot Robot) SetupData()
        {
            var table = new Table(5, 5);
            var robot = new Robot(table.Dimension.X, table.Dimension.Y);

            return (table, robot);
        }

        private static void SetupContext(Table table, Robot robot)
        {
            CacheContext.Instance.Table.Add(table);
            CacheContext.Instance.Robot.Add(robot);
        }
    }

    public class ConsoleReporter : IConsoleReporter
    {
        public void Report(string message)
        {
            Console.WriteLine(message);
        }
    }
}
