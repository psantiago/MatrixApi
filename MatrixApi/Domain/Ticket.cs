﻿using System;
using NHibernate.Mapping;
using System.Collections.Generic;

namespace MatrixApi.Domain
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
        public DateTime? Deadline { get; set; }
        public User User { get; set; }

        public List<Comment> Comments { get; set; }
    }
}