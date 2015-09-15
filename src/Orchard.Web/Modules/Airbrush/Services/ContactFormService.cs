using System.Collections.Generic;
using System.Linq;
using Airbrush.Events;
using Airbrush.Models;
using Orchard;
using Orchard.ContentManagement;
using Orchard.Core.Common.Models;
using Orchard.Core.Title.Models;
using Orchard.UI.Notify;
using Airbrush.ViewModels;
using System;

namespace Airbrush.Services
{
    public class ContactFormService : Component, IContactFormService
    {
        private readonly IOrchardServices _services;
        private readonly IEnumerable<IContactFormFilter> _filters;
        private readonly IContactFormEventHandler _contactFormEventHandler;

        public ContactFormService(
            IOrchardServices services,
            IEnumerable<IContactFormFilter> filters,
            IContactFormEventHandler contactFormEventHandler)
        {

            _services = services;
            _filters = filters;
            _contactFormEventHandler = contactFormEventHandler;
        }

        public ContentItem NewEntry(ContactFormEntry entry)
        {
            var contentItem = _services.ContentManager.New("ContactFormEntry");
            var commonPart = contentItem.As<CommonPart>();
            var titlePart = contentItem.As<TitlePart>();
            var bodyPart = contentItem.As<BodyPart>();
            var contactFormEntryPart = contentItem.As<ContactFormEntryPart>();

            commonPart.CreatedUtc = entry.CreatedUtc;
            titlePart.Title = entry.Subject;
            bodyPart.Text = entry.MessageBody;
            contactFormEntryPart.SenderName = entry.Name;
            contactFormEntryPart.SenderEmail = entry.Email;
            return contentItem;
        }

        public ContentItem StoreEntry(ContactFormEntry entry)
        {

            foreach (var filter in _filters)
            {
                filter.Process(entry);
            }

            var contentItem = NewEntry(entry);
            var test = contentItem.Id;

            var entryCreatingContext = new ContactFormCreatingContext
            {
                ContactFormEntry = contentItem
            };

            _contactFormEventHandler.ContactFormEntryCreating(entryCreatingContext);

            if (entryCreatingContext.Cancel)
                return null;

            _services.ContentManager.Create(contentItem);

            var entryCreatedContext = new ContactFormCreatedContext
            {
                ContactFormEntry = contentItem
            };

            _contactFormEventHandler.ContactFormEntryCreated(entryCreatedContext);

            _services.Notifier.Information(T("Uw bericht is ontvangen. Dank u voor de reactie!"));
            return contentItem;
        }

        public IEnumerable<ContentItem> GetEntries()
        {
            var entries = _services.ContentManager.Query("ContactFormEntry").List();
            return entries;
            //var entries = _services.ContentManager.Query("ContactFormEntry").List();
            //int i = 8;
            //var entries = _services.ContentManager.Query<ContactFormEntry>("ContactFormEntry").List();

            //return new List<ContactFormEntry>();
               

            //return null;// entries.Select(new ContactFormEntry() { });
        }

        public IEnumerable<ContentItem> GetEntriesByTitle(string title)
        {
            //return null;

            
            return _services.ContentManager.Query("ContactFormEntry")
                .ForPart<TitlePart>()
                .Where<TitlePartRecord>(x => x.Title == title)
                .List()
                .Select(x => x.ContentItem);
                
        }

        public ContentItem GetEntry(int id)
        {
            return _services.ContentManager.Get(id);
        }

        public void DeleteEntry(ContentItem entry)
        {
            _services.ContentManager.Remove(entry);
        }

        public ContactFormEntryViewModel Convert(ContactFormEntry entry)
        {
            if(entry == null)
                return new ContactFormEntryViewModel();

            return new ContactFormEntryViewModel()
            {
                CreatedUtc = entry.CreatedUtc,
                Email = entry.Email,
                MessageBody = entry.MessageBody,
                Name = entry.Name,
                Subject = entry.Subject
                
            };
        }

        public ContactFormEntry Convert(ContactFormEntryViewModel model)
        {
            if(model == null)
                return new ContactFormEntry();

            return new ContactFormEntry()
            {
                Subject = model.Subject,
                Name = model.Name,
                MessageBody = model.MessageBody,
                CreatedUtc = model.CreatedUtc,
                Email = model.Email
            };
        }

        public void SendMaiLOnContactFormCreated(ContentItem contentItem)
        {
            var values = new ContactFormEntry()
            {
                Name = contentItem.As<ContactFormEntryPart>().SenderName,
                Email = contentItem.As<ContactFormEntryPart>().SenderEmail,
                Subject = contentItem.As<TitlePart>().Title,
                MessageBody = contentItem.As<BodyPart>().Text,
                CreatedUtc = contentItem.As<CommonPart>().CreatedUtc.Value
            };
            MailService.SendMail(values);
            int y = 0;
        }
    }

    public interface IContactFormFilter
    {
        void Process(ContactFormEntry entry);
    }
}