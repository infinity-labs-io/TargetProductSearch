using System.Threading.Tasks;

namespace InfinityLabs.Target.ProductSearch.Api.Seeders
{
    public interface IDatabaseSeeder
    {
        Task SeedAsync();
    }
}