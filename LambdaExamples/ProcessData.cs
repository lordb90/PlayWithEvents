using System;

namespace LambdaExamples
{
    public class ProcessData
    {
        /// <summary>
        /// Lambda Example
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="myfunc"></param>
        public void Process(int x, int y,BizRulesDelegate myfunc)
        {
            var result = myfunc(x, y);
            Console.WriteLine(result);
        }

        /// <summary>
        /// Action<T> example
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="myAction"></param>
        public void ProcessAction(int x, int y, Action<int, int> myAction)
        {
            myAction.Invoke(x,y);
            Console.WriteLine("Action completed!");
        }

        /// <summary>
        /// 
        /// </summary>Than
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public int ProcessFunction(int x, int y, Func<int, int, int> func)
        {
            var results = func.Invoke(x, y);
            Console.WriteLine(results);
            return results;
        }
    }
}