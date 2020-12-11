using System;
using System.Collections.Generic;

namespace MarsRover
{
    public class Rover
    {
        enum CommandEnum { L, R, M }
        DirectionManager _directionManager;
        
        public Rover(Point start, string direction)
        {
            _directionManager=new DirectionManager(start, direction);
        }

        public string Execute(string commandList)
        {
            foreach (var command in commandList)
            {
                ParseCommand(command, out CommandEnum validCommand);
                if (!RunCommand(validCommand))
                    break;
            }

            return _directionManager.GetLocationInfo();
        }

        bool RunCommand(CommandEnum validCommand)
        {
            if (validCommand == CommandEnum.L) { _directionManager.TurnLeft(); return true; }
            else if (validCommand == CommandEnum.R) { _directionManager.TurnRight(); return true; }
            else if (validCommand == CommandEnum.M) { return _directionManager.Move(); }

            return false;
        }

        bool ParseCommand(char command, out CommandEnum validCommand)
        {
            if (Enum.TryParse<CommandEnum>(command.ToString(), out validCommand))
                return true;
            throw new Exception("Command cannot be parsed!");
        }

        internal void SetObstcle(Point obstcle)
        {
            _directionManager.SetObstcle(obstcle);
        }
    }
}

//    internal class Rover
//    {
//        int _x, _y;
//        DirectionEnum _direction;

//        Dictionary<CommandEnum, DirectionEnum> NorthCommandMap;
//        Dictionary<CommandEnum, DirectionEnum> SouthCommandMap;
//        Dictionary<CommandEnum, DirectionEnum> EastCommandMap;
//        Dictionary<CommandEnum, DirectionEnum> WestCommandMap;

//        public Rover(int x, int y, string direction)
//        {
//            _direction = ParseDirection(direction);
//            _x = x;
//            _y = y;

//        }

//        public string Execute(string commandList)
//        {
//            string result= string.Empty;
//            foreach (var command in commandList)
//            {
//                if (ParseCommand(command, out CommandEnum validCommand))
//                {
//                    //move here
//                    switch (validCommand)
//                    {
//                        case CommandEnum.M:
//                            Move(); break;
//                        case CommandEnum.L:
//                            TurnLeft(); break;
//                        case CommandEnum.R:
//                            TurnRight();
//                    }

//                     _direction = GetDirection(validCommand);
//                    result = $"{_x}:{_y}:{_direction}";
//                    continue;
//                }
//            }
//            return result;
//        }

//        private DirectionEnum TurnRight()
//        {
//            switch (_direction)
//            {
//                case DirectionEnum.N: return NorthCommandMap[validCommand];
//                case DirectionEnum.N: return NorthCommandMap[validCommand];
//                case DirectionEnum.N: return NorthCommandMap[validCommand];
//                case DirectionEnum.N: return NorthCommandMap[validCommand];
//            }
//            if (_direction == DirectionEnum.N) return NorthCommandMap[validCommand];
//            else if (_direction == DirectionEnum.E && (validCommand == CommandEnum.R || validCommand == CommandEnum.L))
//                return EastCommandMap[validCommand];
//            else if (_direction == DirectionEnum.S && (validCommand == CommandEnum.R || validCommand == CommandEnum.L))
//                return SouthCommandMap[validCommand];
//            else if (_direction == DirectionEnum.W && (validCommand == CommandEnum.R || validCommand == CommandEnum.L))
//                return WestCommandMap[validCommand];

//            throw new Exception($"{validCommand} is not mapped!");
//        }

//        //private DirectionEnum ChangeDirection(CommandEnum validCommand)
//        //{
//        //    if (_direction == DirectionEnum.N && (validCommand == CommandEnum.R || validCommand == CommandEnum.L || validCommand == CommandEnum.M))
//        //        return NorthCommandMap[validCommand];
//        //    else if (_direction == DirectionEnum.E && (validCommand == CommandEnum.R || validCommand == CommandEnum.L))
//        //        return EastCommandMap[validCommand];
//        //    else if (_direction == DirectionEnum.S && (validCommand == CommandEnum.R || validCommand == CommandEnum.L))
//        //        return SouthCommandMap[validCommand];
//        //    else if (_direction == DirectionEnum.W && (validCommand == CommandEnum.R || validCommand == CommandEnum.L))
//        //        return WestCommandMap[validCommand];

//        //    throw new Exception($"{validCommand} is not mapped!");
//        //}

//        //private DirectionEnum Move(CommandEnum validCommand)
//        //{
//        //    if (_direction == DirectionEnum.N && validCommand == CommandEnum.M)
//        //        return NorthCommandMap[validCommand];
//        //    else if (_direction == DirectionEnum.E && (validCommand == CommandEnum.R || validCommand == CommandEnum.L))
//        //        return EastCommandMap[validCommand];
//        //    else if (_direction == DirectionEnum.S && (validCommand == CommandEnum.R || validCommand == CommandEnum.L))
//        //        return SouthCommandMap[validCommand];
//        //    else if (_direction == DirectionEnum.W && (validCommand == CommandEnum.R || validCommand == CommandEnum.L))
//        //        return WestCommandMap[validCommand];

//        //    throw new Exception($"{validCommand} is not mapped!");
//        //}

//        private bool ParseCommand(char command, out CommandEnum validCommand)
//        {
//            return Enum.TryParse<CommandEnum>(command.ToString(), out validCommand);
//        }

//        DirectionEnum ParseDirection(string direction)
//        {
//            return Enum.Parse<DirectionEnum>(direction);
//        }
//    }

//    enum DirectionEnum { N, W, S, E }
//    enum CommandEnum { L, R, M }
//}