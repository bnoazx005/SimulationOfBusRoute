using System.Text.RegularExpressions;


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

        public static TPoint2 TryParse(string str)
        {
            Regex checker = new Regex("(\\d+,\\d+);\\s*(\\d+,\\d+)", RegexOptions.Singleline);
            Match match = checker.Match(str);

            if (match == null)
            {
                return TPoint2.mNullPoint;
            }

            return new TPoint2( double.Parse(match.Groups[1].Value), double.Parse(match.Groups[2].Value));
        }

        #endregion

        #region Operators

        public static TVector2 operator- (TPoint2 p1, TPoint2 p2)
        {
            return new TVector2(p1.mX - p2.mX, p1.mY - p2.mY);
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

        #endregion
    }
}
