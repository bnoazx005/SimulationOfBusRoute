using SimulationOfBusRoute.Models;
using SimulationOfBusRoute.Views;
using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SimulationOfBusRoute.Presenters
{
    class CStationsEditorPresenter : CBasePresenter<CMainModel, IStationsEditorView>
    {
        private object mSyncObject;

        public CStationsEditorPresenter(CMainModel model, IStationsEditorView view):
            base(model, view)
        {
            mSyncObject = new object();

            mView.OnFormInit += _onFormInit;
            mView.OnQuit += _onQuit;

            mView.OnAddMatrix += _onAddMatrix;
            mView.OnRemoveMatrix += _onRemoveMatrix;
            mView.OnTimerTick += _onTimerTick;
            mView.OnCloseForm += _onCloseForm;
        }
        
        private void _onFormInit(object sender, EventArgs e)
        {

        }

        private void _onQuit(object sender, FormClosingEventArgs e)
        {            
            mIsRunning = false;
        }

        private void _onCloseForm(object sender, EventArgs e)
        {
            mView.Quit();
        }

        private void _onAddMatrix(object sender, EventArgs e)
        {

        }

        private void _onRemoveMatrix(object sender, EventArgs e)
        {

        }

        private void _onTimerTick(object sender, EventArgs e)
        {
            if (!mIsRunning)
            {
                return;
            }

            //_highlightSyntax();
            new Task(_highlightSyntax).Start();
        }

        private void _highlightSyntax()
        {
            Regex highlightingGroup1Pattern = new Regex(Properties.Resources.mDataEditorHighlightingGroup1, RegexOptions.Singleline);

            RichTextBox textEditor = mView.TextEditor;

            int startPos = 0;
            int length = 0;
            int selectionStart = 0;

            string programText = null;

            //используются асинхронные вызовы методов
            lock (mSyncObject)
            {
                textEditor.Invoke((MethodInvoker)(() => { programText = textEditor.Text; }));

                MatchCollection matches = highlightingGroup1Pattern.Matches(programText);

                textEditor.Invoke((MethodInvoker)(() =>
                {
                    selectionStart = textEditor.SelectionStart;
                    textEditor.SelectAll();

                    textEditor.SelectionColor = Color.Black;
                    textEditor.SelectionStart = selectionStart;
                    textEditor.SelectionLength = 0;
                }));

                foreach (Match currMatch in matches)
                {
                    startPos = currMatch.Index;
                    length = currMatch.Length;

                    textEditor.Invoke((MethodInvoker)(() => 
                    {
                        textEditor.Select(startPos, length);

                        textEditor.SelectionColor = Color.Blue;

                        textEditor.SelectionStart = selectionStart;
                        textEditor.SelectionLength = 0;
                        textEditor.SelectionColor = Color.Black;
                    }));
                }
            }
        }
    }
}
