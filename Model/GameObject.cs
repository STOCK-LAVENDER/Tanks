namespace UltimateTankClash.Model
{
    public abstract class GameObject
    {
        private int id;
        private double positionX;
        private double positionY;
        private double width;
        private double height;

        public int Id
        {
            get
            {
                return this.id;
            }

            protected set
            {
                this.id = value;
            }

        }
        public virtual double PositionX
        {
            get
            {
                return this.positionX;
            }

            protected set
            {
                this.positionX = value;
            }

        }

        public virtual double PositionY
        {
            get
            {
                return this.positionY;
            }

            protected set
            {
                this.positionY = value;
            }

        }

        public virtual double Width
        {
            get
            {
                return this.width;
            }

            protected set
            {
                this.width = value;
            }

        }

        public virtual double Height
        {
            get
            {
                return this.height;
            }

            protected set
            {
                this.height = value;
            }

        }
    }
}
