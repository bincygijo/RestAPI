using Newtonsoft.Json;
using NUnit.Framework;
using api_automation.API;
using System;


namespace api_automation
{
   public class APITest
    {

        Landlord landlord;

        [SetUp]
        public void Setup() {
            landlord = new Landlord();
        }

        [TearDown]
        public void Distroy() {
            landlord = null;
        }


        [TestCase("Firsn", "asdfsadf", true)]
        [TestCase("Firsn", "addsdfsadf", true)]
        [TestCase("Firdddsn", "asdfsadf", true)]
        public void TestCreate(string fname, string lname,bool trusted)
        {

            Employee postEmp = new Employee(fname, lname, trusted);
            string jsonData = JsonConvert.SerializeObject(postEmp);

            //Post

            var responsePost = landlord.Post(jsonData);
            Employee ActualEmp = JsonConvert.DeserializeObject<Employee>(responsePost.Content);
            Console.Error.WriteLine(responsePost.Content);
            // ActualEmp.firstName = "Ravi";
            Employee.CompareEmployees(postEmp, ActualEmp);

            //Get
            var responseGet = landlord.Get(ActualEmp.id);
            Employee ActualEmp1 = JsonConvert.DeserializeObject<Employee>(responseGet.Content);
            Console.Error.WriteLine(responseGet.Content);
            Employee.CompareEmployees(postEmp, ActualEmp1);

        }



        [Test]
        public void TestCreate()
        {

            Employee postEmp = new Employee("m", "mm", true);
            string jsonData = JsonConvert.SerializeObject(postEmp);

           //Post
         
            var responsePost = landlord.Post(jsonData);
            Employee ActualEmp = JsonConvert.DeserializeObject<Employee>(responsePost.Content);
            Console.Error.WriteLine(responsePost.Content);
            // ActualEmp.firstName = "Ravi";
            Employee.CompareEmployees(postEmp, ActualEmp);

            //Get
            var responseGet = landlord.Get(ActualEmp.id);
            Employee ActualEmp1 = JsonConvert.DeserializeObject<Employee>(responseGet.Content);
            Console.Error.WriteLine(responseGet.Content);
            Employee.CompareEmployees(postEmp, ActualEmp1);

        }

     

        [Test]
        public void TestDelete()
        {
            Employee ExpEmp = new Employee("hh", "hh", true);
            string jsonData = JsonConvert.SerializeObject(ExpEmp);

            //Post
            var responsePost = landlord.Post(jsonData);
            Employee ActualEmp = JsonConvert.DeserializeObject<Employee>(responsePost.Content);
            Console.Error.WriteLine(responsePost.Content);

            //Get
            var ResponseGet = landlord.Get(ActualEmp.id);
            Employee ActualEmp2 = JsonConvert.DeserializeObject<Employee>(ResponseGet.Content);
            Console.Error.WriteLine(ResponseGet.Content);


            //Delete
            var ResponseDelete = landlord.Delete(ActualEmp2.id);

            Employee ActualEmp3 = JsonConvert.DeserializeObject<Employee>(ResponseDelete.Content);
            Console.Error.WriteLine(ResponseDelete.Content);


        }

        [Test]
        public void TestUpdate()
        {
            Employee ExpEmp = new Employee("s", "ss", true);
            string jsonData = JsonConvert.SerializeObject(ExpEmp);

            //Post
            var responsePost = landlord.Post(jsonData);
            Employee ActualEmp = JsonConvert.DeserializeObject<Employee>(responsePost.Content);
            Console.Error.WriteLine(responsePost.Content);
            
            //Get
            var ResponseGet = landlord.Get(ActualEmp.id);
            Employee ActualEmp2 = JsonConvert.DeserializeObject<Employee>(ResponseGet.Content);
            Console.Error.WriteLine(ResponseGet.Content);


            //Put
            Employee ExpEmp1 = new Employee("s", "ccc", true);
            string jsonData1 = JsonConvert.SerializeObject(ExpEmp1);
            var ResponsePut = landlord.Put(ActualEmp2.id, jsonData1);

            Employee ActualEmp3 = JsonConvert.DeserializeObject<Employee>(ResponsePut.Content);
            Console.Error.WriteLine(ResponsePut.Content);

           
        }
    }
}
