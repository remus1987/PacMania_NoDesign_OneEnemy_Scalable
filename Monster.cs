using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace PacMania_OneEnemy_NoGraphics_Scalable
{
    class Monster
    {
        private Rectangle _monster;
        private int _x;
        private int _y;
        private Direction _latestOppositeDirection;
        private bool _isMoved;

        public int xpos { get => _x; }
        public int ypos { get => _y; }

        public Monster(Rectangle rectangle, int x, int y)
        {
            _monster = rectangle;
            _x = x;
            _y = y;
        }

        public void Move(ObjectType[,] map)
        {//catch the exception here
            var direction = DetectDirection(map, new Direction[] { Direction.Bottom, Direction.Left, Direction.Right, Direction.Up });

            switch (direction)
            {
                case Direction.Up:
                    _y--;
                    Canvas.SetTop(_monster, (_y * _monster.Height));
                    break;
                case Direction.Right:
                    _x++;
                    Canvas.SetLeft(_monster, (_x * _monster.Width));
                    break;
                case Direction.Bottom:
                    _y++;
                    Canvas.SetTop(_monster, (_y * _monster.Height));
                    break;
                case Direction.Left:
                    _x--;
                    Canvas.SetLeft(_monster, (_x * _monster.Width));
                    break;
            }
        }

        private Direction DetectDirection(ObjectType[,] monsterMap, Direction[] directions)
        {
            var random = new Random();

            if (_isMoved)
            {
                // dont go back, go forward
                var index = Array.IndexOf(directions, _latestOppositeDirection);
                if (index != -1)
                {
                    directions = directions.RemoveAt(index);
                }

                // there is no other way, go previous direction
                if (directions.Length == 0)
                {
                    directions = new Direction[1];
                    directions[0] = _latestOppositeDirection;
                }
            }

            var randomDirection = random.Next(0, directions.Length);
            var direction = directions[randomDirection];
            var obj = ObjectType.Space;

            switch (direction)
            {
                case Direction.Up:
                    obj = monsterMap[_x, _y - 1];
                    break;
                case Direction.Right:
                    obj = monsterMap[_x + 1, _y];
                    break;
                case Direction.Bottom:
                    obj = monsterMap[_x, _y + 1];
                    break;
                case Direction.Left:
                    obj = monsterMap[_x - 1, _y];
                    break;
            }

            if (obj == ObjectType.Obstacle)
            {
                var index = Array.IndexOf(directions, direction);
                var newDirections = directions.RemoveAt(index);
                return DetectDirection(monsterMap, newDirections);
            }

            if (obj == ObjectType.Packman)
            {
                throw new Exception();
            }


            // dont go back, go forward            
            _isMoved = true;
            switch (direction)
            {
                case Direction.Up:
                    _latestOppositeDirection = Direction.Bottom;
                    break;
                case Direction.Right:
                    _latestOppositeDirection = Direction.Left;
                    break;
                case Direction.Bottom:
                    _latestOppositeDirection = Direction.Up;
                    break;
                case Direction.Left:
                    _latestOppositeDirection = Direction.Right;
                    break;
            }

            return direction;
        }
    }
}
