using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Marketing.Models.Entities
{
    [Table("Services")]
    public class Service : EntityBase
    {
        public string Name { get; set; }
        public bool IsDaily { get; set; }
        /// <summary>
        /// Dakika cinsinden period süresi
        /// </summary>
        public int Interval { get; set; }
        public DateTime LastExecutionDate { get; set; }
        /// <summary>
        /// Service tetiklendiğinde çalışacak olan method adı
        /// </summary>
        public string WorkerTaskName { get; set; }
        [NotMapped]
        public DateTime NextExecutionDate => LastExecutionDate.AddMinutes(Interval);
        [NotMapped]
        public bool ShouldExecute => ShouldServiceExecute();

        public bool ShouldServiceExecute()
        {
            var now = DateTime.Now;

            if (IsDaily)
            {
                if (now >= LastExecutionDate.AddDays(1))
                    return true;
                return false;
            }
            if (now >= LastExecutionDate.AddMinutes(Interval))
                return true;
            return false;
        }

    }
}
