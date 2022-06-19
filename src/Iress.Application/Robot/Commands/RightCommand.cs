using Iress.Infrastrcuture.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Iress.Application.Robot.Commands
{
    public class RightCommand : ICommand
    {
        public Guid RobotId { get; set; }
    }

    public class RightCommandHandler : ICommandHandler<RightCommand, Guid>
    {
        public Task<Guid> Handle(RightCommand command, CancellationToken cancellationToken)
        {
            var robot = CacheContext.Instance.Robot.Single(_ => _.Id == command.RobotId);

            robot.Right();

            return Task.FromResult(robot.Id);
        }
    }
}
