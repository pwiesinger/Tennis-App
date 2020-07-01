using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisBackend.DTO;

namespace TennisBackend.Filter
{
    public class PersonResultFilterAttribute : ResultFilterAttribute
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var result = context.Result as ObjectResult;
            if (result.Value == null
                || result.StatusCode < 200
                || result.StatusCode >= 300)
            {
                await next();
                return;
            }

            result.Value = new PersonReplyDto().CopyPropertiesFrom(result.Value);
            await next();
        }
    }
}
