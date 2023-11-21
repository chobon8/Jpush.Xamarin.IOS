using System;
using ObjCRuntime;

namespace Jpush.Xamarin.IOS {
    [Flags]
    [Native]
    public enum JPAuthorizationOptions : ulong
    {
        None = 0x0,
        Badge = (1uL << 0),
        Sound = (1uL << 1),
        Alert = (1uL << 2),
        CarPlay = (1uL << 3),
        CriticalAlert = (1uL << 4),
        ProvidesAppNotificationSettings = (1uL << 5),
        Provisional = (1uL << 6),
        Announcement = (1uL << 7)
    }

    [Native]
    public enum JPAuthorizationStatus : ulong
    {
        NotDetermined = 0,
        StatusDenied,
        StatusAuthorized,
        StatusProvisional
    }
}