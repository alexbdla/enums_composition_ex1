using System.Diagnostics.Contracts;
using System.Globalization;
using WorkerContract.Entities;
using WorkerContract.Entities.Enums;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Enter department's name: ");
        string departmentName = Console.ReadLine();
        Console.WriteLine("Enter worker data: ");
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Level (Junior/MidLevel/Senior): ");
        WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
        Console.Write("Base Salary: ");
        double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        Department dept = new Department(departmentName);
        Worker w1 = new Worker(name, level, baseSalary, dept);

        Console.Write("How many contracts to this worker? ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Enter #" + (i + 1) + "contract data:");
            Console.Write("Date (DD/MM/YYYY): ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.Write("Value per hour: ");
            double value = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Duration (hours): ");
            int duration = int.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            HourContract contract = new HourContract(date, value, duration);
            w1.AddContract(contract);
        }

        Console.WriteLine();
        Console.Write("Enter month and year to calculate income (MM/YYYY): ");
        string d1 = Console.ReadLine();
        int month = int.Parse(d1.Substring(0, 2));
        int year = int.Parse(d1.Substring(3));
        Console.WriteLine("Name: " + w1.Name);
        Console.WriteLine("Department: " + w1.Department.Name);
        Console.WriteLine("Income for " + d1 + ": " + w1.Income(year, month).ToString("F2", CultureInfo.InvariantCulture));


    }
}