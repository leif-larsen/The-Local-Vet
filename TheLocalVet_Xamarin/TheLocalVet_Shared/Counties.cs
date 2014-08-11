using System;
using System.Collections.Generic;

namespace TheLocalVet_Shared
{
	public class Counties
	{
		private Dictionary<int, string> dCounties = new Dictionary<int, string>();
		private Dictionary<string, string> dPlaces = new Dictionary<string, string>();

		public Counties ()
		{
			addCounties ();
			addPlaces ();
		}

		private void addCounties() 
		{
			dCounties.Add(1, "Akershus");
			dCounties.Add(2, "Aust-Agder");
			dCounties.Add(3, "Buskerud");
			dCounties.Add(4, "Finnmark");
			dCounties.Add(5, "Hedmark");
			dCounties.Add(6, "Hordaland");
			dCounties.Add(7, "Møre og Romsdal");
			dCounties.Add(8, "Nord-Trøndelag");
			dCounties.Add(9, "Nordland");
			dCounties.Add(10, "Oppland");
			dCounties.Add(11, "Oslo");
			dCounties.Add(12, "Rogaland");
			dCounties.Add(13, "Sogn og Fjordane");
			dCounties.Add(14, "Sør-Trøndelag");
			dCounties.Add(15, "Telemark");
			dCounties.Add(16, "Troms");
			dCounties.Add(17, "Vest-Agder");
			dCounties.Add(18, "Vestfold");
			dCounties.Add(19, "Østfold");
		}

		private void addPlaces() 
		{
			dPlaces.Add ("Drammen", "Buskerud");
			dPlaces.Add ("Flesberg", "Buskerud");
			dPlaces.Add ("Flå", "Buskerud");
			dPlaces.Add ("Gol", "Buskerud");
			dPlaces.Add ("Hemsedal", "Buskerud");
			dPlaces.Add ("Hol", "Buskerud");
			dPlaces.Add ("Hole", "Buskerud");
			dPlaces.Add ("Hurum", "Buskerud");
			dPlaces.Add ("Kongsberg", "Buskerud");
			dPlaces.Add ("Krødsherad", "Buskerud");
			dPlaces.Add ("Lier", "Buskerud");
			dPlaces.Add ("Modum", "Buskerud");
			dPlaces.Add ("Nedre Eiker", "Buskerud");
			dPlaces.Add ("Nes", "Buskerud");
			dPlaces.Add ("Nore og Uvdal", "Buskerud");
			dPlaces.Add ("Ringerike", "Buskerud");
			dPlaces.Add ("Rollag", "Buskerud");
			dPlaces.Add ("Røyken", "Buskerud");
			dPlaces.Add ("Sigdal", "Buskerud");
			dPlaces.Add ("Ål", "Buskerud");
			dPlaces.Add ("Øvre Eiker", "Buskerud");
		}
			
	}
}

