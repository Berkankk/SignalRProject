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
    public class EfAboutDal : GenericRepository<About>, IAboutDal
    {
        //Generic repositoryden about için miras al oradaki crud işlemlerini about için uygula ve ıaboutdal ı da miras al çünkü about için özel metot tanımlarsak onu burada implemente edeceğiz
        public EfAboutDal(SignalRContext context) : base(context)
        {
            //Bunu da geçmemizin sebebi context sınıfında signalrContext i constructor geçtik diye yazdık bunu 
        }
    }
}
