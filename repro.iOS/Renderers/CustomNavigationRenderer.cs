using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using System;
using repro.iOS.Renderers;

[assembly: ExportRenderer(typeof(NavigationPage), typeof(CustomNavigationRenderer))]
namespace repro.iOS.Renderers
{
    public class CustomNavigationRenderer : NavigationRenderer
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            if (NavigationBar.Translucent)
            {
                UINavigationBar.Appearance.SetBackgroundImage(new UIImage(), UIBarMetrics.Default);
                UINavigationBar.Appearance.ShadowImage = new UIImage();
                UINavigationBar.Appearance.BackgroundColor = UIColor.Clear;
                UINavigationBar.Appearance.Translucent = true;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
            }

            base.Dispose(disposing);
        }
    }
}