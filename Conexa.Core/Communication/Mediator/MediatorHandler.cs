using Conexa.Core.Messages;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Conexa.Core.Communication.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ValidationResult> SendCommand<T>(T comando)
            where T : Command
        {
            return await _mediator.Send(comando);
        }
    }
}
