namespace GPAC_Software.Models
{
    public class MeetingMinutesDetail
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public MeetingMinutesMaster MeetingMinutesMaster { get; set; }
    }
}
