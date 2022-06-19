using Iress.Infrastrcuture.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Iress.Application.Robot.Commands
{
    public class MoveCommand : ICommand
    {
        public Guid RobotId { get; set; }
    }

    public class MoveCommandHandler : ICommandHandler<MoveCommand, Guid>
    {
        public Task<Guid> Handle(MoveCommand command, CancellationToken cancellationToken)
        {
            var robot = CacheContext.Instance.Robot.Single(_ => _.Id == command.RobotId);

            robot.Move();

            return Task.FromResult(robot.Id);
        }
    }
}
