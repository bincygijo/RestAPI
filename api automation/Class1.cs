using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_automation
{
    public class Class1
    {
        public string url = "http://localhost:8080/landlords";

        //public string postData = "{\"firstName\": \"test\", \"lastName\": \"george\", \"trusted\": false}";

        public IRestResponse Post(String data) {
            RestClient client = new RestClient(url);
            RestRequest request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");

            request.AddParameter("undefined", data, ParameterType.RequestBody);

          //  request.AddBody(postData);

            IRestResponse response = client.Execute(request);
           // Console.Error.WriteLine(response.Content);
            return response;
        }

        public IRestResponse Get(String ID)
        {
            var client = new RestClient(url+"/"+ID);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);
          //  Console.Error.WriteLine(response.Content);
            return response;
        }

        [Repeat(1000)]
           public void TestPost() {

            Employee postEmp = new Employee(RandomString(9), RandomString(9), true);

            string jsonData = JsonConvert.SerializeObject(postEmp);

            //Employee ExpectedEmp = JsonConvert.DeserializeObject<Employee>(jsonData);

            //Post
            var responsePost = Post(jsonData);
            Employee ActualEmp = JsonConvert.DeserializeObject<Employee>(responsePost.Content);
            VerifyEmployee(postEmp, ActualEmp);
            
            //Get
            var responseGet = Get(ActualEmp.id);
            Employee ActualEmp1 = JsonConvert.DeserializeObject<Employee>(responseGet.Content);
            VerifyEmployee(postEmp, ActualEmp1);

        }


        public bool VerifyEmployee(Employee emp1, Employee emp2) {
            //Assertions //ActualEmp.firstName === ExpectedEmp.firstName
            return true;
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
