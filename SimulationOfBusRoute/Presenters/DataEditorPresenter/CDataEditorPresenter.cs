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
            mView.OnQuit += _onQuit;

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
                view.BusVelocitiesHeaderText.Text = string.Format(Properties.Resources.mBusesVelocitiesHeaderTemplate,
                                                                  '\n',
                                                                  numOfSpans);

                view.StationsEditorHeaderText.Text = string.Format(Properties.Resources.mStationsDataHeaderTemplate,
                                                                   '\n',
                                                                   numOfBusStations,
                                                                   numOfBusStations);
            }
            
            //mJobList[0] = new Task(_highlightSyntax, mView.StationsEditorHeaderText);
            //mJobList[1] = new Task(_highlightSyntax, mView.BusVelocitiesHeaderText);

           // mJobList[0].Start();
           // mJobList[1].Start();
        }
        
        private void _onFormInit(object sender, EventArgs e)
        {
            CDataManager model = mModel;
            IDataEditorView view = mView;

            COptionsList options = model.OptionsList;

            Dictionary<string, Button> buttons = view.ButtonsList;

            //Updating the view
            int numOfBusStations = model.RouteNodesStorage.NumOfBusStations;
            int numOfSpans = Math.Max(0, numOfBusStations - 1);

            //headers' generation for the editors
            lock (mSyncObject)
            {
                view.BusVelocitiesHeaderText.Text = string.Format(Properties.Resources.mBusesVelocitiesHeaderTemplate,
                                                                  '\n',
                                                                  numOfSpans);

                view.BusVelocitiesEditorText.Text = options.GetStringParam(Properties.Resources.mOptionsVelocitiesEditorCode);

                view.StationsEditorHeaderText.Text = string.Format(Properties.Resources.mStationsDataHeaderTemplate,
                                                                   '\n',
                                                                   numOfBusStations,
                                                                   numOfBusStations);

                view.StationsEditorText.Text = options.GetStringParam(Properties.Resources.mOptionsStationsEditorCode);

                //view.ButtonsList[""]
            }

            ////подсветка синтаксиса для заголовков
            //mJobList[0] = new Task(_highlightSyntax, mView.StationsEditorHeaderText);
            //mJobList[1] = new Task(_highlightSyntax, mView.BusVelocitiesHeaderText);

            // mJobList[0].Start();
            // mJobList[1].Start();            
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
            //ВОССТАНОВИТЬ ПОСЛЕ ПОЧИНКИ ПОДСВЕТКИ
            //foreach (Task currTask in mJobList)
            //{
            //    if (currTask != null)
            //    {
            //        currTask.Wait();
            //    }
            //}

            mView.Quit();
        }
        
        private void _onTimerTick(object sender, EventArgs e)
        {
            if (!mIsRunning)
            {
                return;
            }

            switch(mView.CurrSelectedEditorIndex)
            {
                case 0:         //stations' editor
                    //mJobList[2] = new Task(_highlightSyntax, mView.StationsEditorText);
                    //mJobList[2].Start();
                    break;
                case 1:         //buses velocities' editor
                    //mJobList[3] = new Task(_highlightSyntax, mView.BusVelocitiesEditorText);
                    //mJobList[3].Start();
                    break;
            }
        }

        private void _highlightSyntax(object textEditorObj)
        {
            RichTextBox textEditor = textEditorObj as RichTextBox;

            if (textEditor == null)
            {
                return;
            }

            Regex highlightingGroup1Pattern = new Regex(Properties.Resources.mDataEditorHighlightingGroup1, RegexOptions.Singleline);
            Regex highlightingGroup2Pattern = new Regex(Properties.Resources.mDataEditorHighlightingGroup2, RegexOptions.Singleline);

            int startPos = 0;
            int length = 0;
            int selectionStart = 0;
            int selectionLength = 0;

            string programText = null;

            //используются асинхронные вызовы методов
            lock (mSyncObject)
            {
                textEditor.Invoke((MethodInvoker)(() => { programText = textEditor.Text; }));

                MatchCollection matchesOfFirstGroup = highlightingGroup1Pattern.Matches(programText);
                MatchCollection matchesOfSecondGroup = highlightingGroup2Pattern.Matches(programText);

                textEditor.Invoke((MethodInvoker)(() =>
                {
                    selectionStart = textEditor.SelectionStart;
                    selectionLength = textEditor.SelectionLength;

                    textEditor.SelectAll();

                    textEditor.SelectionColor = Color.Black;
                    textEditor.SelectionStart = selectionStart;
                    textEditor.SelectionLength = selectionLength;
                }));

                //group1
                foreach (Match currMatch in matchesOfFirstGroup)
                {
                    startPos = currMatch.Index;
                    length = currMatch.Length;

                    textEditor.Invoke((MethodInvoker)(() =>
                    {
                        textEditor.Select(startPos, length);

                        textEditor.SelectionColor = Color.Blue;

                        textEditor.SelectionStart = selectionStart;
                        textEditor.SelectionLength = selectionLength;
                        textEditor.SelectionColor = Color.Black;
                    }));
                }

                //group2
                foreach (Match currMatch in matchesOfSecondGroup)
                {
                    startPos = currMatch.Index;
                    length = currMatch.Length;

                    textEditor.Invoke((MethodInvoker)(() =>
                    {
                        textEditor.Select(startPos, length);

                        textEditor.SelectionColor = Color.CornflowerBlue;
                       
                        textEditor.SelectionStart = selectionStart;
                        textEditor.SelectionLength = selectionLength;
                        textEditor.SelectionColor = Color.Black;
                    }));
                }
            }
        }

        private void _onCompileData(object sender, EventArgs e)
        {
            //IDataEditorView view = mView;

            //ToolStripStatusLabel exceptionLabel = view.MessageText;

            //try
            //{
            //    string programCode = null;

            //    CLexer lexer = null;
            //    CParser parser = null;

            //    int currSelectedEditorIndex = view.CurrSelectedEditorIndex;

            //    lock (mSyncObject)
            //    {
            //        switch (currSelectedEditorIndex)
            //        {
            //            case 0: //stations' data editor
            //                programCode = view.StationsEditorHeaderText.Text + view.StationsEditorText.Text;
            //                break;
            //            case 1: //buses velocities' editor
            //                programCode = view.BusVelocitiesHeaderText.Text + view.BusVelocitiesEditorText.Text;
            //                break;
            //            default:
            //                return;
            //        }
            //    }

            //    lexer = new CLexer(programCode);
            //    parser = new CParser(lexer);

            //    switch (currSelectedEditorIndex)
            //    {
            //        case 0: //stations' data editor
            //            mModel.MatricesOfIntensitiesList = CDataBuilder.Compile(parser.Parse());
            //            break;
            //        case 1: //buses velocities' editor
            //            mModel.BusesVelocitiesList = CDataBuilder.Compile(parser.Parse());
            //            break;
            //    }           
            //}
            //catch (CParserException parserException)
            //{
            //    exceptionLabel.Text = parserException.Message;
            //    exceptionLabel.ForeColor = Color.Red;

            //    mClassLogger.Info(parserException.Message);

            //    return;
            //}
            //catch (CUndexpectedTokenException tokenException)
            //{
            //    exceptionLabel.Text = tokenException.Message;
            //    exceptionLabel.ForeColor = Color.Red;

            //    mClassLogger.Info(tokenException.Message);

            //    return;
            //}
            //catch (CSymbolTableException symbTableException)
            //{
            //    exceptionLabel.Text = symbTableException.Message;
            //    exceptionLabel.ForeColor = Color.Red;

            //    mClassLogger.Info(symbTableException.Message);

            //    return;
            //}

            //exceptionLabel.Text = "Данные успешно скомпилированны";
            //exceptionLabel.ForeColor = Color.Green;

            //mClassLogger.Info("Данные успешно скомпилированны");
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
    }
}
