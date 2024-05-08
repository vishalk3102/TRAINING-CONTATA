using System.Text.Json;


namespace Program
{
    public class Program
    {
        public static void Main(string[] args)
        {

            try
            {
                string jsonData = File.ReadAllText("input.json");
                People people = JsonSerializer.Deserialize<People>(jsonData);

                using (StreamWriter sw = new StreamWriter("output.csv"))
                {
                    sw.WriteLine("ID,Name,DOB,Telephone,Email,Description");

                    foreach (var person in people.peopleData)
                    {
                        string csvRow = $"{person._id},{person.name},{person.dob},{person.email},{person.telephone},{person.description}";
                         // string csvRow = $"\"{person._id}\"|\"{person.name}\"|\"{person.dob}\"|\"{person.telephone}\"|\"{person.email}\"|\"{person.description}\"";

                        sw.WriteLine(csvRow);
                    }
                    string csvData = sw.ToString();
                    Console.WriteLine(sw.ToString());
                }
            }
            catch(FileNotFoundException) 
            {
                Console.WriteLine("File Not found");
            }
            catch (IOException e)
            {
                Console.WriteLine($"Error occured while reading file :{e.Message}");
            }
        }
    }

    public class People
    {
        public Person[] peopleData { get; set; }
    }

    public class Person
    {
        public string _id { get; set; }
        public string name { get; set; }
        public DateOnly dob { get; set; }
        public string telephone { get; set; }
        public string email { get; set; }
        public string description { get; set; }

    }
}