

namespace SimulationOfBusRoute.Utils
{
    public struct TPoint2
    {
        #region Members

        private double mX;

        private double mY;

        #endregion

        #region StaticPublicMembers

        public static TPoint2 mNullPoint = new TPoint2();

        #endregion

        #region Constructors

        public TPoint2(double x = 0.0, double y = 0.0)
        {
            mX = x;
            mY = y;
        }

        public TPoint2(TPoint2 vec2)
        {
            mX = vec2.X;
            mY = vec2.Y;
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return string.Format("({0}; {1})", mX, mY);
        }

        #endregion

        #region Operators
        #endregion

        #region Properties

        public double X
        {
            get
            {
                return mX;
            }

            set
            {
                mX = value;
            }
        }

        public double Y
        {
            get
            {
                return mY;
            }

            set
            {
                mY = value;
            }
        }

        #endregion
    }
}
