//Packages used for building the tests
using NUnit.Framework;
using System;
using System.Net;
using System.Threading.Tasks;
using RestSharp;
//using NUnit.Framework.Legacy;
using Allure.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;

namespace NUnitTestChallenge2
{
    // Defines a suite for Allure reports named "API Testing"
    [AllureSuite("API Testing")]
    public class Tests
    {
        private RestClient _client;

        // Runs before each test to initialize the client.
        [SetUp]
        public void Setup()
        {
            _client = new RestClient("https://jsonplaceholder.typicode.com");//Base URL
        }

        [Test] // Test for validating a GET request.
        [AllureSubSuite("Get Post API")]
        public async Task GetPost_ShouldReturnPostWithStatusCode200()
        {
            var request = new RestRequest("/posts/1", Method.Get);
            var response = await _client.ExecuteAsync(request);


            // Assert that the response status code is 200 (OK)
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Console.WriteLine("GET Response Body: " + response.Content);

            // Validate response content contains expected data.
            Assert.IsTrue(response.Content.Contains("\"id\": 1"));
            Assert.IsTrue(response.Content.Contains("\"userId\""));
            Assert.IsTrue(response.Content.Contains("\"title\""));
            Assert.IsTrue(response.Content.Contains("\"body\""));
        }

        [Test] // Test for validating a POST request.
        [AllureSubSuite("Post Post API")]
        public async Task CreatePost_ShouldReturnNewPostWithStatusCode201()
        {
            var request = new RestRequest("/posts", Method.Post);
            request.AddJsonBody(new { userId = 1, title = "foo", body = "bar" });

            var response = await _client.ExecuteAsync(request);

            // Assert that the response status code is 201 (Created).
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Console.WriteLine("POST Response Body: " + response.Content);

            // Validate response content.
            Assert.IsTrue(response.Content.Contains("\"title\": \"foo\""));
            Assert.IsTrue(response.Content.Contains("\"body\": \"bar\""));
        }

        [Test] // Test for validating a PUT request.
        [AllureSubSuite("Put Post API")]
        public async Task UpdatePost_ShouldReturnUpdatedPostWithStatusCode200()
        {
            var request = new RestRequest("/posts/1", Method.Put);
            request.AddJsonBody(new { userId = 1, id = 1, title = "updated title", body = "updated body" });

            var response = await _client.ExecuteAsync(request);

            // Assert that the response status code is 200 (OK).
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Console.WriteLine("PUT Response Body: " + response.Content);

            // Validate response content.
            Assert.IsTrue(response.Content.Contains("\"title\": \"updated title\""));
            Assert.IsTrue(response.Content.Contains("\"body\": \"updated body\""));
        }

        [Test] // Test for validating a DELETE request.
        [AllureSubSuite("Delete Post API")]
        public async Task DeletePost_ShouldReturnStatusCode200Or204()
        {
            var request = new RestRequest("/posts/1", Method.Delete);
            var response = await _client.ExecuteAsync(request);

            // Assert that the response status code is 200 (OK) or 204 (No Content).
            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.NoContent);
            Console.WriteLine("DELETE Response Body: " + response.Content);
        }

        // Runs after each test to clean up resources
        [TearDown]
        public void TearDown()
        {
            _client.Dispose();
        }
    }
}