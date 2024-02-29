using System;
using System.Linq;


namespace Lab3CSharp
{
   
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Завдання 1: Робимо масив ромбів і виводимо інформацію про кожен ромб
            Romb[] rombs = {
            new Romb(5, 8, 1),
            new Romb(6, 10, 2),
            new Romb(7, 12, 3),
            new Romb(5, 8, 4)
        };

            foreach (var romb in rombs)
            {
                Console.WriteLine($"Довжина сторони: {romb.Side}, Діагональ: {romb.Diagonal}, Площа: {romb.CalculateArea()}, Периметр: {romb.CalculatePerimeter()}, Чи є квадратом: {romb.IsSquare}");
            }

            // Завдання 2: Побудова ієрархії класів та масиву об'єктів
            Shape[] shapes = new Shape[4];
            shapes[0] = new Circle(5, "Red");
            shapes[1] = new Rectangle(4, 6, "Green");
            shapes[2] = new Triangle(3, 4, 5, "Blue");
            shapes[3] = new Square(7, "Yellow");

            Array.Sort(shapes);

            foreach (var shape in shapes)
            {
                shape.Show();
            }
        }
    }

    class Romb
    {
        private int side;
        private int diagonal;
        private readonly int color;

        public Romb(int side, int diagonal, int color)
        {
            this.side = side;
            this.diagonal = diagonal;
            this.color = color;
        }

        public int Side
        {
            get { return side; }
            set { side = value; }
        }

        public int Diagonal
        {
            get { return diagonal; }
            set { diagonal = value; }
        }

        public int Color
        {
            get { return color; }
        }

        public int CalculatePerimeter()
        {
            return 4 * side;
        }

        public double CalculateArea()
        {
            return 0.5 * side * diagonal;
        }

        public bool IsSquare
        {
            get { return side == diagonal; }
        }
    }

    abstract class Shape : IComparable<Shape>
    {
        protected string color;

        public abstract void Show();

        public int CompareTo(Shape other)
        {
            // Порівнюємо за кольором
            return this.color.CompareTo(other.color);
        }
    }

    class Circle : Shape
    {
        private int radius;

        public Circle(int radius, string color)
        {
            this.radius = radius;
            this.color = color;
        }

        public override void Show()
        {
            Console.WriteLine($"Circle - Radius: {radius}, Color: {color}");
        }
    }

    class Rectangle : Shape
    {
        private int length;
        private int width;

        public Rectangle(int length, int width, string color)
        {
            this.length = length;
            this.width = width;
            this.color = color;
        }

        public override void Show()
        {
            Console.WriteLine($"Rectangle - Length: {length}, Width: {width}, Color: {color}");
        }
    }

    class Triangle : Shape
    {
        private int side1;
        private int side2;
        private int side3;

        public Triangle(int side1, int side2, int side3, string color)
        {
            this.side1 = side1;
            this.side2 = side2;
            this.side3 = side3;
            this.color = color;
        }

        public override void Show()
        {
            Console.WriteLine($"Triangle - Side1: {side1}, Side2: {side2}, Side3: {side3}, Color: {color}");
        }
    }

    class Square : Shape
    {
        private int side;

        public Square(int side, string color)
        {
            this.side = side;
            this.color = color;
        }

        public override void Show()
        {
            Console.WriteLine($"Square - Side: {side}, Color: {color}");
        }
    }

}
