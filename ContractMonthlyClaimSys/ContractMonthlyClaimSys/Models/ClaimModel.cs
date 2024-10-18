using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContractMonthlyClaimSys.Models
{
    // Model representing a claim
    public class ClaimModel
    {
        [Key]
        public int ClaimId { get; set; }

        [Required]
        public string LecturerName { get; set; }

        [Range(0, int.MaxValue)]
        public int HoursWorked { get; set; }

        [Range(0, double.MaxValue)]
        public decimal HourlyRate { get; set; }

        public string Notes { get; set; }

        public DateTime SubmissionDate { get; set; }

        [Required]
        public string Status { get; set; } // E.g., Pending, Approved, Rejected

        // Store file paths for uploaded documents
        public List<string> UploadedFiles { get; set; } = new List<string>();
    }
}
