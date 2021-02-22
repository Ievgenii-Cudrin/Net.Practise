using CodeFirstWithFluentApiCrudOperation.DataContext;
using CodeFirstWithFluentApiCrudOperation.Entities;
using CodeFirstWithFluentApiCrudOperation.Views;
using System;
using System.Linq;

namespace CodeFirstWithFluentApiCrudOperation
{
    class Program
    {
        static void Main(string[] args)
        {
            //PersonView.CreatePerson();
            //PersonView.UpdatePerson(1);
            //PersonView.DeletePerson(4);
            PersonView.ShowAllPersons();

            //DepartmentView.CreateDepartment();
            DepartmentView.ShowAllDepartments();
            //DepartmentView.UpdateDepartment(2);
            //DepartmentView.ShowAllDepartments();
            //DepartmentView.DeleteDepartment(1);

            //EmployeeView.CreateEmployee();
            EmployeeView.ShowAllEmployees();
            //EmployeeView.UpdateEmployee(2);
            //EmployeeView.ShowAllEmployees();
            //EmployeeView.DeleteEmployee(2);

            //ShiftView.CreateShift();
            ShiftView.ShowAllShifts();
            //ShiftView.UpdateShift(1);
            //ShiftView.ShowAllShifts();
            //ShiftView.DeleteShift(2);

            //EmployeeDepartmentView.CreateEmployeeDepartment();
            EmployeeDepartmentView.ShowAllEmployeesDepartment();
            //EmployeeDepartmentView.UpdateEmployeeDepartment(2);
            //EmployeeDepartmentView.ShowAllEmployeesDepartment();
            //EmployeeDepartmentView.DeleteEmployeeDepartment(2);
            //EmployeeDepartmentView.ShowAllEmployeesDepartment();

            //SalesPersonView.CreateSalesPerson();
            SalesPersonView.ShowAllSalesPersons();
            //SalesPersonView.UpdateSalesPerson(2);
            //SalesPersonView.ShowAllSalesPersons();
            //SalesPersonView.DeleteSalesPerson(1);
            //SalesPersonView.ShowAllSalesPersons();

            //JobCandidateView.CreateJobCandidate();
            JobCandidateView.ShowAllJobCandidate();
            //JobCandidateView.UpdateJobCandidate(2);
            //JobCandidateView.ShowAllJobCandidate();
            //JobCandidateView.DeleteJobCandidate(1);
            //JobCandidateView.ShowAllJobCandidate();

            //EmployeePayHistoryView.CreateEmployeePayHistory();
            EmployeePayHistoryView.ShowAllEmployeePayHistories();
            //EmployeePayHistoryView.UpdateEmployeePayHistory(2);
            //EmployeePayHistoryView.ShowAllEmployeePayHistories();
            //EmployeePayHistoryView.DeleteEmployeePayHistory(2);
            //EmployeePayHistoryView.ShowAllEmployeePayHistories();

            Console.Read();
        }
    }
}
