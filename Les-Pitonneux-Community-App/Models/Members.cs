using System;


namespace LesPitonneuxCommunityApp
{
    public class Member : Person
    {
        public Member()
        {
        }

        enum ProgrammingLanguage
        {
            Cplusplus,
            Csharp,
            Java,
            JavaScript,
            Html,
            CSS,
            Android,
            iOS,
            Angular,
            PHP,

        };

		public override string ToString()
		{
			return "Id = " + Id + 
                   "FirstName = " + FirstName + 
                   " LastName = " + LastName + 
                   "City = " + City +
                   "State = " + State +
                   "Email ="  + Email;
		}
    }
	
}
