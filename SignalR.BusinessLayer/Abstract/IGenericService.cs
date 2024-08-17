using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class  //Business tarafı bunlar
    {
        //Igenericdal da olanlar ile karışmasın diye metotların başlarına T yazıyoruz

        void TAdd(T entity);

        void TDelete(T entity); //Silme  
        void TUpdate(T entity); //Güncelleme
        T TGetById(int id); //İd değerine göre getirme
        List<T> TGetListAll(); //Tüm verileri liste şeklinde getirme
    }
}
