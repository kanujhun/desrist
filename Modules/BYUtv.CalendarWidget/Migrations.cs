using BYUtv.CalendarWidget.Models;
using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;

namespace BYUtv.CalendarWidget
{
    /*
     * Migration
     * A migration is a descritpion of the operations to execute when first installing (enabling) a feature (module) or when upgrading it from one vertion to the next.
     * This enables smooth upgrades of individual features without data loss.
     * Orchard includes a data migration framework.
     */
    public class Migrations : DataMigrationImpl
    {
        public int Create()
        {
            // programatically create a content type called TimeSpanPart
            ContentDefinitionManager.AlterPartDefinition("TimeSpanPart",
                builder => builder
                    .Attachable()
                    .WithField("StartDateTime",
                        field => field
                            .OfType("DateTimeField")
                            .WithDisplayName("Start Date Time")
                    )
                    .WithField("EndDateTime",
                        field => field
                            .OfType("DateTimeField")
                            .WithDisplayName("End Date Time")
                    )
            );

            SchemaBuilder.CreateTable("CalendarWidgetPartRecord",
                table => table
                    .ContentPartRecord() // creates an id column that will be auto populated
                    .Column<int>("QueryId")
            );

            // make CalendarWidgetPart attachable
            ContentDefinitionManager.AlterPartDefinition(typeof(CalendarWidgetPart).Name, builder => builder.Attachable());

            // create a content type called CalendarWidget, add parts to it, treat it as a widget
            ContentDefinitionManager.AlterTypeDefinition("CalendarWidget",
                cfg => cfg
                    .WithPart("CalendarWidgetPart")
                    .WithPart("WidgetPart")
                    .WithPart("CommonPart")
                    .WithSetting("Stereotype", "Widget")
            );

            return 1;
        }
    }
}