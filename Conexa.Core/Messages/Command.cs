using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conexa.Core.Messages
{
    public class Command : Message, IRequest<ValidationResult>
    {
        protected Command()
        {
            Timestamp = DateTime.UtcNow;
        }

        public DateTime Timestamp { get; private set; }

        public ValidationResult ValidationResult { get; set; }

        public virtual bool IsValid()
        {
            return true;
        }
    }
}
