
namespace Suit.Supply.Web.ApiModels
{
    public class SalesDTO : CreateSalesDTO
    {
        public SalesDTO(int id, List<OrderItemDTO>? orderItems) : base(orderItems)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
    public class CreateSalesDTO
    {
        protected CreateSalesDTO(List<OrderItemDTO>? orderItemDTO)
        {
            OrderItemDTO = orderItemDTO;
        }

        public List<OrderItemDTO> OrderItemDTO { get; set; }
    }
    
}
