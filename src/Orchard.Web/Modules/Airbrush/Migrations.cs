using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;
using Orchard.ContentManagement.MetaData;
using System.Data;

namespace Airbrush
{
    public class Migrations : DataMigrationImpl
    {
        public int Create()
        {
            SchemaBuilder.CreateTable("ContactPageRecord", table => table
                .Column("Id", DbType.Int32, column => column.PrimaryKey().Identity())
                .Column("MainText", DbType.String, column => column.Unlimited())
                .Column("ExtraText", DbType.String, column => column.Unlimited())
                .Column("Phone", DbType.String, column => column.WithLength(50))
                .Column("Email", DbType.String, column => column.WithLength(50))
                .Column("AddressName", DbType.String, column => column.WithLength(50))
                .Column("City", DbType.String, column => column.WithLength(50))
                .Column("AddressLine", DbType.String, column => column.WithLength(50))
                .Column("PostalCode", DbType.String, column => column.WithLength(50))
                .Column("Link1Name", DbType.String, column => column.WithLength(50))
                .Column("Link1Url", DbType.String, column => column.WithLength(256))
                .Column("Link2Name", DbType.String, column => column.WithLength(50))
                .Column("Link2Url", DbType.String, column => column.WithLength(256))

               );

            
            SchemaBuilder.CreateTable("ContactFormEntry", table => table
               .Column("Id", DbType.Int32, column => column.PrimaryKey().Identity())
               .Column("Name", DbType.String, column => column.WithLength(50))
               .Column("Email", DbType.String, column => column.WithLength(50))
               .Column("Subject", DbType.String, column => column.WithLength(256))
               .Column("MessageBody", DbType.String, column => column.Unlimited())
               .Column("CreatedUtc", DbType.DateTime)
               .Column("SenderName", DbType.String, column => column.WithLength(50))
               .Column("SenderEmail", DbType.String, column => column.WithLength(50)));
               
            SchemaBuilder.CreateTable("ContactFormEntryPartRecord", table => table
                .ContentPartRecord()
                .Column("SenderName", DbType.String, column => column.WithLength(50))
                .Column("SenderEmail", DbType.String, column => column.WithLength(50))
                .Column("Subject", DbType.String, column => column.WithLength(256)));

            ContentDefinitionManager.AlterPartDefinition("ContactFormEntryPart", part => part
                .Attachable(false));

            ContentDefinitionManager.AlterTypeDefinition("ContactFormEntry", type => type
                .WithPart("CommonPart")
                .WithPart("TitlePart")
                .WithPart("BodyPart")
                .WithPart("ContactFormEntryPart")
                .DisplayedAs("Contact Form Entry"));

            return 1;
        }
    }
}