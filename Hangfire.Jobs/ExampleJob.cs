using System;

namespace Hangfire.Jobs
{
    public class ExampleJob
    {
        public void Print(string text)
        {
            Console.WriteLine(text);
        }
    }
}
