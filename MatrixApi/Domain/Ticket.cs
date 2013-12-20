using System;
using NHibernate.Mapping;
using System.Collections.Generic;

namespace MatrixApi.Domain
{
    public class Ticket
    {
        private IList<Comment> _comments = new List<Comment>();

        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public virtual Priority Priority { get; set; }
        public virtual Status Status { get; set; }
        public virtual DateTime? Deadline { get; set; }
        public virtual User User { get; set; }
        public virtual IList<Comment> Comments
        {
            get { return _comments; }
            set { _comments = value; }
        }
        public virtual Project Project { get; set; }
        public virtual int ProjectId { get; set; }
    }
}