namespace GPAC_Software.Models
{
    public class MeetingMinutesMaster
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerType { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string MeetingPlace { get; set; } 
        public string AttendeesClientSide { get; set; }
        public string AttendeesHostSide { get; set; } 
        public string MeetingAgenda { get; set; } 
        public string MeetingDiscussion { get; set; } 
        public string MeetingDecision { get; set; } 

        public ICollection<MeetingMinutesDetail> MeetingMinutesDetails { get; set; }
    }
}
