using System;
using CoreLocation;
using Foundation;
using ObjCRuntime;
using UIKit;
using UserNotifications;

namespace Jpush.Xamarin.IOS {

    // The first step to creating a binding is to add your native framework ("MyLibrary.xcframework")
    // to the project.
    // Open your binding csproj and add a section like this
    // <ItemGroup>
    //   <NativeReference Include="MyLibrary.xcframework">
    //     <Kind>Framework</Kind>
    //     <Frameworks></Frameworks>
    //   </NativeReference>
    // </ItemGroup>
    //
    // Once you've added it, you will need to customize it for your specific library:
    //  - Change the Include to the correct path/name of your library
    //  - Change Kind to Static (.a) or Framework (.framework/.xcframework) based upon the library kind and extension.
    //    - Dynamic (.dylib) is a third option but rarely if ever valid, and only on macOS and Mac Catalyst
    //  - If your library depends on other frameworks, add them inside <Frameworks></Frameworks>
    // Example:
    // <NativeReference Include="libs\MyTestFramework.xcframework">
    //   <Kind>Framework</Kind>
    //   <Frameworks>CoreLocation ModelIO</Frameworks>
    // </NativeReference>
    // 
    // Once you've done that, you're ready to move on to binding the API...
    //
    // Here is where you'd define your API definition for the native Objective-C library.
    //
    // For example, to bind the following Objective-C class:
    //
    //     @interface Widget : NSObject {
    //     }
    //
    // The C# binding would look like this:
    //
    //     [BaseType (typeof (NSObject))]
    //     interface Widget {
    //     }
    //
    // To bind Objective-C properties, such as:
    //
    //     @property (nonatomic, readwrite, assign) CGPoint center;
    //
    // You would add a property definition in the C# interface like so:
    //
    //     [Export ("center")]
    //     CGPoint Center { get; set; }
    //
    // To bind an Objective-C method, such as:
    //
    //     -(void) doSomething:(NSObject *)object atIndex:(NSInteger)index;
    //
    // You would add a method definition to the C# interface like so:
    //
    //     [Export ("doSomething:atIndex:")]
    //     void DoSomething (NSObject object, nint index);
    //
    // Objective-C "constructors" such as:
    //
    //     -(id)initWithElmo:(ElmoMuppet *)elmo;
    //
    // Can be bound as:
    //
    //     [Export ("initWithElmo:")]
    //     NativeHandle Constructor (ElmoMuppet elmo);
    //
    // For more information, see https://aka.ms/ios-binding
    //


    // @interface JGInforCollectionAuthItems : NSObject
    [BaseType(typeof(NSObject))]
    interface JGInforCollectionAuthItems
    {
        // @property (assign, nonatomic) BOOL isAuth;
        [Export("isAuth")]
        bool IsAuth { get; set; }
    }

    // @interface JGInforCollectionAuth : NSObject
    [BaseType(typeof(NSObject))]
    interface JGInforCollectionAuth
    {
        // +(void)JCollectionAuth:(void (^ _Nullable)(JGInforCollectionAuthItems * _Nonnull))authBlock;
        [Static]
        [Export("JCollectionAuth:")]
        void JCollectionAuth([NullAllowed] Action<JGInforCollectionAuthItems> authBlock);
    }

    // typedef void (^JPUSHTagsOperationCompletion)(NSInteger, NSSet * _Nullable, NSInteger);
    delegate void JPUSHTagsOperationCompletion(nint arg0, [NullAllowed] NSSet arg1, nint arg2);

    // typedef void (^JPUSHTagValidOperationCompletion)(NSInteger, NSSet * _Nullable, NSInteger, BOOL);
    delegate void JPUSHTagValidOperationCompletion(nint arg0, [NullAllowed] NSSet arg1, nint arg2, bool arg3);

    // typedef void (^JPUSHAliasOperationCompletion)(NSInteger, NSString * _Nullable, NSInteger);
    delegate void JPUSHAliasOperationCompletion(nint arg0, [NullAllowed] string arg1, nint arg2);

    // typedef void (^JPUSHPropertiesOperationCompletion)(NSInteger, NSDictionary * _Nullable, NSInteger);
    delegate void JPUSHPropertiesOperationCompletion(nint arg0, [NullAllowed] NSDictionary arg1, nint arg2);

    // typedef void (^JPUSHLiveActivityTokenCompletion)(NSInteger, NSString * _Nullable, NSData * _Nullable, NSInteger);
    delegate void JPUSHLiveActivityTokenCompletion(nint arg0, [NullAllowed] string arg1, [NullAllowed] NSData arg2, nint arg3);

    [Static]
    //[Verify(ConstantsInterfaceAssociation)]
    partial interface Constants
    {
        // extern NSString *const _Nonnull kJPFNetworkIsConnectingNotification;
        [Field("kJPFNetworkIsConnectingNotification", "__Internal")]
        NSString kJPFNetworkIsConnectingNotification { get; }

        // extern NSString *const _Nonnull kJPFNetworkDidSetupNotification;
        [Field("kJPFNetworkDidSetupNotification", "__Internal")]
        NSString kJPFNetworkDidSetupNotification { get; }

        // extern NSString *const _Nonnull kJPFNetworkDidCloseNotification;
        [Field("kJPFNetworkDidCloseNotification", "__Internal")]
        NSString kJPFNetworkDidCloseNotification { get; }

        // extern NSString *const _Nonnull kJPFNetworkDidRegisterNotification;
        [Field("kJPFNetworkDidRegisterNotification", "__Internal")]
        NSString kJPFNetworkDidRegisterNotification { get; }

        // extern NSString *const _Nonnull kJPFNetworkFailedRegisterNotification;
        [Field("kJPFNetworkFailedRegisterNotification", "__Internal")]
        NSString kJPFNetworkFailedRegisterNotification { get; }

        // extern NSString *const _Nonnull kJPFNetworkDidLoginNotification;
        [Field("kJPFNetworkDidLoginNotification", "__Internal")]
        NSString kJPFNetworkDidLoginNotification { get; }

        // extern NSString *const _Nonnull kJPFNetworkDidReceiveMessageNotification;
        [Field("kJPFNetworkDidReceiveMessageNotification", "__Internal")]
        NSString kJPFNetworkDidReceiveMessageNotification { get; }

        // extern NSString *const _Nonnull kJPFServiceErrorNotification;
        [Field("kJPFServiceErrorNotification", "__Internal")]
        NSString kJPFServiceErrorNotification { get; }
    }

    // @interface JPUSHRegisterEntity : NSObject
    [BaseType(typeof(NSObject))]
    interface JPUSHRegisterEntity
    {
        // @property (assign, nonatomic) NSInteger types;
        [Export("types")]
        nint Types { get; set; }

        // @property (nonatomic, strong) NSSet * _Nullable categories;
        [NullAllowed, Export("categories", ArgumentSemantic.Strong)]
        NSSet Categories { get; set; }
    }

    // @interface JPushNotificationIdentifier : NSObject <NSCopying, NSCoding>
    [BaseType(typeof(NSObject))]
    interface JPushNotificationIdentifier : INSCopying, INSCoding
    {
        // @property (copy, nonatomic) NSArray<NSString *> * _Nullable identifiers;
        [NullAllowed, Export("identifiers", ArgumentSemantic.Copy)]
        string[] Identifiers { get; set; }

        // @property (copy, nonatomic) NS_DEPRECATED_IOS(4_0, 10_0) UILocalNotification * notificationObj __attribute__((availability(ios, introduced=4.0, deprecated=10.0)));
        [Introduced(PlatformName.iOS, 4, 0)]
        [Deprecated(PlatformName.iOS, 10, 0)]
        [Export("notificationObj", ArgumentSemantic.Copy)]
        UILocalNotification NotificationObj { get; set; }

        // @property (assign, nonatomic) BOOL delivered __attribute__((availability(ios, introduced=10.0)));
        //[iOS(10, 0)]
        [Export("delivered")]
        bool Delivered { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(NSArray * _Nullable) findCompletionHandler;
        [NullAllowed, Export("findCompletionHandler", ArgumentSemantic.Copy)]
        Action<NSArray> FindCompletionHandler { get; set; }
    }

    // @interface JPushNotificationSound : NSObject <NSCopying, NSCoding>
    [BaseType(typeof(NSObject))]
    interface JPushNotificationSound : INSCopying, INSCoding
    {
        // @property (copy, nonatomic) NSString * _Nullable soundName;
        [NullAllowed, Export("soundName")]
        string SoundName { get; set; }

        // @property (copy, nonatomic) NS_AVAILABLE_IOS(12.0) NSString * criticalSoundName __attribute__((availability(ios, introduced=12.0)));
        //[iOS(12, 0)]
        [Export("criticalSoundName")]
        string CriticalSoundName { get; set; }

        // @property (assign, nonatomic) float criticalSoundVolume __attribute__((availability(ios, introduced=12.0)));
        //[iOS(12, 0)]
        [Export("criticalSoundVolume")]
        float CriticalSoundVolume { get; set; }
    }

    // @interface JPushNotificationContent : NSObject <NSCopying, NSCoding>
    [BaseType(typeof(NSObject))]
    interface JPushNotificationContent : INSCopying, INSCoding
    {
        // @property (copy, nonatomic) NSString * _Nonnull title;
        [Export("title")]
        string Title { get; set; }

        // @property (copy, nonatomic) NSString * _Nonnull subtitle;
        [Export("subtitle")]
        string Subtitle { get; set; }

        // @property (copy, nonatomic) NSString * _Nonnull body;
        [Export("body")]
        string Body { get; set; }

        // @property (copy, nonatomic) NSNumber * _Nullable badge;
        [NullAllowed, Export("badge", ArgumentSemantic.Copy)]
        NSNumber Badge { get; set; }

        // @property (copy, nonatomic) NS_DEPRECATED_IOS(8_0, 10_0) NSString * action __attribute__((availability(ios, introduced=8.0, deprecated=10.0)));
        [Introduced(PlatformName.iOS, 8, 0)]
        [Deprecated(PlatformName.iOS, 10, 0)]
        [Export("action")]
        string Action { get; set; }

        // @property (copy, nonatomic) NSString * _Nonnull categoryIdentifier;
        [Export("categoryIdentifier")]
        string CategoryIdentifier { get; set; }

        // @property (copy, nonatomic) NSDictionary * _Nonnull userInfo;
        [Export("userInfo", ArgumentSemantic.Copy)]
        NSDictionary UserInfo { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable sound;
        [NullAllowed, Export("sound")]
        string Sound { get; set; }

        // @property (copy, nonatomic) NS_AVAILABLE_IOS(10.0) JPushNotificationSound * soundSetting __attribute__((availability(ios, introduced=10.0)));
        //[iOS(10, 0)]
        [Export("soundSetting", ArgumentSemantic.Copy)]
        JPushNotificationSound SoundSetting { get; set; }

        // @property (copy, nonatomic) NS_AVAILABLE_IOS(10_0) NSArray * attachments __attribute__((availability(ios, introduced=10.0)));
        //[iOS(10, 0)]
        [Export("attachments", ArgumentSemantic.Copy)]
        //[Verify(StronglyTypedNSArray)]
        NSObject[] Attachments { get; set; }

        // @property (copy, nonatomic) NS_AVAILABLE_IOS(10_0) NSString * threadIdentifier __attribute__((availability(ios, introduced=10.0)));
        //[iOS(10, 0)]
        [Export("threadIdentifier")]
        string ThreadIdentifier { get; set; }

        // @property (copy, nonatomic) NS_AVAILABLE_IOS(10_0) NSString * launchImageName __attribute__((availability(ios, introduced=10.0)));
        //[iOS(10, 0)]
        [Export("launchImageName")]
        string LaunchImageName { get; set; }

        // @property (copy, nonatomic) NS_AVAILABLE_IOS(12.0) NSString * summaryArgument __attribute__((availability(ios, introduced=12.0)));
        //[iOS(12, 0)]
        [Export("summaryArgument")]
        string SummaryArgument { get; set; }

        // @property (assign, nonatomic) NSUInteger summaryArgumentCount __attribute__((availability(ios, introduced=12.0)));
        //[iOS(12, 0)]
        [Export("summaryArgumentCount")]
        nuint SummaryArgumentCount { get; set; }

        // @property (copy, nonatomic) NS_AVAILABLE_IOS(13.0) NSString * targetContentIdentifier __attribute__((availability(ios, introduced=13.0)));
        //[iOS(13, 0)]
        [Export("targetContentIdentifier")]
        string TargetContentIdentifier { get; set; }

        // @property (assign, nonatomic) NSUInteger interruptionLevel __attribute__((availability(ios, introduced=15.0)));
        //[iOS(15, 0)]
        [Export("interruptionLevel")]
        nuint InterruptionLevel { get; set; }

        // @property (assign, nonatomic) double relevanceScore __attribute__((availability(ios, introduced=15.0)));
        //[iOS(15, 0)]
        [Export("relevanceScore")]
        double RelevanceScore { get; set; }

        // @property (copy, nonatomic) NS_AVAILABLE_IOS(16.0) NSString * filterCriteria __attribute__((availability(ios, introduced=16.0)));
        //[iOS(16, 0)]
        [Export("filterCriteria")]
        string FilterCriteria { get; set; }
    }

    // @interface JPushNotificationTrigger : NSObject <NSCopying, NSCoding>
    [BaseType(typeof(NSObject))]
    interface JPushNotificationTrigger : INSCopying, INSCoding
    {
        // @property (assign, nonatomic) BOOL repeat;
        [Export("repeat")]
        bool Repeat { get; set; }

        // @property (copy, nonatomic) NS_DEPRECATED_IOS(2_0, 10_0) NSDate * fireDate __attribute__((availability(ios, introduced=2.0, deprecated=10.0)));
        [Introduced(PlatformName.iOS, 2, 0)]
        [Deprecated(PlatformName.iOS, 10, 0)]
        [Export("fireDate", ArgumentSemantic.Copy)]
        NSDate FireDate { get; set; }

        // @property (copy, nonatomic) NS_AVAILABLE_IOS(8_0) CLRegion * region __attribute__((availability(ios, introduced=8.0)));
        //[iOS(8, 0)]
        [Export("region", ArgumentSemantic.Copy)]
        CLRegion Region { get; set; }

        // @property (copy, nonatomic) NS_AVAILABLE_IOS(10_0) NSDateComponents * dateComponents __attribute__((availability(ios, introduced=10.0)));
        //[iOS(10, 0)]
        [Export("dateComponents", ArgumentSemantic.Copy)]
        NSDateComponents DateComponents { get; set; }

        // @property (assign, nonatomic) NSTimeInterval timeInterval __attribute__((availability(ios, introduced=10.0)));
        //[iOS(10, 0)]
        [Export("timeInterval")]
        double TimeInterval { get; set; }
    }

    // @interface JPushNotificationRequest : NSObject <NSCopying, NSCoding>
    [BaseType(typeof(NSObject))]
    interface JPushNotificationRequest : INSCopying, INSCoding
    {
        // @property (copy, nonatomic) NSString * _Nonnull requestIdentifier;
        [Export("requestIdentifier")]
        string RequestIdentifier { get; set; }

        // @property (copy, nonatomic) JPushNotificationContent * _Nonnull content;
        [Export("content", ArgumentSemantic.Copy)]
        JPushNotificationContent Content { get; set; }

        // @property (copy, nonatomic) JPushNotificationTrigger * _Nonnull trigger;
        [Export("trigger", ArgumentSemantic.Copy)]
        JPushNotificationTrigger Trigger { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(id _Nonnull) completionHandler;
        [NullAllowed, Export("completionHandler", ArgumentSemantic.Copy)]
        Action<NSObject> CompletionHandler { get; set; }
    }

    // @interface JPushInAppMessage : NSObject
    [BaseType(typeof(NSObject))]
    interface JPushInAppMessage
    {
        // @property (copy, nonatomic) NSString * _Nonnull mesageId;
        [Export("mesageId")]
        string MesageId { get; set; }

        // @property (copy, nonatomic) NSString * _Nonnull title;
        [Export("title")]
        string Title { get; set; }

        // @property (copy, nonatomic) NSString * _Nonnull content;
        [Export("content")]
        string Content { get; set; }

        // @property (nonatomic, strong) NSArray * _Nonnull target;
        [Export("target", ArgumentSemantic.Strong)]
        //[Verify(StronglyTypedNSArray)]
        NSObject[] Target { get; set; }

        // @property (copy, nonatomic) NSString * _Nonnull clickAction;
        [Export("clickAction")]
        string ClickAction { get; set; }

        // @property (nonatomic, strong) NSDictionary * _Nonnull extras;
        [Export("extras", ArgumentSemantic.Strong)]
        NSDictionary Extras { get; set; }
    }

    // @interface JPUSHService : NSObject
    [BaseType(typeof(NSObject))]
    interface JPUSHService
    {
        // +(void)setupWithOption:(NSDictionary * _Nullable)launchingOption appKey:(NSString * _Nonnull)appKey channel:(NSString * _Nullable)channel apsForProduction:(BOOL)isProduction;
        [Static]
        [Export("setupWithOption:appKey:channel:apsForProduction:")]
        void SetupWithOption([NullAllowed] NSDictionary launchingOption, string appKey, [NullAllowed] string channel, bool isProduction);

        // +(void)setupWithOption:(NSDictionary * _Nullable)launchingOption appKey:(NSString * _Nonnull)appKey channel:(NSString * _Nullable)channel apsForProduction:(BOOL)isProduction advertisingIdentifier:(NSString * _Nullable)advertisingId;
        [Static]
        [Export("setupWithOption:appKey:channel:apsForProduction:advertisingIdentifier:")]
        void SetupWithOption([NullAllowed] NSDictionary launchingOption, string appKey, [NullAllowed] string channel, bool isProduction, [NullAllowed] string advertisingId);

        // +(void)registerForRemoteNotificationTypes:(NSUInteger)types categories:(NSSet * _Nullable)categories;
        [Static]
        [Export("registerForRemoteNotificationTypes:categories:")]
        void RegisterForRemoteNotificationTypes(nuint types, [NullAllowed] NSSet categories);

        // +(void)registerForRemoteNotificationConfig:(JPUSHRegisterEntity * _Nonnull)config delegate:(id<JPUSHRegisterDelegate> _Nullable)delegate;
        [Static]
        [Export("registerForRemoteNotificationConfig:delegate:")]
        void RegisterForRemoteNotificationConfig(JPUSHRegisterEntity config, [NullAllowed] JPUSHRegisterDelegate @delegate);

        // +(void)registerDeviceToken:(NSData * _Nonnull)deviceToken;
        [Static]
        [Export("registerDeviceToken:")]
        void RegisterDeviceToken(NSData deviceToken);

        // +(void)registerLiveActivity:(NSString * _Nonnull)liveActivityId pushToken:(NSData * _Nullable)pushToken completion:(JPUSHLiveActivityTokenCompletion _Nullable)completion seq:(NSInteger)seq;
        [Static]
        [Export("registerLiveActivity:pushToken:completion:seq:")]
        void RegisterLiveActivity(string liveActivityId, [NullAllowed] NSData pushToken, [NullAllowed] JPUSHLiveActivityTokenCompletion completion, nint seq);

        // +(void)handleRemoteNotification:(NSDictionary * _Nonnull)remoteInfo;
        [Static]
        [Export("handleRemoteNotification:")]
        void HandleRemoteNotification(NSDictionary remoteInfo);

        // +(void)registerVoipToken:(NSData * _Nonnull)voipToken;
        [Static]
        [Export("registerVoipToken:")]
        void RegisterVoipToken(NSData voipToken);

        // +(void)handleVoipNotification:(NSDictionary * _Nonnull)remoteInfo;
        [Static]
        [Export("handleVoipNotification:")]
        void HandleVoipNotification(NSDictionary remoteInfo);

        // +(void)requestNotificationAuthorization:(void (^ _Nullable)(JPAuthorizationStatus))completion;
        [Static]
        [Export("requestNotificationAuthorization:")]
        void RequestNotificationAuthorization([NullAllowed] Action<JPAuthorizationStatus> completion);

        // +(void)openSettingsForNotification:(void (^ _Nullable)(BOOL))completionHandler __attribute__((availability(ios, introduced=8.0)));
        //[iOS(8, 0)]
        [Static]
        [Export("openSettingsForNotification:")]
        void OpenSettingsForNotification([NullAllowed] Action<bool> completionHandler);

        // +(void)addTags:(NSSet<NSString *> * _Nonnull)tags completion:(JPUSHTagsOperationCompletion _Nullable)completion seq:(NSInteger)seq;
        [Static]
        [Export("addTags:completion:seq:")]
        void AddTags(NSSet<NSString> tags, [NullAllowed] JPUSHTagsOperationCompletion completion, nint seq);

        // +(void)setTags:(NSSet<NSString *> * _Nonnull)tags completion:(JPUSHTagsOperationCompletion _Nullable)completion seq:(NSInteger)seq;
        [Static]
        [Export("setTags:completion:seq:")]
        void SetTags(NSSet<NSString> tags, [NullAllowed] JPUSHTagsOperationCompletion completion, nint seq);

        // +(void)deleteTags:(NSSet<NSString *> * _Nonnull)tags completion:(JPUSHTagsOperationCompletion _Nullable)completion seq:(NSInteger)seq;
        [Static]
        [Export("deleteTags:completion:seq:")]
        void DeleteTags(NSSet<NSString> tags, [NullAllowed] JPUSHTagsOperationCompletion completion, nint seq);

        // +(void)cleanTags:(JPUSHTagsOperationCompletion _Nullable)completion seq:(NSInteger)seq;
        [Static]
        [Export("cleanTags:seq:")]
        void CleanTags([NullAllowed] JPUSHTagsOperationCompletion completion, nint seq);

        // +(void)getAllTags:(JPUSHTagsOperationCompletion _Nullable)completion seq:(NSInteger)seq;
        [Static]
        [Export("getAllTags:seq:")]
        void GetAllTags([NullAllowed] JPUSHTagsOperationCompletion completion, nint seq);

        // +(void)validTag:(NSString * _Nonnull)tag completion:(JPUSHTagValidOperationCompletion _Nullable)completion seq:(NSInteger)seq;
        [Static]
        [Export("validTag:completion:seq:")]
        void ValidTag(string tag, [NullAllowed] JPUSHTagValidOperationCompletion completion, nint seq);

        // +(void)setAlias:(NSString * _Nonnull)alias completion:(JPUSHAliasOperationCompletion _Nullable)completion seq:(NSInteger)seq;
        [Static]
        [Export("setAlias:completion:seq:")]
        void SetAlias(string alias, [NullAllowed] JPUSHAliasOperationCompletion completion, nint seq);

        // +(void)deleteAlias:(JPUSHAliasOperationCompletion _Nullable)completion seq:(NSInteger)seq;
        [Static]
        [Export("deleteAlias:seq:")]
        void DeleteAlias([NullAllowed] JPUSHAliasOperationCompletion completion, nint seq);

        // +(void)getAlias:(JPUSHAliasOperationCompletion _Nullable)completion seq:(NSInteger)seq;
        [Static]
        [Export("getAlias:seq:")]
        void GetAlias([NullAllowed] JPUSHAliasOperationCompletion completion, nint seq);

        // +(NSSet * _Nonnull)filterValidTags:(NSSet * _Nonnull)tags;
        [Static]
        [Export("filterValidTags:")]
        NSSet FilterValidTags(NSSet tags);

        // +(void)setProperties:(NSDictionary * _Nonnull)properties completion:(JPUSHPropertiesOperationCompletion _Nullable)completion seq:(NSInteger)seq;
        [Static]
        [Export("setProperties:completion:seq:")]
        void SetProperties(NSDictionary properties, [NullAllowed] JPUSHPropertiesOperationCompletion completion, nint seq);

        // +(void)deleteProperties:(NSSet<NSString *> * _Nonnull)keys completion:(JPUSHPropertiesOperationCompletion _Nullable)completion seq:(NSInteger)seq;
        [Static]
        [Export("deleteProperties:completion:seq:")]
        void DeleteProperties(NSSet<NSString> keys, [NullAllowed] JPUSHPropertiesOperationCompletion completion, nint seq);

        // +(void)cleanProperties:(JPUSHPropertiesOperationCompletion _Nullable)completion seq:(NSInteger)seq;
        [Static]
        [Export("cleanProperties:seq:")]
        void CleanProperties([NullAllowed] JPUSHPropertiesOperationCompletion completion, nint seq);

        // +(void)pageEnterTo:(NSString * _Nonnull)pageName;
        [Static]
        [Export("pageEnterTo:")]
        void PageEnterTo(string pageName);

        // +(void)pageLeave:(NSString * _Nonnull)pageName;
        [Static]
        [Export("pageLeave:")]
        void PageLeave(string pageName);

        // +(void)setInAppMessageDelegate:(id<JPUSHInAppMessageDelegate> _Nonnull)inAppMessageDelegate;
        [Static]
        [Export("setInAppMessageDelegate:")]
        void SetInAppMessageDelegate(JPUSHInAppMessageDelegate inAppMessageDelegate);

        // +(void)startLogPageView:(NSString * _Nonnull)pageName __attribute__((deprecated("JCore 1.1.8 版本已过期")));
        [Static]
        [Export("startLogPageView:")]
        void StartLogPageView(string pageName);

        // +(void)stopLogPageView:(NSString * _Nonnull)pageName __attribute__((deprecated("JCore 1.1.8 版本已过期")));
        [Static]
        [Export("stopLogPageView:")]
        void StopLogPageView(string pageName);

        // +(void)beginLogPageView:(NSString * _Nonnull)pageName duration:(int)seconds __attribute__((deprecated("JCore 1.1.8 版本已过期")));
        [Static]
        [Export("beginLogPageView:duration:")]
        void BeginLogPageView(string pageName, int seconds);

        // +(void)crashLogON;
        [Static]
        [Export("crashLogON")]
        void CrashLogON();

        // +(void)setLatitude:(double)latitude longitude:(double)longitude;
        [Static]
        [Export("setLatitude:longitude:")]
        void SetLatitude(double latitude, double longitude);

        // +(void)setLocation:(CLLocation * _Nonnull)location;
        [Static]
        [Export("setLocation:")]
        void SetLocation(CLLocation location);

        // +(void)setGeofeneceMaxCount:(NSInteger)count;
        [Static]
        [Export("setGeofeneceMaxCount:")]
        void SetGeofeneceMaxCount(nint count);

        // +(void)setGeofenecePeriodForInside:(NSInteger)seconds;
        [Static]
        [Export("setGeofenecePeriodForInside:")]
        void SetGeofenecePeriodForInside(nint seconds);

        // +(void)registerLbsGeofenceDelegate:(id<JPUSHGeofenceDelegate> _Nonnull)delegate withLaunchOptions:(NSDictionary * _Nullable)launchOptions;
        [Static]
        [Export("registerLbsGeofenceDelegate:withLaunchOptions:")]
        void RegisterLbsGeofenceDelegate(JPUSHGeofenceDelegate @delegate, [NullAllowed] NSDictionary launchOptions);

        // +(void)removeGeofenceWithIdentifier:(NSString * _Nonnull)geofenceId;
        [Static]
        [Export("removeGeofenceWithIdentifier:")]
        void RemoveGeofenceWithIdentifier(string geofenceId);

        // +(void)addNotification:(JPushNotificationRequest * _Nonnull)request;
        [Static]
        [Export("addNotification:")]
        void AddNotification(JPushNotificationRequest request);

        // +(void)removeNotification:(JPushNotificationIdentifier * _Nullable)identifier;
        [Static]
        [Export("removeNotification:")]
        void RemoveNotification([NullAllowed] JPushNotificationIdentifier identifier);

        // +(void)findNotification:(JPushNotificationIdentifier * _Nonnull)identifier;
        [Static]
        [Export("findNotification:")]
        void FindNotification(JPushNotificationIdentifier identifier);

        // +(UILocalNotification * _Nonnull)setLocalNotification:(NSDate * _Nonnull)fireDate alertBody:(NSString * _Nonnull)alertBody badge:(int)badge alertAction:(NSString * _Nonnull)alertAction identifierKey:(NSString * _Nonnull)notificationKey userInfo:(NSDictionary * _Nonnull)userInfo soundName:(NSString * _Nonnull)soundName __attribute__((deprecated("JPush 2.1.9 版本已过期")));
        [Static]
        [Export("setLocalNotification:alertBody:badge:alertAction:identifierKey:userInfo:soundName:")]
        UILocalNotification SetLocalNotification(NSDate fireDate, string alertBody, int badge, string alertAction, string notificationKey, NSDictionary userInfo, string soundName);

        // +(UILocalNotification * _Nonnull)setLocalNotification:(NSDate * _Nonnull)fireDate alertBody:(NSString * _Nonnull)alertBody badge:(int)badge alertAction:(NSString * _Nonnull)alertAction identifierKey:(NSString * _Nonnull)notificationKey userInfo:(NSDictionary * _Nonnull)userInfo soundName:(NSString * _Nonnull)soundName region:(CLRegion * _Nonnull)region regionTriggersOnce:(BOOL)regionTriggersOnce category:(NSString * _Nonnull)category __attribute__((availability(ios, introduced=8.0))) __attribute__((deprecated("JPush 2.1.9 版本已过期")));
        //[iOS(8, 0)]
        [Static]
        [Export("setLocalNotification:alertBody:badge:alertAction:identifierKey:userInfo:soundName:region:regionTriggersOnce:category:")]
        UILocalNotification SetLocalNotification(NSDate fireDate, string alertBody, int badge, string alertAction, string notificationKey, NSDictionary userInfo, string soundName, CLRegion region, bool regionTriggersOnce, string category);

        // +(void)showLocalNotificationAtFront:(UILocalNotification * _Nonnull)notification identifierKey:(NSString * _Nonnull)notificationKey __attribute__((deprecated("JPush 2.1.9 版本已过期")));
        [Static]
        [Export("showLocalNotificationAtFront:identifierKey:")]
        void ShowLocalNotificationAtFront(UILocalNotification notification, string notificationKey);

        // +(void)deleteLocalNotificationWithIdentifierKey:(NSString * _Nonnull)notificationKey __attribute__((deprecated("JPush 2.1.9 版本已过期")));
        [Static]
        [Export("deleteLocalNotificationWithIdentifierKey:")]
        void DeleteLocalNotificationWithIdentifierKey(string notificationKey);

        // +(void)deleteLocalNotification:(UILocalNotification * _Nonnull)localNotification __attribute__((deprecated("JPush 2.1.9 版本已过期")));
        [Static]
        [Export("deleteLocalNotification:")]
        void DeleteLocalNotification(UILocalNotification localNotification);

        // +(NSArray * _Nonnull)findLocalNotificationWithIdentifier:(NSString * _Nonnull)notificationKey __attribute__((deprecated("JPush 2.1.9 版本已过期")));
        [Static]
        [Export("findLocalNotificationWithIdentifier:")]
        //[Verify(StronglyTypedNSArray)]
        NSObject[] FindLocalNotificationWithIdentifier(string notificationKey);

        // +(void)clearAllLocalNotifications __attribute__((deprecated("JPush 2.1.9 版本已过期")));
        [Static]
        [Export("clearAllLocalNotifications")]
        void ClearAllLocalNotifications();

        // +(BOOL)setBadge:(NSInteger)value;
        [Static]
        [Export("setBadge:")]
        bool SetBadge(nint value);

        // +(void)resetBadge;
        [Static]
        [Export("resetBadge")]
        void ResetBadge();

        // +(void)setMobileNumber:(NSString * _Nonnull)mobileNumber completion:(void (^ _Nullable)(NSError * _Nonnull))completion;
        [Static]
        [Export("setMobileNumber:completion:")]
        void SetMobileNumber(string mobileNumber, [NullAllowed] Action<NSError> completion);

        // +(NSString * _Nonnull)registrationID;
        [Static]
        [Export("registrationID")]
        //[Verify(MethodToProperty)]
        string RegistrationID { get; }

        // +(void)registrationIDCompletionHandler:(void (^ _Nonnull)(int, NSString * _Nullable))completionHandler;
        [Static]
        [Export("registrationIDCompletionHandler:")]
        void RegistrationIDCompletionHandler(Action<int, NSString> completionHandler);

        // +(void)setDebugMode;
        [Static]
        [Export("setDebugMode")]
        void SetDebugMode();

        // +(void)setLogOFF;
        [Static]
        [Export("setLogOFF")]
        void SetLogOFF();

        // +(void)setLocationEanable:(BOOL)isEanble;
        [Static]
        [Export("setLocationEanable:")]
        void SetLocationEanable(bool isEanble);

        // +(void)setPushEnable:(BOOL)isEnable completion:(void (^ _Nullable)(NSInteger))completion;
        [Static]
        [Export("setPushEnable:completion:")]
        void SetPushEnable(bool isEnable, [NullAllowed] Action<nint> completion);

        // +(void)setNotiInMessageDelegate:(id<JPUSHNotiInMessageDelegate> _Nonnull)notiInMessageDelegate;
        [Static]
        [Export("setNotiInMessageDelegate:")]
        void SetNotiInMessageDelegate(JPUSHNotiInMessageDelegate notiInMessageDelegate);

        // +(void)setTags:(NSSet * _Nonnull)tags alias:(NSString * _Nonnull)alias callbackSelector:(SEL _Nonnull)cbSelector target:(id _Nonnull)theTarget __attribute__((deprecated("JPush 2.1.1 版本已过期")));
        //[Static]
        //[Export("setTags:alias:callbackSelector:target:")]
        //void SetTags(NSSet tags, string alias, Selector cbSelector, NSObject theTarget);

        // +(void)setTags:(NSSet * _Nonnull)tags alias:(NSString * _Nonnull)alias callbackSelector:(SEL _Nonnull)cbSelector object:(id _Nonnull)theTarget __attribute__((deprecated("JPush 3.0.6 版本已过期")));
        //[Static]
        //[Export("setTags:alias:callbackSelector:object:")]
        //void SetTags(NSSet tags, string alias, Selector cbSelector, NSObject theTarget);

        // +(void)setTags:(NSSet * _Nonnull)tags callbackSelector:(SEL _Nonnull)cbSelector object:(id _Nonnull)theTarget __attribute__((deprecated("JPush 3.0.6 版本已过期")));
        [Static]
        [Export("setTags:callbackSelector:object:")]
        void SetTags(NSSet tags, Selector cbSelector, NSObject theTarget);

        // +(void)setTags:(NSSet * _Nonnull)tags alias:(NSString * _Nonnull)alias fetchCompletionHandle:(void (^ _Nonnull)(int, NSSet * _Nonnull, NSString * _Nonnull))completionHandler __attribute__((deprecated("JPush 3.0.6 版本已过期")));
        [Static]
        [Export("setTags:alias:fetchCompletionHandle:")]
        void SetTags(NSSet tags, string alias, Action<int, NSSet, NSString> completionHandler);

        // +(void)setTags:(NSSet * _Nonnull)tags aliasInbackground:(NSString * _Nonnull)alias __attribute__((deprecated("JPush 3.0.6 版本已过期")));
        [Static]
        [Export("setTags:aliasInbackground:")]
        void SetTags(NSSet tags, string alias);

        // +(void)setAlias:(NSString * _Nonnull)alias callbackSelector:(SEL _Nonnull)cbSelector object:(id _Nonnull)theTarget __attribute__((deprecated("JPush 3.0.6 版本已过期")));
        [Static]
        [Export("setAlias:callbackSelector:object:")]
        void SetAlias(string alias, Selector cbSelector, NSObject theTarget);
    }

    // @protocol JPUSHRegisterDelegate <NSObject>
    //[Protocol, Model(AutoGeneratedName = true)]
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface JPUSHRegisterDelegate
    {
        // @required -(void)jpushNotificationCenter:(UNUserNotificationCenter * _Nonnull)center willPresentNotification:(UNNotification * _Nonnull)notification withCompletionHandler:(void (^ _Nonnull)(NSInteger))completionHandler;
        [Abstract]
        [Export("jpushNotificationCenter:willPresentNotification:withCompletionHandler:")]
        void JpushNotificationCenter(UNUserNotificationCenter center, UNNotification notification, Action<int> completionHandler);

        // @required -(void)jpushNotificationCenter:(UNUserNotificationCenter * _Nonnull)center didReceiveNotificationResponse:(UNNotificationResponse * _Nonnull)response withCompletionHandler:(void (^ _Nonnull)(void))completionHandler;
        [Abstract]
        [Export("jpushNotificationCenter:didReceiveNotificationResponse:withCompletionHandler:")]
        void JpushNotificationCenter(UNUserNotificationCenter center, UNNotificationResponse response, Action completionHandler);

        // @required -(void)jpushNotificationCenter:(UNUserNotificationCenter * _Nonnull)center openSettingsForNotification:(UNNotification * _Nonnull)notification __attribute__((availability(ios, introduced=12.0)));
        //[iOS(12, 0)]
        [Abstract]
        [Export("jpushNotificationCenter:openSettingsForNotification:")]
        void JpushNotificationCenter(UNUserNotificationCenter center, UNNotification notification);

        // @required -(void)jpushNotificationAuthorization:(JPAuthorizationStatus)status withInfo:(NSDictionary * _Nullable)info;
        [Abstract]
        [Export("jpushNotificationAuthorization:withInfo:")]
        void JpushNotificationAuthorization(JPAuthorizationStatus status, [NullAllowed] NSDictionary info);
    }

    // @protocol JPUSHGeofenceDelegate <NSObject>
    //[Protocol, Model(AutoGeneratedName = true)]
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface JPUSHGeofenceDelegate
    {
        // @required -(void)jpushGeofenceRegion:(NSDictionary * _Nullable)geofence error:(NSError * _Nullable)error;
        [Abstract]
        [Export("jpushGeofenceRegion:error:")]
        void JpushGeofenceRegion([NullAllowed] NSDictionary geofence, [NullAllowed] NSError error);

        // @required -(void)jpushCallbackGeofenceReceived:(NSArray<NSDictionary *> * _Nullable)geofenceList;
        [Abstract]
        [Export("jpushCallbackGeofenceReceived:")]
        void JpushCallbackGeofenceReceived([NullAllowed] NSDictionary[] geofenceList);

        // @required -(void)jpushGeofenceIdentifer:(NSString * _Nonnull)geofenceId didEnterRegion:(NSDictionary * _Nullable)userInfo error:(NSError * _Nullable)error __attribute__((deprecated("JPush 3.6.0 版本已过期")));
        [Abstract]
        [Export("jpushGeofenceIdentifer:didEnterRegion:error:")]
        void DidEnterJpushGeofenceIdentifer(string geofenceId, [NullAllowed] NSDictionary userInfo, [NullAllowed] NSError error);

        // @required -(void)jpushGeofenceIdentifer:(NSString * _Nonnull)geofenceId didExitRegion:(NSDictionary * _Nullable)userInfo error:(NSError * _Nullable)error __attribute__((deprecated("JPush 3.6.0 版本已过期")));
        [Abstract]
        [Export("jpushGeofenceIdentifer:didExitRegion:error:")]
        void DidExitJpushGeofenceIdentifer(string geofenceId, [NullAllowed] NSDictionary userInfo, [NullAllowed] NSError error);
    }

    // @protocol JPUSHNotiInMessageDelegate <NSObject>
    //[Protocol, Model(AutoGeneratedName = true)]
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface JPUSHNotiInMessageDelegate
    {
        // @required -(void)jPushNotiInMessageDidShowWithContent:(NSDictionary * _Nonnull)content;
        [Abstract]
        [Export("jPushNotiInMessageDidShowWithContent:")]
        void JPushNotiInMessageDidShowWithContent(NSDictionary content);

        // @required -(void)jPushNotiInMessageDidClickWithContent:(NSDictionary * _Nonnull)content;
        [Abstract]
        [Export("jPushNotiInMessageDidClickWithContent:")]
        void JPushNotiInMessageDidClickWithContent(NSDictionary content);
    }

    // @protocol JPUSHInAppMessageDelegate <NSObject>
    //[Protocol, Model(AutoGeneratedName = true)]
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface JPUSHInAppMessageDelegate
    {
        // @required -(void)jPushInAppMessageDidShow:(JPushInAppMessage * _Nonnull)inAppMessage;
        [Abstract]
        [Export("jPushInAppMessageDidShow:")]
        void JPushInAppMessageDidShow(JPushInAppMessage inAppMessage);

        // @required -(void)jPushInAppMessageDidClick:(JPushInAppMessage * _Nonnull)inAppMessage;
        [Abstract]
        [Export("jPushInAppMessageDidClick:")]
        void JPushInAppMessageDidClick(JPushInAppMessage inAppMessage);
    }
}

