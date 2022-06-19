using System;
using System.Collections.Generic;
using System.Text;

namespace Iress.Domain
{
    public class Robot
    {
        private readonly Coordinate _tableDimensions;
        private Guid _guid = Guid.NewGuid();

        public Robot(int tableX, int tableY)
        {
            _tableDimensions = new Coordinate(tableX, tableY);
            Direction = Direction.NONE;
        }

        public void Place(int x, int y, Direction direction)
        {
            if (IsPositionValid(x, y))
            {
                Position = new Coordinate(x, y);
                Direction = direction;
            }
        }

        public void Move()
        {
            if (Position == null)
            {
                return;
            }

            switch (Direction)
            {
                case Direction.NORTH:
                    if (IsPositionValid(Position.Value.X + 1, Position.Value.Y))
                    {
                        Position = new Coordinate(Position.Value.X + 1, Position.Value.Y);
                    }
                    break;
                case Direction.SOUTH:
                    if (IsPositionValid(Position.Value.X - 1, Position.Value.Y))
                    {
                        Position = new Coordinate(Position.Value.X - 1, Position.Value.Y);
                    }
                    break;
                case Direction.EAST:
                    if (IsPositionValid(Position.Value.X, Position.Value.Y + 1))
                    {
                        Position = new Coordinate(Position.Value.X, Position.Value.Y + 1);
                    }
                    break;
                case Direction.WEST:
                    if (IsPositionValid(Position.Value.X, Position.Value.Y - 1))
                    {
                        Position = new Coordinate(Position.Value.X, Position.Value.Y - 1);
                    }
                    break;
            }
        }

        public void Right()
        {
            if (Position == null)
            {
                return;
            }

            int current = (int)Direction;
            int length = Enum.GetNames(typeof(Direction)).Length - 1;
            if (current == length)
            {
                Direction = (Direction)Enum.Parse(typeof(Direction), "1");
            }
            else
            {
                Direction = (Direction)Enum.Parse(typeof(Direction), $"{current + 1}");
            }
        }

        public void Left()
        {
            if (Position == null)
            {
                return;
            }

            int current = (int)Direction;
            int length = Enum.GetNames(typeof(Direction)).Length - 1;
            if (current == 1)
            {
                Direction = (Direction)Enum.Parse(typeof(Direction), length.ToString());
            }
            else
            {
                Direction = (Direction)Enum.Parse(typeof(Direction), $"{current - 1}");
            }
        }

        private bool IsPositionValid(int x, int y)
        {
            return x >= 0 && x <= (_tableDimensions.X - 1) && y >= 0 && y <= (_tableDimensions.Y - 1);
        }

        public Coordinate? Position { get; private set; }
        public Direction Direction { get; private set; }
        public Guid Id => _guid;
    }
}
