using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IAboutDal : IGenericDal<About>
    { 
        //Sadece Abouta özgü bir şey olursa gelip burada tanımlayacağız böylelikle diğer entitilerimiz bundan etkilenmeyecek
    }
}
