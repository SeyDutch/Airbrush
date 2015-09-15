using System;

namespace Airbrush.ViewModels
{
    public class ContactFormEntryViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string MessageBody { get; set; }
        public DateTime CreatedUtc { get; set; }
    }
}
