// See https://aka.ms/new-console-template for more information
using samplecatservice.client;
Console.WriteLine("++++Create cat by RestApi++++");
var catHttpClient = new CatHttpClient();
var newCats = new string[]{"Calixto Deina", "Joonas Ransu", "Ameyalli Samira","Anneka Melanija", "Braylon Rhea"};
await catHttpClient.CreateCatsAsync(newCats);

Console.WriteLine("++++Get cats by gRPC++++");
CatGrpcClient catGrpcClient = new CatGrpcClient();
var cats = catGrpcClient.GetCats();
foreach (var item in cats.Cats){
    Console.WriteLine("Cats: " + item.Name);
    catGrpcClient.DeleteCats(item.Id);
}
Console.ReadKey();
