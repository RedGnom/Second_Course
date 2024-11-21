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
        
        
        public Region(): base(){ }
        public Region(string name) : base(name) { }
        public Region(Region other) : base(other) { }
        public override void Init()
        {
            Console.WriteLine("Введите название области: ");
            Name = Console.ReadLine(); 
        }

        public override void RandomInit()
        {
            string[] randomRegion = new string[] {
                "Архангельская область",
                "Белгородская область",
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
                "Пермский край"
            };
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

    }
}
