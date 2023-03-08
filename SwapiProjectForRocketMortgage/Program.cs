using SwapiProjectForRocketMortgage;

var httpClient = new HttpClient();
var swapiClient = new SwapiClient(httpClient);
var planetNames = await swapiClient.GetNames();

foreach(var planetName in planetNames) 
{ 
    Console.WriteLine(planetName); 
}
