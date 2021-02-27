using AdoNetWithTwoTablesFromAleksandr0102.DI;
using AdoNetWithTwoTablesFromAleksandr0102.Interfaces;
using AdoNetWithTwoTablesFromAleksandr0102.ProgramBranch;
using AdoNetWithTwoTablesFromAleksandr0102.Views;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AdoNetWithTwoTablesFromAleksandr0102
{
    class Program
    {
        static void Main(string[] args)
        {
            Branch.StartApp();
            Console.ReadLine();
        }
    }
}
