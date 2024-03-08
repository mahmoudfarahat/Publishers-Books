using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using PublishersAPI;
using System.Net.Http.Json;
using System.Net;
using PublisherData;

namespace TestAPIMethods
{
    [TestClass]
    public class APITests
    {
        [TestMethod]
        public async Task ApiIsRunning()
        {
             await using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();
            var response = await client.GetStringAsync("/weatherforecast");
            Assert.AreEqual("[{\"date",response.Substring(0,7));    
        }

        [TestMethod]
        public async Task CanRetrieveAnAuthorDTO()
        {
            await using var application = new CustomWebApplicationFactory<Program>();
            CreateAndSeedDatabase(application);
            using var client = application.CreateClient();
            var authorDTO = await client.GetFromJsonAsync<AuthorDto>("/api/author/2");
            Assert.IsInstanceOfType(authorDTO, typeof(AuthorDto));
        }

        [TestMethod]
        public async Task CanInsertAnAuthor()
        {
            var authorDTO = new AuthorDto(0, "John", "Doe");
            await using var application = new CustomWebApplicationFactory<Program>();
            CreateAndSeedDatabase(application);
            using var client = application.CreateClient();
            var response = await client.PostAsJsonAsync("/api/author/", authorDTO);
            var author = await response.Content.ReadFromJsonAsync<AuthorDto>();
            Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);
            Assert.AreNotEqual(0, author.Id);
        }

        private static void CreateAndSeedDatabase(WebApplicationFactory<Program> appFactory)
        {
            using (var scope = appFactory.Services.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<ApplicationDbContext>();
                db.Database.EnsureCreated();

            }


        }


    }
}