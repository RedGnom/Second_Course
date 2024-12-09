using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LAB10_lib
{
    

    public class Region: Place
    {
        private List<City> cities = new List<City>();
        //private int amount=0;
        private int totalPopulation;
        public int TotalPopulation
        {
            get { return totalPopulation; }
            
        }
        //public int Amount
        //{
        //    get { return amount; }

        //}
        public List<City> Cities
        {
            get { return cities; }
            set { cities = value ?? new List<City>(); }
        }

        public Region(): base(){ }
        public Region(string country, string name) : base(country, name) { }
        public Region(Region other) : base(other) { }
        
        public void AddCity(City city)
        {
            if (city == null)
            {
                throw new ArgumentNullException(nameof(city), "Город не может быть null");
            }

            if (city is City || city is Megalopolis)
            {
                if (city.Name == Name)
                {
                    Cities.Add(city);
                    totalPopulation += city.Population;
                }
            }
            else
            {
                throw new ArgumentException("Объект должен быть из класса city или megalopolis");
            }
        }
        public void ShowCities()
        {
            foreach (City city in Cities)
            {
                Console.WriteLine(city.CityName);
            }
        }
        public void ShowPopulation()
        {

            Console.WriteLine(TotalPopulation);
        }
        public void ShowAmount()
        {
            Console.WriteLine(Cities.Count);
        }
        public override void Init()
        {
            base.Init();
        }
        public override void RandomInit()
        {
            base.RandomInit();
            string[] randomRegion = new string[] {
    "Архангельская область",
    "Белгородская область",
    "Пермский край",
    "Владимирская область",
    "Воронежская область",
    "Ивановская область",
    "Калининградская область",
    "Калужская область",
    "Костромская область",
    "Курганская область",
    "Ленинградская область",
    "Липецкая область",
    "Мурманская область",
    "Новгородская область",
    "Пензенская область",
    "Рязанская область",
    "Смоленская область",
    "Тамбовская область",
    "Тверская область",
    "Тульская область",
    "Ярославская область",
    "Краснодарский край",
    "Ставропольский край",
    "Хабаровский край",
    "Приморский край",
    "Алтайский край",
    "Амурская область",
    "Астраханская область",
    "Брянская область",
    "Челябинская область",
    "Иркутская область",
    "Кемеровская область",
    "Кировская область",
    "Курская область",
    "Московская область",
    "Нижегородская область",
    "Новосибирская область",
    "Омская область",
    "Оренбургская область",
    "Орловская область",
    "Ростовская область",
    "Самарская область",
    "Саратовская область",
    "Сахалинская область",
    "Свердловская область",
    "Томская область",
    "Тюменская область",
    "Ульяновская область",
    "Волгоградская область",
    "Вологодская область",
    "Ямало-Ненецкий автономный округ"
};


            Name = randomRegion[rnd.Next(randomRegion.Length)];

        }
        public override void Show()
        {
            
            Console.Write("Название области: ");
            base.Show();
            
        }
        public void ShowNonVirtual()
        {
            Console.WriteLine("Название области: " + Name);
            Console.WriteLine("Страна: " + Country);
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj) && obj is Region;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return $"{Country}-{Name}";
        }




        public override Place ShallowCopy()
        {
            return (Region)this.MemberwiseClone();
        }
        public override object Clone()
        {
            Region copy = new Region(this.Country, this.Name);
            foreach (City city in Cities) {
                copy.Cities.Add(city);
            }
            return copy;
        }


    }
}
