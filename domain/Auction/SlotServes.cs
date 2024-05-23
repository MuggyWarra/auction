using System.Linq;
namespace Auction
{
    public class SlotServes
    {
        private readonly ExcelService _excelService;
        public SlotServes(ExcelService excelService)
        {
            _excelService = excelService;
        }
        public Slot[] GetAllByQuery(string query)
        {
            var slots = _excelService.GetSlots();
            if (Slot.IsTegs(query))
                return slots.Where(slot => slot.Tegs == query).ToArray();
            return slots.Where(slot => slot.Title.Contains(query)).ToArray();
        }
    }
}
