namespace ClassBoxData
{
    using System;

    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length 
        { 
            get => this.length;
            private set
            {
                this.Validate(value, nameof(this.Length));
                this.length = value;
            }
        }
        public double Width 
        { 
            get => this.width;
            private set
            {
                this.Validate(value, nameof(this.Width));
                this.width = value;
            }
        }
        public double Height 
        { 
            get => this.height;
            private set
            {
                this.Validate(value, nameof(this.Height));
                this.height = value;
            }
        }

        public double SurfaceArea()
        {
            return 2 * this.Length * this.Width 
                + 2 * this.Width * this.Height 
                + 2 * this.Height * this.Length;
        }

        public double LateralSurfaceArea()
        {
            return 2 * this.Height * (this.Length + this.Width);
        }
        public double Volume()
        {
            return this.Length * this.Width * this.Height;
        }

        private bool Validate(double value, string param)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{param} cannot be zero or negative.");
            }

            return true;
        }
    }
}
