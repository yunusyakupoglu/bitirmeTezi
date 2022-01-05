using Microsoft.AspNetCore.Components.Forms;

namespace Blazor_UI.Data
{
    public class AdvertisementCreateDtoBlazor
    {
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public bool Status { get; set; }
        public IBrowserFile FileDoc { get; set; }
    }
}
