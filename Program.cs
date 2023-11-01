// See https://aka.ms/new-console-template for more information

using Newtonsoft.Json;
using RestAPICase;

HttpClient client = new HttpClient() { BaseAddress = new Uri("https://jsonplaceholder.typicode.com") };
var response = await client.GetAsync("comments");
var content = await response.Content.ReadAsStringAsync();
var comments = JsonConvert.DeserializeObject<List<Comment>>(content);


List<Comment> sortByDecreasingOrder(List<Comment> list) {

    List<Comment> sortedComments = list.OrderByDescending(comment => comment.PostId).ThenByDescending(comment => comment.Body).ToList();

    return sortedComments;
}


void topComments(List<Comment> list, int limit) {
    for (int i = 0; i < limit; i++)
    {

        Console.WriteLine(list[i].PostId);
    }
}

sortByDecreasingOrder(comments);
topComments(sortByDecreasingOrder(comments), 10);


