using ContainerRollingUpdate.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ContainerRollingUpdate.ViewComponents
{
    public class ServerDetailsViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var serverDatails = await Task.Run(() => new ServerDatails
            {
                AppName = Assembly.GetEntryAssembly().GetName().Name,
                AppVersion = Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion,
                Time = DateTime.UtcNow.ToLocalTime().ToString()
            });

            return View(serverDatails);
        }
    }
}
