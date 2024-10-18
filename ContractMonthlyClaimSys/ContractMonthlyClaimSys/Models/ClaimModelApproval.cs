using System;
using System.Collections.Generic;

namespace ContractMonthlyClaimSys.Models
{
    // Model representing the claim for approval views
    public class ClaimApprovalModel
    {
        public int ClaimId { get; set; }
        public string LecturerName { get; set; }
        public int HoursWorked { get; set; }
        public decimal HourlyRate { get; set; }
        public string Notes { get; set; }
        public DateTime SubmissionDate { get; set; }
        public string Status { get; set; }
    }
}
