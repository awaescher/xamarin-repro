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
	}
}
