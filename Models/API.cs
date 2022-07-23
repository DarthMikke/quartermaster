namespace Quartermaster;
using Quartermaster.Models;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

class QuartermasterAPI
{
    public bool IsInitialized
    {
        get => BaseURL != null && Http != null;
    }

    public string? BaseURL { get; set; }
    public HttpClient? Http { get; set; }

    public List<Category>? Categories { get; set; }
    public List<Thing>? Things { get; set; }
    public Int64? LastUpdated { get; private set; }

    public void Initialize(string baseURL, HttpClient http)
    {
        Console.WriteLine($"API initialized with base URL of {baseURL}");
        BaseURL = baseURL;
        Http = http;
    }

    private async Task<U?> request<T, U>(string method, string path, T? content) where U: class
    {
        Console.WriteLine($"{method} {path}");
        if (Http == null) {
            Console.WriteLine("API not initialized");
            return null;
        }
        HttpContent encodedContent = content == null ? new StringContent("") : JsonContent.Create<T>(content);
        HttpResponseMessage? response;

        switch (method)
        {
            case "GET":
                response = await Http!.GetAsync(this.BaseURL + path);
                break;
            case "PUT":
                response = await Http!.PutAsync(this.BaseURL + path, encodedContent);
                break;
            case "PATCH":
                response = await Http!.PatchAsync(this.BaseURL + path, encodedContent);
                break;
            case "DELETE":
                response = await Http!.DeleteAsync(this.BaseURL + path);
                break;
            default:
                Console.WriteLine("Unknown HTTP method");
                return null;
        }
        var decodedResponse = await response!.Content.ReadFromJsonAsync<U>();
        return decodedResponse;
    }

    public async Task<U?> Put<T, U>(string path, T? content) where U: class
    {
        return await request<T, U>("PUT", path, content);

        /*HttpContent encodedContent = content == null ? new StringContent("") : JsonContent.Create<T>(content);
        var response = await Http!.PutAsync(this.BaseURL + path, encodedContent);
        var decodedResponse = await response.Content.ReadFromJsonAsync<U>();
        return decodedResponse;*/
    }

    public async Task<U?> Patch<T, U>(string path, T? content) where U: class 
    {
        Console.WriteLine($"PATCH {path}");
        if (Http == null) {
            Console.WriteLine("API not initialized");
            return null;
        }
        HttpContent encodedContent = content == null ? new StringContent("") : JsonContent.Create<T>(content); 
        var response = await Http!.PatchAsync(this.BaseURL + path, encodedContent);
        var decodedResponse = await response.Content.ReadFromJsonAsync<U>();
        return decodedResponse;
        // Get categories & things from the server
    }

    public void AddCategory(Category category)
    {

    }

    public async Task<Thing> AddThing(Thing thing)
    {
        Console.WriteLine("Adding a new thing…");

        /* var content = JsonContent.Create<Thing>(thing);
        //var content = new StringContent(Encoding.UTF8.GetString(JsonSerializer.SerializeToUtf8Bytes<Thing>(thing)));
        Console.WriteLine(Encoding.Default.GetString(await content.ReadAsByteArrayAsync()));
        foreach (var header in content.Headers) {
            var key = header.Key;
            var sb = new StringBuilder();
            foreach (var value in header.Value) {
                sb.Append(value).Append(",");
            }
            if (sb.Length>=1) 
                sb.Length--;
            var values = sb.ToString();
            Console.WriteLine($"{key}: [ {values} ]");
        }
        
        var response = await Http.PutAsync(BaseURL + "api/things/", content);*/
        var response = await this.Put<Thing, Thing>("api/things/", thing);
        Console.WriteLine($"Id assigned by back-end: {response.Id}");
        return thing;
    }

    public void IncreaseThing(Thing thing) {
        thing.Multiplier += 1;
        Console.WriteLine(thing.Make);
    }

    public void DecreaseThing(Thing thing) {
        thing.Multiplier -= 1;
        Console.WriteLine(thing.Make);
    }

    public void DeleteThing(Thing thing) {

    }
}
