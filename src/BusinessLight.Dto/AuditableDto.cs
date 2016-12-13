namespace BusinessLight.Dto
{
    using System;


    public abstract class AuditableDto : Dto
    {
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    }
}
