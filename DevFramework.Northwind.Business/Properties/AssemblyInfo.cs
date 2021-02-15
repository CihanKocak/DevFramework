using DevFramework.Core.Aspects.Postsharp.ExceptionAspects;
using DevFramework.Core.Aspects.Postsharp.LogAspects;
using DevFramework.Core.Aspects.Postsharp.PerformanceAspects;
using DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Bir bütünleştirilmiş koda ilişkin Genel Bilgiler aşağıdaki öznitelikler kümesiyle
// denetlenir. Bütünleştirilmiş kod ile ilişkili bilgileri değiştirmek için
// bu öznitelik değerlerini değiştirin.
[assembly: AssemblyTitle("DevFramework.Northwind.Business")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("DevFramework.Northwind.Business")]
[assembly: AssemblyCopyright("Copyright ©  2020")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: LogAspect(typeof(DatabaseLogger),AttributeTargetTypes = "DevFramework.Northwind.Business.Concrete.Managers.*")]
[assembly: ExceptionLogAspect(typeof(DatabaseLogger), AttributeTargetTypes = "DevFramework.Northwind.Business.Concrete.Managers.*")]
[assembly: PerformanceCounterAspect(AttributeTargetTypes = "DevFramework.Northwind.Business.Concrete.Managers.*")]

// ComVisible özniteliğinin false olarak ayarlanması bu bütünleştirilmiş koddaki türleri
// COM bileşenleri için görünmez yapar. Bu bütünleştirilmiş koddaki bir türe
// erişmeniz gerekirse ComVisible özniteliğini o türde true olarak ayarlayın.
[assembly: ComVisible(false)]

// Bu proje COM'un kullanımına sunulursa, aşağıdaki GUID tür kitaplığının kimliği içindir
[assembly: Guid("619c0640-cf56-4eab-ba26-942fbbac8448")]

// Bir derlemenin sürüm bilgileri aşağıdaki dört değerden oluşur:
//
//      Ana Sürüm
//      İkincil Sürüm 
//      Yapı Numarası
//      Düzeltme
//
// Tüm değerleri belirtebilir veya varsayılan Derleme ve Düzeltme Numaralarını kullanmak için
// aşağıda gösterildiği gibi '*' kullanabilirsiniz:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
