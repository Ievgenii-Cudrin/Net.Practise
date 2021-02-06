using CodeFirstWithFluentApiCrudOperation.BLLInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.Views
{
    public class PersonView
    {
        IPersonService personService;

        public PersonView(IPersonService personService)
        {
            this.personService = personService;
        }
    }
}
