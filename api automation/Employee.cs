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


        // public Apartments apartments { get; set; }
    }
}