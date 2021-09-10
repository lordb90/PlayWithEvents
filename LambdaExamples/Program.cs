using System;
using System.ComponentModel;
using System.Threading.Channels;

namespace LambdaExamples
{
    public delegate int BizRulesDelegate(int x, int y);
    
    class Program
    {
        static void Main(string[] args)
        {
            var add = new BizRulesDelegate((x,y) => x+y);
            var multiply = new BizRulesDelegate((x, y) => x * y);
            
            var data = new ProcessData();
            data.Process(2, 3, add);
            data.Process(2, 3, multiply);


            Action<int, int> addAction = (x, y) => Console.WriteLine(x + y);
            Action<int, int> multiplyAction = (x, y) => Console.WriteLine(x * y);

            var data2 = new ProcessData();
            data.ProcessAction(10, 10, addAction);
            data.ProcessAction(10, 10, multiplyAction);

            Func<int, int, int> addFunc = (x, y) => (x + y);
            Func<int, int, int> multiplyFunc = (x, y) => (x * y);
            var data3 = new ProcessData();
            var valuereturn1 = data.ProcessFunction(10, 10, addFunc);
            Console.WriteLine(valuereturn1);
            var valuereturn2 = data.ProcessFunction(10, 10, multiplyFunc);
            Console.WriteLine(valuereturn2);

            // var worker = new Worker();
            // worker.WorkPerformed += WorkPerformed;
            // worker.WorkCompleted += WorkIsComplete;
            // worker.DoWork(4,WorkType.Reports);
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