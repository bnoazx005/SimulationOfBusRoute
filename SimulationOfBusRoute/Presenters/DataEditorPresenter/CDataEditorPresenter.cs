using MDLParser.Data;
using MDLParser.Lexer;
using MDLParser.Parser;
using NLog;
using SimulationOfBusRoute.Models.Implementations;
using SimulationOfBusRoute.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SimulationOfBusRoute.Presenters.DataEditorPresenter
{
    public class CDataEditorPresenter : CBasePresenter<CDataManager, IDataEditorView>
    {
        private object mSyncObject;

        private Task[] mJobList;

        private static Logger mClassLogger;

        public CDataEditorPresenter(CDataManager model, IDataEditorView view):
            base(model, view)
        {
            mClassLogger = LogManager.GetCurrentClassLogger();

            mSyncObject = new object();

            mJobList = new Task[4];

            mView.OnFormInit += _onFormInit;
            mView.OnQuit     += _onQuit;
            mView.OnOpenDocs += _onOpenDocs;

            mView.OnTimerTick += _onTimerTick;
            mView.OnCloseForm += _onCloseForm;

            mView.OnUndoChanges += _onUndoChanges;
            mView.OnRedoChanges += _onRedoChanges;
            mView.OnCutText     += _onCutText;
            mView.OnCopyText    += _onCopyText;
            mView.OnPasteText   += _onPasteText;
            mView.OnCompileData += _onCompileData;

            mView.OnMouseButtonPressed += _onMouseButtonPressed;
        }

        public void OnModelChanged()
        {
            IDataEditorView view = mView;

            int numOfBusStations = mModel.RouteNodesStorage.NumOfBusStations;
            int numOfSpans = Math.Max(0, numOfBusStations - 1);

            //headers' generation for the editors
            lock (mSyncObject)
            {
                if (view.BusVelocitiesHeaderText.InvokeRequired || view.StationsEditorHeaderText.InvokeRequired)
                {
                    view.BusVelocitiesHeaderText.Invoke((MethodInvoker)(() =>
                    {
                        _generateHeaders(numOfBusStations/*, numOfSpans*/);
                    }));
                }
                else
                {
                    _generateHeaders(numOfBusStations/*, numOfSpans*/);
                }

            }
        }
        
        private void _onFormInit(object sender, EventArgs e)
        {
            CDataManager model = mModel;
            IDataEditorView view = mView;

            COptionsList options = model.OptionsList;

            Dictionary<string, Button> buttons = view.ButtonsList;

            //Updating the view
            int numOfBusStations = model.RouteNodesStorage.NumOfBusStations;
            //int numOfSpans = Math.Max(0, numOfBusStations - 1);

            //headers' generation for the editors
            lock (mSyncObject)
            {
                if (view.BusVelocitiesHeaderText.InvokeRequired || view.StationsEditorHeaderText.InvokeRequired)
                {
                    view.BusVelocitiesHeaderText.Invoke((MethodInvoker)(() =>
                    {
                        _generateHeaders(numOfBusStations/*, numOfSpans*/);
                        
                        view.BusVelocitiesEditorText.Text = options.GetStringParam(Properties.Resources.mOptionsVelocitiesEditorCode);

                        view.StationsEditorText.Text = options.GetStringParam(Properties.Resources.mOptionsStationsEditorCode);
                    }));
                }
                else
                {
                    _generateHeaders(numOfBusStations/*, numOfSpans*/);

                    view.BusVelocitiesEditorText.Text = options.GetStringParam(Properties.Resources.mOptionsVelocitiesEditorCode);

                    view.StationsEditorText.Text = options.GetStringParam(Properties.Resources.mOptionsStationsEditorCode);
                }
            }          
        }

        private void _onQuit(object sender, FormClosingEventArgs e)
        {            
            mIsRunning = false;

            COptionsList options = mModel.OptionsList;

            options.AddStringParam(Properties.Resources.mOptionsVelocitiesEditorCode, mView.BusVelocitiesEditorText.Text);
            options.AddStringParam(Properties.Resources.mOptionsStationsEditorCode, mView.StationsEditorText.Text);
        }

        private void _onCloseForm(object sender, EventArgs e)
        {
            mView.Quit();
        }
        
        private void _onTimerTick(object sender, EventArgs e)
        {
            if (!mIsRunning)
            {
                return;
            }
        }
        
        private void _onCompileData(object sender, EventArgs e)
        {
            IDataEditorView view = mView;

            ToolStripStatusLabel exceptionLabel = view.MessageText;

            int currEditorIdx = 0;
            
            try
            {
                string programCode = null;

                CLexer lexer = null;
                CParser parser = null;

                CBusRoute busRouteObject = mModel.CurrBusRouteObject;
                                
                //try to compile stations data
                programCode = view.StationsEditorHeaderText.Text + view.StationsEditorText.Text;
                
                lexer = new CLexer(programCode);
                parser = new CParser(lexer);
                
                busRouteObject.PassengersIntensities = CDataBuilder.Compile(parser.Parse());

                //if the last try was sucessully complited
                currEditorIdx = 1;

                programCode = view.BusVelocitiesHeaderText.Text + view.BusVelocitiesEditorText.Text;

                lexer = new CLexer(programCode);
                parser = new CParser(lexer);

                busRouteObject.VelocitiesOfSpans = CDataBuilder.Compile(parser.Parse());
            }         
            catch (CParserException parserException)
            {
                exceptionLabel.Text = string.Format("({0}) : {1}", 
                                                    currEditorIdx == 0 ? "Редактор матриц интенсивностей" : "Редактор скоростей автобусов",
                                                    parserException.Message);

                exceptionLabel.ForeColor = Color.Red;

                mClassLogger.Info(parserException.Message);

                return;
            }
            catch (CUndexpectedTokenException tokenException)
            {
                exceptionLabel.Text = string.Format("({0}) : {1}",
                                                    currEditorIdx == 0 ? "Редактор матриц интенсивностей" : "Редактор скоростей автобусов",
                                                    tokenException.Message);

                exceptionLabel.ForeColor = Color.Red;

                mClassLogger.Info(tokenException.Message);

                return;
            }
            catch (CSymbolTableException symbTableException)
            {
                exceptionLabel.Text = string.Format("({0}) : {1}",
                                                    currEditorIdx == 0 ? "Редактор матриц интенсивностей" : "Редактор скоростей автобусов",
                                                    symbTableException.Message);

                exceptionLabel.ForeColor = Color.Red;

                mClassLogger.Info(symbTableException.Message);

                return;
            }

            exceptionLabel.Text = "Данные успешно скомпилированы";
            exceptionLabel.ForeColor = Color.Green;

            mClassLogger.Info("Data is sucessfully compiled");
        }

        private void _onUndoChanges(object sender, EventArgs e)
        {
            lock(mSyncObject)
            {
                switch (mView.CurrSelectedEditorIndex)
                {
                    case 0: //stations' data editor
                        mView.StationsEditorText.Undo();
                        break;
                    case 1:
                        mView.BusVelocitiesEditorText.Undo();
                        break;
                }
            }
        }

        private void _onRedoChanges(object sender, EventArgs e)
        {
            lock (mSyncObject)
            {
                switch (mView.CurrSelectedEditorIndex)
                {
                    case 0: //stations' data editor
                        mView.StationsEditorText.Redo();
                        break;
                    case 1:
                        mView.BusVelocitiesEditorText.Redo();
                        break;
                }
            }
        }

        private void _onMouseButtonPressed(object sender, MouseEventArgs e)
        {
            
        }

        private void _onCutText(object sender, EventArgs e)
        {
            lock (mSyncObject)
            {
                switch (mView.CurrSelectedEditorIndex)
                {
                    case 0: //stations' data editor
                        mView.StationsEditorText.Cut();
                        break;
                    case 1:
                        mView.BusVelocitiesEditorText.Cut();
                        break;
                }
            }
        }

        private void _onCopyText(object sender, EventArgs e)
        {
            lock (mSyncObject)
            {
                switch (mView.CurrSelectedEditorIndex)
                {
                    case 0: //stations' data editor
                        mView.StationsEditorText.Copy();
                        break;
                    case 1:
                        mView.BusVelocitiesEditorText.Copy();
                        break;
                }
            }
        }

        private void _onPasteText(object sender, EventArgs e)
        {
            lock (mSyncObject)
            {
                switch (mView.CurrSelectedEditorIndex)
                {
                    case 0: //stations' data editor
                        mView.StationsEditorText.Paste();
                        break;
                    case 1:
                        mView.BusVelocitiesEditorText.Paste();
                        break;
                }
            }
        }

        private void _generateHeaders(int numOfBusStations/*, int numOfSpans*/)
        {
            IDataEditorView view = mView;

            view.BusVelocitiesHeaderText.Text = string.Format(Properties.Resources.mBusesVelocitiesHeaderTemplate,
                                                              '\n',
                                                              numOfBusStations/*numOfSpans*/);

            view.StationsEditorHeaderText.Text = string.Format(Properties.Resources.mStationsDataHeaderTemplate,
                                                               '\n',
                                                               numOfBusStations,
                                                               numOfBusStations);
        }

        private void _onOpenDocs(object sender, EventArgs e)
        {
            Help.ShowHelp(sender as Control, Properties.Resources.mHelpSource, HelpNavigator.Topic, "/DataEditorInterface.htm");
        }
    }
}
