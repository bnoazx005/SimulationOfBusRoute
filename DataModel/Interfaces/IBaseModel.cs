namespace DataModel.Interfaces
{
    public interface IBaseModel
    {
        uint ID { get; set; }

        string Name { get; set; }

        void Verify();
    }
}
