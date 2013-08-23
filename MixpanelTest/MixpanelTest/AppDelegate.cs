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

