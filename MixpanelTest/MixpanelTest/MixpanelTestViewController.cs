//
// MixpanelTestViewController.cs: definition for the Mixpanel API
//
// Authors:
//   Airam Rguez
//
// Copyright 2013 Stelapps - Appsales.
//
//	Licensed under the Apache License, Version 2.0 (the "License");
//	you may not use this file except in compliance with the License.
//	You may obtain a copy of the License at
//
//	http://www.apache.org/licenses/LICENSE-2.0
//
//	Unless required by applicable law or agreed to in writing, software
//	distributed under the License is distributed on an "AS IS" BASIS,
//	WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//	See the License for the specific language governing permissions and
//	limitations under the License.
//
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

