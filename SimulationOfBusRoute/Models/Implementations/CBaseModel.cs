using SimulationOfBusRoute.Models.Interfaces;


namespace SimulationOfBusRoute.Models.Implementations
{
    public abstract class CBaseModel : IBaseModel
    {
        protected int mID;

        protected string mName;

        protected CBaseModel(int id)
        {
            mID = id;
        }

        protected CBaseModel(int id, string name)
        {
            mID = id;
            mName = name;
        }

        #region Methods
        
        public abstract void Verify();

        #endregion

        #region Properties

        public int ID
        {
            get
            {
                return mID;
            }

            set
            {
                mID = value;
            }
        }

        public string Name
        {
            get
            {
                return mName;
            }

            set
            {
                mName = value;
            }
        }

        #endregion
    }
}
