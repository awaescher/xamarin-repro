﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using repro.Models;
using repro.Views;
using repro.ViewModels;
using Xamarin.Forms.PlatformConfiguration;

namespace repro.Views
{
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class TranslucentNavbarWithTableViewAndRefreshView : ContentPage
	{
		ItemsViewModel viewModel;

		public TranslucentNavbarWithTableViewAndRefreshView()
		{
			InitializeComponent();

			BindingContext = viewModel = new ItemsViewModel();
		}

		async void OnItemSelected(object sender, EventArgs args)
		{
			var layout = (BindableObject)sender;
			var item = (Item)layout.BindingContext;
			await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));
		}

		async void AddItem_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			if (viewModel.Items.Count == 0)
				viewModel.IsBusy = true;
		}
	}
}