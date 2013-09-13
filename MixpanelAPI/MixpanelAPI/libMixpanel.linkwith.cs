using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libMixpanel.a", LinkTarget.Simulator | LinkTarget.ArmV7, 
                     Frameworks = "Foundation, CoreTelephony, UIKit, SystemConfiguration", 
                     WeakFrameworks = "AdSupport", ForceLoad = true)]