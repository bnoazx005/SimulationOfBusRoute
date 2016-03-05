using System.Data.SQLite;


namespace SimulationOfBusRoute.Models
{
    public interface IBaseModel
    {
        void LoadFromDataBase(SQLiteConnection dbConnection);

        void SaveIntoDataBase(SQLiteConnection dbConnection);

        uint ID { get; set; }

        string Name { get; set; }
    }
}
