using GMap.NET.WindowsForms;
using System.Windows.Forms;
using System;
using GMap.NET.ObjectModel;


namespace SimulationOfBusRoute.Presenters.MainFormPresenter
{
    public abstract class CMainFormState
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

        public abstract void SelectNodeMode();

        public abstract void AddNodeMode();

        public abstract void RemoveNodeMode();

        public abstract void MoveNodeMode();

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
        
        //void ComputationsMode(CMainFormPresenter context);
    }
}
