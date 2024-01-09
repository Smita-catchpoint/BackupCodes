//using Newtonsoft.Json;
//using System;

//namespace CustomSerializer
//{
//    class Result
//    {
//        public int[] timeout { get; set; }
//    }

//    class TestResult
//    {
//        public string TestId { get; set; }
//        public DateTime StartTime { get; set; }
//        public Result TestResults { get; set; }
//    }

//    internal class NewProgram3
//    {
//        static void Main(string[] args)
//        {
//            string json = @"
//            {
//                ""cp-test-test-id"": ""asdf"",
//                ""cp-test-start-time,"": ""10-10-2023"",
//                ""cp-test-ping-results"": ""10,15,20,25,50""
//            }";

//            TestResult obj = JsonConvert.DeserializeObject<TestResult>(json);

//            Console.WriteLine($"TestId: {obj.TestId}, StartTime: {obj.StartTime}, TestResults: {obj.TestResults.timeout}");
//        }
//    }
//}