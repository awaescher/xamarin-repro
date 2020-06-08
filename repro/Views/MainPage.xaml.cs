using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using repro.Models;
using Xamarin.Forms.PlatformConfiguration;
namespace repro.Views
{
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class MainPage : MasterDetailPage
	{
		Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
		public MainPage()
		{
			InitializeComponent();

			MasterBehavior = MasterBehavior.Popover;
		}

		public async Task NavigateFromMenu(int id)
		{
			if (!MenuPages.ContainsKey(id))
			{
				switch (id)
				{
					case (int)MenuItemType.About:
						MenuPages.Add(id, CreateNavigationPage(new AboutPage()));
						break;
					case (int)MenuItemType.AutoSizeEditors:
						MenuPages.Add(id, CreateNavigationPage(new AutoSizeEditors()));
						break;
					case (int)MenuItemType.TranslucentWithoutRefreshView:
						MenuPages.Add(id, CreateNavigationPage(new TranslucentWithoutRefreshPage()));
						break;
					case (int)MenuItemType.TranslucentWithRefreshView:
						MenuPages.Add(id, CreateNavigationPage(new TranslucentWithRefreshPage()));
						break;
				}
			}

			var newPage = MenuPages[id];

			if (newPage != null && Detail != newPage)
			{
				Detail = newPage;

				if (Device.RuntimePlatform == Device.Android)
					await Task.Delay(100);

				IsPresented = false;
			}
		}


		private Xamarin.Forms.NavigationPage CreateNavigationPage(Xamarin.Forms.Page page)
		{
			var navigationPage = new Xamarin.Forms.NavigationPage(page);
			Xamarin.Forms.PlatformConfiguration.iOSSpecific.NavigationPage.SetIsNavigationBarTranslucent(navigationPage, true);
			return navigationPage;
		}

	}
}