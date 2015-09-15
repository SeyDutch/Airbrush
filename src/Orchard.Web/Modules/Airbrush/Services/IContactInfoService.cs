using Airbrush.Models;
using Airbrush.ViewModels;
using Orchard;

namespace Airbrush.Services
{
    public interface IContactInfoService : IDependency
    {
        ContactPage GetInfo();

        ContactPage EditInfo(ContactPage edit);

        ContactPageViewModel Convert(ContactPage model);
        ContactPage Convert(ContactPageViewModel model);
    }
}
