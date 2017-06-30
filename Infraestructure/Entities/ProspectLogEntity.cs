using System;
using SQLite.Net.Attributes;

namespace Infraestructure.Entities
{
    public class ProspectLogEntity
    {
        public ProspectLogEntity()
        {
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string ProspectIdId { get; set; }
		public string Name { get; set; }
        [Indexed]
        public DateTime CreationDate { get; set; }
    }
}
