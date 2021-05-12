﻿using System;
using System.Net.Http;
using System.Web.Http.Tracing;

namespace AppSampleBaseLine.Trace
{
    public class SimpleTracer : ITraceWriter
    {
        public void Trace(HttpRequestMessage request, string category, TraceLevel level, Action<TraceRecord> traceAction)
        {
            TraceRecord rec = new TraceRecord(request, category, level);
            traceAction(rec);
        }

        protected void WriteTrace(TraceRecord rec)
        {
            var message = $"{rec.Operator};{rec.Operation};{rec.Message}";
            System.Diagnostics.Trace.WriteLine(message, rec.Category);
        }
    }
}