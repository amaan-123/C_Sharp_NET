namespace SchoolSheetReceiver.Models
{
    public class SheetSubmission
    {
        public string SubmissionStatus { get; set; }
        public DateTime SubmittedOn { get; set; }
        public string SubmittedBy { get; set; }
        public string TemplateVersion { get; set; }
        public string SheetUrl { get; set; }
        public string FileId { get; set; }
    }
}