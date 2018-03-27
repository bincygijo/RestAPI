using api_automation;
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
    public class Class1
    {
        public string url = "http://localhost:8080/landlords";

       // public string postData = "{\"firstName\": \"test\", \"lastName\": \"george\", \"trusted\": false}";
       
        public IRestResponse Post(String data) {
            RestClient client = new RestClient(url);
            RestRequest request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");

            request.AddParameter("application/json", data, ParameterType.RequestBody);

          // request.AddBody(postData);

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
      
        public IRestResponse Put(string Id)
        {
            var client = new RestClient(url + "/" + Id);
            var request1 = new RestRequest(Method.PUT);
            request1.AddHeader("Content-Type", "application/json");
            IRestResponse response1 = client.Execute(request1);
            //  Console.Error.WriteLine(response.Content);
            return response1;
        }

        [Test]
           public void TestPost() {

            Employee postEmp = new Employee("test123","test34", true);

            string jsonData = JsonConvert.SerializeObject(postEmp);

           //Employee ExpectedEmp = JsonConvert.DeserializeObject<Employee>(jsonData);

            //Post
            var responsePost = Post(jsonData);
            Employee ActualEmp = JsonConvert.DeserializeObject<Employee>(responsePost.Content);
            //VerifyEmployee(postEmp, ActualEmp);
            Console.Error.WriteLine(responsePost.Content);
           // ActualEmp.firstName == ExpectedEmp.firstName;
          //  Assert.IsTrue(responsePost.StatusCode == HttpStatusCode.Created);
                 


            //Get
            var responseGet = Get(ActualEmp.id);
            Employee ActualEmp1 = JsonConvert.DeserializeObject<Employee>(responseGet.Content);
          //  VerifyEmployee(postEmp, ActualEmp1);
           // ActualEmp1.firstName = postEmp.firstName;
            Console.Error.WriteLine(responseGet.Content);

         //   Assert.IsTrue(responsePost.StatusCode == HttpStatusCode.OK);

        }


        [Test]
        public void TestPut()
        {
            Employee ExpEmp = new Employee("aa", "tt1", true);
            string jsonData = JsonConvert.SerializeObject(ExpEmp);

            //Post
            var responsePost = Post(jsonData);
            Employee ActualEmp = JsonConvert.DeserializeObject<Employee>(responsePost.Content);
            //VerifyEmployee(postEmp, ActualEmp);
            Console.Error.WriteLine(responsePost.Content);
            // ActualEmp.firstName == ExpectedEmp.firstName;
          


            //Get
            var responsePutGet = Get(ActualEmp.id);
            Employee ActualEmp2 = JsonConvert.DeserializeObject<Employee>(responsePutGet.Content);
            //  VerifyEmployee(postEmp, ActualEmp1);
            // ActualEmp1.firstName = postEmp.firstName;
            Console.Error.WriteLine(responsePutGet.Content);
            Console.Error.WriteLine(ActualEmp2.id);
            //Assert.IsTrue(responsePutGet.StatusCode == HttpStatusCode.OK);

            //Put
            
           
            //Employee ExpE = new Employee( "aa","ss",false);
            //var responsePut = Put( ExpE);
            //Console.Error.WriteLine("id====" + ActualEmp2.id);
            //string jsonData1 = JsonConvert.SerializeObject(ExpE);
            //var response_up = Put(jsonData1);
            //Employee ActualEm = JsonConvert.DeserializeObject<Employee>(response_up.Content);
            //Console.Error.WriteLine(response_up.Content);
        }

        //public bool VerifyEmployee(Employee emp1, Employee emp2) {

        //    // Assertions 

        //    // ActualEmp.firstName = ExpectedEmp.firstName;
        //   // ActualEmp1.firstName = postEmp.firstName;
        //   // Assert.IsTrue(responsePost.StatusCode == HttpStatusCode.OK);
        //    //return true;
        //}


    }
}
