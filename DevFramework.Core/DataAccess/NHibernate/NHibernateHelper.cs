using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.DataAccess.NHibernate
{
    public abstract class NHibernateHelper : IDisposable
    {
        private static ISessionFactory _sesionFactory; // Factory Design Pattern'inden besleniyor.

        public virtual ISessionFactory SessionFactory // Bu session'ı çözmek için yazdık
        {
            //Varsa döndür,yok null'sa sen initialize et dedik
            get { return _sesionFactory ?? (_sesionFactory = InitializeFactory()); }
        }
        protected abstract ISessionFactory InitializeFactory();
        // InitializeFactory'i biz yazdık.Bu NHibernate'i kim kullanacaksa onu ezip kullan demiş olduk.
       
        public virtual ISession OpenSession()// Bu session'ı açmam gerek
        {
            return SessionFactory.OpenSession();
            //Kiş nasıl bir sessionfactory gönderdi ise,o zaman bana onu kullanarak bir session aç
        }

        public void Dispose()
        {
            //Garbage Collector'ü kullanaraktan SuppressFinalize methodunu klasik Dispose operasyonlarında çağırıyoruz
            GC.SuppressFinalize(this);
        }
    }
}
