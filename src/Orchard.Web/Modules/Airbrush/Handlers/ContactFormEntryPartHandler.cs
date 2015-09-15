using Airbrush.Models;
using Airbrush.Services;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;

namespace Airbrush.Handlers
{
    public class ContactFormEntryPartHandler : ContentHandler
    {
        private readonly IContactFormService _contactFormService;

        public ContactFormEntryPartHandler(IRepository<ContactFormEntryPartRecord> repo, IContactFormService cfs)
        {
            _contactFormService = cfs;

            Filters.Add(StorageFilter.For(repo));
            
            OnCreated<ContactFormEntryPart>(
                    (context, part) => _contactFormService.SendMaiLOnContactFormCreated(context.ContentItem)
                );
            
        }

        /*
        protected override void Created(CreateContentContext context)
        {
            base.Created(context);
        }

        protected override void Creating(CreateContentContext context)
        {
            base.Creating(context);
        }*/
    }
}
