using System;
using System.Collections.Immutable;
using System.Numerics;
using LAB10_lib;
using LAB11;

class Program
{
    static void Main(string[] args)
    {
        TestCollections test = new TestCollections();
        test.ShowCollections();
        //test.RemoveFirstElement();
        //test.ShowCollections();
        //City city = new City();
        //city.RandomInit();
        //test.AddElem(city);
        //test.ShowCollections();
        test.FindTimeCollections();
    }
}