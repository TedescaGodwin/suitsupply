namespace Suit.Supply.Function
{
    public class CompletedOrderParam
    {
        public int SalesId { get; set; }
        public bool IsCompleted { get; set; }
        public string To { get; set; }
        public string From{ get; set; }
        public string Body { get; set; }
    }
}
