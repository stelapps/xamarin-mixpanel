//
// ApiDefinitions.cs: definition for the Mixpanel API
//
// Authors:
//   Airam Rguez
//
// Copyright 2013 Stelapps - Appsales.
//
//		Licensed under the Apache License, Version 2.0 (the "License");
//		you may not use this file except in compliance with the License.
//		You may obtain a copy of the License at
//
//		http://www.apache.org/licenses/LICENSE-2.0
//
//		Unless required by applicable law or agreed to in writing, software
//		distributed under the License is distributed on an "AS IS" BASIS,
//		WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//		See the License for the specific language governing permissions and
//			limitations under the License.
//
using System;
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;

namespace MonoTouch.Mixpanel
{
	[BaseType (typeof (NSObject))]
	public partial interface MPCJSONDataSerializer
	{

		[Static, Export ("serializer")]
		NSObject Serializer { get; }

		[Export ("serializeObject:error:")]
		NSData SerializeObject (NSObject inObject, out NSError outError);

		[Export ("serializeNull:error:")]
		NSData SerializeNull (NSNull inNull, out NSError outError);

		[Export ("serializeNumber:error:")]
		NSData SerializeNumber (NSNumber inNumber, out NSError outError);

		[Export ("serializeString:error:")]
		NSData SerializeString (string inString, out NSError outError);

		[Export ("serializeArray:error:")]
		NSData SerializeArray (NSArray inArray, out NSError outError);

		[Export ("serializeDictionary:error:")]
		NSData SerializeDictionary (NSDictionary inDictionary, out NSError outError);
	}

	[BaseType (typeof (NSObject))]
	public partial interface MPCSerializedJSONData
	{

		[Export ("data", ArgumentSemantic.Retain)]
		NSData Data { get; }

		[Export ("initWithData:")]
		IntPtr Constructor (NSData inData);
	}

	[Category, BaseType (typeof (NSData))]
	public partial interface MP_Base64_NSData
	{

		[Static, Export ("mp_dataFromBase64String:")]
		NSData Mp_dataFromBase64String (string aString);

		[Static, Export ("mp_base64EncodedString")]
		string Mp_base64EncodedString { get; }
	}

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

	[BaseType (typeof (NSObject))]
	public partial interface MixpanelPeople
	{

		[Export ("addPushDeviceToken:")]
		void AddPushDeviceToken (NSData deviceToken);

		[Export ("set:")]
		NSDictionary Set (NSDictionary properties);

		[Export ("set:to:")]
		void Set (string property, NSObject obj);

		[Export ("once")]
		NSDictionary Once { set; }

		[Export ("increment:")]
		void Increment (NSDictionary properties);

		[Export ("increment:by:")]
		void Increment (string property, NSNumber amount);

		[Export ("append:")]
		void Append (NSDictionary properties);

		[Export ("trackCharge:")]
		void TrackCharge (NSNumber amount);

		[Export ("trackCharge:withProperties:")]
		void TrackCharge (NSNumber amount, NSDictionary properties);

		[Export ("clearCharges")]
		void ClearCharges ();

		[Export ("deleteUser")]
		void DeleteUser ();
	}

	[Model, BaseType (typeof (NSObject))]
	public partial interface MixpanelDelegate
	{

		[Export ("mixpanelWillFlush:")]
		bool mixpanelWillFlush (Mixpanel mixpanel);
	}

	[BaseType (typeof (NSObject))]
	public partial interface MPCJSONSerializer
	{

		[Static, Export ("serializer")]
		NSObject Serializer { get; }

		[Export ("serializeObject:error:")]
		string SerializeObject (NSObject inObject, out NSError outError);

		[Export ("serializeArray:error:")]
		string SerializeArray (NSArray inArray, out NSError outError);

		[Export ("serializeDictionary:error:")]
		string SerializeDictionary (NSDictionary inDictionary, out NSError outError);
	}
}
