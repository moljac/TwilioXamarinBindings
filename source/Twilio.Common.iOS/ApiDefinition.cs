using Foundation;
using ObjCRuntime;

namespace Twilio.Common
{
	// @interface TwilioAccessManager : NSObject
	[BaseType (typeof(NSObject))]
	interface TwilioAccessManager
	{
		[Wrap ("WeakDelegate")]
		TwilioAccessManagerDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<TwilioAccessManagerDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// +(instancetype)accessManagerWithToken:(NSString *)token delegate:(id<TwilioAccessManagerDelegate>)delegate;
		[Static]
		[Export ("accessManagerWithToken:delegate:")]
		TwilioAccessManager AccessManagerWithToken (string token, TwilioAccessManagerDelegate @delegate);

		// -(void)updateToken:(NSString *)token;
		[Export ("updateToken:")]
		void UpdateToken (string token);

		// -(NSString *)token;
		[Export ("token")]
		//mc++ [Verify (MethodToProperty)]
		string Token { get; }

		// -(NSString *)identity;
		[Export ("identity")]
		//mc++ [Verify (MethodToProperty)]
		string Identity { get; }

		// -(BOOL)isExpired;
		[Export ("isExpired")]
		//mc++ [Verify (MethodToProperty)]
		bool IsExpired { get; }

		// -(NSDate *)expirationDate;
		[Export ("expirationDate")]
		//mc++ [Verify (MethodToProperty)]
		NSDate ExpirationDate { get; }
	}

	// @protocol TwilioAccessManagerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface TwilioAccessManagerDelegate
	{
		// @required -(void)accessManagerTokenExpired:(TwilioAccessManager *)accessManager;
		[Abstract]
		[Export ("accessManagerTokenExpired:")]
		void AccessManagerTokenExpired (TwilioAccessManager accessManager);

		// @required -(void)accessManager:(TwilioAccessManager *)accessManager error:(NSError *)error;
		[Abstract]
		[Export ("accessManager:error:")]
		void AccessManager (TwilioAccessManager accessManager, NSError error);
	}
}
