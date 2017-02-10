using BuilderPath;

namespace BuilderPath
{
    public class Direction
    {
        /// <summary>
        /// Пункт отправления
        /// </summary>
        public City From { get; set; }

        /// <summary>
        /// Пункт назначения
        /// </summary>
        public City To { get; set; }


        public Direction(City from, City to)
        {
            From = from;
            To = to;
        }
    }
}
