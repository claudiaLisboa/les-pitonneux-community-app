using System;


namespace LesPitonneuxCommunityApp
{
    public class Person
    {
        public Person()
        {
        }

		public int Id { get; set; }
		public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Email { get; set; }

    }
}
