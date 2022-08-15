using Suit.Supply.Core.SalesAggregate.Models;

namespace Suit.Supply.Web.ApiModels;

public class AlterationDetailsDTO
{
    public decimal SleeveRight { get; set; }
    public decimal SleeveLeft { get; set; }
    public decimal TrouserRight { get; set; }
    public decimal TrouserLeft { get; set; }

    public static AlterationDetailsDTO FromAlterationDetails(AlterationDetails details)
      {
        return new AlterationDetailsDTO()
        {
          SleeveLeft = details.SleeveLeft,
          SleeveRight = details.SleeveRight,
          TrouserLeft = details.TrouserLeft,
          TrouserRight = details.TrouserRight,
        };
      }

    public static AlterationDetails FromDTO(AlterationDetailsDTO item)
    {
        return new AlterationDetails()
        {
            SleeveLeft = item.SleeveLeft,
            SleeveRight = item.SleeveRight,
            TrouserLeft = item.TrouserLeft,
            TrouserRight = item.TrouserRight,
        };
    }
}
