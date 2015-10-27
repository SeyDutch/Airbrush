using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Web.WebPages;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard;

namespace AirbrushTheme.Providers.Layouts
{
    public class LayoutShapes : IDependency
    {
        public LayoutShapes()
        {
            T = NullLocalizer.Instance;
        }

        public Localizer T { get; set; }

        [Shape]
        public void Carousel(dynamic Display, TextWriter Output, HtmlHelper Html, string Id, IEnumerable<dynamic> Items, IEnumerable<string> OuterClasses, IDictionary<string, string> OuterAttributes, IEnumerable<string> InnerClasses, IDictionary<string, string> InnerAttributes, IEnumerable<string> FirstItemClasses, IDictionary<string, string> FirstItemAttributes, IEnumerable<string> ItemClasses, IDictionary<string, string> ItemAttributes)
        {
            if (Items == null)
                return;

            var items = Items.ToList();
            var itemsCount = items.Count;

            if (itemsCount < 1)
                return;

            var outerDivTag = GetTagBuilder("div", Id, OuterClasses, OuterAttributes);
            var innerDivTag = GetTagBuilder("div", string.Empty, InnerClasses, InnerAttributes);
            var firstItemTag = GetTagBuilder("div", string.Empty, FirstItemClasses, FirstItemAttributes);
            var itemTag = GetTagBuilder("div", string.Empty, ItemClasses, ItemAttributes);
           
            Output.Write(outerDivTag.ToString(TagRenderMode.StartTag));
            Output.Write(outerDivTag.ToString(TagRenderMode.StartTag));

            var firstItem = true;
            foreach (var item in items)
            {
                if (firstItem)
                    Output.Write(firstItemTag.ToString(TagRenderMode.StartTag));
                else
                    Output.Write(itemTag.ToString(TagRenderMode.StartTag));

                Output.Write(Display(item));
                //firstItemTag is also a div
                Output.Write(itemTag.ToString(TagRenderMode.EndTag));
                firstItem = false;
            }

            Output.Write(innerDivTag.ToString(TagRenderMode.EndTag));

            Output.Write("<a href=\"#{0}\" class=\"carousel-control left\" data-slide=\"prev\">&lsaquo;</a>", Id);
            Output.Write("<a href=\"#{0}\" class=\"carousel-control right\" data-slide=\"next\">&lsaquo;</a>", Id);

            Output.Write(outerDivTag.ToString(TagRenderMode.EndTag));

            Output.Write("<div id='carouselIdRef' style=\"display:none;\" data-carousel-ref=\"" + Id + "\"></div>");
        }

        static TagBuilder GetTagBuilder(string tagName, string id, IEnumerable<string> classes, IDictionary<string, string> attributes)
        {
            var tagBuilder = new TagBuilder(tagName);
            tagBuilder.MergeAttributes(attributes, false);
            foreach (var cssClass in classes ?? Enumerable.Empty<string>())
                tagBuilder.AddCssClass(cssClass);
            if (!string.IsNullOrWhiteSpace(id))
                tagBuilder.GenerateId(id);
            return tagBuilder;
        }
    }
}
