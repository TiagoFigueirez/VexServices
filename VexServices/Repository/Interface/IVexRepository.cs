using VexServices.DTO;

namespace VexServices.Repository.Interface
{
    public interface IVexRepository
    {
        public bool InsertDB(List<TituloDto> titles);
    }
}
