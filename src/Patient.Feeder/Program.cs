using System.Text;
using System.Text.Json;
using Patient.Feeder.Models;

Console.WriteLine("Start feeding");

var names = "Николай,Руслан,Алексей,Юрий,Семен,Евгений,Олег,Артур,Петр,Илья,Вячеслав,Сергей,Василий,Ева,Василиса,Мирослава,Есения,Эмилия,Агата,Аделина,Ясмина,Аврора,Агния,Амалия".Split(',');
var surnames = "Иванов,Смирнов,Кузнецов,Попов,Васильев,Петров,Соколов,Михайлов,Новиков,Фёдоров,Морозов,Волков,Алексеев,Лебедев,Семенов,Егоров,Павлов,Козлов,Степанов,Николаев".Split(',');

var rand = new Random();
var client = new HttpClient()
{
    BaseAddress = new Uri("http://api:80"),
};

for (var i = 0; i < 100; i++)
{
    var nameIndex = rand.Next(names.Length);
    var surname = surnames[rand.Next(surnames.Length)];
    var isFemale = nameIndex > 12;

    if (isFemale)
    {
        surname = surname + "a";
    }

    var name = new Name { Id = Guid.NewGuid(), Family = surname, Given = new[] { names[nameIndex] }, Use = "official" };

    var dateBirth = new DateTime(1950, 1, 1);
    dateBirth = dateBirth.AddSeconds(rand.Next(int.MaxValue));

    var gender = isFemale ? Gender.Female : Gender.Male;
    gender = rand.Next(1000) > 500 ? Gender.Other : gender;
    gender = rand.Next(1000) > 500 ? Gender.Unknown : gender;

    var patient = new Patient.Feeder.Models.Patient { Name = name, BirthDate = dateBirth, Gender = gender.ToString(), Active = rand.Next(1000) > 500 };

    await PostAsync(client, patient);
}

Console.WriteLine("Finish feeding");

static async Task PostAsync(HttpClient httpClient, Patient.Feeder.Models.Patient patient)
{
    using var jsonContent = new StringContent(JsonSerializer.Serialize(patient), Encoding.UTF8, "application/json");

    using var response = await httpClient.PostAsync("patients", jsonContent);

    response.EnsureSuccessStatusCode();

    var jsonResponse = await response.Content.ReadAsStringAsync();
    Console.WriteLine($"{jsonResponse}\n");
}
