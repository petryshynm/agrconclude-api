﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace agrconclude.API.DTOs.Response
{
    public class InvalidModelStateResponse
    {
        public InvalidModelStateResponse(ActionContext context)
        {
            Errors = ConstructResponse(context);
        }

        public IEnumerable<ErrorResponse> Errors { get; init; }

        private IEnumerable<ErrorResponse> ConstructResponse(ActionContext context)
        {
            var mapper = context.HttpContext.RequestServices.GetRequiredService<IMapper>();
            return mapper.Map<IEnumerable<ErrorResponse>>(context.ModelState);
        }
    }
}
