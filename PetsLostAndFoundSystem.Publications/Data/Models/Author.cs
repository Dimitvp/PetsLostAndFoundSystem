using System.Collections.Generic;

namespace PetsLostAndFoundSystem.Publications.Data.Models
{
    public class Author
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string UserId { get; set; }

        public ICollection<Article> Articles { get; set; } = new List<Article>();

        public ICollection<Shelter> Shelters { get; set; } = new List<Shelter>();

    }
}
