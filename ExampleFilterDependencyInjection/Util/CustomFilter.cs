using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleFilterDependencyInjection.Util
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomFilter : Attribute, IAuthorizationFilter, IFilterFactory
    {
        private IConfiguration _configuration;

        public bool IsReusable => throw new NotImplementedException();

        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            return new CustomFilter((IConfiguration)serviceProvider.GetService(typeof(IConfiguration)));
        }

        public CustomFilter(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var requestKey = context.HttpContext.Request.Headers["Key"].ToString();
            var secretKey = _configuration["Key"].ToString();

            if(requestKey != secretKey)
                context.Result = new UnauthorizedResult();
        }
    }
}
