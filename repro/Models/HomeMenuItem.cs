using System;
using System.Collections.Generic;
using System.Text;

namespace repro.Models
{
	public enum MenuItemType
	{
		AutoSizeEditors,
		TranslucentWithoutRefreshView,
		TranslucentWithRefreshView,
	}
	public class HomeMenuItem
	{
		public MenuItemType Id { get; set; }

		public string Title { get; set; }
	}
}
