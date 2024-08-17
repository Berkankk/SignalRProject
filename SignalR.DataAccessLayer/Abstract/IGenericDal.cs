using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class  //Mutlaka bir class olmalı bu t değeri onu verdik
    {
        void Add(T entity);  //Ekleme
        void Delete(T entity); //Silme  
        void Update(T entity); //Güncelleme
        T GetById(int id); //İd değerine göre getirme
        List<T> GetListAll(); //Tüm verileri liste şeklinde getirme
    }
}
