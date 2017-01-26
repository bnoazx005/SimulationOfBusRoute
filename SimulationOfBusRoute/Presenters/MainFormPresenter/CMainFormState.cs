using GMap.NET.WindowsForms;
using System.Windows.Forms;
using System;
using GMap.NET.ObjectModel;


namespace SimulationOfBusRoute.Presenters.MainFormPresenter
{
    public class CMainFormState
    {
        public event EventHandler OnNeedSubmitProperties;

        public event Action<GMapControl, ObservableCollectionThreadSafe<GMapMarker>> OnNeedUpdateRouteLines;
        
        protected CMainFormPresenter mContext;

        protected CMainFormState(CMainFormPresenter context)
        {
            mContext = context;
        }

        public virtual void OnMarkerSelected(GMapMarker item, MouseEventArgs e) { }

        public virtual void OnMapMouseClick(object sender, MouseEventArgs e) { }

        public virtual void SelectNodeMode() { }

        public virtual void AddNodeMode() { }

        public virtual void RemoveNodeMode() { }

        public virtual void MoveNodeMode() { }

        public virtual void ComputationsMode()
        {
            mContext.SetState(mContext.ComputationsState);
        }     

        protected void _onNeedSumbitProperties()
        {
            if (OnNeedSubmitProperties != null)
            {
                OnNeedSubmitProperties(null, EventArgs.Empty);
            }
        }

        protected void _onNeedUpdateRouteLines(GMapControl map, ObservableCollectionThreadSafe<GMapMarker> markers)
        {
            if (OnNeedUpdateRouteLines != null)
            {
                OnNeedUpdateRouteLines(map, markers);
            }
        }
    }
}
