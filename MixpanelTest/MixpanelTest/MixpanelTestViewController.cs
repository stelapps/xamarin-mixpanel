using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.ComponentModel;
using MonoTouch.Mixpanel;

namespace MixpanelTest
{
	public partial class MixpanelTestViewController : UIViewController
	{
		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public MixpanelTestViewController ()
			: base (UserInterfaceIdiomIsPhone ? "MixpanelTestViewController_iPhone" : "MixpanelTestViewController_iPad", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			SendInfo.TouchUpInside += delegate {
				// Run mixpanel tasks in background.
				BackgroundWorker worker = new BackgroundWorker ();
				worker.DoWork += (object sender, DoWorkEventArgs e) => {
					// Test tracking events.
					Mixpanel.SharedInstance.Track ("Test 1");
					NSMutableDictionary properties = new NSMutableDictionary ();
					properties ["gender"] = new NSString ("female");
					properties ["plan"] = new NSString ("premium");
					Mixpanel.SharedInstance.Track ("Player create", properties);
					// Test people properties.
					Mixpanel.SharedInstance.Identify ("user123");
					Mixpanel.SharedInstance.People.Set ("Bought Premium Plan", NSDate.Now);
				};
				worker.RunWorkerAsync ();
			};
		}
	}
}

