using Iress.Infrastrcuture.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Iress.Application.Robot.Commands
{
    public class LeftCommand : ICommand
    {
        public Guid RobotId { get; set; }
    }

    public class LeftCommandHandler : ICommandHandler<LeftCommand, Guid>
    {
        public Task<Guid> Handle(LeftCommand command, CancellationToken cancellationToken)
        {
            var robot = CacheContext.Instance.Robot.Single(_ => _.Id == command.RobotId);

            robot.Left();

            return Task.FromResult(robot.Id);
        }
    }
}
