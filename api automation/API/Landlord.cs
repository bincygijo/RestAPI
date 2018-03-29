using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_automation.API
{
    public class Landlord
    {
        public string url = "http://localhost:8080/landlords";
        public IRestResponse Post(string data)
        {
            RestClient client = new RestClient(url);
            RestRequest request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", data, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return response;
        }
        public IRestResponse Get(String ID)
        {
            var client = new RestClient(url + "/" + ID);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);
            return response;
        }
        public IRestResponse Put(string Id, string data)
        {
            var client = new RestClient(url + "/" + Id);
            var request1 = new RestRequest(Method.PUT);
            request1.AddHeader("Content-Type", "application/json");
            request1.AddParameter("application/json", data, ParameterType.RequestBody);
            IRestResponse response1 = client.Execute(request1);
            return response1;
        }
        public IRestResponse Delete(string Id)
        {
            var client = new RestClient(url + "/" + Id);
            var request1 = new RestRequest(Method.DELETE);
            request1.AddHeader("Content-Type", "application/json");
            IRestResponse response1 = client.Execute(request1);
            return response1;
        }
    }
}
