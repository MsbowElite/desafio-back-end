using Conexa.Core.Communication.Mediator;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conexa.Core.Messages
{
    public abstract class CommandHandler
    {
        protected ValidationResult ValidationResult;

        protected CommandHandler()
        {
        }

        protected IMediatorHandler MediatorHandler { get; private set; }

        protected void AddError(string mensagem)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem));
        }
    }
}
