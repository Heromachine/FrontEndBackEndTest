using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TripTracker.BackService.Models;
using TripTracker.UI.Data;
using TripTracker.UI.Services;

namespace TripTracker.UI.Pages.DesktopComputers
{
    public class IndexModel : PageModel
    {
        private readonly IApiClientDesktopComputers _Client;

        public IndexModel(IApiClientDesktopComputers client)
        {
            _Client = client;
        }

        public IList<DesktopComputer> DesktopComputers { get;set; }

        public async Task OnGetAsync()
        {
            DesktopComputers = await _Client.GetDesktopComputersAsync();
        }
    }
}
