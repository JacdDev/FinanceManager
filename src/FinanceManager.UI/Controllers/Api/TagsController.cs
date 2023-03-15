﻿using FinanceManager.Application.Tags.Commands.CreateTag;
using FinanceManager.UI.Models;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.UI.Controllers.Api
{
    [Route("api/[controller]")]
    public class TagsController : ApiControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public TagsController(IMapper mapper, ISender mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTag(
            CreateTagRequest request)
        {
            var command = _mapper.Map<CreateTagCommand>(request);

            var createTagResult = await _mediator.Send(command);

            return createTagResult.Match(
                tag => Ok(_mapper.Map<TagResponse>(tag)),
                errors => Problem(errors)
                );
        }
    }
}
