using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB10_lib
{
    public class Address: City
    {
        private int house;
        private int flat;
        private string street =  string.Empty;
        public int House
        {
            get { return house; }
            set
            {

                    if (value >= 0)
                    {
                        house = value;
                    }
                    else
                    {
                        throw new Exception("Номер дома не может быть меньше 0");
                    }
                
            }
        }
        public int Flat
        {
            get { return flat; }
            set
            {
                    if (value >= 0)
                    {
                        flat = value;
                    }
                    else
                    {
                        throw new Exception("Номер квартиры не может быть меньше 0");
                    }
                
            }
        }
        public string Street { get { return street; } set { street = value; } }
        public Address(string country,string name, string cityName, int population, int house, int flat, string street) : base(country, name, cityName, 0)
        {
            House = house;
            Flat = flat;
            Street = street;
        }
        public Address(Address other): base(other)
        {
            House = other.House;
            Flat = other.Flat;
            Street = other.Street;
        }
        public Address(): base()
        {
            House = 0;
            Flat = 0;
            Street = ' '.ToString();
        }
        public override void Init()
        {
            base.Init();
            try
            {
                Console.WriteLine("Введите номер дома: ");
                House = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите номер квартиры: ");
                Flat = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите улицу: ");
                Street = Console.ReadLine();
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }
        public override void RandomInit()
        {
            base.RandomInit();
            House = rnd.Next(1, 200);
            Flat = rnd.Next(1, 110);
            string[] randomStreet = new string[] {
                "Ленина",
                "Кирова",
                "Советская",
                "Победы",
                "Мира",
                "Гагарина",
                "Пушкина",
                "Лермонтова",
                "Октябрьская",
                "Заречная",
                "Комсомольская",
                "Парковая",
                "Лесная",
                "Центральная",
                "Набережная",
                "Солнечная",
                "Школьная",
                "Строителей",
                "Рабочая",
                "Южная",
                "Северная",
                "Восточная",
                "Западная",
                "Пролетарская",
                "Молодежная",
                "Зеленая",
                "Горького",
                "Новоселов",
                "Первомайская",
                "Революционная"
            };
            Street = randomStreet[rnd.Next(randomStreet.Length)];

        }
        public override void Show()
        {
            base.Show();
            Console.WriteLine("Улица: " + Street);
            Console.WriteLine("Дом: " + House);
            Console.WriteLine("Квартира " + Flat);
            
        }
        public override bool Equals(object obj)
        {
            if (!base.Equals(obj)) { return false; }
            Address other = (Address)obj;
            return ((Street == other.Street)&&(House==other.House)&&(Flat==other.Flat));
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override Place ShallowCopy()
        {
            return (Address)this.MemberwiseClone();
        }
        public override object Clone()
        {
            return new Address(Country, Name, CityName, Population, House, Flat, Street);
        }
    }
}
