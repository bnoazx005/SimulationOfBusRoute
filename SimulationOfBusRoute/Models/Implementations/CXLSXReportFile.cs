using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using SimulationOfBusRoute.Models.Implementations.Bus;
using SimulationOfBusRoute.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;


namespace SimulationOfBusRoute.Models.Implementations
{
    public class CXLSXReportFile : CBaseReportFile
    {
        private FileStream mOutputFile;

        private IWorkbook mWorkbook;

        public CXLSXReportFile():
            base()
        {
        }

        public CXLSXReportFile(string filename):
            base(filename)
        {
            Open(filename);
        }

        public override void Open(string filename)
        {
            if (mOutputFile != null)
            {
                return;
            }

            mOutputFile = new FileStream(filename, FileMode.OpenOrCreate);
            mOutputFile.SetLength(0);
           
            mWorkbook = new XSSFWorkbook();
        }

        public override void Close()
        {
            if (mOutputFile == null)
            {
                throw new ArgumentNullException("outputFile");
            }

            mWorkbook.Write(mOutputFile);

            mOutputFile.Close();
            mOutputFile.Dispose();

            mOutputFile = null;
        }

        public override void WriteData(CDataManager dataManager)
        {
            if (mOutputFile == null)
            {
                throw new ArgumentNullException("outputFile");
            }

            if (dataManager == null)
            {
                throw new ArgumentNullException("dataManager");
            }

            CComputationsResults results = dataManager.ComputationsResults;

            ISheet buses = mWorkbook.CreateSheet("Автобусы");

            BindingList<TBusTableEntity> busesRecords = results.BusesRecords;

            TBusTableEntity currBus;

            IRow currRow = null;
            
            Dictionary<string, string> headers = typeof(TBusTableEntity).ToPropertiesDictonary();
            
            currRow = buses.CreateRow(0);
            
            currRow.CreateCell(0).SetCellValue(headers["ID"]);
            currRow.CreateCell(1).SetCellValue(headers["CurrStationId"]);
            currRow.CreateCell(2).SetCellValue(headers["CurrBusCapacity"]);
            currRow.CreateCell(3).SetCellValue(headers["MaxCapacity"]);
            currRow.CreateCell(4).SetCellValue(headers["CurrArrivalTime"]);
            currRow.CreateCell(5).SetCellValue(headers["CurrDepartureTime"]);
            currRow.CreateCell(6).SetCellValue(headers["CurrNumOfExcurrentPassengers"]);
            currRow.CreateCell(7).SetCellValue(headers["CurrNumOfIncomingPassengers"]);
            currRow.CreateCell(8).SetCellValue(headers["AlightingTimePerPassenger"]);
            currRow.CreateCell(9).SetCellValue(headers["BoardingTimePerPassenger"]);

            for (int i = 0; i < busesRecords.Count; i++)
            {
                currBus = busesRecords[i];

                currRow = buses.CreateRow(i + 1);
                
                currRow.CreateCell(0).SetCellValue(currBus.ID);
                currRow.CreateCell(1).SetCellValue(currBus.CurrStationId);
                currRow.CreateCell(2).SetCellValue(currBus.CurrBusCapacity);
                currRow.CreateCell(3).SetCellValue(currBus.MaxCapacity);
                currRow.CreateCell(4).SetCellValue(currBus.CurrArrivalTime);
                currRow.CreateCell(5).SetCellValue(currBus.CurrDepartureTime);
                currRow.CreateCell(6).SetCellValue(currBus.CurrNumOfExcurrentPassengers);
                currRow.CreateCell(7).SetCellValue(currBus.CurrNumOfIncomingPassengers);
                currRow.CreateCell(8).SetCellValue(currBus.AlightingTimePerPassenger);
                currRow.CreateCell(9).SetCellValue(currBus.BoardingTimePerPassenger);
            }

            ISheet stations = mWorkbook.CreateSheet("Остановки");

            BindingList<TStationTableEntity> stationsRecords = results.StationsRecords;

            TStationTableEntity currStation;
            
            headers = typeof(TStationTableEntity).ToPropertiesDictonary();

            currRow = stations.CreateRow(0);

            currRow.CreateCell(0).SetCellValue(headers["Time"]);
            currRow.CreateCell(1).SetCellValue(headers["ID"]);
            currRow.CreateCell(2).SetCellValue(headers["CurrNumOfPassengers"]);
                
            for (int i = 0; i < stationsRecords.Count; i++)
            {
                currStation = stationsRecords[i];

                currRow = stations.CreateRow(i + 1);
                
                currRow.CreateCell(0).SetCellValue(currStation.Time);
                currRow.CreateCell(1).SetCellValue(currStation.ID);
                currRow.CreateCell(2).SetCellValue(currStation.CurrNumOfPassengers);
            }
        }
    }
}
