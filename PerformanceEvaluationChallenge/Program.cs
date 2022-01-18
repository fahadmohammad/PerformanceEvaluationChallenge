using System;
using System.Diagnostics;
using System.Text;

namespace PerformanceEvaluationChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            //Stopwatch stopwatch = Stopwatch.StartNew();
            //stopwatch.Start();

            //string test = "";

            //for (int i = 0; i < 50000; i++)
            //{
            //    test += "Testing";
            //}

            //stopwatch.Stop();

            //Console.WriteLine($"Elapsed: {stopwatch.ElapsedMilliseconds} ms");

            //stopwatch = Stopwatch.StartNew();
            //stopwatch.Start();

            //StringBuilder stringBuilder = new StringBuilder();

            //for (int i = 0; i < 50000; i++)
            //{
            //    stringBuilder.Append("Testing");
            //}

            //string sbString = stringBuilder.ToString();

            //stopwatch.Stop();

            //Console.WriteLine($"Elapsed: {stopwatch.ElapsedMilliseconds} ms");

            //int[] iterations = new[] {500, 5000, 50000};

            //CalculateSpeed(StringAddTest, iterations, "StringAddTest");
            //CalculateSpeed(StringBuilderTest, iterations, "StringBuilderTest");

            int[] iterations = new[] {500000, 5000000 };

            CalculateSpeed(DoubleTest, iterations, "DoubleTest");
            CalculateSpeed(DecimalTest, iterations, "DecimalTest");

            Console.ReadLine();
        }

        private static void StringAddTest(int iteration)
        {
            string test = "";

            for (int i = 0; i < iteration; i++)
            {
                test += "Testing";
            }
        }

        private static void StringBuilderTest(int iteration)
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < iteration; i++)
            {
                stringBuilder.Append("Testing");
            }
        }

        private static void DoubleTest(int iteration)
        {
            double x = 4.25;
            double y = 25.75;

            for (int i = 0; i < iteration; i++)
            {
                x += y;
            }
        }

        private static void DecimalTest(int iteration)
        {
            decimal x = 4.25M;
            decimal y = 25.75M;

            for (int i = 0; i < iteration; i++)
            {
                x += y;
            }
        }

        private static void CalculateSpeed(Action<int> methodToTest, int[] repetitions, string testName)
        {
            for (int i = 0; i < repetitions.Length; i++)
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                stopwatch.Start();

                methodToTest(repetitions[i]);

                stopwatch.Stop();

                Console.WriteLine($"TestName: {testName}, Reps: {repetitions[i]} Elapsed: {stopwatch.ElapsedMilliseconds} ms");
            }
        }
    }
}
