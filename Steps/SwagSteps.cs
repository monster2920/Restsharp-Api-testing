using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SwagRestApi.Steps
{
    [Binding]
    public sealed class SwagSteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;
        private readonly  string baseURL= "https://be-java.azurewebsites.net";

        public SwagSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"endpoint url is (.*)")]
        public void GivenEndpointUrlIs_(string endpoint)
        {
            RestCommon.InitializeClient(baseURL,endpoint);
        }
        // GET
        [Given(@"i created a (.*) request")]
        public void GivenICreatedA_Request(Method methodName)
        {
            RestCommon.CreateRequest(methodName);
        }

        [Given(@"i pass the url parameter as (.*)")]
        public void GivenIPassTheUrlParameterAs_(int urlParam)
        {
            RestCommon.AddUrlParameter(urlParam);
        }

        [When(@"i send the request")]
        public void WhenISendTheRequest()
        {
            RestCommon.Execute();
        }

        [Then(@"I validated the status code Accepted (.*)")]
        public void ThenIValidatedTheStausCodeAccepted( string expectedtext)
        {
            RestCommon.ValidateResponseContent(expectedtext);
        }
        //Post
        [Given(@"i add the Request body")]
        public void GivenIAddTheRequestBody(Table table)
        {
            var requestBody = table.CreateInstance<SwagEmpDTO>();
            string requestJsonBody = JsonConvert.SerializeObject(requestBody);
            RestCommon.AddRequestBody(requestJsonBody);
        }

        [Then(@"I validated the response statuscode as '(.*)'")]
        public void ThenIValidatedTheResponseStatuscodeAs(string expected)
        {
            RestCommon.ValidateResponseCode(expected);
        }
        [Scope(Tag ="put")]
        [Then(@"I validated the  response statuscode as '(.*)'")]
        public void ThenIValidatedTheResponseStatuscode(string expected)
        {
            RestCommon.ValidateResponseCode(expected);
        }
        //delete
        [Then(@"I validated the https code Accepted (.*)")]
        public void ThenIValidatedTheHttpsCodeAccepted(int expected)
        {
            RestCommon.ValidatehttpsCode(expected);
        }












    }
}
