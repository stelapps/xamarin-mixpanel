using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libMixpanel.a", LinkTarget.Simulator | LinkTarget.ArmV7, 
                     Frameworks = "Foundation, AdSupport, CoreTelephony, UIKit, SystemConfiguration", ForceLoad = true)]