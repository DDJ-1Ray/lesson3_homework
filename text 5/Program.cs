using System;

namespace text_5
{
    abstract class Figure
    {
        protected double area=0;//初始为0
        public abstract double CalculationArea();//计算面积
        public  double Area
        {
            set => area = CalculationArea();
            get => area;
        }
    }
    interface Check//接口:檢查
    {
        bool check();
    }
    class Rectangle :Figure,Check//長方形
    {
        private double height;//長
        private double width;//宽
        public Rectangle(double height,double width)//初始化
        {
            this.height = height;
            this.width = width;
            Area = CalculationArea();
        }
        public override double CalculationArea()//計算面积
        {
            if (check())
                return height * width;
            else
                return 0;
        }
        public bool check()//檢查
        {
            if (height < 0 || width < 0)
            {
                return false;
            }
            return true;
        }
    }
    class Square : Figure
    {
        private double side;
        public Square(double side)
        {
            this.side = side;
            Area = CalculationArea();
        }
        public override double CalculationArea()
        {
            if (check())
            {
                return side * side;
            }
            return 0;
        }
        public bool check()
        {
            if (side < 0)
            {
                return false;
            }
            return true;
        }
    }
    class Triangle : Figure,Check
    {
        private double side1, side2, side3;
        public Triangle(double side1, double side2, double side3)
        {
            this.side1 = side1;
            this.side2 = side2;
            this.side3 = side3;
            Area = CalculationArea();
        }
        public override double CalculationArea()
        {
            if (check())
            {
                double s = (side1 + side2 + side3) / 2;
                return Math.Sqrt(s * (s - side1) * (s - side2) * (s - side3));
            }
            return 0;
            
        }
        public bool check()
        {
            if (side1 < 0 || side2 < 0 || side3 < 0)
                return false;
            if ((side1 + side2 < side3) || (side1 + side3 < side2) || (side2 + side3 < side1))
            {
                return false;
            }
            return true;
        }
    }
    class CreateFigue
    {
        private double sum = 0;
        public  CreateFigue(int a)//图形制作造机,
        {
            if (a <= 0)
            {
                Console.WriteLine("生成錯誤");
            }
            for(int i = 0; i < a; i++)
            {

                Random random = new Random();
                int which=random.Next(1, 4);
                switch (which)
                {
                    case 1://長方形
                        while (true)
                        {
                            int height = random.Next(1, 10);
                            int width = random.Next(1, 10);
                            Rectangle rectangle = new Rectangle(height, width);
                            if (rectangle.check() == true)
                            {
                                sum += rectangle.Area;
                                break;
                            }
                        }
                        break;
                    case 2://正方形
                        while (true)
                        {
                            int side = random.Next(1, 10);
                            Square square = new Square(side);
                            if (square.check() == true)
                            {
                                sum += square.Area;
                                break;
                            }
                        }
                        break;
                    case 3://三角形
                        while (true)
                        {
                            int side1 = random.Next(1, 10);
                            int side2 = random.Next(1, 10);
                            int side3 = random.Next(1, 10);
                            Triangle triangle = new Triangle(side1, side2, side3);
                            if (triangle.check() == true)
                            {
                                sum += triangle.Area;
                                break;
                            }
                        }
                        break;
                }
            }
        
        }
        public void Sum()
        {
            Console.WriteLine($"總面積是{sum}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Square square = new Square(5);
            //Console.WriteLine($"{square.Area}");
            //Triangle triangle = new Triangle(3,4, 5);
            //triangle.check();
            //Console.WriteLine($"{triangle.Area}");
            CreateFigue createFigue = new CreateFigue(10);
            createFigue.Sum();
        }
    }
}
