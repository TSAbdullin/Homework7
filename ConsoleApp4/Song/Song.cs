namespace Homework7.Song
{
    internal class Song
    {
        private string _name; //название песни
        private string _author; //автор песни
        private Song _prev; //связь с предыдущей песней в списке

        public Song(string name, string author, Song prev = null)
        {
            _name = name;
            _author = author;
            _prev = prev;
        }

        /// <summary>
        /// Метод для заполнения поля название песни
        /// </summary>
        /// <param name="Name"></param>
        public void SetName(string Name) => _name = Name;

        /// <summary>
        /// Метод для получения приватного поля имени
        /// </summary>
        /// <returns></returns>
        public string GetName() => _name;

        /// <summary>
        /// Метод для заполнения поля author
        /// </summary>
        /// <param name="Author"></param>
        public void SetAuthor(string Author) => _author = Author;  

        /// <summary>
        /// Метод для получения приватного поля автора
        /// </summary>
        /// <returns></returns>
        public string GetAuthor() => _author;

        /// <summary>
        /// Метод для заполнения поля prev
        /// </summary>
        /// <param name="Prev"></param>
        public void SetPrev(Song Prev) => _prev = Prev;

        /// <summary>
        /// Метод для получения предыдущей песни
        /// </summary>
        /// <returns></returns>
        public Song GetPrev() => _prev;

        /// <summary>
        /// Метод для печати названия песни и ее исполнителя
        /// </summary>
        public void PrintInfo() 
        {
            Console.WriteLine($"Название песни: {_name}\nАвтор песни: {_author}\n");
        }

        /// <summary>
        /// Метод, который возвращает название песни + автора
        /// </summary>
        /// <returns></returns>
        public string Title()
        {
            return $"{_name} - {_author}";
        }
        
        public override bool Equals(object d) 
        {
            var song = d as Song;
            if (song is null)
            {
                return false;
            }

            return string.Equals(song.GetAuthor(), GetAuthor(), StringComparison.Ordinal)
                && string.Equals(song.GetName(), GetName(), StringComparison.Ordinal);
        }

    }
}
