//
// Mixpanel.cs: definition for the Mixpanel API
//
// Authors:
//   Airam Rguez
//
// Copyright 2013 Stelapps - Appsales.
//
// Licensed under the terms of the Apache 2 License
//
using System;
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;

namespace MixpanelSDK
{

	[BaseType (typeof (NSObject))]
	public partial interface Mixpanel
	{

		[Export ("people", ArgumentSemantic.Retain)]
		MixpanelPeople People { get; }

		[Export ("distinctId", ArgumentSemantic.Copy)]
		string DistinctId { get; }

		[Export ("nameTag", ArgumentSemantic.Copy)]
		string NameTag { get; set; }

		[Export ("serverURL", ArgumentSemantic.Copy)]
		string ServerURL { get; set; }

		[Export ("flushInterval")]
		uint FlushInterval { get; set; }

		[Export ("flushOnBackground")]
		bool FlushOnBackground { get; set; }

		[Export ("showNetworkActivityIndicator")]
		bool ShowNetworkActivityIndicator { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)]
		MixpanelDelegate Delegate { get; set; }

		[Static, Export ("sharedInstanceWithToken:")]
		Mixpanel SharedInstanceWithToken (string apiToken);

		[Static, Export ("sharedInstance")]
		Mixpanel SharedInstance { get; }

		[Export ("initWithToken:andFlushInterval:")]
		IntPtr Constructor (string apiToken, uint flushInterval);

		[Export ("identify:")]
		void Identify (string distinctId);

		[Export ("track:")]
		void Track (string evt);

		[Export ("track:properties:")]
		void Track (string evt, NSDictionary properties);

		[Export ("registerSuperProperties:")]
		void RegisterSuperProperties (NSDictionary properties);

		[Export ("registerSuperPropertiesOnce:")]
		void RegisterSuperPropertiesOnce (NSDictionary properties);

		[Export ("registerSuperPropertiesOnce:defaultValue:")]
		void RegisterSuperPropertiesOnce (NSDictionary properties, NSObject defaultValue);

		[Export ("unregisterSuperProperty:")]
		void UnregisterSuperProperty (string propertyName);

		[Export ("clearSuperProperties")]
		void ClearSuperProperties ();

		[Export ("currentSuperProperties")]
		NSDictionary CurrentSuperProperties { get; }

		[Export ("reset")]
		void Reset ();

		[Export ("flush")]
		void Flush ();

		[Export ("archive")]
		void Archive ();
	}
	
}
