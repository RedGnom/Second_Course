using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB10_lib
{
    public class City: Region
    {
        private int population;
        private string cityName = string.Empty;
        public int Population
        {
            get { return population; }
            set
            {
                if (int.TryParse(Console.ReadLine(), out value))
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
                else
                {
                    throw new Exception("Население должно быть числом");
                }
            }
        }
        public string CityName { get { return cityName; } set { cityName = value; } }
        public  City(string name,string cityName, int population): base(name){
            CityName = cityName;
            Population = population;
        }
        public City() : base()
        {
            CityName = ' '.ToString();
            Population = 0;
        }
        public City(City other) : base(other.Name)
        {
            CityName = other.Name;
            Population = other.Population;
        }
        public override void Init()
        {
            base.Init();
            Console.WriteLine("Введите название города: ");
            CityName = Console.ReadLine();
            try
            {
                Console.WriteLine("Введите население: ");
                Population = int.Parse(Console.ReadLine());
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
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
            Console.WriteLine("Город:" + CityName);
            Console.WriteLine("Население" + Population);
        }
        public override bool Equals(object obj)
        {
            if (!base.Equals(obj)) { return false; }
            City other = (City)obj;
            return Population == other.Population;
        }
    }
}
