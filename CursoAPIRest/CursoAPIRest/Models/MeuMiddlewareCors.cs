using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoAPIRest.Models
{
    public class MeuMiddlewareCors
    {
        private readonly RequestDelegate _next;

        public MeuMiddlewareCors(RequestDelegate next)
        {
            _next = next;
        }

        public async Task UsandoCors(HttpContext context)
        {
            Console.WriteLine("Antes");
            await _next(context);
            Console.WriteLine("DEpois");
        }
    }
}
