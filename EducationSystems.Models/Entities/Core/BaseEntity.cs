using System;

namespace EducationSystems.Models.Entities.Core
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            this.IsActive = true;
            this.CreationTime = DateTime.Now;
        }

        public bool IsActive { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
