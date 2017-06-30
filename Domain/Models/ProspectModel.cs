using System;
namespace Domain.Models
{
	public class ProspectModel
	{
		public ProspectModel()
		{
		}

		public string id { get; set; }
		public string name { get; set; }
		public string surname { get; set; }
		public string telephone { get; set; }
		public string schProspectIdentification { get; set; }
		public string address { get; set; }
		public DateTime createdAt { get; set; }
		public DateTime updatedAt { get; set; }
		public int statusCd { get; set; }
		public string zoneCode { get; set; }
		public string neighborhoodCode { get; set; }
		public string cityCode { get; set; }
		public string sectionCode { get; set; }
		public int roleId { get; set; }
		public string appointableId { get; set; }
		public string rejectedObservation { get; set; }
		public string observation { get; set; }
		public bool disable { get; set; }
		public bool visited { get; set; }
		public bool callcenter { get; set; }
		public bool acceptSearch { get; set; }
		public string campaignCode { get; set; }
		public string userId { get; set; }
        public string ImgStatus { get; set; }
        public string StatusName { get; set; }
        public string StatusColor { get; set; }
	}
}

