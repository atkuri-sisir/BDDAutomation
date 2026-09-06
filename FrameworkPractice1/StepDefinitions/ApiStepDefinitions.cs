using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;
using Utilities.AppUtils;
using Utilities.ConfigUtils;
using System.Reflection;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using RestSharp;
using FrameworkLayer.Models;
using AventStack.ExtentReports;

namespace FrameworkLayer.StepDefinitions
{
    [Binding]
    public class ApiStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly TestSettings _testSettings;
        private RestResponse _response;
        public ApiStepDefinitions(ScenarioContext scenarioContext, FeatureContext featureContext)
        {
            _scenarioContext = scenarioContext;
            _testSettings = (TestSettings)featureContext["TestSettings"];
        }

        [Given(@"I call the api")]
        public void GivenICallTheApi()
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            APIUtility.SetRestClient(_testSettings.ApiCatFactUrl);
            _scenarioContext["response"] = APIUtility.Get("breeds");
            parameters.Add("limit", "1");
            _scenarioContext["responseWithParameter"] = APIUtility.Get("breeds", parameters);
        }

        [Then(@"I should get the response")]
        public void ThenIShouldGetTheResponse()
        {
            var response = (RestResponse)_scenarioContext["response"];
            var data = JsonConvert.DeserializeObject<BreedData>(response.Content);
            var responseWithParameters = (RestResponse)_scenarioContext["responseWithParameter"];
            var dataWithParameters = JsonConvert.DeserializeObject<BreedData>(responseWithParameters.Content);
        }

        [Given(@"I call the books api")]
        public void GivenICallTheBooksApi()
        {
            APIUtility.SetRestClient(_testSettings.ApiBookstoreUrl);
            _scenarioContext["bookresponse"] = APIUtility.Get("Books");
        }

        [Then(@"I Should get the books response")]
        public void ThenIShouldGetTheBooksResponse()
        {
            var response = (RestResponse)_scenarioContext["bookresponse"];
            var bookData = JsonConvert.DeserializeObject<BookList>(response.Content);
        }

        [Given(@"I have the user credentials from a json file")]
        public void GivenIHaveTheUserCredentialsFromAJsonFile()
        {
            var userCredentialsFile = $"{Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\\TestData\\bookStoreUserCredentials.json";
            var bookStoreUserData = File.ReadAllText(userCredentialsFile);
            var bookStoreUserObject = JsonConvert.DeserializeObject<BookStoreUser>(bookStoreUserData);
            _scenarioContext["bookStoreUser"] = bookStoreUserObject;
        }

        [When(@"I post the user credentials to create user")]
        public void WhenIPostTheUserCredentials()
        {
            APIUtility.SetRestClient(_testSettings.ApiBookstoreUserUrl);
            var bookStoreUserObject = (BookStoreUser)_scenarioContext["bookStoreUser"];
            _response = APIUtility.Post<BookStoreUser>("User", bookStoreUserObject);
            _scenarioContext["userCreationResponse"] = _response;
        }

        [Then(@"I should get the response that user is created")]
        public void ThenIShouldGetTheResponseThatUserIsCreated()
        {
            _response = (RestResponse)_scenarioContext["userCreationResponse"];
            try
            {
                Assert.AreEqual(201, APIUtility.GetResponseCode(_response));
            }
            catch (AssertionException e)
            {
                Console.WriteLine(_response.Content);
                throw;
            }
            var createdUserData = APIUtility.Deserialize<CreatedBookstoreUser>(_response.Content);
            CreatedBookstoreUser.UpdateUserId(createdUserData);
        }

        [When(@"I post the user credentials to generate a token")]
        public void GivenIPostTheUserCredentialsFromTheJsonFile()
        {
            APIUtility.SetRestClient(_testSettings.ApiBookstoreUserUrl);
            var bookStoreUserObject = (BookStoreUser)_scenarioContext["bookStoreUser"];
            _response = APIUtility.Post<BookStoreUser>("GenerateToken", bookStoreUserObject);
            _scenarioContext["bookStoreTokenReponse"] = _response;
        }

        [Then(@"I should get the token as response")]
        public void ThenIShouldGetTheTokenAsResponse()
        {
            _response = (RestResponse)_scenarioContext["bookStoreTokenReponse"];
            Console.WriteLine(_response.Content);
            try
            {
                Assert.AreEqual(200, APIUtility.GetResponseCode(_response));
            }
            catch(AssertionException e)
            {
                Console.WriteLine(_response.Content);
                throw;
            }
        }

        [When(@"I post the books data with the authorization token")]
        public void WhenIPostTheBooksDataWithTheAuthorizationToken()
        {
            APIUtility.SetRestClient(_testSettings.ApiBookstoreUrl);
            Dictionary<string, string> headers = new Dictionary<string, string>();
            _response = (RestResponse)_scenarioContext["bookStoreTokenReponse"];
            var tokenData = APIUtility.Deserialize<TokenData>(_response.Content);
            headers.Add("Authorization", $"Bearer {tokenData.Token}");
            var userBookId = File.ReadAllText($"{Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\\TestData\\UserId.json");
            var user = JsonConvert.DeserializeObject<UserIdentityNumber>(userBookId);
            var userBookData = File.ReadAllText($"{Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\\TestData\\userBookData.json");
            var userBookObject = new UserBookData
            {
                UserId = user.UserId,
                Isbns = JsonConvert.DeserializeObject<UserBooks>(userBookData).Isbns
            };
            _response = APIUtility.Post<UserBookData>("Books", userBookObject, headers);
            _scenarioContext["bookAdditionResponse"] = _response;
        }

        [Then(@"I should get response as books are added")]
        public void ThenIShouldGetResponseAsBooksAreAdded()
        {
            _response = (RestResponse)_scenarioContext["bookAdditionResponse"];
            try
            {
                Assert.AreEqual(201, APIUtility.GetResponseCode(_response));
            }
            catch(AssertionException e)
            {
                Console.WriteLine(_response.Content);
                throw;
            }
        }

        [When(@"I delete the specified book data using the authorization token")]
        public void WhenIDeleteTheSpecifiedBookDataUsingTheAuthorizationToken()
        {
            APIUtility.SetRestClient(_testSettings.ApiBookstoreUrl);
            Dictionary<string, string> headers = new Dictionary<string, string>();
            _response = (RestResponse)_scenarioContext["bookStoreTokenReponse"];
            var tokenData = APIUtility.Deserialize<TokenData>(_response.Content);
            headers.Add("Authorization", $"Bearer {tokenData.Token}");
            var userBookId = File.ReadAllText($"{Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\\TestData\\UserId.json");
            var user = JsonConvert.DeserializeObject<UserIdentityNumber>(userBookId);
            var BookToDelete = new BookToDelete
            {
                UserId = user.UserId,
                Isbn = "9781449325862"
            };
            _response = APIUtility.Delete<BookToDelete>("Book", BookToDelete, headers);
            _scenarioContext["bookAdditionResponse"] = _response;
        }

        [Then(@"I should get response as book is deleted")]
        public void ThenIShouldGetResponseAsBookIsDeleted()
        {
            _response = (RestResponse)_scenarioContext["bookAdditionResponse"];
            try
            {
                Assert.AreEqual(204, APIUtility.GetResponseCode(_response));
            }
            catch (AssertionException e)
            {
                Console.WriteLine(_response.Content);
                throw;
            }
        }


    }
}
