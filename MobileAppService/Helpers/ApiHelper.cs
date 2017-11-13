using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using RestSharp;

namespace Mobilize.ChalkServices.MobileAppService.Helpers
{
    public static class ApiHelper
    {
        public async static Task<RestResponse> GetData(string baseUrl, string resource, Dictionary<string, string> parameters, Dictionary<string, string> urlSegments)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest(resource, Method.GET);

            foreach (var parameter in parameters)
            {
                request.AddParameter(parameter.Key, parameter.Value);                
            }

            foreach (var urlSegment in urlSegments)
            {
                request.AddUrlSegment(urlSegment.Key, urlSegment.Value);
            }

            TaskCompletionSource<IRestResponse> taskCompletion = new TaskCompletionSource<IRestResponse>();
            RestRequestAsyncHandle handle = client.ExecuteAsync(request, r => taskCompletion.SetResult(r));
            return (RestResponse)(await taskCompletion.Task);
        }
    }
}