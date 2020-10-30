using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using System.Xml.Serialization;

namespace CMDSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteXML();
        }

        static void WriteXML()
        {
            IList<Person> personCollection = new List<Person>();
            Person person1 = new Person
            {
                FirstName = "Andrew",
                LastName = "Young"
            };
            Person person2 = new Person
            {
                FirstName = "Austin",
                LastName = "Snyder"
            };
            Person person3 = new Person
            {
                FirstName = "Bruce",
                LastName = "Wayne"
            };
            personCollection.Add(person1);
            personCollection.Add(person2);
            personCollection.Add(person3);

            XmlSerializer writer = new XmlSerializer(personCollection.GetType(), new XmlRootAttribute("Population"));
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "//SerializationOverview.xml";
            System.IO.FileStream file = System.IO.File.Create(path);

            writer.Serialize(file, personCollection);
            file.Close();
        }
    }
}
