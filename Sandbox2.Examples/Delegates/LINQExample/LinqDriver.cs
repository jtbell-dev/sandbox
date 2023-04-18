using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox2.Examples.Delegates.LINQExample
{
    internal class LinqDriver
    {
        public void Run(List<string> addresses)
        {
            ContainsValueDelegate del = Contains123;

            Func<string, bool> f1 = Contains123;

            var addressesWith123_1 = addresses.Where(a => a.Contains("123"));

            foreach (var item in addresses)
            {
                if (item.Contains("123"))
                {

                }
            }

            var addressesWith123_2 = addresses.Where(a => del(a));

            var addressesWith123_3 = addresses.Where(a => f1(a));

            var items = addresses.Where(f1(a));

            DoSomethingDelegate del2 = s => Console.WriteLine(s);
            this.ExecuteAction(del2);

            Action<string> a1 = s => Console.WriteLine($"You said {s}");
            this.ExecuteAction(a1);

        }

        public void ExecuteAction(DoSomethingDelegate doSomethingAction)
        {

        }

        private bool Contains123(string address)
        {
            return address.Contains("123");
        }

        private bool EqualsNextValue(string first, string next)
        {
            return first.Equals(next); // first == next
        }

        private delegate bool ContainsValueDelegate(string text);

        private delegate void DoSomethingDelegate(string text);
    }
}
