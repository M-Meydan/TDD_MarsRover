using System;

namespace MarsRover
{
    internal class DirectionManager
     {
        public enum DirectionEnum { N, W, S, E }
   
        DirectionEnum _currentDirection;
        DirectionEnum _left;
        DirectionEnum _right;
        Point _location;
        Point? _obstcle;
        string _direction;
        const int MaxX = 10;
        const int MaxY = 10;
        string errorString = null;
        public DirectionManager(Point start, string direction)
        {
            _currentDirection = ParseDirection(direction);
            _location = start;
        }
        
        public string GetLocationInfo()
        {
            return $"{errorString}{_location.X}:{_location.Y}:{_currentDirection}";
        }

        void UpdateDirections()
        {
            switch (_currentDirection)
            {
                case DirectionEnum.N: _left = DirectionEnum.W; _right = DirectionEnum.E; break;
                case DirectionEnum.E: _left = DirectionEnum.N; _right = DirectionEnum.S; break;
                case DirectionEnum.W: _left = DirectionEnum.S; _right = DirectionEnum.N; break;
                case DirectionEnum.S: _left = DirectionEnum.E; _right = DirectionEnum.W; break;
            }
        }

        public void TurnLeft()
        {
            UpdateDirections();
            _currentDirection = _left;
            errorString = null;
        }

        public void TurnRight()
        {
            UpdateDirections();
            _currentDirection = _right;
            errorString = null;
        }

        internal void SetObstcle(Point obstcle)
        {
            _obstcle = obstcle;
        }

        public bool Move()
        {
            int nextLocation;
            var error = "0:";
            if (_currentDirection == DirectionEnum.N)
            {
                nextLocation = (_location.Y + 1) % MaxY;
                if (CanMove(nextLocation, _obstcle?.Y)) { _location.Y = nextLocation; }
                else errorString = error;
            }
            else if (_currentDirection == DirectionEnum.E)
            {
                nextLocation = (_location.X + 1) % MaxX;
                if (CanMove(nextLocation, _obstcle?.X)) { _location.X = nextLocation; }
                else errorString = error;
            }
            else if (_currentDirection == DirectionEnum.W)
            {
                nextLocation = (_location.X - 1 < 0 ? MaxX - 1 : _location.X-1);
                if (CanMove(nextLocation, _obstcle?.X)) { _location.X = nextLocation; }
                else errorString = error;
            }
            else if (_currentDirection == DirectionEnum.S)
            {
                nextLocation = (_location.Y-1 < 0) ? MaxY - 1 : _location.Y-1;
                if (CanMove(nextLocation, _obstcle?.Y)) { _location.Y = nextLocation; }
                else errorString = error;
            }

            return errorString == null; // no error if null 
        }

        private bool CanMove(int nextMoveLocation, int? obstcleLocation)
        {
            return (!obstcleLocation.HasValue || nextMoveLocation != obstcleLocation);
        }

        DirectionEnum ParseDirection(string direction)
        {
            return Enum.Parse<DirectionEnum>(direction);
        }
    }
}