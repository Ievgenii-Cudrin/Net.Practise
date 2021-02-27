using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingTask.Core.Interfaces;
using TestingTask.Core.Models;

namespace TestingTask.Core.Services
{
    public class GroupValidator : IValidator<Group>
    {
        public bool Validate(Group item)
        {
            throw new NotImplementedException();
        }
    }
}
