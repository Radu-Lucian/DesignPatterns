using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceManagement.Command
{
    public class CheckOutCarCommand : ICommand
    {
        public void Execute(string command)
        {
            Console.WriteLine(command);
        }
    }
}
