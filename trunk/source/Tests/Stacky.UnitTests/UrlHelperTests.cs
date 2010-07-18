using System;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Specialized;
using System.Collections.Generic;

namespace Stacky.UnitTests
{
    [TestClass]
    public class UrlHelperTests
    {
        public TestContext TestContext { get; set; }
        private static string version = "1.0";

        #region BuildUrl

        [TestMethod]
        public void BuildUrl_UrlParameters_IncludedInResult()
        {
            var url = UrlHelper.BuildUrl("TestMethod", version, Sites.StackOverflow.ApiEndpoint, new string[] { "item1", "item2" }, null);
            Assert.AreEqual("http://api.stackoverflow.com/" + version + "/TestMethod/item1/item2/", url.ToString());
        }

        [TestMethod]
        public void BuildUrl_NullUrlParameters_ResultsInNoUrlParameters()
        {
            var url = UrlHelper.BuildUrl("TestMethod", version, Sites.StackOverflow.ApiEndpoint, null, null);
            Assert.AreEqual("http://api.stackoverflow.com/" + version + "/TestMethod/", url.ToString());
        }

        [TestMethod]
        public void BuildUrl_UrlParamatersAndQueryStringParameters_BuiltCorrectly()
        {
            var url = UrlHelper.BuildUrl("TestMethod", version, Sites.StackOverflow.ApiEndpoint, new string[] { "item1", "item2" }, new
            {
                key = "key",
                config = "1"
            });
            Assert.AreEqual("http://api.stackoverflow.com/" + version + "/TestMethod/item1/item2/?key=key&config=1", url.ToString());
        }

        #endregion

        #region BuildParameters

        [TestMethod]
        public void BuildParameters_NullParameters_ResultsInEmptyString()
        {
            string queryString = UrlHelper.BuildParameters((object)null);
            Assert.AreEqual(String.Empty, queryString);
        }

        [TestMethod]
        public void BuildParameters_WithDictionary_NullParameters_ResultsInEmptyString()
        {
            string queryString = UrlHelper.BuildParameters((Dictionary<string, string>)null);
            Assert.AreEqual(String.Empty, queryString);
        }

        class NoReadableProperties
        {
            private string val;

            public string Value
            {
                set
                {
                    val = value;
                }
            }
        }

        [TestMethod]
        public void BuildParameters_ObjectWithNoReadableProperties_ResultsInEmptyString()
        {
            NoReadableProperties o = new NoReadableProperties();
            string queryString = UrlHelper.BuildParameters(o);
            Assert.AreEqual(String.Empty, queryString);
        }

        [TestMethod]
        public void BuildParameters_ObjectWithNoProperties_ResultsInEmptyString()
        {
            string queryString = UrlHelper.BuildParameters(4);
            Assert.AreEqual(String.Empty, queryString);
        }

        class TestParameters
        {
            public object Key { get; set; }
            public object Value { get; set; }
        }

        [TestMethod]
        public void BuildParameters_ObjectWithNullValueProperty_ResultsInEmptyString()
        {
            string queryString = UrlHelper.BuildParameters(new TestParameters {Key = null});
            Assert.AreEqual(String.Empty, queryString);
        }

        [TestMethod]
        public void BuildParameters_ObjectWithNullValueProperty_KeyIsSkipped()
        {
            string queryString = UrlHelper.BuildParameters(new TestParameters { Key = null, Value = 1 });
            Assert.AreEqual("Value=1", queryString);
        }

        [TestMethod]
        public void BuildParameters_ValuesAreUrlEncoded()
        {
            string s = "I Owe $100";
            string encoded = Uri.EscapeDataString(s);
            string queryString = UrlHelper.BuildParameters(new {Key = s});
            Assert.AreEqual("Key=" + encoded, queryString);
        }

        [TestMethod]
        public void BuildParameters_QueryStringDoesNotEndInAmpersand()
        {
            string queryString = UrlHelper.BuildParameters(new {Value1 = 3, Value2 = "Me"});
            Assert.IsFalse(queryString.EndsWith("&"));
        }

        [TestMethod]
        public void BuildParameters_WithDictionary_ValuesAreUrlEncoded()
        {
            string s = "I Owe $100";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["Key"] = s;
            string encoded = Uri.EscapeDataString(s);
            string queryString = UrlHelper.BuildParameters(parameters);
            Assert.AreEqual("Key=" + encoded, queryString);
        }

        [TestMethod]
        public void BuildParameters_WithDictionary_QueryStringDoesNotEndInAmpersand()
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["Value1"] = "3";
            parameters["Value2"] = "Me";
            string queryString = UrlHelper.BuildParameters(parameters);
            Assert.IsFalse(queryString.EndsWith("&"));
        }

        #endregion

        #region ObjectToDictionary

        [TestMethod]
        public void ObjectToDictionary_nullObject_ReturnsEmptyDictionary()
        {
            var d = UrlHelper.ObjectToDictionary(null);
            Assert.AreEqual(0, d.Count);
        }

        [TestMethod]
        public void ObjectToDictionary_AllReadablePropertiesBecomeKeys()
        {
            TestParameters p = new TestParameters { Key = "Key", Value = 1 };
            var d = UrlHelper.ObjectToDictionary(p);
            Assert.AreEqual(2, d.Count);
            Assert.IsTrue(d.ContainsKey("Key"));
            Assert.IsTrue(d.ContainsValue("Key"));
            Assert.IsTrue(d.ContainsKey("Value"));
            Assert.IsTrue(d.ContainsValue("1"));
        }

        [TestMethod]
        public void ObjectToDictionary_ObjectWithNoReadableProperties_ReturnsEmptyDictionary()
        {
            NoReadableProperties o = new NoReadableProperties();
            var d = UrlHelper.ObjectToDictionary(o);
            Assert.AreEqual(0, d.Count);
        }

        [TestMethod]
        public void ObjectToDictionary_ObjectWithNullValueProperty_KeyIsSkipped()
        {
            TestParameters p = new TestParameters { Key = null, Value = 1 };
            var d = UrlHelper.ObjectToDictionary(p);
            Assert.AreEqual(1, d.Count);
            Assert.IsFalse(d.ContainsKey("Key"));
            Assert.IsTrue(d.ContainsKey("Value"));
            Assert.IsTrue(d.ContainsValue("1"));
        }

        #endregion

        [TestMethod]
        public void Bug6099_PoundSignEncodedCorrectly()
        {
            var url = UrlHelper.BuildUrl("questions", version, Sites.StackOverflow.ApiEndpoint, null, new
            {
                item1 = "test#one",
                item2 = "anotherOne"
            });

            Assert.IsTrue(url.ToString().Contains("%23"));
        }
    }
}