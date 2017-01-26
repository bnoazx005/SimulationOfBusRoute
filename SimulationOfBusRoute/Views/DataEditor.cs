using SimulationOfBusRoute.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace SimulationOfBusRoute.Views
{
    public partial class DataEditor : Form, IDataEditorView
    {
        private Dictionary<string, Button> mButtonsList;

        public DataEditor()
        {
            InitializeComponent();
            
            mButtonsList = Controls.GetControlsDictionaryOfType<Button>();

            Load                        += (sender, e) => { if (OnFormInit != null) { OnFormInit(this, EventArgs.Empty); } };
            FormClosing                 += (sender, e) => { if (OnQuit != null) { OnQuit(this, e); } };
            
            editorTimer.Tick            += (sender, e) => { if (OnTimerTick != null) { OnTimerTick(editorTimer, EventArgs.Empty); } };
            
            //buttons
            quitButton.Click            += (sender, e) => { if (OnCloseForm != null) { OnCloseForm(null, EventArgs.Empty); } };
            undoChangesButton.Click     += (sender, e) => { if (OnUndoChanges != null) { OnUndoChanges(undoChangesButton, EventArgs.Empty); } };
            redoChangesButton.Click     += (sender, e) => { if (OnRedoChanges != null) { OnRedoChanges(redoChangesButton, EventArgs.Empty); } };
            copyTextButton.Click        += (sender, e) => { if (OnCopyText != null) { OnCopyText(copyTextButton, EventArgs.Empty); } };
            pasteTextButton.Click       += (sender, e) => { if (OnPasteText != null) { OnPasteText(pasteTextButton, EventArgs.Empty); } };
            cutTextButton.Click         += (sender, e) => { if (OnCutText != null) { OnCutText(cutTextButton, EventArgs.Empty); } };
            generateDataButton.Click    += (sender, e) => { if (OnCompileData != null) { OnCompileData(generateDataButton, EventArgs.Empty); } };

            //menu items
            closeWindowMenuItem.Click   += (sender, e) => { if (OnCloseForm != null) { OnCloseForm(null, EventArgs.Empty); } };
            undoChangesMenuItem.Click   += (sender, e) => { if (OnUndoChanges != null) { OnUndoChanges(undoChangesMenuItem, EventArgs.Empty); } };
            redoChangesMenuItem.Click   += (sender, e) => { if (OnRedoChanges != null) { OnRedoChanges(redoChangesMenuItem, EventArgs.Empty); } };
            copyTextMenuItem.Click      += (sender, e) => { if (OnCopyText != null) { OnCopyText(copyTextMenuItem, EventArgs.Empty); } };
            pasteTextMenuItem.Click     += (sender, e) => { if (OnPasteText != null) { OnPasteText(pasteTextMenuItem, EventArgs.Empty); } };
            cutTextMenuItem.Click       += (sender, e) => { if (OnCutText != null) { OnCutText(cutTextMenuItem, EventArgs.Empty); } };
            compileDataMenuItem.Click   += (sender, e) => { if (OnCompileData != null) { OnCompileData(compileDataMenuItem, EventArgs.Empty); } };
            docsMenuItem.Click          += (sender, e) => { if (OnOpenDocs != null) { OnOpenDocs(this, e); } };
        }
        
        public event EventHandler OnFormInit;
        public event FormClosingEventHandler OnQuit;
        public event EventHandler OnCloseForm;
        public event EventHandler OnTimerTick;
        public event EventHandler OnUndoChanges;
        public event EventHandler OnRedoChanges;
        public event EventHandler OnCopyText;
        public event EventHandler OnCutText;
        public event EventHandler OnPasteText;
        public event MouseEventHandler OnMouseButtonPressed;
        public event EventHandler OnCompileData;
        public event EventHandler OnOpenDocs;

        public void Display()
        {
            Show();
        }

        public void Quit()
        {
            Close();
        }

        #region Properties

        public RichTextBox StationsEditorHeaderText
        {
            get
            {
                return stationsEditorHeaderText;
            }

            set
            {
                stationsEditorHeaderText = value;
            }
        }

        public RichTextBox StationsEditorText
        {
            get
            {
                return stationsDataEditorText;
            }

            set
            {
                stationsDataEditorText = value;
            }
        }

        public RichTextBox BusVelocitiesHeaderText
        {
            get
            {
                return busVelocitiesHeaderText;
            }

            set
            {
                busVelocitiesHeaderText = value;
            }
        }

        public RichTextBox BusVelocitiesEditorText
        {
            get
            {
                return busVelocitiesEditorText;
            }

            set
            {
                busVelocitiesEditorText = value;
            }
        }

        public bool CanRedoText
        {
            get
            {
                switch (editorTabs.SelectedIndex)
                {
                    case 0:
                        return stationsDataEditorText.CanRedo;
                    case 1:
                        return busVelocitiesEditorText.CanRedo;
                    default:
                        return false;
                }
            }
        }

        public bool CanUndoText
        {
            get
            {
                switch (editorTabs.SelectedIndex)
                {
                    case 0:
                        return stationsDataEditorText.CanUndo;
                    case 1:
                        return busVelocitiesEditorText.CanUndo;
                    default:
                        return false;
                }
            }
        }

        public int CurrSelectedEditorIndex
        {
            get
            {
                return editorTabs.SelectedIndex;
            }
        }

        public Dictionary<string, Button> ButtonsList
        {
            get
            {
                return mButtonsList;
            }

            set
            {
                mButtonsList = value;
            }
        }

        public ToolStripStatusLabel MessageText
        {
            get
            {
                return exceptionLabel;
            }

            set
            {
                exceptionLabel = value;
            }
        }

        #endregion
    }
}
