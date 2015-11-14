
using Orchard.ContentManagement;
using System.Collections.Generic;

namespace Airbrush.ViewModels
{
    public class GalleryViewModel
    {
        public List<GalleryItemViewModel> GalleryItems { get; set; }

        public GalleryViewModel()
        {
            GalleryItems = new List<GalleryItemViewModel>();
        }

        public class GalleryItemViewModel
        {
            public string MediaUrl { get; set; }
            public string Title { get; set; }
            public string Caption { get; set; }

            public GalleryItemViewModel()
            { }
            public GalleryItemViewModel(string mediaUrl, string title, string caption)
            {
                MediaUrl = mediaUrl;
                Title = title;
                Caption = caption;
            }
        }

    }


}
