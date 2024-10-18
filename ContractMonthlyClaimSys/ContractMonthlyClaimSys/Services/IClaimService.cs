using System.Collections.Generic;
using ContractMonthlyClaimSys.Models;

namespace ContractMonthlyClaimSys.Services
{
    // Interface defining methods for managing claims
    public interface IClaimService
    {
        List<ClaimModel> GetPendingClaims();
        void SubmitClaim(ClaimModel claim);
        void ApproveClaim(int claimId);
        void RejectClaim(int claimId);
        List<ClaimModel> GetClaimsByLecturer(string lecturerName);
    }
}
