using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null // Filtre boşsa
                    ? context.Set<TEntity>().ToList() // DbContext'e abone olup onu da listeye çevir
                    : context.Set<TEntity>().Where(filter).ToList();// Şayet dolu ise,gönderdiğim bir prediget'ı listele
            }
        }
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                //Burda tek bir nesne döndüreceğim için contexte abone olup SingleOrDefault kullanıp ilgili filtremi gönderiyorum
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }
        public TEntity Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);//Context'de ilgili nesneye abone olduk
                addedEntity.State = EntityState.Added; // Durumunu eklenecek data diye EntityFramework'e bildiriyorum
                context.SaveChanges();// Değişikliği kaydet diyoruz
                return entity; // Entity'i de burda return ediyoruz parametrede belirttiğimiz entity nesnesini!
            }
        }
        public TEntity Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);//Context'de ilgili nesneye abone olduk
                updatedEntity.State = EntityState.Modified; // Durumunu güncellenecek data diye EntityFramework'e bildiriyorum
                context.SaveChanges();// Değişikliği kaydet diyoruz
                return entity; // Entity'i de burda return ediyoruz parametrede belirttiğimiz entity nesnesini!
            }
        }
        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                //void bir method olduğu için artık return demiyoruz burda!Sadece silecek
                var deletedEntity = context.Entry(entity);//Context'de ilgili nesneye abone olduk
                deletedEntity.State = EntityState.Deleted; // Durumunu silinecek data diye EntityFramework'e bildiriyorum
                context.SaveChanges();// Değişikliği kaydet diyoruz
            }
        }     
    }
}
