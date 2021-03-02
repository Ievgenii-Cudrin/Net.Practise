using CodeFirstWithFluentApiCrudOperation.BLLInterfaces;
using CodeFirstWithFluentApiCrudOperation.DI;
using CodeFirstWithFluentApiCrudOperation.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.Views
{
    public static class SalesPersonView
    {
        static ISalesPersonService salesPersonService = Startup.ConfigureService().GetRequiredService<ISalesPersonService>();

        public static void CreateSalesPerson()
        {
            SalesPerson salesPerson = new SalesPerson()
            {
                BusinessEntityID = 5,
                SalesQuota = 15
            };

            SalesPerson salesPerson2 = new SalesPerson()
            {
                BusinessEntityID = 6,
                SalesQuota = 16
            };

            salesPersonService.CreateSalesPerson(salesPerson);
            salesPersonService.CreateSalesPerson(salesPerson2);
            Console.WriteLine("SalesPerson added");
        }

        public static void UpdateSalesPerson(int id)
        {
            SalesPerson salesPerson = salesPersonService.GetSalesPerson(id);

            salesPerson.SalesQuota = 46;

            salesPersonService.UpdateSalesPerson(salesPerson);
            Console.WriteLine("SalesPerson updated");
        }

        public static void DeleteSalesPerson(int id)
        {
            salesPersonService.DeleteSalesPerson(id);
            Console.WriteLine("SalesPerson deleted");
        }
    }
}
