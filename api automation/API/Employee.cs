using NUnit.Framework;

namespace api_automation
{
    public class Employee
    {
      public string firstName { get  ; set; }
        public string lastName { get; set; }
        public bool trusted { get; set; }
        public string id { get; set; }

        public Employee( string firstName, string lastName, bool trusted)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.trusted = trusted;
           
        }

        public Employee()
        {
        }

        public static void CompareEmployees(Employee actual, Employee expected)
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(actual.firstName, expected.firstName);
                Assert.AreEqual(actual.lastName, expected.lastName);
                Assert.AreEqual(actual.trusted, expected.trusted);
            });
        }
        // public Apartments apartments { get; set; }
    }
}