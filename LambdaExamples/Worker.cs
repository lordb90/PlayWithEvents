using System;

namespace LambdaExamples
{
    public class Worker
    {
        public event EventHandler<WorkPerformedEventArgs> WorkPerformed;
        public event EventHandler<WorkPerformedEventArgs> WorkCompleted;
        
        public void DoWork(int hours, WorkType workType)
        {
            for (var i = 0; i < hours; i++)
            {
                OnWorkPerformed(i+1, workType);
            }
            OnWorkCompleted(hours, workType);
        }

        protected virtual void OnWorkPerformed(int hours, WorkType workType)
        {
            var worker = WorkPerformed;
            Console.WriteLine("Some Work is being performed....");
            worker?.Invoke(this, new WorkPerformedEventArgs(hours, workType));
        }
        
        protected virtual void OnWorkCompleted(int hours, WorkType workType)
        {
            var worker = WorkCompleted;
            Console.WriteLine("Some Work has completed....");
            worker?.Invoke(this, new WorkPerformedEventArgs(hours, workType));
        }
    }
}