using System;
using System.Collections.Generic;
using System.Text;

namespace Nedelja7.Application.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(int id, string type)
            : base($"Entity of type {type} with an id of {id} was not found.")
        {
            
        }
    }
}
