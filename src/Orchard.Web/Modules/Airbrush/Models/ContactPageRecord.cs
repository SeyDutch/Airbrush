using Orchard.ContentManagement.Records;
using Orchard.Data.Conventions;

namespace Airbrush.Models
{
    public class ContactPageRecord //: ContentPartRecord
    {
        public virtual int Id { get; set; }  // { get { return base.Id; } set { base.Id = value; } }

        [StringLengthMax]
        public virtual string MainText { get; set; }

        [StringLengthMax]
        public virtual string ExtraText { get; set; }

        public virtual string Phone { get; set; }

        public virtual string Email { get; set; }

        public virtual string AddressName { get; set; }

        public virtual string City { get; set; }

        public virtual string AddressLine { get; set; }

        public virtual string PostalCode { get; set; }

        public virtual string Link1Name { get; set; }

        public virtual string Link1Url { get; set; }

        public virtual string Link2Name { get; set; }

        public virtual string Link2Url { get; set; }
    }
}