using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using ContractMonthlyClaimSys.Models;
using ContractMonthlyClaimSys.Services;

public class ClaimSubmissionController : Controller
{
    private readonly IClaimService _claimService;

    public ClaimSubmissionController(IClaimService claimService)
    {
        _claimService = claimService;
    }

    // GET: SubmitClaim
    [HttpGet]
    public IActionResult SubmitClaim()
    {
        return View(new ClaimModel()); // Return a new ClaimModel instance
    }

    // POST: SubmitClaim
    [HttpPost]
    public IActionResult SubmitClaim(ClaimModel claim)
    {
        if (ModelState.IsValid)
        {
            _claimService.SubmitClaim(claim);
            return RedirectToAction("CheckStatus", "Lecturer"); // Redirect to CheckStatus after submission
        }
        return View(claim); // Return the same view with the invalid model
    }

    // GET: UploadDocuments
    [HttpGet]
    public IActionResult UploadDocuments()
    {
        return View(); // Return the view for uploading documents
    }

    // POST: UploadDocuments
    [HttpPost]
    public IActionResult UploadDocuments(IFormFile document)
    {
        if (document != null && document.Length > 0)
        {
            var path = Path.Combine("wwwroot/uploads", Path.GetFileName(document.FileName));
            using (var stream = new FileStream(path, FileMode.Create))
            {
                document.CopyTo(stream);
            }
            return RedirectToAction("CheckStatus", "Lecturer"); // Redirect after successful upload
        }
        return View(); // Return the view if the file is not valid
    }
}
