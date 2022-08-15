namespace Suit.Supply.Web.ApiModels
{
    public class EmailDTO : CreateEmailDTO
    {
        public string? Body { get; set; }
        public EmailDTO(string to, string from, string body) : base(to, from)
        {
            Body = body;
        }
    }

    public abstract class CreateEmailDTO
    {
        protected CreateEmailDTO(string to,string from)
        {
            To = to;
            From = from;
        }

        public string To { get; set; }
        public string From { get; set; }
    }
}
