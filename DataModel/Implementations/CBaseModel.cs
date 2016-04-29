using DataModel.Interfaces;


namespace DataModel.Implementations
{
    public abstract class CBaseModel : IBaseModel
    {
        protected uint mID;

        protected string mName;

        protected CBaseModel(uint id)
        {
            mID = id;
        }

        protected CBaseModel(uint id, string name)
        {
            mID = id;
            mName = name;
        }

        #region Methods

        public abstract void LoadFromFile(string filename);

        public abstract void SaveIntoFile(string filename);

        public abstract void Verify();

        #endregion

        #region Properties

        public uint ID
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
