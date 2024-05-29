using MauiBlazorWeb.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBlazor.Services
{
    public class DefaultSettings : IDefaultSettings
    {
        public int GetDefaultSilentInterval()
        {
            return 5;
        }
    }
}
