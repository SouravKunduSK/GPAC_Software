namespace GPAC_Software.Models.ViewModel
{
    public class MeetingViewModel
    {
        public string CustomerType { get; set; } // Corporate or Individual
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string MeetingPlace { get; set; }
        public string AttendeesClientSide { get; set; }
        public string AttendeesHostSide { get; set; }
        public string MeetingAgenda { get; set; }
        public string MeetingDiscussion { get; set; }
        public string MeetingDecision { get; set; }
        public List<MeetingDetailViewModel> Details { get; set; }
    }
}
