using System;
using System.Collections.Generic;
using NHibernate.Mapping;

namespace MatrixApi.Domain
{
    public class Project
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public virtual Priority Priority { get; set; }
        public virtual Status Status { get; set; }
        public virtual DateTime? Deadline { get; set; }
        public virtual List<Ticket> Tickets { get; set; }
    }
}