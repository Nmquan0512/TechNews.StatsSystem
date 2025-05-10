namespace TechNews.StatsSystem.Services
{
	public interface IAppStatsService
	{
		Guid GetAppInstanceId();
		int GetTotalVisits();
		void Increment();
	}
}
