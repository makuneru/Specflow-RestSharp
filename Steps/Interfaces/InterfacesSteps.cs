using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using SmooveAPI;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using System;


namespace RestSharp_SpecFlow.Steps.Interfaces
{
    [Binding]
    public class InterfacesSteps
    {
        RestResponse response; 
        public InterfacesSteps(SharedSteps sharedSteps){
            response = sharedSteps.response;
        }

        [Then(@"Validate API response content")]
        public void ThenValidateAPIResponse()
        {
            //TODO: assertions
            try { 
                var interfaces = JsonConvert.DeserializeObject<List<Interface>>(response.Content);
                Assert.IsNotEmpty(interfaces);
            }
            catch
            {
                var interfaces = JsonConvert.DeserializeObject<Interface>(response.Content);
                Assert.IsNotNull(interfaces.Id);
            }
        }
    }
}
