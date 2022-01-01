using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseLog.Domain.EntidadesAuxiliares
{
    public enum StatusResult { Error, Correct }
    public class Status
    {
        private StatusResult StatusResult { get;  set; }
        private string Message { get; set; }

        public Status ResultWas(StatusResult result)
        {
            this.StatusResult = result;
            return this;
        }

        public Status WithMessage(string message)
        {
            this.Message = message;
            return this;
        }
    }
}

