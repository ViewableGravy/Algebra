﻿using System;

namespace Algebra
{
    class CreateVariableCommandException : Exception
    {
        public CreateVariableCommandException() { }
        public CreateVariableCommandException(string message) : base(message) { }
    }

    class AddCommandException : Exception
    {
        public AddCommandException() { }
        public AddCommandException(string message) : base(message) { }
    }

    class AssignCommandException : Exception
    {
        public AssignCommandException() { }
        public AssignCommandException(string message) : base(message) { }
    }
}
