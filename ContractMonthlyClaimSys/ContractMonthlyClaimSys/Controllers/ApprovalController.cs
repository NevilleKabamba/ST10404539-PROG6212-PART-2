using Microsoft.AspNetCore.Mvc;
using ContractMonthlyClaimSys.Services;

namespace ContractMonthlyClaimSys.Controllers
{
    // Controller to handle claim approvals
    public class ApprovalController : Controller
    {
        private readonly IClaimService _claimService;

        public ApprovalController(IClaimService claimService)
        {
            _claimService = claimService;
        }

        // Display the 'Approve Claims' page
        public IActionResult ApproveClaims()
        {
            var claims = _claimService.GetPendingClaims();
            return View(claims); // Returns a view displaying pending claims
        }

        // Approve a specific claim
        [HttpPost]
        public IActionResult ApproveClaim(int claimId)
        {
            _claimService.ApproveClaim(claimId);
            return RedirectToAction("ApproveClaims");
        }

        // Reject a specific claim
        [HttpPost]
        public IActionResult RejectClaim(int claimId)
        {
            _claimService.RejectClaim(claimId);
            return RedirectToAction("ApproveClaims");
        }
    }
}
