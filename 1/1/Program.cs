using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace _2
{
    [Serializable]
    class Program
    {

        static void Main(string[] args)
        {
            Person obj = new Person();
            obj.city = new City();
            obj.name = "Vybhav";
            obj.age = 22;
            obj.city.name = "Bangalore";
            obj.city.population = 3000000;
            var binaryformat = new BinaryFormatter();
            Stream sh = new FileStream(@"C:\c# training\serial.txt", FileMode.OpenOrCreate, FileAccess.Write);
            binaryformat.Serialize(sh, obj);
            sh.Close();
            Console.WriteLine("Object serialized\n*******************************************");
            sh = new FileStream(@"C:\c# training\serial.txt", FileMode.Open, FileAccess.Read);
            Person person = (Person)binaryformat.Deserialize(sh);
            Console.WriteLine("object deserialized");
            Console.WriteLine(person.name);
            Console.WriteLine(person.age);
            Console.WriteLine(person.city.name);
            Console.WriteLine(person.city.population);
            Console.Read();

        }

    }
    [Serializable]
    class City
    {
        public string name { get; set; }
        public int population { get; set; }

    }

    [Serializable]
    class Person
    {
        public string name { get; set; }
        public int age { get; set; }
        public City city { get; set; }
    }
}
