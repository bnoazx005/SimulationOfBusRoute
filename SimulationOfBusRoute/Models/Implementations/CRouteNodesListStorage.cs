using System;
using System.Collections.Generic;


namespace SimulationOfBusRoute.Models.Implementations
{
    public class CRouteNodesListStorage : CBaseListStorage<CRouteNode>
    {
        public CRouteNodesListStorage():
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
            using (CSqLiteRouteNodesDataMapper dataMapper = new CSqLiteRouteNodesDataMapper(string.Format(Properties.Resources.mSQLiteConnectionString,
                                                                                                          filename)))
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
            using (CSqLiteRouteNodesDataMapper dataMapper = new CSqLiteRouteNodesDataMapper(string.Format(Properties.Resources.mSQLiteConnectionString,
                                                                                                          filename)))
            {
                //dataMapper.SaveAll(mEntitiesList);
            }
        }

        #endregion

        public int NumOfRouteNodes
        {
            get
            {
                return mEntitiesList.Count;
            }
        }

        public int NumOfBusStations
        {
            get
            {
                return GetAllBySpecification(new CIsBusStationSpecification()).Count;
            }
        }
    }
}
