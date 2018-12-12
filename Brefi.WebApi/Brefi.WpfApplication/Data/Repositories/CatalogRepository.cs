using System.Threading.Tasks;
using Brefi.WpfApplication.Models;
using Brefi.WpfApplication.WebApi;

namespace Brefi.WpfApplication.Data.Repositories
{
    public class CatalogRepository
    {
        private BrefiWebApi webAPI;

        private BrendRepository brendRepository;
        private EquipmentRepository equipmentRepository;
        private ToolTypeRepository toolTypeRepository;
        private UpdateRepository updateRepository;
                
        public CatalogRepository(BrendRepository bRepository, EquipmentRepository eRepository, ToolTypeRepository tRepository, UpdateRepository uRepository)
        {
            webAPI = new BrefiWebApi();
            updateRepository = uRepository;
            brendRepository = bRepository;
            equipmentRepository = eRepository;
            toolTypeRepository = tRepository;
        }

        public async Task Synchronyze()
        {
            var anyUpdates = updateRepository.Any();

            FullCatalog allData;

            if (!anyUpdates)
            {
                allData = await webAPI.GetLines();
            }
            else
            {
                var last = updateRepository.GetLast();
                var fullCatalog = GetFullCatalog(last);

                allData = await webAPI.Update(fullCatalog, last.UpdateTime);
            }

            brendRepository.AddLines(allData.Brends);
            equipmentRepository.AddLines(allData.Equipments);
            toolTypeRepository.AddLines(allData.ToolTypes);
            updateRepository.AddLine();
        }

        private FullCatalog GetFullCatalog(Update last)
        {
            var brends = brendRepository.GetByTime(last.UpdateTime);
            var equipments = equipmentRepository.GetByTime(last.UpdateTime);
            var toolTypes = toolTypeRepository.GetByTime(last.UpdateTime);

            return new FullCatalog() { Brends = brends, Equipments = equipments, ToolTypes = toolTypes };
        }
    }
}
