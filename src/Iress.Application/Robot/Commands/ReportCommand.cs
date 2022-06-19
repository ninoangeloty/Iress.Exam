using Iress.Infrastrcuture.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Iress.Infrastrcuture.Reporter;

namespace Iress.Application.Robot.Commands
{
    public class ReportCommand : ICommand
    {
        public Guid RobotId { get; set; }
    }

    public class ReportCommandHandler : ICommandHandler<ReportCommand, Guid>
    {
        private readonly IConsoleReporter _reporter;

        public ReportCommandHandler(IConsoleReporter reporter)
        {
            _reporter = reporter;
        }

        public Task<Guid> Handle(ReportCommand command, CancellationToken cancellationToken)
        {
            var robot = CacheContext.Instance.Robot.Single(_ => _.Id == command.RobotId);

            if (robot.Position != null)
            {
                _reporter.Report($"Output: {robot.Position.Value.X},{robot.Position.Value.Y},{robot.Direction}");
            }
            else
            {
                _reporter.Report("Robot has not been placed.");
            }

            return Task.FromResult(robot.Id);
        }
    }
}
