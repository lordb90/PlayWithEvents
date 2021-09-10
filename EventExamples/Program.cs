using System;

namespace EventExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            var worker = new Worker();
            worker.WorkPerformed += WorkPerformed;
            worker.WorkCompleted += WorkIsComplete;
            worker.DoWork(4,WorkType.Reports);
        }

        private static void WorkIsComplete(object sender, WorkPerformedEventArgs we)
        {
            Console.WriteLine($"Worked that was completed: {we.WorkType} it took {we.Hours} to complete.");
        }

        private static void WorkPerformed(object sender, WorkPerformedEventArgs we)
        {
            Console.WriteLine($"Worked that was performed: {we.WorkType} for {we.Hours} hour(s)");
        }
    }
}