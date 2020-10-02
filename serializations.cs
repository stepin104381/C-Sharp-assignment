using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;
using SampleConApp;

namespace SampleConApp
{
    [Serializable]
    public class Student
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public long Phone { get; set; }

        public override string ToString()
        {
            return string.Format($"The name: {Name} from {Address} is available at {Phone}");
        }
    }
    class Serialization
    {
        static void Main(string[] args)
        {
            //binaryFile();
            xmlFile();
            Console.ReadKey();
        }

        private static void binaryFile()
        {
            Console.WriteLine("What do U want to do today: Read or Write");
            string choice = Console.ReadLine();
            if (choice.ToLower() == "read")
                deserializing();
            else
                serializing();
        }

        private static void deserializing()
        {
            FileStream fs = new FileStream("Binary.bin", FileMode.Open, FileAccess.Read);
            BinaryFormatter fm = new BinaryFormatter();
            Student stud = fm.Deserialize(fs) as Student;
            Console.WriteLine(stud.Name);
            fs.Close();
        }

        private static void serializing()
        {
           
            Student stud = new Student { Address = "Mysore", Name = "Nisarga", Phone = 23423423 };
            BinaryFormatter fm = new BinaryFormatter();
            FileStream fs = new FileStream("Binary.bin", FileMode.OpenOrCreate, FileAccess.Write);
            fm.Serialize(fs, stud);
            fs.Close();
        }

        private static void xmlFile()
        {
            Console.WriteLine("What do U want to do today: Read or Write");
            string choice = Console.ReadLine();
            if (choice.ToLower() == "read")
                deserializingXml();
            else
                serializingXml();
        }

        private static void deserializingXml()
        {
            try
            {
                XmlSerializer sl = new XmlSerializer(typeof(Student));
                FileStream fs = new FileStream("Xmlfile.xml", FileMode.Open, FileAccess.Read);
                Student stud = (Student)sl.Deserialize(fs);
                Console.WriteLine(stud);
                fs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void serializingXml()
        {
            Student stud = new Student();
            stud.Name = MyConsole.getString("Enter the name");
            stud.Address = MyConsole.getString("Enter the address");
            stud.Phone = MyConsole.getNumber("Enter the landline Phone no");
            FileStream fs = new FileStream("Xmlfile.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer sl = new XmlSerializer(typeof(Student));
            sl.Serialize(fs, stud);
            fs.Flush();//Clears the buffer into the destination so that no unused stream is left over before U close the Stream...
            fs.Close();

        }
    }
}
