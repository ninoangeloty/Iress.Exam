using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Iress.Infrastrcuture.Commands
{
    public interface ICommand { }

    public interface ICommandHandler<T, U>
    {
        Task<U> Handle(T command, CancellationToken cancellationToken);
    }
}
