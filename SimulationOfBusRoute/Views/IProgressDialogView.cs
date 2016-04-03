using System.Windows.Forms;


namespace SimulationOfBusRoute.Views
{
    public interface IProgressDialogView : IBaseView
    {
        string Message { get; set; }

        Form Form { get; }
    }
}
