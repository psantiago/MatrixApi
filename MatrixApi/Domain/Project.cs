using System;
using System.Collections.Generic;
using NHibernate.Mapping;

namespace MatrixApi.Domain
{
    public class Project
    {
        private IList<Ticket> _tickets = new List<Ticket>();

        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public virtual Priority Priority { get; set; }
        public virtual Status Status { get; set; }
        public virtual DateTime? Deadline { get; set; }

        public virtual IList<Ticket> Tickets
        {
            get { return _tickets; }
            set { _tickets = value; }
        }
    }
}