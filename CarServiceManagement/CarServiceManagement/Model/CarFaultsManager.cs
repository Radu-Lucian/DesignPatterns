using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceManagement.Model
{
    public class CarFaultsManager
    {
        private List<string> _undone;
        private List<string> _done;

        public CarFaultsManager()
        {
            _undone = new List<string>();
            _done = new List<string>();
        }

        public void AddFault(string f)
        {
            _undone.Add(f);
        }

        public void AddFaults(List<string> f)
        {
            _undone.AddRange(f);
        }

        public void GetCurrentProgress()
        {
            if(_undone.Count > 0)
                Console.WriteLine("Currently working on: "+ _undone.First());
            else
            {
                if(_undone.Count()==0&&_done.Count()==0)
                    Console.WriteLine("Your car hasn't been revised by anybody. Please check again later.");
                else
                    Console.WriteLine("Your car is done!");
            }
               
        }

        public void CompleteCurrentOperation()
        {
            if (_undone.Count > 0)
            {
                _done.Add(_undone.Last());
                _undone.RemoveAt(_undone.Count - 1);
            }
        }

        public void PrintFaults()
        {
            if (_undone.Count()!=0)
            {
                Console.WriteLine("Done:");
                foreach(string f in _done)
                {
                    Console.WriteLine(f);
                }
                Console.WriteLine("Undone:");
                foreach (string f in _undone)
                {
                    Console.WriteLine(f);
                }
            }
            else if (_done.Count() != 0)
            {
                Console.WriteLine("The work that has been done to your car:");
                foreach (string f in _done)
                {
                    Console.WriteLine(f);
                }
            }
        }
    }
}
