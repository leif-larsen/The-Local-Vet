using System;

namespace TheLocalVet.Models
{
	public class FilterEventArgs : EventArgs
	{
		public string FilterType { get; set; }
		public string FilterValue { get; set; }

		public FilterEventArgs ()
		{
			FilterType = string.Empty;
			FilterValue = string.Empty;
		}
	}
}

