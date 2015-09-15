using System.Linq;
using Orchard;
using Orchard.ContentManagement;
using Orchard.Core.Common.Models;
using Orchard.UI.Notify;
using Airbrush.Events;

namespace Harvest.OrchardDevToolbelt.Handlers
{
    public class SpamProtectedContactFormEventHandler : Component, IContactFormEventHandler
    {
        private readonly INotifier _notifier;

        public SpamProtectedContactFormEventHandler(INotifier notifier)
        {
            _notifier = notifier;
        }

        public void ContactFormEntryCreating(ContactFormCreatingContext context)
        {
            var text = context.ContactFormEntry.As<BodyPart>().Text;
            var spamTerms = new[] { "viagra", "opportunity", "win!", "$$$", "Lose weight", "Extra income", "Money making", "Earn $", "Save $" };

            if (!spamTerms.Any(text.Contains))
            {
                _notifier.Information(T("Bericht geaccepteerd"));
                return;
            }

            context.Cancel = true;
            _notifier.Warning(T("Uw bericht is als spam beoordeeld en is daarom niet verstuurd."));
        }

        public void ContactFormEntryCreated(ContactFormCreatedContext context)
        {
            
        }
    }
}