using Iress.Domain;
using Iress.Infrastrcuture.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Iress.Application.Robot.Commands
{
    public class PlaceCommand : ICommand
    {
        public Guid RobotId { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Direction { get; set; }
    }

    public class PlaceCommandHandler : ICommandHandler<PlaceCommand, Guid>
    {
        public Task<Guid> Handle(PlaceCommand command, CancellationToken cancellationToken)
        {
            var robot = CacheContext.Instance.Robot.Single(_ => _.Id == command.RobotId);

            robot.Place(command.X, command.Y, command.Direction);

            return Task.FromResult(robot.Id);
        }
    }
}
