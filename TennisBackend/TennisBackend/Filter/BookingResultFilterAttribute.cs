using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisBackend.DTO;
using TennisBackendDb;

namespace TennisBackend.Filter
{
    public class BookingResultFilterAttribute : ResultFilterAttribute
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

            var reply = new BookingReplyDto().CopyPropertiesFrom(result.Value);
            (reply as BookingReplyDto).PersonId = (result.Value as Booking).PersonId;
            result.Value = reply;
            await next();
        }
    }
}
