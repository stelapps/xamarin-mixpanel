//
// AppDelegate.cs: definition for the Mixpanel API
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
using MonoTouch.Mixpanel;

namespace MixpanelTest
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// Mixpanel token.
		const string MixpanelToken = "Place your Token Here (Account > Projects > Token)";
		UIWindow window;
		MixpanelTestViewController viewController;

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			// Use your own token.
			Mixpanel.SharedInstanceWithToken (MixpanelToken);

			window = new UIWindow (UIScreen.MainScreen.Bounds);
			
			viewController = new MixpanelTestViewController ();
			window.RootViewController = viewController;
			window.MakeKeyAndVisible ();
			
			return true;
		}
		// Register for notifications
		public override void RegisteredForRemoteNotifications (UIApplication application, NSData deviceToken)
		{
			Mixpanel.SharedInstance.People.AddPushDeviceToken (deviceToken);
		}
	}
}

