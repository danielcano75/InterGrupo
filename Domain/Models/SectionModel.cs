using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class SectionModel
    {
        public SectionModel()
        {
        }

		public string SectionName { get; set; }
		public string ImgName { get; set; }
		public string IdentifierSegue { get; set; }
		public string InstanciateView { get; set; }

		public static List<SectionModel> GetAllSections()
		{

			List<SectionModel> sections = new List<SectionModel>();
			sections.Add(new SectionModel()
			{
				SectionName = "Prospectos",
				ImgName = "iconProspecto.png",
				IdentifierSegue = "Prospectos",
				InstanciateView = "viewProspectos"
			});
			sections.Add(new SectionModel()
			{
				SectionName = "Logs",
				ImgName = "iconLog.png",
				IdentifierSegue = "Logs",
				InstanciateView = "viewLogs"
			});
			sections.Add(new SectionModel()
			{
				SectionName = "Salir",
				ImgName = "iconSalir.png",
				IdentifierSegue = "Salir",
				InstanciateView = "viewSalir"
			});

			return sections;

		}

    }
}
