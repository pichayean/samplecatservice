// See https://aka.ms/new-console-template for more information
using samplecatservice.client;
CatGrpcClient catGrpcClient = new CatGrpcClient();
var newCats = new string[]{"Calixto Deina", "Joonas Ransu", "Ameyalli Samira","Anneka Melanija", "Braylon Rhea"};
catGrpcClient.AddCats(newCats);

var cats = catGrpcClient.GetCats();
foreach (var item in cats.Cats){
    Console.WriteLine("Cats: " + item.Name);
    catGrpcClient.DeleteCats(item.Id);
}
Console.ReadKey();
