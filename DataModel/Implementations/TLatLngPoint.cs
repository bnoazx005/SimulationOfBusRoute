using System.Text.RegularExpressions;


namespace DataModel.Implementations
{
    public struct TLatLngPoint
    {
        #region Members

        private double mX;

        private double mY;

        #endregion

        #region StaticPublicMembers

        public static TLatLngPoint mNullPoint = new TLatLngPoint();

        #endregion

        #region Constructors

        public TLatLngPoint(double x = 0.0, double y = 0.0)
        {
            mX = x;
            mY = y;
        }

        public TLatLngPoint(TLatLngPoint vec2)
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

        public static TLatLngPoint TryParse(string str)
        {
            Regex checker = new Regex("(\\d+,\\d+);\\s*(\\d+,\\d+)", RegexOptions.Singleline);
            Match match = checker.Match(str);

            if (match == null)
            {
                return TLatLngPoint.mNullPoint;
            }

            return new TLatLngPoint(double.Parse(match.Groups[1].Value), double.Parse(match.Groups[2].Value));
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
