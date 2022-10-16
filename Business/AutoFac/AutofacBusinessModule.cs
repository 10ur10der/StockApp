using Autofac;
using DataAccess;
using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoFac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StockManager>().As<IStockService>();
            builder.RegisterType<EfStockDal>().As<IStockDal>();

        }
    }
}
