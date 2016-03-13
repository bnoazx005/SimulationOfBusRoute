using System.Windows.Forms;


namespace SimulationOfBusRoute.Views
{
    public partial class BusEditor : Form, IBusEditorView
    {
        public BusEditor()
        {
            InitializeComponent();
        }

        public void Display()
        {
            Show();
        }
    }
}
