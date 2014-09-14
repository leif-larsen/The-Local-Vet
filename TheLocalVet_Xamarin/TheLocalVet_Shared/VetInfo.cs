using System;

namespace TheLocalVet_Shared
{
	public class VetInfo
	{
		public VetInfo ()
		{
			addresse = new Addresse();
		}

		public Addresse addresse;
		public string vetName { get; set; }
		public string phone { get; set; }
		public string phonealt { get; set; }
		public string email { get; set; }
		public string web { get; set; }
		public string openingHours { get; set; }
	}
}