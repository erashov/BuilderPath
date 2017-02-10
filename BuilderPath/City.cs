namespace BuilderPath
{
    public class City
    {
        /// <summary>
        /// Название города
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// указывает что данный город не является первоначальным пунктом отправления
        /// </summary>
        public bool IsNotRoot { get; set; }

        public City(string name)
        {

            Name = name;
            IsNotRoot = false;
        }
    }
}
