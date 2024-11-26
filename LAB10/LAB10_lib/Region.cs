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
            foreach (City city in Cities)
            {
                totalPopulation += city.Population;
            }
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
                "Пермский край"
            };
            //"Владимирская область",
            //    "Воронежская область",
            //    "Ивановская область",
            //    "Калининградская область",
            //    "Калужская область",
            //    "Костромская область",
            //    "Курганская область",
            //    "Ленинградская область",
            //    "Липецкая область",
            //    "Мурманская область",
            //    "Новгородская область",
            //    "Пензенская область",
            //    "Рязанская область",
            //    "Смоленская область",
            //    "Тамбовская область",
            //    "Тверская область",
            //    "Тульская область",
            //    "Ярославская область",
            //    "Краснодарский край",
            //    "Ставропольский край",
            //    "Хабаровский край",
            //    "Приморский край",
            //    "Алтайский край",
            Name = randomRegion[rnd.Next(randomRegion.Length)];

        }
        public override void Show()
        {
            
            Console.Write("Название области: ");
            base.Show();
            
        }
        public override bool Equals(object obj)
        {
            // Вызов метода базового класса для общей логики
            if (!base.Equals(obj)) return false;
            // Упрощенная проверка на тип Region
            if (obj is not Region other) return false; // Проверка на тип и приведение
            // Сравнение дополнительных свойств
            return Name == other.Name;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
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
