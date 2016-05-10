using GMap.NET;
using GMap.NET.WindowsForms;
using System.Drawing;


namespace SimulationOfBusRoute.Utils
{
    public class CGMapImageMarker : GMapMarker
    {
        private Image mImage;

        public CGMapImageMarker(PointLatLng p, Image image)
            : base(p)
        {
            mImage = image;
            Size = mImage.Size;

            Offset = new Point(-Size.Width / 2, -Size.Height / 2);
        }

        public override void OnRender(Graphics g)
        {
            g.DrawImage(mImage, LocalPosition.X, LocalPosition.Y, Size.Width, Size.Height);
        }

        #region Properties

        public Image Image
        {
            get
            {
                return mImage;
            }

            set
            {
                mImage = value;
            }
        }

        #endregion
    }
}
