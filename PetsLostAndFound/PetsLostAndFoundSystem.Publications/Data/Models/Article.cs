﻿using PetsLostAndFoundSystem.Data.Models;

namespace PetsLostAndFoundSystem.Publications.Data.Models
{
    public class Article : BasePublications
    {
        public int AuthorId { get; set; }

        public Author Author { get; set; }

    }
}
