using System;

namespace BusinessLight.Domain.Application
{
    public interface IApplicationUserClaim
    {
        /// <summary>Primary key</summary>
        int Id { get; set; }

        /// <summary>User Id for the user who owns this login</summary>
        Guid UserId { get; set; }

        /// <summary>Claim type</summary>
        string ClaimType { get; set; }

        /// <summary>Claim value</summary>
        string ClaimValue { get; set; }
    }
}