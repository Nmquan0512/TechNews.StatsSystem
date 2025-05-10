using Microsoft.AspNetCore.Mvc;
using TechNews.StatsSystem.Services;
using Microsoft.AspNetCore.Http;

namespace TechNews.StatsSystem.Controllers
{
	[ApiController]
	[Route("api/stats")]
	public class StatsController : ControllerBase
	{
		private readonly IRequestIdService _requestIdService;
		private readonly IUserSessionService _userSessionService;
		private readonly IAppStatsService _appStatsService;

		public StatsController(
			IRequestIdService requestIdService,
			IUserSessionService userSessionService,
			IAppStatsService appStatsService)
		{
			_requestIdService = requestIdService;
			_userSessionService = userSessionService;
			_appStatsService = appStatsService;
		}

		[HttpGet("test-lifetime")]
		public IActionResult GetServiceIds()
		{
			_appStatsService.Increment();

			_userSessionService.IP = HttpContext.Connection.RemoteIpAddress?.ToString();
			_userSessionService.UserAgent = Request.Headers["User-Agent"];
			_userSessionService.Time = DateTime.Now;
			Console.WriteLine($"RequestId: {_requestIdService.GetRequestId()} | SessionId: {_userSessionService.GetSessionId()} | AppInstance: {_appStatsService.GetAppInstanceId()} | IP: {_userSessionService.IP}");


			return Ok(new
			{
				RequestId = _requestIdService.GetRequestId(),
				SessionId = _userSessionService.GetSessionId(),
				AppInstanceId = _appStatsService.GetAppInstanceId(),
				IP = _userSessionService.IP,
				UserAgent = _userSessionService.UserAgent,
				Time = _userSessionService.Time,
				TotalVisits = _appStatsService.GetTotalVisits(),
				Explanation = new
				{
					Transient = "RequestIdService được tạo mới mỗi lần gọi – luôn khác nhau.",
					Scoped = "UserSessionService được tạo mới cho mỗi HTTP request – giống nhau trong 1 request, khác ở request khác.",
					Singleton = "AppStatsService được tạo 1 lần duy nhất – giữ nguyên suốt vòng đời ứng dụng."
				}

			});

		}
	}
}
