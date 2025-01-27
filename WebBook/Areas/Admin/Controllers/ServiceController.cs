using Domin.Entity;
using FreeBook.Resource;
using Infarstuructre.Data;
using Infarstuructre.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FreeBook.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class ServiceController : Controller
    {
        private readonly FreeBookDbContext _context;
        public ServiceController(FreeBookDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task< IActionResult> Service()
        {
            var  model= new ServiceViewModel{
                NewService = new NewService(),
                 services = await _context.services.Include(x=>x.Requests).ToListAsync()



            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Service(ServiceViewModel service)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    
                        var serviceInput = new Service()
                        {
                            Name = service.NewService.Name,
                            Description = service.NewService.Description,
                            CreatedAt = service.NewService.CreatedAt,
                            IsActive = service.NewService.IsActive

                        };
                    if (serviceInput.ServiceID==null) {
                        await _context.services.AddAsync(serviceInput);
                        await _context.SaveChangesAsync();
                        TempData["Success"] = @ResourceWeb.lbSuccess;

                    }
                    else
                    {
                        var serviceUpdate = await _context.services.FirstOrDefaultAsync(x=>x.ServiceID== service.NewService.ServiceID);
                        if (serviceUpdate != null)
                        {

                            serviceUpdate.Name = service.NewService.Name;
                            serviceUpdate.Description = service.NewService.Description;
                            serviceUpdate.CreatedAt = service.NewService.CreatedAt;
                            serviceUpdate.IsActive = service.NewService.IsActive;
                             _context.services.Update(serviceUpdate);
                            await _context.SaveChangesAsync();
                            TempData["Update"] = @ResourceWeb.lbUpdate;


                        }
                        else
                        {
                            TempData["Error"] = "Service not found.";
                        }
                    }

                }
                catch (Exception)
                {
                    return null;
                }

            }
            return RedirectToAction("Service");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteService(int id)
        {
            var model = await _context.services.FindAsync(id);
            try
            {
                if (model != null)
                {
                    _context.services.Remove(model);
                    await _context.SaveChangesAsync();
                    TempData["Delete"] = ResourceWeb.lbTitleDeletedOk;

                }
                else
                {

                }
            }
            catch (Exception ex )
            {
                TempData["Error"] = $"An unexpected error occurred: {ex.Message}";
            }

            return RedirectToAction ("Service");
        }
    }
}
