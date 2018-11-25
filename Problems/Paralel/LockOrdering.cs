using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.Alg.Paralel
{
    class LockOrdering
    {
        int balance;
        private bool Move(LockOrdering to, int money)
        {
            lock (this)
            {
                lock (to)
                {
                    if (money > balance)
                        return false;
                    to.balance = balance + money;
                    balance = balance - money;
                    return true;
                }
            }


        }

        


    }
}
