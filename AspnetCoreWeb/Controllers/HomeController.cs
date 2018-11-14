using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspnetCoreWeb.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Steeltoe.Extensions.Configuration.CloudFoundry;
using Steeltoe.Extensions.Configuration.ConfigServer;

namespace AspnetCoreWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOptionsSnapshot<ConfigServerData> _configServerData;
        private readonly IOptions<CloudFoundryServicesOptions> _serviceOptions;
        private readonly IConfiguration _configuration;
        private readonly IOptions<CloudFoundryApplicationOptions> _appOptions;
        private readonly IOptions<ConfigServerClientSettingsOptions> _configServerSettings;

        public HomeController(IConfigurationRoot config
            , IOptionsSnapshot<ConfigServerData> configServerData
            , IOptions<CloudFoundryApplicationOptions> appOptions
            , IOptions<CloudFoundryServicesOptions> serviceOptions
            , IOptions<ConfigServerClientSettingsOptions> coinfigServerSettings)
        {
            if (configServerData != null)
                _configServerData = configServerData;
            if (serviceOptions != null)
                _serviceOptions = serviceOptions;
            _configuration = config;
            if (appOptions != null)
                _appOptions = appOptions;
            if (coinfigServerSettings != null)
                _configServerSettings = coinfigServerSettings;
        }

        public IActionResult Index()
        {
            ViewBag.ConfigLable = _configuration["option1"];
            ViewBag.AppName = _configServerSettings.Value;
            ViewBag.FeatureOn = _configServerData.Value.Features.WowFeature;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
