using System.Web.Http;
using System.Web.Http.Tracing;
using AppSampleBaseLine.Trace;

namespace AppSampleBaseLine
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API の設定およびサービス

            // Web API ルート
            config.MapHttpAttributeRoutes();
            //、Web API パイプラインにSystemDiagnosticsTraceWriterクラスを追加するｊ。
            var traceWriter = config.EnableSystemDiagnosticsTracing();
            traceWriter.IsVerbose = false;
            traceWriter.MinimumLevel = TraceLevel.Debug;
            // TraceWriterの設定
            config.Services.Replace(typeof(ITraceWriter), new  SimpleTracer());
        }
    }
}
