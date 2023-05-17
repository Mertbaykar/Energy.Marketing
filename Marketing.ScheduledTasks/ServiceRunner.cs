using Marketing.EF.Core;
using Marketing.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Marketing.ScheduledTasks
{
    public class ServiceRunner
    {
        private MarketingContext _marketingContext;
        public ServiceRunner(MarketingContext marketingContext)
        {
            _marketingContext = marketingContext;
        }
        private IEnumerable<Service> GetServices2Execute()
        {
            var services = _marketingContext.Services.ToList();
            return services.Where(x => x.ShouldExecute);
        }
        private void Save()
        {
            _marketingContext.SaveChanges();
        }
        public Task RunServicesAsync()
        {
            var services = GetServices2Execute();
            if (services != null && services.Count() > 0)
            {
                foreach (var service in services)
                {
                    MethodInfo method = this.GetType().GetMethod(service.WorkerTaskName, BindingFlags.NonPublic | BindingFlags.Instance);
                    if (method == null)
                        throw new Exception(service.Name + " adlı servisteki " + service.WorkerTaskName + " ismiyle fonksiyon bulunamadı");
                    method.Invoke(this, null);
                    service.LastExecutionDate = DateTime.Now;
                }
                Save();
            }
            return Task.CompletedTask;
        }

        #region WorkerTask Methods
        private void UpdatePrices()
        {
            Console.WriteLine("UpdatePrices");
        }
        #endregion
    }
}
