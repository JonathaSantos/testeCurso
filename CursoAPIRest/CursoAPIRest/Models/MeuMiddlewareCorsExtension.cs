using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoAPIRest.Models
{
    public static class MeuMiddlewareCorsExtension
    {
        public static IApplicationBuilder UserMeuMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MeuMiddlewareCors>();
        }
    }
}
