using AutoMapper;
using BL.IServices;
using DAL;
using Microsoft.AspNetCore.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IAdvertisementManager _advertisementManager;
        private readonly IBreadCrumbManager _breadCrumbManager;
        private readonly ICounterManager _counterManager;
        private readonly IDocumentaryManager _documentaryManager;
        private readonly ILinkManager _linkManager;
        private readonly IPresentationManager _presentationManager;
        private readonly IVideoManager _videoManager;

        public HomeController(ApplicationDbContext context, IMapper mapper, IAdvertisementManager advertisementManager, IBreadCrumbManager breadCrumbManager, ICounterManager counterManager, IDocumentaryManager documentaryManager, ILinkManager linkManager, IPresentationManager presentationManager, IVideoManager videoManager)
        {
            _context = context;
            _mapper = mapper;
            _advertisementManager = advertisementManager;
            _breadCrumbManager = breadCrumbManager;
            _counterManager = counterManager;
            _documentaryManager = documentaryManager;
            _linkManager = linkManager;
            _presentationManager = presentationManager;
            _videoManager = videoManager;
        }

        public IActionResult Index()
        {
            HomeViewModel home = new HomeViewModel();
            home.Advertisements = _advertisementManager.GetAllAsync().Result.Data;
            home.BreadCrumbs = _breadCrumbManager.GetAllAsync().Result.Data;
            home.Counters = _counterManager.GetAllAsync().Result.Data;
            home.Documentaries=_documentaryManager.GetAllAsync().Result.Data;
            home.Links=_linkManager.GetAllAsync().Result.Data;
            home.Presentations=_presentationManager.GetAllAsync().Result.Data;
            home.Videos=_videoManager.GetAllAsync().Result.Data;
            return View(home);
        }

        public IActionResult Admin()
        {
            return View();
        }
    }
}
