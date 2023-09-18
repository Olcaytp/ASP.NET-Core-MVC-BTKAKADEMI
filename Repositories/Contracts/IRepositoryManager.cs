namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        IProductRepository Product {get; }
        ICategoryRepository Category {get; }
        IOrderRepository Order {get; } //manager tanimimizi yapiyoruz ve bu manager uzerinden repositorylerimize erisecegiz
        //bu tanimdan sonra IRepositoryManagerin concrete hali olan RepositoryManager.cs dosyasina geciyoruz(go to implementation)
        void Save();
    }
}