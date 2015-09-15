﻿using Orchard.ContentManagement.Records;
using System;

namespace Airbrush.Models
{
    public class ContactFormEntry : ContentPartRecord
    {
        public virtual string Name { get; set; }
        public virtual string Email { get; set; }
        public virtual string Subject { get; set; }
        public virtual string MessageBody { get; set; }
        public virtual DateTime CreatedUtc { get; set; }
    }
}