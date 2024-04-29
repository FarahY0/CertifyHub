using CertifyHub.Core.Data;
using CertifyHub.Core.Service;
using CertifyHub.Infra.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CertifyHub.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	
	public class NotificationController : ControllerBase
	{
		private readonly INotificationService notificationService;
		public NotificationController(INotificationService notificationService)
		{
			this.notificationService = notificationService;
		}

		[HttpGet]
        //[CheckClaims("RoleId", "2")]
        [Route("GetNotificationsBySectionId/{sectionId}")]
      
        public List<Notification> GetNotificationsBySectionId(int sectionId)
		{
			return notificationService.GetNotificationsBySectionId(sectionId);
		}
		[HttpPost]
        //[CheckClaims("RoleId", "2")]
        [Route("CreateNotification")]
        
        public void CreateNotification(Notification notification)
		{
			notificationService.CreateNotification(notification);
		}

		[HttpPut]
        //[CheckClaims("RoleId", "2")]
        [Route("UpdateNotification")]

        public void UpdateNotification(Notification notification)
		{
			notificationService.UpdateNotification(notification);
		}
		[HttpDelete]
        //[CheckClaims("RoleId", "2")]
        [Route("DeleteNotification/{NotificationId}")]
		public void DeleteNotification(int NotificationId)
		{
			notificationService.DeleteNotification(NotificationId);
		}

	}
}
