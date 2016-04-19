﻿using SimulationOfBusRoute.Utils;
using System.Data.SQLite;


namespace SimulationOfBusRoute.Models
{
    public class CCrossRoadNode : CRouteNode
    {
        #region Constructors

        public CCrossRoadNode(uint id, string name):
            base(id, name)
        {
        }

        public CCrossRoadNode(uint id, string name, TPoint2 position):
            base(id, name, position)
        {
        }

        #endregion

        #region Methods

        public override void LoadFromDataBase(SQLiteConnection dbConnection)
        {

        }

        public override void SaveIntoDataBase(SQLiteConnection dbConnection)
        {
            using (SQLiteCommand currCommand = new SQLiteCommand(dbConnection))
            {
                //добавление данных в таблицу routeNodes
                currCommand.CommandText = Properties.Resources.mSQLQueryInsertRouteNode;

                currCommand.Parameters.AddWithValue("@id", mIndex);
                currCommand.Parameters.AddWithValue("@name", mName);
                currCommand.Parameters.AddWithValue("@position", mPosition.ToString());
                currCommand.Parameters.AddWithValue("@type", E_ROUTE_NODE_TYPE.RNT_CROSSROAD);

                currCommand.ExecuteNonQuery();

                //добавление данных в таблицу crossroadNodes
                currCommand.CommandText = Properties.Resources.mSQLQueryInsertCrossroadNode;

                currCommand.Parameters.AddWithValue("@id", mIndex);

                currCommand.ExecuteNonQuery();
            }
        }

        #endregion

        #region Properties   

        public override E_ROUTE_NODE_TYPE NodeType
        {
            get
            {
                return E_ROUTE_NODE_TYPE.RNT_CROSSROAD;
            }
        }
        
        #endregion
    }
}
