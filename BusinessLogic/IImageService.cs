using Nettbutikk.Model;

namespace Nettbutikk.BusinessLogic
{
    public interface IImageService : IEntityService<Image>
    {
        bool AddImage(int productId, string imageUrl);
    }
}