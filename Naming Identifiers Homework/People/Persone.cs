namespace People
{
    class Persone
    {
        public Persone()
        {

        }

        public Gender Gender { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public Persone ConfigurePersone(int id)
        {
            Persone currentPersone = new Persone();
            currentPersone.Age = id;
            if (id % 2 == 0)
            {
                currentPersone.Name = "Батката";
                currentPersone.Gender = Gender.male;
            }
            else
            {
                currentPersone.Name = "Мацето";
                currentPersone.Gender = Gender.female;
            }

            return currentPersone;
        }

        public override string ToString()
        {
            return "Name: "+this.Name + " Gender: " + this.Gender + " Age: " + this.Age;
        }
    }

}