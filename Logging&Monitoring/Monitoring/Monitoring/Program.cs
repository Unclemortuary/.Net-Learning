using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace Monitoring
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateNewPerfomanceCounterCategory(Constants.CategoryName, Constants.LoginCounterName); //Create a new counter category with login counter

            //Write to our counter
            using (var loginCounter = new PerformanceCounter(
                Constants.CategoryName,
                Constants.LoginCounterName,
                "Test project",
                false))
            {
                loginCounter.RawValue = 0;

                for (int i = 0; i < 20; i++)
                {
                    Thread.Sleep(3000);
                    loginCounter.Increment();
                }
            }

            //Read from some counter
            using (var loginCounter = new PerformanceCounter(
                "Processor",
                "% Processor Time",
                "_Total"))
            {
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(2000);
                    Console.WriteLine(loginCounter.NextValue());
                }
            }
        }

        #region Sample of creation custom counter category and custom counter in there
        static void CreateNewPerfomanceCounterCategory(string categoryName, string loginCounterName)
        {
            if (!PerformanceCounterCategory.Exists(categoryName))
            {
                var counterCreationDataCollection = new CounterCreationDataCollection();
                var loginCounter = new CounterCreationData()
                {
                    CounterName = loginCounterName,
                    CounterType = PerformanceCounterType.NumberOfItems32
                };
                counterCreationDataCollection.Add(loginCounter);

                try
                {
                    PerformanceCounterCategory.Create(
                        categoryName, "", PerformanceCounterCategoryType.MultiInstance,
                        counterCreationDataCollection);
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine("Do not have permissions");
                }

                Console.WriteLine("Category created");
            }
        }
        #endregion
    }
}
