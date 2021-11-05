using System;
using System.Collections.Generic;
using System.Text;

namespace BoxTI.Challenge.CovidTracking.Models.Exceptions
{
	public class DomainException : Exception
    {
        public DomainException(string message) : base(message) { }

        public static void ToThrow(bool invalid, string message)
        {
            if (invalid)
                throw new DomainException(message);
        }
    }
}
