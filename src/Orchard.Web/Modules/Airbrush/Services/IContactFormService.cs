using Airbrush.Models;
using Airbrush.ViewModels;
using Orchard;
using Orchard.ContentManagement;
using System.Collections.Generic;

namespace Airbrush.Services
{
    public interface IContactFormService : IDependency
    {
        ContentItem NewEntry(ContactFormEntry entry);
        ContentItem StoreEntry(ContactFormEntry entry);
        IEnumerable<ContentItem> GetEntries();
        ContentItem GetEntry(int id);
        void DeleteEntry(ContentItem entry);

        ContactFormEntryViewModel Convert(ContactFormEntry entry);
        ContactFormEntry Convert(ContactFormEntryViewModel model);

        void SendMaiLOnContactFormCreated(ContentItem contentItem);
    }
}
