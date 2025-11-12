using demo_taller.Models.Entities;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using demo_taller;

namespace AcceptanceTests
{
    public class ControllerTest : IClassFixture<WebApplicationFactory<demo_taller.Program>>
    {
        private readonly HttpClient _client;

        public ControllerTest(WebApplicationFactory<demo_taller.Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task test()
        {
            // Arrange
            var message = new Message
            {
                Name = "Dennis",
                Email = "dennis@example.com",
                Subject = "Prueba desde Testing",
                Content = "Hola, este es un mensaje de prueba"
            };

            // Act
            var response = await _client.PostAsJsonAsync("/Message/Post", message);

            // Assert
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            Assert.Contains("-1", content);
        }
    }
}
