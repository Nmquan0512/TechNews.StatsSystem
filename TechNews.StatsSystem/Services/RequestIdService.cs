using System;

namespace TechNews.StatsSystem.Services
{
	public class RequestIdService : IRequestIdService
	{
		private readonly Guid _id;

		public RequestIdService()
		{
			_id = Guid.NewGuid();
		}

		public Guid GetRequestId() => _id;
	}
}
