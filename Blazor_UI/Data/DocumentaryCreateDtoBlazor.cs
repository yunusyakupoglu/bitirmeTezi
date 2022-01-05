using Microsoft.AspNetCore.Components.Forms;

namespace Blazor_UI.Data
{
    public class DocumentaryCreateDtoBlazor
    {
        public string Title { get; set; }
        public string VideoPath { get; set; }
        public bool Status { get; set; }
        public IBrowserFile FileDoc { get; set; }
    }
}
