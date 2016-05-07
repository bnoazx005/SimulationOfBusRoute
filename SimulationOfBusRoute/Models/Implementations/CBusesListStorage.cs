namespace SimulationOfBusRoute.Models.Implementations
{
    public class CBusesListStorage : CBaseListStorage<CBus>
    {
        public CBusesListStorage():
            base()
        {
        }

        #region Methods

        /// <summary>
        /// Method loads data from a specified file (SqLite data base).
        /// </summary>
        /// <param name="filename">A name of a file</param>

        public override void LoadFromFile(string filename)
        {
            using (CSqLiteBusDataMapper dataMapper = new CSqLiteBusDataMapper(string.Format(Properties.Resources.mSQLiteConnectionString, filename)))
            {
                //mEntitiesList = dataMapper.LoadAll();
            }
        }

        /// <summary>
        /// Method stores data into a specified file (SqLite data base).
        /// </summary>
        /// <param name="filename">A name of a file</param>

        public override void SaveIntoFile(string filename)
        {
            using (CSqLiteBusDataMapper dataMapper = new CSqLiteBusDataMapper(string.Format(Properties.Resources.mSQLiteConnectionString, filename)))
            {
                //dataMapper.SaveAll(mEntitiesList);
            }
        }

        #endregion
    }
}
