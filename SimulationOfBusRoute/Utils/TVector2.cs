using System;


namespace SimulationOfBusRoute.Utils
{
    public struct TVector2
    {
        #region Members

        private double mX;

        private double mY;

        #endregion

        #region StaticPublicMembers

        public static TVector2 mNullVector = new TVector2();

        public static TVector2 mRightVector = new TVector2(1.0, 0.0);

        public static TVector2 mUpVector = new TVector2(0.0, 1.0);

        #endregion

        #region Constructors

        public TVector2(double x = 0.0, double y = 0.0)
        {
            mX = x;
            mY = y;
        }

        public TVector2(TVector2 vec2)
        {
            mX = vec2.X;
            mY = vec2.Y;
        }

        #endregion

        #region Methods

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

        public double Length
        {
            get
            {
                return Math.Sqrt(mX * mX + mY * mY);
            }
        }

        public double SqrLength
        {
            get
            {
                return (mX * mX + mY * mY);
            }
        }

        public TVector2 Normalized
        {
            get
            {
                double invLength = 1.0 / Math.Sqrt(mX * mX + mY * mY);

                return new TVector2(mX * invLength, mY * invLength);
            }
        }

        #endregion
    }
}
