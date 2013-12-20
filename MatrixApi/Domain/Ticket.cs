using System;
using NHibernate.Mapping;
using System.Collections.Generic;

namespace MatrixApi.Domain
{
    public class Ticket
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public virtual Priority Priority { get; set; }
        public virtual Status Status { get; set; }
        public virtual DateTime? Deadline { get; set; }
        public virtual User User { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual Project Project { get; set; }
    }
}