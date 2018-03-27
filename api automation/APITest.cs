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
   public class APITest
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
        public IRestResponse Put(string Id,string data)
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


        [Test]
        public void TestCreate()
        {

            Employee postEmp = new Employee("m", "mm", true);
            string jsonData = JsonConvert.SerializeObject(postEmp);

           //Post
            var responsePost = Post(jsonData);
            Employee ActualEmp = JsonConvert.DeserializeObject<Employee>(responsePost.Content);
            Console.Error.WriteLine(responsePost.Content);
            Assert.IsTrue(Employee.Equals(postEmp, ActualEmp));
            //Get
            var responseGet = Get(ActualEmp.id);
            Employee ActualEmp1 = JsonConvert.DeserializeObject<Employee>(responseGet.Content);
            Console.Error.WriteLine(responseGet.Content);
            Assert.IsTrue(Employee.Equals(postEmp, ActualEmp1));

        }

        [Test]
        public void TestDelete()
        {
            Employee ExpEmp = new Employee("hh", "hh", true);
            string jsonData = JsonConvert.SerializeObject(ExpEmp);

            //Post
            var responsePost = Post(jsonData);
            Employee ActualEmp = JsonConvert.DeserializeObject<Employee>(responsePost.Content);
            Console.Error.WriteLine(responsePost.Content);

            //Get
            var ResponseGet = Get(ActualEmp.id);
            Employee ActualEmp2 = JsonConvert.DeserializeObject<Employee>(ResponseGet.Content);
            Console.Error.WriteLine(ResponseGet.Content);


            //Delete
            var ResponseDelete = Delete(ActualEmp2.id);

            Employee ActualEmp3 = JsonConvert.DeserializeObject<Employee>(ResponseDelete.Content);
            Console.Error.WriteLine(ResponseDelete.Content);


        }

        [Test]
        public void TestUpdate()
        {
            Employee ExpEmp = new Employee("s", "ss", true);
            string jsonData = JsonConvert.SerializeObject(ExpEmp);

            //Post
            var responsePost = Post(jsonData);
            Employee ActualEmp = JsonConvert.DeserializeObject<Employee>(responsePost.Content);
            Console.Error.WriteLine(responsePost.Content);
            
            //Get
            var ResponseGet = Get(ActualEmp.id);
            Employee ActualEmp2 = JsonConvert.DeserializeObject<Employee>(ResponseGet.Content);
            Console.Error.WriteLine(ResponseGet.Content);


            //Put
            Employee ExpEmp1 = new Employee("s", "ccc", true);
            string jsonData1 = JsonConvert.SerializeObject(ExpEmp1);
            var ResponsePut = Put(ActualEmp2.id, jsonData1);

            Employee ActualEmp3 = JsonConvert.DeserializeObject<Employee>(ResponsePut.Content);
            Console.Error.WriteLine(ResponsePut.Content);

           
        }
    }
}
