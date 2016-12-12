namespace BusinessLight.Domain
{
    using System;

    public abstract class AuditableEntity : Entity, IAuditable
    {
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    }
}