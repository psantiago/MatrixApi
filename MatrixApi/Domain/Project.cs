using System;
using System.Collections.Generic;
using NHibernate.Mapping;

namespace MatrixApi.Domain
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
        public DateTime? Deadline { get; set; }
        public List<Ticket> Tickets { get; set; }
    }
}