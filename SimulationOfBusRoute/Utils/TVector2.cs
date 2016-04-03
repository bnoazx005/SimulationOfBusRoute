﻿using System;


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

        public void Normalize()
        {
            double invMag = 1.0 / Math.Sqrt(mX * mX + mY * mY);

            mX *= invMag;
            mY *= invMag;
        }

        public TVector2 UnitVector()
        {
            double invMag = 1.0 / Math.Sqrt(mX * mX + mY * mY);

            return new TVector2(mX * invMag, mY * invMag);
        }

        #endregion

        #region Operators

        public static TVector2 operator* (TVector2 vec2, double coeff)
        {
            return new TVector2(vec2.X * coeff, vec2.Y * coeff);
        }

        public static TVector2 operator *(double coeff, TVector2 vec2)
        {
            return new TVector2(vec2.X * coeff, vec2.Y * coeff);
        }

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
