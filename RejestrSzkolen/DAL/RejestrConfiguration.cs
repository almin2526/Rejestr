using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Web;

namespace RejestrSzkolen.DAL
{
    public class RejestrConfiguration:DbConfiguration
    {
        public RejestrConfiguration()
        {
            //DbInterception.Add(new InterceptorLogging());
            DbInterception.Add(new NLogCommandInterceptor());
        }
    }
}