using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using SimulationOfBusRoute.Models.Implementations.Bus;
using SimulationOfBusRoute.Utils;
using System.Collections.Generic;
using System.ComponentModel;

namespace SimulationOfBusRoute.Models.Implementations
{
    public class CPDFReportFile: CBaseReportFile
    {
        private Document mReportDocument;

        public CPDFReportFile():
            base()
        {
        }

        public CPDFReportFile(string filename):
            base(filename)
        {
            Open(filename);
        }

        public override void Open(string filename)
        {
            if (mReportDocument != null)
            {
                return;
            }

            mReportDocument = new Document();
        }

        public override void Close()
        {
            if (mReportDocument == null)
            {
                throw new System.ArgumentNullException("mReportDocument");
            }

            PdfDocumentRenderer render = new PdfDocumentRenderer(false, PdfSharp.Pdf.PdfFontEmbedding.Always);

            render.Document = mReportDocument;

            render.RenderDocument();
            render.PdfDocument.Save(mFilename);

            mReportDocument = null;
        }

        public override void WriteData(CDataManager dataManager)
        {
            if (mReportDocument == null)
            {
                throw new System.ArgumentNullException("mReportDocument");
            }

            Section buses = mReportDocument.AddSection();

            Table busesTable = buses.AddTable();

            busesTable.Borders.Visible = true;

            Dictionary<string, string> headers = typeof(TBusTableEntity).ToPropertiesDictonary();
            
            CComputationsResults results = dataManager.ComputationsResults;
                        
            BindingList<TBusTableEntity> busesRecords = results.BusesRecords;

            Row currRow = null;
            Column currColumn = null;

            for (int i = 0; i < headers.Count - 2; i++)
            {
                busesTable.AddColumn();
            }

            currRow = busesTable.AddRow();

            currRow.Cells[0].AddParagraph(headers["ID"]);
            currRow.Cells[1].AddParagraph(headers["CurrStationId"]);
            currRow.Cells[2].AddParagraph(headers["CurrBusCapacity"]);
            currRow.Cells[3].AddParagraph(headers["MaxCapacity"]);
            currRow.Cells[4].AddParagraph(headers["CurrArrivalTime"]);
            currRow.Cells[5].AddParagraph(headers["CurrDepartureTime"]);
            currRow.Cells[6].AddParagraph(headers["CurrNumOfExcurrentPassengers"]);
            currRow.Cells[7].AddParagraph(headers["CurrNumOfIncomingPassengers"]);
            currRow.Cells[8].AddParagraph(headers["AlightingTimePerPassenger"]);
            currRow.Cells[9].AddParagraph(headers["BoardingTimePerPassenger"]);

            TBusTableEntity currBus;

            for (int i = 0; i < busesRecords.Count; i++)
            {
                currBus = busesRecords[i];

                currRow = busesTable.AddRow();

                currRow.Cells[0].AddParagraph(currBus.ID.ToString());
                currRow.Cells[1].AddParagraph(currBus.CurrStationId.ToString());
                currRow.Cells[2].AddParagraph(currBus.CurrBusCapacity.ToString());
                currRow.Cells[3].AddParagraph(currBus.MaxCapacity.ToString());
                currRow.Cells[4].AddParagraph(currBus.CurrArrivalTime.ToString());
                currRow.Cells[5].AddParagraph(currBus.CurrDepartureTime.ToString());
                currRow.Cells[6].AddParagraph(currBus.CurrNumOfExcurrentPassengers.ToString());
                currRow.Cells[7].AddParagraph(currBus.CurrNumOfIncomingPassengers.ToString());
                currRow.Cells[8].AddParagraph(currBus.AlightingTimePerPassenger.ToString());
                currRow.Cells[9].AddParagraph(currBus.BoardingTimePerPassenger.ToString());
            }
        }
    }
}
