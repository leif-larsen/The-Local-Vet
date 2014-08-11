using System;
using System.Net.Http;
using System.Net
using Microsoft.WindowsAzure.MobileServices;

namespace TheLocalVet_Shared
{
	public class AzureData
	{
		private static MobileServiceClient MobileServiceUser = new MobileServiceClient ("https://thelocalvet.azure-mobile.net/", "nOxIuiQuykTdGVCqokuszfVdJmwYJz82");

		public AzureData ()
		{
		}
	}
}

