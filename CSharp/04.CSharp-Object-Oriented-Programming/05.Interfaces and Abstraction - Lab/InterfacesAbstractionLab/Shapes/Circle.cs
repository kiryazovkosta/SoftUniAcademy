namespace Shapes
{
    using System;
    public class Circle : IDrawable
    {
        private int radius;

        public Circle(int radius)
        {
            this.Radius = radius;
        }

        private int Radius
        {
            get => this.radius;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(nameof(this.Radius));
                }

                this.radius = value;
            }
        }
        public void Draw()
        {
            double radiusIn = this.Radius - 0.4;
            double radiusOut = this.Radius + 0.4;
            for (double y = this.Radius; y >= -this.radius; --y)
            {
                for (double x = -this.Radius; x < radiusOut; x += 0.5)
                {
                    double value = x * x + y * y;
                    if (value >= radiusIn * radiusIn && value <= radiusOut * radiusOut)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.WriteLine(" ");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
