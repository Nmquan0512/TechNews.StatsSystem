using System;

namespace TechNews.StatsSystem.Services
{
	public class UserSessionService : IUserSessionService
	{
		private readonly Guid _sessionId;

		public UserSessionService()
		{
			_sessionId = Guid.NewGuid();
		}

		public Guid GetSessionId() => _sessionId;

		public string IP { get; set; }
		public string UserAgent { get; set; }
		public DateTime Time { get; set; }
	}
}
