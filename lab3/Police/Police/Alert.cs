namespace Police
{
    // Business-logic object
    public class Alert
    {
        public string Type { get; }
        public string Caller { get; }
        public string Address { get; }
        public bool IsUrgent { get; }
        public string Details { get; }

        public Alert(string type, string caller, string address, bool isUrgent, string details)
        {
            Type = type;
            Caller = caller;
            Address = address;
            IsUrgent = isUrgent;
            Details = details;
        }
    }
}