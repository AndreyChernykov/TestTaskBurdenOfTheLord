using System;
using System.Collections.Generic;

namespace TestTask.GeometricFigure
{
    public class ApplicationFigure
    {
        public void ApplicationStart()
        {
            IOManager iOManager = new IOManager();
            iOManager.StartApplication();
        }
    }

    public class Figure
    {
        public float SideA { get; private set; }
        public float SideB { get; private set; }
        private int _sideCount = 4;

        public Figure() { }

        public Figure(float sideLength)
        {
            SideA = sideLength;
        }

        public Figure(float sideA, float sideB)
        {
            SideA = sideA;
            SideB = sideB;
        }

        public float GetPerimetr()
        {
            return SideA * _sideCount;
        }

        public float GetArea()
        {
            return SideA * SideB;
        }

        public bool CheckFigure()
        {
            if (SideA > 0) return true;
            return false;
        }

    }

    public class Square : Figure
    {
        public Square(float side) : base(side) { }

        public new float GetArea()
        {
            return (float)Math.Pow(SideA, 2);
        }
    }

    public class Rectangle : Figure
    {
        public Rectangle(float sideA, float sideB) : base(sideA, sideB) { }

        public new float GetPerimetr()
        {
            return (SideA + SideB) * 2;
        }

        public new bool CheckFigure()
        {
            if (SideA <= 0 || SideB <= 0) return false;
            return true;
        }
    }

    public class Circle : Figure
    {
        private float _circleFactor = 2f;

        public Circle(float radius) : base(radius) { }

        public new float GetPerimetr()
        {
            return _circleFactor * (float)Math.PI * SideA;
        }

        public new float GetArea()
        {
            return (float)(Math.PI * Math.Pow(SideA, 2));
        }
    }

    public class Rhombus : Figure
    {
        public float Angle { get; private set; }
        public Rhombus(float sideLength, float angle) : base(sideLength) { Angle = angle; }

        public new float GetArea()
        {
            return (float)(Math.Pow(SideA, 2) * Math.Sin(Angle * Math.PI/180));
        }

        public new bool CheckFigure()
        {
            if (Angle <= 0 || Angle >= 180) return false;
            if (SideA <= 0) return false;
            return true;
        }

    }

    public class IOManager
    {
        private string _createCommandString = "Для того чтобы создать фигуру введите:";
        private string _perimetrString = "периметр = ";
        private string _areaString = "площадь = ";
        private string _sideAString = "Введите сторону фигуры ";
        private string _sideBString = "Ведите вторую сторону фигуры ";
        private string _radiusInputString = "Введите радиус ";
        private string _angleInputString = "Введите угол между сторонами ";
        private string _incorrectDataMessage = "Неверные данные";
        private string _incorrectFigureMessage = "Такая фигура не может существовать";
        private List<string> _figureNameList = new List<string>() { " Квадрат", " Прямоугольник", " Круг", " Ромб" };

        private TypeFigure _typeFigure;

        public void StartApplication()
        {
            do
            {
                Console.WriteLine(_createCommandString);
                foreach (TypeFigure typeFigure in Enum.GetValues(typeof(TypeFigure)))
                {
                    Console.WriteLine((int)typeFigure + _figureNameList[(int)typeFigure - 1]);
                }

                string command = Console.ReadLine();
                if (Enum.TryParse(command, out TypeFigure type)) 
                {
                    if ((int)type > 0 && Enum.GetNames(typeof(TypeFigure)).Length >= (int)type) CreateFigure(type);
                    else
                    {
                        Console.WriteLine(_incorrectDataMessage);                       
                    }
                }
                else
                {
                    Console.WriteLine(_incorrectDataMessage);                  
                }


            } while (true);
        }

        private void CreateFigure(TypeFigure type)
        {
            _typeFigure = type;
            switch (type)
            {
                case TypeFigure.Square:
                    CreateSquare();
                    break;
                case TypeFigure.Rectangle:
                    CreateRectangle();
                    break;
                case TypeFigure.Circle:
                    CreateCircle();
                    break;
                case TypeFigure.Rhombus:
                    CreateRhombus();
                    break;
            }
        }

        private float InputData(string message)
        {
            do
            {
                Console.Write(message);
                string data = Console.ReadLine();
                if (float.TryParse(data, out float datafloat))
                {
                    return datafloat;
                }
                Console.WriteLine(_incorrectDataMessage);
            } while (true);
        }

        private void CreateSquare()
        {
            do
            {
                float side = InputData(_sideAString);
                Square square = new Square(side);
                if (square.CheckFigure())
                {
                    DisplayData(_typeFigure, square.GetPerimetr(), square.GetArea());
                    break;
                }
                else Console.WriteLine(_incorrectFigureMessage);
            } while (true);

        }

        private void CreateRectangle()
        {
            do
            {
                float sideA = InputData(_sideAString);
                float sideB = InputData(_sideBString);
                Rectangle rectangle = new Rectangle(sideA, sideB);
                if (rectangle.CheckFigure())
                {
                    DisplayData(_typeFigure, rectangle.GetPerimetr(), rectangle.GetArea());
                    break;
                }
                else Console.WriteLine(_incorrectFigureMessage);
            } while (true);

        }

        private void CreateCircle()
        {
            do
            {
                float radius = InputData(_radiusInputString);
                Circle circle = new Circle(radius);
                if (circle.CheckFigure())
                {
                    DisplayData(_typeFigure, circle.GetPerimetr(), circle.GetArea());
                    break;
                }
                else Console.WriteLine(_incorrectFigureMessage);

            } while (true);
        }

        private void CreateRhombus()
        {
            do
            {
                float side = InputData(_sideAString);
                float angle = InputData(_angleInputString);
                Rhombus rhombus = new Rhombus(side, angle);
                if (rhombus.CheckFigure())
                {
                    DisplayData(_typeFigure, rhombus.GetPerimetr(), rhombus.GetArea());
                    break;
                }
                else Console.WriteLine(_incorrectFigureMessage);
            } while (true);
        }

        private void DisplayData(TypeFigure type, float perimetr, float area)
        {
            Console.WriteLine(_figureNameList[(int)type - 1] + " " + _perimetrString + perimetr + " " + _areaString + area);
        }
    }

    public enum TypeFigure
    {
        Square = 1,
        Rectangle = 2,
        Circle = 3,
        Rhombus = 4,
    }
}