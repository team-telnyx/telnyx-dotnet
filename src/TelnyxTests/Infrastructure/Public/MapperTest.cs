namespace TelnyxTests
{
    using System;
    using Newtonsoft.Json;
    using Telnyx;
    using Xunit;

    public class MapperTest : BaseTelnyxTest
    {
        private class TestModel
        {
            public string Name { get; set; }

            public string Address { get; set; }
        }

;

        private readonly string _stringValue;
        private readonly TestModel _testModel;
        private readonly TelnyxResponse _telnyxResponse;

        public MapperTest()
        {
            this._stringValue = "TestValue";
            this._testModel = new TestModel()
            {
                Name = this._stringValue,
                Address = this._stringValue
            };
            this._telnyxResponse = new TelnyxResponse()
            {
                ResponseJson = JsonConvert.SerializeObject(this._testModel),
                ObjectJson = this._stringValue,
                RequestId = "Id001",
                RequestDate = DateTime.Now,
                Url = "example.com/test"
            };
        }

        [Fact]
        public void MapCollectionFromJson_Take_JsonString()
        {
            string jsonString = JsonConvert.SerializeObject(this._testModel);
            var response = Mapper<TestModel>.MapCollectionFromJson(jsonString, "Name", this._telnyxResponse);
            Assert.NotNull(response);
            Assert.Equal(0, response.Count);
        }

        [Fact]
        public void MapCollectionFromJson_Take_TelnyxResponse()
        {
            string jsonString = JsonConvert.SerializeObject(this._testModel);
            var response = Mapper<TestModel>.MapCollectionFromJson(this._telnyxResponse, "Name");
            Assert.NotNull(response);
            Assert.Equal(0, response.Count);
        }

        [Fact]
        public void MapFromPlainText()
        {
            string jsonString = JsonConvert.SerializeObject(this._testModel);
            var response = Mapper<string>.MapFromPlainText(jsonString);
            Assert.NotNull(response);
        }

        [Fact]
        public void MapFromJson()
        {
            string jsonString = @"{  'data':{'Name':'Test', 'Address':'Test'  } }";
            var response = Mapper<TestModel>.MapFromJson(jsonString);
            Assert.NotNull(response);
            Assert.Equal(typeof(TestModel), response.GetType());
        }

        [Fact]
        public void MapFromJsonError()
        {
            string jsonString = @"{  'error':{'Name':'Test', 'Address':'Test'  } }";
            var response = Mapper<TestModel>.MapFromJsonError(jsonString);
            Assert.NotNull(response);
            Assert.Equal(typeof(TestModel), response.GetType());
        }

        [Fact]
        public void MapFromJsonErrors()
        {
            string jsonString = @"{  'errors':{'Name':'Test', 'Address':'Test'  } }";
            var response = Mapper<TestModel>.MapFromJsonErrors(jsonString);
            Assert.NotNull(response);
            Assert.Equal(typeof(TestModel), response.GetType());
        }

        [Fact]
        public void MapFromJson_Take_Telnyx()
        {
            var response = Mapper<TestModel>.MapFromJson(this._telnyxResponse, string.Empty);
            Assert.NotNull(response);
            Assert.Equal(typeof(TestModel), response.GetType());
        }
    }
}

