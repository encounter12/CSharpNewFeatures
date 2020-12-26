using System;
using System.Collections.Generic;
using System.Linq;

namespace EqualityOrderComparisonMoney
{
    public class Notification
    {
        private readonly List<Error> _errors = new();

        public void AddError(string message, Exception e)
            => _errors.Add(new Error(message, e));

        public void AddError(string message) => AddError(message, null);

        public bool HasErrors => _errors.Count > 0;

        public string ErrorMessage
            => string.Join(", ", _errors.Select(e => e.Message));

        private class Error
        {
            internal string Message { get; }

            internal Exception Cause { get; }

            internal Error(string message, Exception cause)
            {
                this.Message = message;
                this.Cause = cause;
            }
        }
    }
}