namespace DefiningClasses
{
    public class Family
    {
        private List<Person> people;

        public Family()
        {
            people = new List<Person>();
        }

        public List<Person> People
        {
            get
            {
                return this.people;
            }
            set
            {
                this.People = value;
            }
        }

        public void AddMember(Person person)
        {
            this.People.Add(person);
        }

        public Person GetOldestMember()
        {
            return this.People.MaxBy(p => p.Age);
        }
    }
}