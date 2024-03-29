﻿using MongoDB.Bson.Serialization.Attributes;

namespace WebApp.MODELS.Data
{
    public class Book
    {
        [BsonId]
        [BsonElement("_id")]
        public Guid Id { get; set; }

        public string Title { get; set; }

        public Guid AuthorId { get; set; }

        public string Description { get; set; }
    }
}
