// The 'using' keyword ensures that resources are properly disposed of when you're done using them.
/*
    - HttpClient implements IDisposable.
    - That means it holds unmanaged resources (like sockets).
    - To release those resources, you should call .Dispose() — and 'using' does that automatically for you.  
      
    * Don't Dispose of HttpClient Frequently. Only if it's short lived like in console apps. In services or long running apps just create one and reuse:
    
        private static readonly HttpClient httpClient = new HttpClient();

         public async Task<string> GetDataAsync()
        {
            HttpResponseMessage response = await httpClient.GetAsync("https://api.example.com/data");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

    * For expensive or reusable objects like HttpClient, create them once and reuse them, not inside a loop or inside a method that's called in a loop. 
 */

using API.Models;
using System.Text.Json;
using System.Text;

// HttpCllient
using var httpClient = new HttpClient();
// build url string
string baseUrl = "https://jsonplaceholder.typicode.com/";

// GET REQUEST
string GET_allResources = "posts";

try
{
    var GET_response = await httpClient.GetAsync(baseUrl + GET_allResources);
    GET_response.EnsureSuccessStatusCode();

    /*        
        GET_response - an HttpResponseMessage object, typically returned from an HTTP call using HttpClient.

        GET_response.Content - accesses the content/body of the HTTP response (not the headers or status code, just the actual content/data returned by the server).

        ReadAsStringAsync() - an asynchronous method that reads the content and returns it as a string.
     */
    string GET_responseContent = await GET_response.Content.ReadAsStringAsync();

    Console.WriteLine(GET_responseContent);
}
catch (HttpRequestException ex)
{
    Console.WriteLine(ex.Message);
}
catch (Exception ex)
{
    throw;
}


// POST REQUEST 
//string POST_resource = "posts";

//var POST_data = new Data
//{
//    title = "New title",
//    body = "This is new body",
//    userId = 1
//};

//var POST_json = JsonSerializer.Serialize(POST_data);

//try
//{
//    /*
//        StringContent - creates HTTP content from a string.

//        Encoding.UTF8 - sets the character encoding to UTF-8, which is standard for web APIs.

//        "application/json" - sets the Content-Type header to application/json, telling the server that you're sending JSON data. 
//     */
//    var POST_content = new StringContent(POST_json, Encoding.UTF8, "application/json");

//    var POST_response = await httpClient.PostAsync(baseUrl + POST_resource, POST_content);

//    POST_response.EnsureSuccessStatusCode();

//    var POST_responseContent = await POST_response.Content.ReadAsStringAsync();

//    Console.WriteLine(POST_responseContent);

//}
//catch (HttpRequestException ex)
//{
//    Console.WriteLine("Error: " + ex.Message);
//}
//catch (Exception ex)
//{
//    throw;
//}


// PUT/UPDATING REQUEST
//string PUT_resource = "posts/1";

//var PUT_data = new Data
//{
//    title = "Update title",
//    body = "Update body",
//    userId = 12
//};

//var PUT_json = JsonSerializer.Serialize(PUT_data);

//try
//{
//    var PUT_content = new StringContent(PUT_json, Encoding.UTF8, "application/json");

//    var PUT_response = await httpClient.PutAsync(baseUrl + PUT_resource, PUT_content);

//    PUT_response.EnsureSuccessStatusCode();

//    var PUT_responseContent = await PUT_response.Content.ReadAsStringAsync();

//    Console.WriteLine(PUT_responseContent);

//}
//catch (HttpRequestException ex){
//    Console.WriteLine("Error: " + ex.Message);
//}
//catch (Exception ex)
//{
//    throw;
//}


// PATCH REQUEST
//string PATCH_resource = "posts/1";

//var PATCH_data = new PatchData
//{
//    title = "Partial updated data"
//};

//var PATCH_json = JsonSerializer.Serialize(PATCH_data);

//try
//{
//    var PATCH_content = new StringContent(PATCH_json, Encoding.UTF8, "application/json");

//    var PATCH_response = await httpClient.PatchAsync(baseUrl + PATCH_resource, PATCH_content);

//    PATCH_response.EnsureSuccessStatusCode();

//    var PATCH_responseContent = await PATCH_response.Content.ReadAsStringAsync();

//    Console.WriteLine(PATCH_responseContent);

//}
//catch (HttpRequestException ex){
//    Console.WriteLine("Error: " + ex.Message);
//}
//catch (Exception ex)
//{
//    throw;
//}


// DELETE REQUEST
//string DELETE_resource = "posts/1";

//try
//{
//    var DELETE_response = await httpClient.DeleteAsync(baseUrl + DELETE_resource);

//    DELETE_response.EnsureSuccessStatusCode();

//    var DELETE_responseContent = await DELETE_response.Content.ReadAsStringAsync();

//    Console.WriteLine(DELETE_responseContent);

//}
//catch(HttpRequestException ex){
//    Console.WriteLine("Error: " + ex.Message);
//}
//catch (Exception ex)
//{

//    throw;
//}