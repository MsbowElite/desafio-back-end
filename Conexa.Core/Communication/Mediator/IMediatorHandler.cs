using Conexa.Core.Messages;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Conexa.Core.Communication.Mediator
{
    public interface IMediatorHandler
    {
        Task<ValidationResult> SendCommand<T>(T command) where T : Command;
    }
}
