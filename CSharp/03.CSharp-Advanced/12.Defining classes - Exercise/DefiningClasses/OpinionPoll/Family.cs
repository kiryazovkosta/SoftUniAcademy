namespace DefiningClasses
{
    using System.Collections.Generic;
    using System.Linq;

    public class Family
    {
        private ICollection<Person> persons;

        public Family()
        {
            this.Persons = new HashSet<Person>();
        }

        private ICollection<Person> Persons
        {
            get => this.persons;
            set => this.persons = value;
        }

        public void AddMember(Person member)
        {
            this.Persons.Add(member);
        }

        public ICollection<Person> GetOlderMembers(int age)
        {
            return this.Persons.Where(p => p.Age > age).OrderBy(p => p.Name).ToList();
        }

        public Person GetOldestMember()
        {
            return this.Persons.OrderByDescending(p => p.Age).FirstOrDefault();
        }
    }
}
