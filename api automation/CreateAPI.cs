using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace api_automation
{
    public class CreateAPI
    {
        public string Url = "http://localhost:8080/landlords";
        public string postData = "{\"firstName\": \"ann11\", \"lastName\": \"george11\", \"trusted\": false}";
        public string postData1 = "{\"firstName\": \"ajith\", \"lastName\": \"neha\", \"trusted\": true}";

        [Test]
        public void POST()
        {
            //Client
            RestClient client = new RestClient(Url);

            //Request
            var request = new RestRequest(Method.POST);

            //Request-header
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");

            //adding body
            request.AddParameter("application/json", postData, ParameterType.RequestBody);

            //Executing the request
            var response = client.Execute(request);

           Console.WriteLine(response.Content);
           Console.WriteLine(response.StatusCode);

           Assert.IsTrue(response.StatusCode == HttpStatusCode.Created);

            // Test Validation
            if (response.StatusCode == HttpStatusCode.Created)
                Console.WriteLine("Test Successfull");
            else
                Console.WriteLine("Test Failed");

        }
 
        public void GET()
        {
            var client = new RestClient(Url);
            var request = new RestRequest("http://localhost:8080/landlords/Q8nhdaZv", Method.GET);

            //Request-header
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");

            //Executing the request
            var response = client.Execute(request);

            Console.WriteLine(response.Content);
            Console.WriteLine(response.StatusCode);

            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK);
           // Assert.IsTrue(!string.IsNullOrEmpty(response.Data)); // the response is not empty

            //Assert.AreEqual(2, response.Data.Length);

            // Test Validation
            if (response.StatusCode == HttpStatusCode.OK)
                Console.WriteLine("Test Successfull");
            else
                Console.WriteLine("Test Failed");

        }
        [Test]
        public void PUT()

        {
            //Client
            RestClient client = new RestClient(Url);

            //Request
            var request = new RestRequest("http://localhost:8080/landlords/Q8nhdaZv", Method.PUT);

            //Request-header
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");

            //adding body
            request.AddParameter("application/json", postData1, ParameterType.RequestBody);

            //Executign the request
            var response = client.Execute(request);

            Console.WriteLine(response.Content);
            Console.WriteLine(response.StatusCode);

            // Test Validation
            if (response.StatusCode == HttpStatusCode.OK)
                Console.WriteLine("Test Successfull");
            else
                Console.WriteLine("Test Failed");

        }

        [Test]
        public void DELETE()
        {
            //Client
            RestClient client = new RestClient(Url);

            //Request
            var request = new RestRequest("http://localhost:8080/landlords/DvFcaVps", Method.DELETE);

            //Request-header
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");

            //Executign the request
            var response = client.Execute(request);

            Console.WriteLine(response.Content);
            Console.WriteLine(response.StatusCode);
            // Test Validation
            if (response.StatusCode == HttpStatusCode.OK)
                Console.WriteLine("Test Successfull");
            else
                Console.WriteLine("Test Failed");
        }
    }
}
