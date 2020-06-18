using System;
using System.Collections.Generic;
using System.Text;

namespace repro.Models
{
	public enum MenuItemType
	{
		About,
		AutoSizeEditors,
		TranslucentNavbarWithScrollviewAndRefreshView,
		TranslucentNavbarWithScrollviewNoRefreshView,
		TranslucentNavbarWithTableViewAndRefreshView,
		TranslucentNavbarWithTableViewNoRefreshView,
	}
	public class HomeMenuItem
	{
		public MenuItemType Id { get; set; }

		public string Title { get; set; }
	}
}
