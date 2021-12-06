using System;
using System.Diagnostics;
using System.Threading;

namespace Afb
{
    class Program
    {
        static void Main(string[] args)
        {
            //create a stopwatch and start it
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            //do a backup only if speficied time elapsed and piervious backup was succesful
            do
            {
                if (!(stopWatch.Elapsed.Seconds > 60))
                {
                    Thread.Sleep(6000 - stopWatch.Elapsed.Milliseconds);
                }
                BackupData.CopyFiles();

            } while (BackupData.BackupSuccesful);
        }
    }

}
