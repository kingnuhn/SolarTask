using SolarTask.Model.Interfaces;

namespace SolarTask.Model
{
    public class Person : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }

    }
}
