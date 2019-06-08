using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lopak.Application.Infrastructure
{
    public class CommandActionResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public Unit Unit { get; set; }
    }
}
