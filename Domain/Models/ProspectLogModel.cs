using System;
namespace Domain.Models
{
    public class ProspectLogModel
    {
        public ProspectLogModel()
        {
        }

		public int Id { get; set; }
		public string ProspectId { get; set; }
		public string Name { get; set; }
		public DateTime CreationDate { get; set; }
    }
}
