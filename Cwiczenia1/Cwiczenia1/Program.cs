using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Linq;

namespace Cwiczenia1
{
    public class Student
    {
        private string nazwisko;
        public string getNazwisko()
        {
            return nazwisko;
        }
        public void setNazwisko(string nazwisko)
        {
            this.nazwisko = nazwisko;
        }
    }
    public class Program
    {
        public static async Task Main(string[] args)
        {
            try {
                var url = args.Length > 0 ? args[0] : "https://www.pja.edu.pl";

                var client = new HttpClient();
                var result = await client.GetAsync("https://www.pja.edu.pl");

                if (!result.IsSuccessStatusCode)
                {
                    Console.WriteLine("Server Error");
                    return;
                }
                string html = await result.Content.ReadAsStringAsync();
                var regex = new Regex("[a-z]+[a-z0-9]*@[a-z.]+");
                var matches = regex.Matches(html);

                //kolekcje
                var set = new HashSet<string>();
                var list = new List<string>();
                //LINQ
                var elementy = from e in list
                               where e.StartsWith("A")
                               select e;
                var elementy2 = list.Where(s => s.StartsWith("A"));

                var slownik = new Dictionary<string, string>();

                foreach (var m in matches)
                {
                    Console.WriteLine(m);
                }
            } catch(Exception exc)
            {
                //string.Format("Wystapil blad {0}", exc.ToString());
                Console.WriteLine($"Wystapi błąd {exc.ToString()}");
            }

            Console.WriteLine("Koniec!");
            }
    }
}