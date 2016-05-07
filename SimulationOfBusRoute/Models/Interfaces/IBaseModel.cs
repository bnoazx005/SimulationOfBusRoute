namespace SimulationOfBusRoute.Models.Interfaces
{
    public interface IBaseModel
    {
        int ID { get; set; }

        string Name { get; set; }

        void Verify();
    }
}
