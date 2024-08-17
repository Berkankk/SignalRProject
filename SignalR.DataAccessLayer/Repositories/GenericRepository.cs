using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        //Burası bana Crud işlemlerini tekrar tekrar yazmak yerine generic bir yapı üzerinde tutarak yazacağız.
        //GenericDal dan gelen interfaceleri implemente ettik burada

        private readonly SignalRContext _context;  //Yapıcı metot geçtik bağımlılıkları azaltacağız bu şekilde

        public GenericRepository(SignalRContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
           _context.Add(entity); //Entityden gelen değeri ekle
            _context.SaveChanges(); //Değişiklikleri kaydet
        }

        public void Delete(T entity)
        {
            _context.Remove(entity); //Entityden gelen değeri sil
            _context.SaveChanges(); //Değişiklikleri kaydet
        }

        public T GetById(int id)
        {
           return _context.Set<T>().Find(id);  // id den gelen değeri bul
        }

        public List<T> GetListAll()
        {
           return _context.Set<T>().ToList(); //Tüm verileri listele
        }

        public void Update(T entity)
        {
            _context.Update(entity); //entityden gelen değeri güncelle
            _context.SaveChanges();  //Değişiklikleri kaydet
        }
    }
}
