namespace SimulationOfBusRoute.Models.Implementations
{
    public abstract class CBaseReportFile
    {
        protected string mFilename;

        protected CBaseReportFile(string filename)
        {
            mFilename = filename;
        }

        protected CBaseReportFile()
        {
            mFilename = string.Empty;
        }

        public abstract void Open(string filename);

        public abstract void Close();

        public abstract void WriteData(CDataManager dataManager);

        public string Name
        {
            get
            {
                return mFilename;
            }

            set
            {
                mFilename = value;
            }
        }
    }
}
