namespace WebApplication1
{
    public class PeopleService
    {
        public People People
        {
            get
            {
                if (people == null)
                {
                    people = new People { new Person { Name = "Adam", Title = "Nörd" }, new Person { Name = "Lennart", Title = "Geek" } };
                }
                return people;
            }
        }
        private People people;
    }
}
