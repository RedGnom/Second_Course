namespace LAB10_lib
{
    public class Place
    {
        private string name = string.Empty;
        protected Random rnd = new Random();
        public  string Name {
            get { return name; }
            set { name = value; }
        }
        public Place(string name) {
            Name = name;
        }
        public Place() {
            Name = ' '.ToString();
        }
        public Place(Place other)
        {
            Name = other.Name;
        }
        public virtual void Show()
        {
            Console.WriteLine(Name);
        }
        public virtual void Init()
        {
            Console.WriteLine("Введите место: ");
            Name = Console.ReadLine();
        }
        public virtual void RandomInit()
        {
            Name = "Место" + (rnd.Next(1,100)).ToString();
        }
        public override bool Equals(object obj)
        {
            // Общая логика проверки
            if (obj == null || !(obj is Place other))
            {
                return false;
            }
            // Сравнение свойств для Place
            return Name == other.Name;
        }

    }
}
