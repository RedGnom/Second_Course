﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB10_lib
{
    [Serializable]
    public class Megalopolis: City
    {
        private int pollution;
        public int Pollution
        {
            get { return pollution; }
            set
            {
                if (value >= 0)
                {
                    pollution = value;
                }
                else
                {
                    throw new Exception("Загрязнение не может быть меньше 0");
                }
            }
        }


        public Megalopolis(string country, string name, string cityName, int population, int pollution) : base(country, name, cityName, population)
        {
            Pollution = pollution;
        }
        public Megalopolis() : base() { Pollution = 0; }
        public Megalopolis(Megalopolis other) : base(other.Country,other.Name, other.CityName, other.Population) {
            Pollution = other.Pollution;
        }
        public override void Show()
        {

            base.Show();
            Console.WriteLine("Загрязнение воздуха: " + Pollution);

        }
        public override void Init()
        {
            base.Init();
            try
            {
                Console.WriteLine("Введите загрязнение: ");
                Pollution = int.Parse(Console.ReadLine());
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        public override void RandomInit()
        {
            base.RandomInit();
            Pollution = rnd.Next(1,100);
        }
        public override bool Equals(object obj)
        {
            if (!base.Equals(obj)) { return false; }
            Megalopolis other = (Megalopolis)obj;
            return (Pollution == other.Pollution);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override Place ShallowCopy()
        {
            return (Megalopolis)this.MemberwiseClone();
        }
        public override object Clone()
        {
            return new Megalopolis(Country, Name, CityName, Population, Pollution);

        }
    }
}
