﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkAnalyzer.ServiceModel.Types;
using ServiceStack;

namespace BenchmarkAnalyzer.ServiceModel
{
    [Route("/testplans/{TestPlanId}/testruns", "POST")]
    public class CreateTestRun : IReturn<TestRun>
    {
        public int TestPlanId { get; set; }
        public string SeriesId { get; set; }
    }

    [Route("/testruns/{Id}/delete", "POST DELETE")]
    public class DeleteTestRun
    {
        public int Id { get; set; }
    }

    [Route("/testplans/{TestPlanId}/testruns", "GET")]
    public class FindTestRuns : IReturn<List<TestRun>>
    {
        public int TestPlanId { get; set; }
    }
}
