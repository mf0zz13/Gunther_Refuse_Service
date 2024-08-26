namespace GuntherRefuse
{
    public static class EntraIdConfig
    {
        public static string Authority = @"https://TrialTenantgsANnBEQ.claimlogin.com/";
        public static string ClientId = "27a8ce6c-a2c2-4a8a-bf19-623bcfa3701a";
        public static string[] Scopes = { "openid", "offline_access" };
        public static string IOSKeychainSecurityGroup = "com.microsoft.adalcache";
        public static object? ParentWIndow { get; set; }
    }
}
