
using Orchard.ContentManagement;
using System.Collections.Generic;

namespace Airbrush.ViewModels
{
    public class ContactFormEntryListViewModel
    {
        public List<ContentItem> ContactFormEntries { get; set; }
        public dynamic Pager { get; set; }
    }
}
