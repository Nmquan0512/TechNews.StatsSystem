using System;
using System.Threading;

namespace TechNews.StatsSystem.Services
{
	public class AppStatsService : IAppStatsService
	{
		private readonly Guid _instanceId;
		private int _counter = 0;

		public AppStatsService()
		{
			_instanceId = Guid.NewGuid();
		}

		public Guid GetAppInstanceId() => _instanceId;

		public int GetTotalVisits() => _counter;

		public void Increment()
		{
			Interlocked.Increment(ref _counter);
		}
	}
}
