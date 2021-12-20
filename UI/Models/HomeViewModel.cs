using DTOs;
using System.Collections.Generic;

namespace UI.Models
{
    public class HomeViewModel
    {
        public List<AdvertisementListDto> Advertisements { get; set; }
        public List<BreadCrumbListDto> BreadCrumbs { get; set; }
        public List<CounterListDto> Counters { get; set; }
        public List<DocumentaryListDto> Documentaries { get; set; }
        public List<LinkListDto> Links { get; set; }
        public List<PresentationListDto> Presentations { get; set; }
        public List<VideoListDto> Videos { get; set; }
    }
}
