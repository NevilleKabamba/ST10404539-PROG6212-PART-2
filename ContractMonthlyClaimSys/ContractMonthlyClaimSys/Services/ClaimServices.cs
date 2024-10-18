using System.Collections.Generic;
using System.Linq;
using ContractMonthlyClaimSys.Models;
using ContractMonthlyClaimSys.Data;

namespace ContractMonthlyClaimSys.Services
{
    // Service implementation for claim-related operations using EF Core
    public class ClaimService : IClaimService
    {
        private readonly ClaimDbContext _context;

        public ClaimService(ClaimDbContext context)
        {
            _context = context;
        }

        public List<ClaimModel> GetPendingClaims()
        {
            return _context.Claims.Where(c => c.Status == "Pending").ToList();
        }

        public void SubmitClaim(ClaimModel claim)
        {
            claim.SubmissionDate = System.DateTime.Now;
            claim.Status = "Pending";
            _context.Claims.Add(claim);
            _context.SaveChanges();
        }

        public void ApproveClaim(int claimId)
        {
            var claim = _context.Claims.Find(claimId);
            if (claim != null)
            {
                claim.Status = "Approved";
                _context.SaveChanges();
            }
        }

        public void RejectClaim(int claimId)
        {
            var claim = _context.Claims.Find(claimId);
            if (claim != null)
            {
                claim.Status = "Rejected";
                _context.SaveChanges();
            }
        }

        public List<ClaimModel> GetClaimsByLecturer(string lecturerName)
        {
            return _context.Claims.Where(c => c.LecturerName == lecturerName).ToList();
        }
    }
}
