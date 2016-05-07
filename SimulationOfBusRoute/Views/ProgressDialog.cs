using System.Windows.Forms;


namespace SimulationOfBusRoute.Views
{
    public partial class ProgressDialog : Form, IProgressDialogView
    {
        public ProgressDialog()
        {
            InitializeComponent();
        }

        #region Methods

        public void Display()
        {
            ShowDialog();
        }

        public void Quit()
        {
            Close();
        }

        #endregion

        #region Properties
        
        public string Message
        {
            get
            {
                return infoLabel.Text;
            }

            set
            {
                infoLabel.Text = value;
            }
        }

        public Form Form
        {
            get
            {
                return this;
            }
        }

        #endregion
    }
}
