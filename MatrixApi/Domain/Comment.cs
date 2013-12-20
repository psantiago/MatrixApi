using System;

namespace MatrixApi.Domain
{
    public class Comment
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public User User { get; set; }
        public Ticket Ticket { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}