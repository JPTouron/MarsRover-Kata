namespace MarsRoverTests
{
    class Square {

        public Square(int width)
        {
            Width = width;
        }
        public int Width { get; protected set; }

        public void SetWidth(int width) {
            this.Width = width;
        }

    }
    //what is terribly wrong here? can a rectangle really be a square in OOP?
    class Rectangle : Square
    {
        public Rectangle(int width, int height) : base(width)
        {
            Height = height;
        }

        public int Height { get; private set; }

        public void SetHeight(int height) {

            Width = height;
            Height = height;
        
        }
    }
}