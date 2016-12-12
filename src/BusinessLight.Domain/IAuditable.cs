namespace BusinessLight.Domain
{
    using System;

    public interface IAuditable
    {
        DateTime CreatedOn
        {
            get;
            set;
        }

        string CreatedBy
        {
            get;
            set;
        }

        DateTime ModifiedOn
        {
            get;
            set;
        }

        string ModifiedBy
        {
            get;
            set;
        }
    }
}