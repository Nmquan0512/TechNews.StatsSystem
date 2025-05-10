using System;

namespace TechNews.StatsSystem.Services
{
    public interface IUserSessionService
    {
        Guid GetSessionId();
        string IP { get; set; }
        string UserAgent { get; set; }
        DateTime Time { get; set; }
    }
}
