/*
Уменьшите размер функции.
static bool ShouldFire(bool enemyInFront, string enemyName, int robotHealth)
{
        bool shouldFire = true;
        if (enemyInFront == true)
        {
            if (enemyName == "boss")
            {
                if (robotHealth < 50) shouldFire = false;
                if (robotHealth > 100) shouldFire = true;
            }
        }
        else
        {
            return false;
        }
        return shouldFire;
}
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ShouldFire(true, "other", 60));
            Console.ReadKey();
        }
        static bool ShouldFire(bool enemyInFront, string enemyName, int robotHealth)
        {
            if ((enemyInFront == false) || ((enemyName == "boss") && (robotHealth < 50)))
                return false;
            else return true;
        }
    }
}
