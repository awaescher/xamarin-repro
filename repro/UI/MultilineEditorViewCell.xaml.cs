using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace repro.UI
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MultilineEditorViewCell : ViewCell
	{
		public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(MultilineEditorViewCell), string.Empty);

		public MultilineEditorViewCell()
		{
			InitializeComponent();
		}

		public string Text
		{
			get => (string)GetValue(TextProperty);
			set => SetValue(TextProperty, value);
		}

		void Editor_MeasureInvalidated(System.Object sender, System.EventArgs e)
		{
			if (sender is Editor editor && !string.IsNullOrWhiteSpace(editor.Text))
				editor.HeightRequest = -1;

			//var tableView = this.Parent as TableView;

			//if (tableView == null || editor == null)
			//	return;


			//// TODO got to try a renderer (wihtout HeightRequest and stuff) ...
			//// https://medium.com/@georgetsifrikas/embedding-uitextview-inside-uitableviewcell-9a28794daf01
			//tableView.BatchBegin();
			//tableView.BatchCommit();
		}
	}
}
