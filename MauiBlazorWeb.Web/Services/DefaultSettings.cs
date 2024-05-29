using MauiBlazorWeb.Shared.Interfaces;

namespace MauiBlazorWeb.Web.Services
{
    public class DefaultSettings : IDefaultSettings
    {
        public int GetDefaultSilentInterval()
        {
            return 5;
        }
    }
}
