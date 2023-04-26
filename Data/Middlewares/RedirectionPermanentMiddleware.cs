using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Middlewares
{
    public class RedirectionPermanentMiddleware
    {
        RequestDelegate _next;
        public RedirectionPermanentMiddleware(RequestDelegate next) 
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, MonDBContext dbContext)
        {
            var path = context.Request.Path.ToUriComponent();
            var entity = dbContext.ReRouting.FirstOrDefault(f => f.OldUrl.ToLower() == path.ToLower());
            if (entity != null)
            { 
                context.Response.Redirect(entity.NewUrl, permanent: true);
                return;
            }

            await _next.Invoke(context);
        }
    }
}
