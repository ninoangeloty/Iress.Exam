using System;

namespace Iress.Domain
{
    public class Table
    {
        private Guid _guid = Guid.NewGuid();

        public Table(int x, int y)
        {
            Dimension = new Coordinate(x, y);
        }

        public Guid Id => _guid;
        public Coordinate Dimension { get; private set; }
    }
}
