using SimulationOfBusRoute.Models.Implementations.Bus;
using System;
using System.Collections.Generic;


namespace SimulationOfBusRoute.Models.Implementations
{
    public static class CDataManagerHelper
    {
        public static void SaveIntoFile(this CDataManager dataManager, string filename)
        {
            string connectionString = string.Format(Properties.Resources.mSQLiteConnectionString, filename);

            //saving the route's nodes
            using (CSqLiteRouteNodesDataMapper routeNodesDataMapper = new CSqLiteRouteNodesDataMapper(connectionString))
            {
                List<CRouteNode> routeNodesList = dataManager.RouteNodesStorage.GetAll();

                routeNodesDataMapper.SaveAll(routeNodesList);
            }

            //saving the buses' data
            using (CSqLiteBusDataMapper busesDataMapper = new CSqLiteBusDataMapper(connectionString))
            {
                List<CBus> buses = dataManager.BusesStorage.GetAll();

                busesDataMapper.SaveAll(buses);
            }

            //saving the options' list
            using (CSqLiteOptionsDataMapper optionsDataMapper = new CSqLiteOptionsDataMapper(connectionString))
            {
                optionsDataMapper.Save(dataManager.OptionsList);
            }

            dataManager.ResetModelStateFlag();
        }

        public static void LoadFromFile(this CDataManager dataManager, string filename)
        {
            string connectionString = string.Format(Properties.Resources.mSQLiteConnectionString, filename);

            //loading the route's nodes
            using (CSqLiteRouteNodesDataMapper routeNodesDataMapper = new CSqLiteRouteNodesDataMapper(connectionString))
            {
                CRouteNodesListStorage routeNodesStorage = dataManager.RouteNodesStorage;

                List<CRouteNode> readRecords = routeNodesDataMapper.LoadAll();

                foreach (CRouteNode routeNode in readRecords)
                {
                    routeNodesStorage.Insert(routeNode);
                }
            }

            //loading the buses' data
            using (CSqLiteBusDataMapper busesDataMapper = new CSqLiteBusDataMapper(connectionString))
            {
                CBusesListStorage busesStorage = dataManager.BusesStorage;

                List<CBus> readRecords = busesDataMapper.LoadAll();

                foreach (CBus bus in readRecords)
                {
                    busesStorage.Insert(bus);
                }
            }

            //loading the options' list
            using (CSqLiteOptionsDataMapper optionsDataMapper = new CSqLiteOptionsDataMapper(connectionString))
            {
                dataManager.OptionsList = optionsDataMapper.Load(0);
            }

            COptionsList options = dataManager.OptionsList;

            TimeSpan finishTime = TimeSpan.Parse(options.GetStringParam(Properties.Resources.mOptionsFinishTimeOfSimulation));
            TimeSpan startTime = TimeSpan.Parse(options.GetStringParam(Properties.Resources.mOptionsStartTimeOfSimulation));

            TimeSpan diffTime = finishTime.Subtract(startTime);
            
            options.AddIntParam(Properties.Resources.mOptionsNumOfSimulationSteps, (int)diffTime.TotalSeconds);
        }
    }
}
