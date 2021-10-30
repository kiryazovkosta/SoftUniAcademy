namespace Animals
{
    using System;
    using System.Text;

    public class Animal
    {
        private string name;
        private int age;
        private string gender;

        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public string Name 
        { 
            get => this.name;
            set => this.name = value;
        }

        public int Age
        {
            get => this.age;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.age = value;
            } 
        }

        public string Gender
        {
            get => this.gender;
            set => this.gender = value;
        }

        public virtual string ProduceSound()
        {
            return string.Empty;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.GetType().Name);
            sb.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            sb.AppendLine(this.ProduceSound());
            return sb.ToString().TrimEnd();
        }
    }
}