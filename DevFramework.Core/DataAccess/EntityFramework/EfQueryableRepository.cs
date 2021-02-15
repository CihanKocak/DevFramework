using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.DataAccess.EntityFramework
{
    public class EfQueryableRepository<T> : IQueryableRepository<T> where T : class, IEntity, new()
    {
        private DbContext _context; // Bize burda bir tane context lazım olduğu için Dependecy injection ile enjekte ettik

        private IDbSet<T> _entities;
        // Aşağıdaki Table aslında bir DbSet'e karşılık gelir.Dolayısıyla biz bu şekilde attach oluruz.Ben bir _entities
        //diyerekten,yani hangi T,örneğin Customer yada Product T'sini gönderdiğimde aslında ordaki DbSet'e,
        //DbSet Customer veya DbSet Product'a abone oluyor olacağım.
        public EfQueryableRepository(DbContext context)
        //Bunu initialize ettik constructor'dan.Yani bu EfQueryableRepository'i kullanan kişiye bir tane context veriyor
        //olacağım.Bu da benim iş katmanımın herhangi bir projeye bağımlı olmasını da engelleyecek.Yani NorthwindContext
        //değil de başka bir projede abc context gibi gönderebiliyor olacağım.
        {
            _context = context;
        }

        //Bir tabloya abone olup o tablo üzerinde queryable yapmamızı sağlayacak.O yüzden ben hangi T nesneyi verirsem
        //onunla ilgili tabloya kendisini attach edecek şekilde bir implementasyon gerçekleştiriyor 

        public IQueryable<T> Table => this.Entities;
        //Burda Table _entities döndürecek ama _entities şuan için boş.O yüzden onu burda çağırarak implemente etmem
        //lazım.Onu da başka sınıflar kullanamasın diye,EfQueryableRepository'i new'leyen birisi çağıramasın diye onu 
        // protected yapıyorum.Virtual da zaten bütün Orm'lerde hemen hemen işte bu Lazy Loading vesaire yapabilmek için
        //gerekli olan imza oluyor.

        protected virtual IDbSet<T> Entities
        {
            get { return _entities ?? (_entities = _context.Set<T>()); }//Aşağıdaki kodun daha temiz hali bu kod!

            //get
            //{
            //    if (_entities == null) 
            //    // Arka arkaya çağırdığında ilk çağırdığında null ama ikinci çağırdığında yine aynısını kullansın diye
            //    {
            //        _entities = _context.Set<T>();
            //        //Context'deki atıyorum Customer'a yada Product'a abone ol dememiz gerekiyor.
            //    }
            //    return _entities;
            //    //Aksi takdirde atıyorum arka arkaya çağırdıysa queryable'ı,yine aynı tabloyu döndürsün.Yani ben bu tablo
            //    //üzerinde sorguya devam ediyorum şeklinde onu çağırabileyim
            //}
        }
    }
}
