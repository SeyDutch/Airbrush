using Airbrush.Models;
using Orchard.Data;
using System;
using System.Linq;
using Airbrush.ViewModels;

namespace Airbrush.Services
{
    public class ContactInfoService : IContactInfoService
    {
        private readonly IRepository<ContactPageRecord> _contactRepo;

        public ContactInfoService(IRepository<ContactPageRecord> contactRepo)
        {
            _contactRepo = contactRepo;
        }
        public ContactPage GetInfo()
        {
            ContactPage c = null;
            try
            {
                var cr = _contactRepo.Table.FirstOrDefault();
                if(cr != null){
                    c = new ContactPage() { Id = cr.Id,
                                       MainText = cr.MainText,
                                        ExtraText = cr.ExtraText,
                                        Phone = cr.Phone,
                                        Email = cr.Email,
                                        AddressName = cr.AddressName,
                                        City = cr.City,
                                        AddressLine = cr.AddressLine,
                                        PostalCode = cr.PostalCode,
                                        Link1Name = cr.Link1Name,
                                        Link1Url = cr.Link1Url,
                                        Link2Name = cr.Link2Name,
                                        Link2Url = cr.Link2Url};
                }
            }
            catch(Exception e)
            {
               c = null; 
            }

            return c;
        }

        public ContactPage EditInfo(ContactPage edit)
        {
            if(edit == null){
                return null;
            }
            
            try{
                var cr = _contactRepo.Table.FirstOrDefault();
                bool update = true;
                if (cr == null)
                {
                    cr = new ContactPageRecord();
                    update = false;
                }

                cr.Id = 1; //always 1 => only one contact page
                cr.MainText = edit.MainText;
                cr.ExtraText = edit.ExtraText;
                cr.Phone = edit.Phone;
                cr.Email = edit.Email;
                cr.AddressName = edit.AddressName;
                cr.City = edit.City;
                cr.AddressLine = edit.AddressLine;
                cr.PostalCode = edit.PostalCode;
                cr.Link1Name = edit.Link1Name;
                cr.Link1Url = edit.Link1Url;
                cr.Link2Name = edit.Link2Name;
                cr.Link2Url = edit.Link2Url;

                if (update)
                    _contactRepo.Update(cr);
                else
                    _contactRepo.Create(cr);
            }
            catch(Exception e)
            {
                return null;
            }

            return edit;
        }

        public ContactPageViewModel Convert(ContactPage model)
        {
            if (model == null)
                return null;

            ContactPageViewModel vm = new ContactPageViewModel()
            {
                AddressLine = model.AddressLine,
                AddressName = model.AddressName,
                City = model.City,
                Email = model.Email,
                ExtraText = model.ExtraText,
                Link1Name = model.Link1Name,
                Link1Url = model.Link1Url,
                Link2Name = model.Link2Name,
                Link2Url = model.Link2Url,
                MainText = model.MainText,
                Phone = model.Phone,
                PostalCode = model.PostalCode
            };

            return vm;

        }

        public ContactPage Convert(ContactPageViewModel model)
        {
            if (model == null)
                return null;


            ContactPage dm = new ContactPage()
            {
                AddressLine = model.AddressLine,
                AddressName = model.AddressName,
                City = model.City,
                Email = model.Email,
                ExtraText = model.ExtraText,
                Link1Name = model.Link1Name,
                Link1Url = model.Link1Url,
                Link2Name = model.Link2Name,
                Link2Url = model.Link2Url,
                MainText = model.MainText,
                Phone = model.Phone,
                PostalCode = model.PostalCode
            };

            return dm;
        }
    }
}