﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkAnalyzer.ServiceModel.Types;
using ServiceStack;

namespace BenchmarkAnalyzer.ServiceModel
{
    [Route("/testplans/{TestPlanId}/upload", "POST")]
    [Route("/testplans/{TestPlanId}/testruns/{TestRunId}/upload", "POST")]
    public class UploadTestResults : IReturn<List<TestResult>>
    {
        public int TestPlanId { get; set; }
        public int? TestRunId { get; set; }
        public bool CreateNewTestRuns { get; set; }
    }

    public class UploadTestResultsResponse
    {
        public bool success { get; set; }
        public TestRun TestRun { get; set; }
        public List<TestResult> Results { get; set; }
        public ResponseStatus ResponseStatus { get; set; }
    }

    [Route("/testplans/{TestPlanId}/testresults", "POST")]
    [Route("/testplans/{TestPlanId}/testruns/{TestRunId}/testresults", "POST")]
    public class AddTestResults : IReturn<List<TestResult>>
    {
        public int TestPlanId { get; set; }
        public int? TestRunId { get; set; }
        public string Contents { get; set; }
    }

    public class AddTestResultsResponse
    {
        public TestRun TestRun { get; set; }
        public List<TestResult> Results { get; set; }
        public ResponseStatus ResponseStatus { get; set; }
    }
}
