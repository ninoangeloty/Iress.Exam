using Iress.Application.Robot.Commands;
using Iress.Domain;
using Iress.Infrastrcuture.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Iress.Client
{
    public class RobotCommandHelper
    {
        private const string CommandPattern = @"^([\w\-]+)";
        private const string ParametersPattern = @"\s(.*)";
        private readonly Guid _robotId;

        public RobotCommandHelper(Guid robotId)
        {
            _robotId = robotId;
        }

        /// <summary>
        /// Create a command object from the input
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public ICommand CreateCommand(string input)
        {
            var command = GetCommandString(input).ToUpper();
            var args = GetCommandParameters(input).ToUpper();

            switch (command)
            {
                case "LEFT":
                    ThrowExceptionWhenArgumentIsNotEmpty(args);
                    return new LeftCommand { RobotId = _robotId };
                case "MOVE":
                    ThrowExceptionWhenArgumentIsNotEmpty(args);
                    return new MoveCommand { RobotId = _robotId };
                case "REPORT":
                    ThrowExceptionWhenArgumentIsNotEmpty(args);
                    return new ReportCommand { RobotId = _robotId };
                case "RIGHT":
                    ThrowExceptionWhenArgumentIsNotEmpty(args);
                    return new RightCommand { RobotId = _robotId };
                case "PLACE":
                    var (x, y, direction) = GetPlaceCommandArgs(args);
                    return new PlaceCommand 
                    { 
                        RobotId = _robotId, 
                        Direction = direction, 
                        X = x, 
                        Y = y 
                    };
                default:
                    throw new CommandException("Bad command or parameter.");
            }
        }

        private static void ThrowExceptionWhenArgumentIsNotEmpty(string args)
        {
            if (!string.IsNullOrEmpty(args))
            {
                throw new CommandException("Command does not accept arguments.");
            }
        }

        private static (int x, int y, Direction direction) GetPlaceCommandArgs(string args)
        {
            var arguments = args.Split(",");
            if (arguments.Length != 3)
            {
                throw new CommandException("Invalid set of parameters.");
            }

            if (!IsInteger(arguments[0]) || !IsInteger(arguments[1]) || !IsEnum<Direction>(arguments[2]))
            {
                throw new CommandException("Invalid set of parameters.");
            }

            return (int.Parse(arguments[0]), int.Parse(arguments[1]), Enum.Parse<Direction>(arguments[2]));
        }

        private static string GetCommandString(string input)
        {
            var regex = new Regex(CommandPattern);
            return regex.Match(input).Value;
        }

        private static string GetCommandParameters(string input)
        {
            var regex = new Regex(ParametersPattern);
            return regex.Match(input).Groups[1].Value.Trim();
        }

        private static bool IsInteger(string input)
        {
            return int.TryParse(input, out _);
        }

        private static bool IsEnum<T>(string input) where T : struct, IConvertible
        {
            return Enum.TryParse<T>(input, out _);
        }
    }
}
