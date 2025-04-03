using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB10_lib
{
    [Serializable]
    public class City: Region
    {
        private int population;
        private string cityName = string.Empty;
        private Region region;
        public int Population
        {
            get { return population; }
            set
            {
                if (value >= 0)
                {
                    population = value;
                }
                else
                {
                    throw new Exception("Население не может быть меньше 0");
                }
            }
        }
        public Region BaseRegion
        {
            get
            {
                return new Region(Country, Name);
            }

        }


        public string CityName { get { return cityName; } set { cityName = value; } }
        public  City(string country,string name,string cityName, int population): base(country, name){
            CityName = cityName;
            Population = population;
        }
        public City() : base()
        {
            CityName = ' '.ToString();
            Population = 0;
        }
        public City(City other) : base(other.Country,other.Name)
        {
            CityName = other.CityName;
            Population = other.Population;
        }

        
        public override void Init()
        {
            base.Init();

            Console.WriteLine("Введите название города: ");
            CityName = Console.ReadLine();

            Console.WriteLine("Введите население: ");
            try
            {
                Population = int.Parse(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public override void RandomInit()
        {
            base.RandomInit();
            string[] randomCity = new string[] {
                "Москва",
                "Санкт-Петербург",
                "Новосибирск",
                "Екатеринбург",
                "Казань",
                "Нижний Новгород",
                "Челябинск",
                "Самара",
                "Омск",
                "Ростов-на-Дону",
                "Уфа",
                "Красноярск",
                "Воронеж",
                "Пермь",
                "Волгоград",
                "Краснодар",
                "Саратов",
                "Тюмень",
                "Тольятти",
                "Ижевск",
                "Барнаул",
                "Ульяновск",
                "Иркутск",
                "Хабаровск",
                "Ярославль",
                "Владивосток",
                "Махачкала",
                "Томск",
                "Оренбург",
                "Кемерово"
            };

            CityName = randomCity[rnd.Next(randomCity.Length)];
            Population = rnd.Next(1, 10000000);
        }
        public override void Show()
        {
            
            base.Show();
            Console.WriteLine("Город: " + CityName);
            Console.WriteLine("Население: " + Population);

        }
        public new void ShowNonVirtual()
        {
            Console.WriteLine("Название области: " + Name);
            Console.WriteLine("Страна: " + Country);
            Console.WriteLine("Город: " + CityName);
            Console.WriteLine("Население: " + Population);
        }
        public override bool Equals(object obj)
        {
            if (!base.Equals(obj))
                return false;

            if (obj is not City other)
                return false;

            return Population == other.Population && CityName == other.CityName;
        }

        public override int GetHashCode()
        {
            return (Country, Name, Population, CityName).GetHashCode();
        }
        public override string ToString()
        {
            return $"{base.ToString()}-{CityName}-{Population}";
        }




        public override Place ShallowCopy()
        {
            return (City)this.MemberwiseClone();
        }
        public override object Clone()
        {
            return new City(Country, Name, CityName, Population);
            
        }
    }
}
