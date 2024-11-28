using System;

namespace LAB10_lib
{
    public interface IInit
    {
        void Init();
        void RandomInit();
        void Show();
    }
    public class Place: IInit, IComparable<Place>, ICloneable
    {
        private string country = string.Empty;
        private string name = string.Empty;
        protected Random rnd = new Random();
        public string Country
        {
            get { return country; }
            set { country = value; }
        }
        public  string Name {
            get { return name; }
            set { name = value; }
        }
        public Place(string country, string name) {
            Country = country;
            Name = name;
        }
        public Place() {
            Country = string.Empty;
            Name = ' '.ToString();
        }
        public Place(Place other)
        {
            Country = other.Country;
            Name = other.Name;
        }
        public virtual void Show()
        {
            
            Console.WriteLine(Name);
            Console.Write("Страна: ");
            Console.WriteLine(Country);
        }
        public virtual void Init()
        {
            Console.WriteLine("Введите страну: ");
            Country = Console.ReadLine();
            Console.WriteLine("Введите место: ");
            Name = Console.ReadLine();
        }
        public virtual void RandomInit()
        {
            string[] randomCountry = new string[] {
                "Россия",
                "Мозамбик",
                "Уганда"
            };
            Country = randomCountry[rnd.Next(randomCountry.Length)];
            Name = "Место" + (rnd.Next(1,100)).ToString();
        }
        public int CompareTo(Place other)
        {
            if (other == null) return 1;
            return Country.CompareTo(other.Country);
        }


        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Place other))
            {
                return false;
            }

            // Сравнение свойств для Place
            return Country == other.Country && Name == other.Name;
        }

        public override int GetHashCode()
        {
            return (Country, Name).GetHashCode();
        }
        public virtual Place ShallowCopy() //поверхностное копирование
        {
            return (Place)this.MemberwiseClone();
        }
        public virtual object Clone()
        {
            return new Place(this.country, this.name );
        }



    }
}
