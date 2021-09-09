using System;
using EventExamples;

namespace DelegatesExamples
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var handler = new EventHandler<WorkPerformedEventArgs>(WorkIsPerformed);
            var handler2 = new EventHandler<WorkPerformedEventArgs>(MoreWorkIsPerformed);
            handler.Invoke(null, new WorkPerformedEventArgs(4, WorkType.Interviews));
            handler2(null, new WorkPerformedEventArgs(3, WorkType.Reports));
        }

        private static void WorkIsPerformed(object sender, WorkPerformedEventArgs we)
        {
            Console.WriteLine($"Worked that was performed: {we.WorkType.ToString()} for {we.Hours} hour(s)");
        }

        private static void MoreWorkIsPerformed(object sender, WorkPerformedEventArgs we)
        {
            Console.WriteLine($"More work was performed: {we.WorkType.ToString()} for {we.Hours} hour(s)");
        }
        
    }
}