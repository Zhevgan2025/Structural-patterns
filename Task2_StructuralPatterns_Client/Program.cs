using System;
using System.Threading.Tasks;

namespace Task2_StructuralPatterns_Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var baseAddress = "https://localhost:7080/";

            var api = new HttpOperatorApi(baseAddress);
            var crud = new CrudApiClient(api);
       

            Console.WriteLine("Creating entities");

            var e1 = await crud.CreateAsync("Robot", "First robot");
            var e2 = await crud.CreateAsync("Drone", "Flying drone");

            Console.WriteLine("Created:");
            Console.WriteLine($"{e1.Id} | {e1.Name}");
            Console.WriteLine($"{e2.Id} | {e2.Name}");

            Console.WriteLine("=== All entities from the server ===");
            await crud.PrintManyAsync();

            Console.WriteLine("=== Only active (FlexibleApiClient) ===");
            var flexible = new FlexibleApiClient(api);
            await flexible.PrintByAsync(new ActiveEntitiesFilter());

            Console.WriteLine("\n=== Image API (Adapter) ===");

            var imageApi = new ImageApiAdapter(api);

            await imageApi.SetImageAsync(e1.Id, "http://images/robot.png");
            await imageApi.SetImageAsync(e2.Id, "http://images/drone.png");

            var withImages = await imageApi.GetEntitiesByFilterAsync(new ActiveEntitiesFilter());

            foreach (var img in withImages)
            {
                Console.WriteLine($"{img.Id} | {img.Name} | {img.ImageUrl}");
            }


            Console.WriteLine("=== Name contains 'go' ===");
            await flexible.PrintByAsync(new NameContainsFilter("go"));


            Console.WriteLine("Done. Press any key...");
            Console.ReadKey();
        }
    }
}


