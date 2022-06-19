using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;
using System.Threading;

namespace Iress.Infrastrcuture.Commands
{
    /// <summary>
    /// Invoke command handlers based on the command type
    /// </summary>
    public class CommandAggregator
    {
        private IEnumerable<Type> _commandHandlers;

        /// <summary>
        /// Find and cache types of ICommandHandler<,> from the assembly
        /// </summary>
        /// <param name="assembly"></param>
        public void Initialize(Assembly assembly)
        {
            var commandHandlerType = typeof(ICommandHandler<,>);

            _commandHandlers = assembly
                .GetTypes()
                .Where(_ => _
                    .GetInterfaces()
                    .Any(__ => __.IsGenericType && 
                        commandHandlerType.IsAssignableFrom(__.GetGenericTypeDefinition())));
        }

        /// <summary>
        /// Invoke command handler for the command
        /// </summary>
        /// <param name="command"></param>
        public void Invoke(ICommand command)
        {
            var handler = _commandHandlers.Single(_ => _.Name == $"{command.GetType().Name}Handler");
            var arguments = new object[] { command, null };

            var constructorParams = handler.GetConstructors().FirstOrDefault().GetParameters(); // just trying to get the first constructor for now to avoid writing too much code
            var args = new List<object>();

            if (constructorParams.Length > 0)
            {
                foreach (var param in constructorParams)
                {
                    var obj = ServiceCollection.Resolve(param.ParameterType);
                    if (obj == null)
                    {
                        throw new InvalidOperationException("Cannot resolve instance of an object.");
                    }
                    args.Add(obj);
                }
            }

            var handlerInstance = Activator.CreateInstance(handler, args.ToArray());
            var handlerMethodInfo = handlerInstance.GetType().GetMethod("Handle");
            handlerMethodInfo.Invoke(handlerInstance, arguments);
        }
    }
}
