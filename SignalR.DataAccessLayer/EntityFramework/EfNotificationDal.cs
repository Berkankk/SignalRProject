using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfNotificationDal : GenericRepository<Notification>, INotificationDal
    {
        public EfNotificationDal(SignalRContext context) : base(context)
        {
        }

        public List<Notification> GetAllNotificationByFalse()
        {
            var context = new SignalRContext();
            return context.Notifications.Where(x => x.Status == false).ToList();
        }

        public void NotificationChangeToFalse(int id)
        {
            var context = new SignalRContext();
            var value = context.Notifications.Find(id);
            value.Status = false;
            context.SaveChanges();
        }

        public void NotificationChangeToTrue(int id)
        {
            var context = new SignalRContext();
            var value = context.Notifications.Find(id);
            value.Status = true;
            context.SaveChanges();
        }

        public int NotificationCountByStatusFalse()
        {
            var context = new SignalRContext();
            return context.Notifications.Where(x => x.Status == false).Count();
        }
    }
}
