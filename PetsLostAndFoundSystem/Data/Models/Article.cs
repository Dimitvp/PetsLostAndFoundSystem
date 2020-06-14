namespace PetsLostAndFoundSystem.Data.Models
{
    public class Article : BasePublications
    {
        public string AuthorId { get; set; }

        public Author Author { get; set; }

    }
}
