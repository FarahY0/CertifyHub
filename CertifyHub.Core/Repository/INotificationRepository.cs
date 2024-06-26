﻿using CertifyHub.Core.Data;
using CertifyHub.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertifyHub.Core.Repository
{
	public interface INotificationRepository
	{
		public List<Notification> GetNotificationsBySectionId(int sectionId);
       
        public void CreateNotification(Notification notification);
		public void DeleteNotification(int NotificationId);
		public void UpdateNotification(Notification notification);
	}
}
