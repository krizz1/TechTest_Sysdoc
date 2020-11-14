using TestApi.Data;
using TestApi.Domain;

namespace TestApi.Logic
{
    public class BaseLogic
    {
        protected readonly IUnitOfWork _unitOfWork;

        public BaseLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
