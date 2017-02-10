using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BuilderPath
{
    public class BuildPath
    {
        /// <summary>
        /// В этом списке будут храниться все уникальные города из цепочки маршрутов
        /// </summary>
        public List<City> Cities { get; set; }

        /// <summary>
        /// Список всех цепочек маршрутов
        /// </summary>
        public List<Direction> Directions { get; set; }
        public string[] Lines { get; set; }
        public string result;

        public BuildPath()
        {

            Cities = new List<City>();
            Directions = new List<Direction>();
            ReadFile();
            Filling();
            var root = Cities.FirstOrDefault(c => c.IsNotRoot == false);//определяем изначальный пункт отправления
            if (root != null)
            {
                WalkPath(root, Directions);
            }

            Console.WriteLine(result);
        }
        public BuildPath(string[] lines)
        {

            Cities = new List<City>();
            Directions = new List<Direction>();
            Lines = lines; ;
            Filling();
            var root = Cities.FirstOrDefault(c => c.IsNotRoot == false);//определяем изначальный пункт отправления
            if (root != null)
            {
                WalkPath(root, Directions);
            }
            Console.WriteLine(result);
        }

        /// <summary>
        /// загружаются данные из файла input.txt
        /// </summary>
        void ReadFile()
        {

            try
            {
                using (var streamReader = File.OpenText("input.txt"))
                {
                    Lines = streamReader.ReadToEnd().Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                }
            }
            catch (FileNotFoundException ex)
            {             
                Console.WriteLine("Не удалось найти файл");
                Console.ReadLine();           
            }
        }
        /// <summary>
        /// В этом закрытом методе заполняются списки Cities, Directions данными из файла input.txt
        /// </summary>
        void Filling()
        {
            if (Lines != null)
            {
                foreach (var line in Lines)
                {
                    var split = line.Replace(" ", string.Empty).Replace("\"", string.Empty).Split('→');
                    City cityFrom = new City(split.First());
                    City cityTo = new City(split.Last());

                    if (!Cities.Any(c => c.Name == cityFrom.Name))
                    {
                        Cities.Add(cityFrom);
                    }
                    if (!Cities.Any(c => c.Name == cityTo.Name))
                    {
                        // здесь указывется что данный город не является точкой отсчета т.к. он является пунктом назначения на данном этапе
                        cityTo.IsNotRoot = true;
                        Cities.Add(cityTo);
                    }
                    else
                    {
                        //этот город был пунктом откправления но в данном случае он является пунктом назначения
                        Cities.FirstOrDefault(c => c.Name == cityTo.Name).IsNotRoot = true;
                    }
                    Directions.Add(new Direction(cityFrom, cityTo));
                }
            }
        }

        /// <summary>
        /// Рекурсивный перебор маршрутов.
        /// </summary>
        /// <param name="city">Город из которого строиться маршрут</param>
        /// <param name="directions">набор маршрутов</param>
        void WalkPath(City city, List<Direction> directions)
        {
            var direct = directions.FirstOrDefault(c => c.From.Name == city.Name);
            if (direct != null)
            {
                result += $"{(result != null ? ", " : string.Empty)}{city.Name} → {direct.To.Name}";

                WalkPath(direct.To, directions);
            }

        }
    }
}
