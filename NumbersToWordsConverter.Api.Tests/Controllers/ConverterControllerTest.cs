using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using NumbersToWordsConverter.Api.Controllers;
using NumbersToWordsConverter.Api.Models;
using System;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace NumbersToWordsConverter.Api.Tests.Controllers
{
    [TestClass]
    public class ConverterControllerTest
    {
        private DataModel dataModelTest;
        private ConverterController converterControllerTest;

        [TestInitialize]
        public void Initialize_ConverterControllerTest()
        {
            dataModelTest = new DataModel();

            converterControllerTest = new ConverterController();

            //https://docs.microsoft.com/en-us/aspnet/web-api/overview/testing-and-debugging/unit-testing-controllers-in-web-api
            converterControllerTest.Request = new HttpRequestMessage();
            converterControllerTest.Configuration = new HttpConfiguration();
        }

        #region Expected Exceptions

        [TestMethod]
        [ExpectedException(typeof(HttpResponseException), "Name cannot be null or Model is invalid format.")]
        public void PassModel_AsNull_MustThrowExceptionWithErrorMessage()
        {
            // Arrange
            var JsonData = JArray.Parse("[{\"Name\":\"\",\"Numbers\":-12}]");
            dataModelTest.Name = JsonData[0]["Name"].ToString(); //null
            dataModelTest.Numbers = Convert.ToInt32(JsonData[0]["Numbers"].ToString());

            // Act
            converterControllerTest.Process(dataModelTest);

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(HttpResponseException), "Name must be alphabet and space only and cannot be null.")]
        public void NameWithEmptyValue_MustThrowExceptionWithErrorMessage()
        {
            // Arrange
            dataModelTest.Name = "M@rV!N L@CuN@";
            dataModelTest.Numbers = 1;

            // Act
            converterControllerTest.Process(dataModelTest);

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(HttpResponseException), "/Numbers must be numberic value from 1 up to 9,999,999 million.")]
        public void NumbersWithZeroValue_MustThrowExceptionWithErrorMessage()
        {
            // Arrange
            dataModelTest.Name = "Marvin Lacuna";
            dataModelTest.Numbers = 0;

            // Act
            converterControllerTest.Process(dataModelTest);

            // Assert
        }

        #endregion Expected Exceptions

        #region Convert Numbers to Words

        [TestMethod]
        //ones
        public void WithOneDigit_WholeNumber_MustReturnNumbersAsWords()
        {
            // Arrange
            dataModelTest.Name = "Marvin Lacuna";
            dataModelTest.Numbers = 8;

            // Act
            var result = converterControllerTest.Process(dataModelTest);
            var dataModelResult = result as OkNegotiatedContentResult<DataModel>;

            // Assert
            Assert.IsTrue(dataModelResult.Content.Name.Equals("Marvin Lacuna"));
            Assert.IsTrue(dataModelResult.Content.Words.Equals("EIGHT DOLLARS"));
            Assert.IsTrue(dataModelResult.Content.Numbers.Equals(8));
        }

        [TestMethod]
        //teens
        public void WithTwoDigits_WholeNumber_MustReturnNumbersAsWords()
        {
            // Arrange
            dataModelTest.Name = "Marvin Lacuna";
            dataModelTest.Numbers = 15;

            // Act
            var result = converterControllerTest.Process(dataModelTest);
            var dataModelResult = result as OkNegotiatedContentResult<DataModel>;

            // Assert
            Assert.IsTrue(dataModelResult.Content.Name.Equals("Marvin Lacuna"));
            Assert.IsTrue(dataModelResult.Content.Words.Equals("FIFTEEN DOLLARS"));
            Assert.IsTrue(dataModelResult.Content.Numbers.Equals(15));
        }

        [TestMethod]
        //tens and hundeds
        public void WithThreeDigits_WholeNumber_MustReturnNumbersAsWords()
        {
            // Arrange
            dataModelTest.Name = "Marvin Lacuna";
            dataModelTest.Numbers = 289;

            // Act
            var result = converterControllerTest.Process(dataModelTest);
            var dataModelResult = result as OkNegotiatedContentResult<DataModel>;

            // Assert
            Assert.IsTrue(dataModelResult.Content.Name.Equals("Marvin Lacuna"));
            Assert.IsTrue(dataModelResult.Content.Words.Equals("TWO HUNDRED EIGHTY-NINE DOLLARS"));
            Assert.IsTrue(dataModelResult.Content.Numbers.Equals(289));
        }

        [TestMethod]
        //thousands
        public void WithFourDigits_WholeNumber_MustReturnNumbersAsWords()
        {
            // Arrange
            dataModelTest.Name = "Marvin Lacuna";
            dataModelTest.Numbers = 1437;

            // Act
            var result = converterControllerTest.Process(dataModelTest);
            var dataModelResult = result as OkNegotiatedContentResult<DataModel>;

            // Assert
            Assert.IsTrue(dataModelResult.Content.Name.Equals("Marvin Lacuna"));
            Assert.IsTrue(dataModelResult.Content.Words.Equals("ONE THOUSAND FOUR HUNDRED THIRTY-SEVEN DOLLARS"));
            Assert.IsTrue(dataModelResult.Content.Numbers.Equals(1437));
        }

        [TestMethod]
        //ten thousands
        public void WithFiveDigits_WholeNumber_MustReturnNumbersAsWords()
        {
            // Arrange
            dataModelTest.Name = "Marvin Lacuna";
            dataModelTest.Numbers = 12531;

            // Act
            var result = converterControllerTest.Process(dataModelTest);
            var dataModelResult = result as OkNegotiatedContentResult<DataModel>;

            // Assert
            Assert.IsTrue(dataModelResult.Content.Name.Equals("Marvin Lacuna"));
            Assert.IsTrue(dataModelResult.Content.Words.Equals("TWELVE THOUSAND FIVE HUNDRED THIRTY-ONE DOLLARS"));
            Assert.IsTrue(dataModelResult.Content.Numbers.Equals(12531));
        }

        [TestMethod]
        //hundred thousands
        public void WithSixDigits_WholeNumber_MustReturnNumbersAsWords()
        {
            // Arrange
            dataModelTest.Name = "Marvin Lacuna";
            dataModelTest.Numbers = 146777;

            // Act
            var result = converterControllerTest.Process(dataModelTest);
            var dataModelResult = result as OkNegotiatedContentResult<DataModel>;

            // Assert
            Assert.IsTrue(dataModelResult.Content.Name.Equals("Marvin Lacuna"));
            Assert.IsTrue(dataModelResult.Content.Words.Equals("ONE HUNDRED FORTY-SIX THOUSAND SEVEN HUNDRED SEVENTY-SEVEN DOLLARS"));
            Assert.IsTrue(dataModelResult.Content.Numbers.Equals(146777));
        }

        [TestMethod]
        //million
        public void WithSevenDigits_WholeNumber_MustReturnNumbersAsWords()
        {
            // Arrange
            dataModelTest.Name = "Marvin Lacuna";
            dataModelTest.Numbers = 5555555;

            // Act
            var result = converterControllerTest.Process(dataModelTest);
            var dataModelResult = result as OkNegotiatedContentResult<DataModel>;

            // Assert
            Assert.IsTrue(dataModelResult.Content.Name.Equals("Marvin Lacuna"));
            Assert.IsTrue(dataModelResult.Content.Words.Equals("FIVE MILLION FIVE HUNDRED FIFTY-FIVE THOUSAND FIVE HUNDRED FIFTY-FIVE DOLLARS"));
            Assert.IsTrue(dataModelResult.Content.Numbers.Equals(5555555));
        }

        [TestMethod]
        //decimals
        public void WithtThreeDigits_WholeNumbers_And_ThreeDecimals_MustReturnNumbersAsWords()
        {
            // Arrange
            dataModelTest.Name = "Marvin Lacuna";
            dataModelTest.Numbers = Convert.ToDecimal(123.45);

            // Act
            var result = converterControllerTest.Process(dataModelTest);
            var dataModelResult = result as OkNegotiatedContentResult<DataModel>;

            // Assert
            Assert.IsTrue(dataModelResult.Content.Name.Equals("Marvin Lacuna"));
            Assert.IsTrue(dataModelResult.Content.Words.Equals("ONE HUNDRED TWENTY-THREE DOLLARS AND FORTY-FIVE CENTS"));
            Assert.IsTrue(dataModelResult.Content.Numbers.Equals(Convert.ToDecimal(123.45)));
        }

        #endregion Convert Numbers to Words

        #region Format Words

        [TestMethod]
        //Format words - Ten-One
        public void FormatWords_TenOne_MustReturnCorrectNumbersAsWords()
        {
            // Arrange
            dataModelTest.Name = "Marvin Lacuna";
            dataModelTest.Numbers = 11111;

            // Act
            var result = converterControllerTest.Process(dataModelTest);
            var dataModelResult = result as OkNegotiatedContentResult<DataModel>;

            // Assert
            Assert.IsTrue(dataModelResult.Content.Name.Equals("Marvin Lacuna"));
            Assert.IsTrue(dataModelResult.Content.Words.Equals("ELEVEN THOUSAND ONE HUNDRED ELEVEN DOLLARS"));
            Assert.IsTrue(dataModelResult.Content.Numbers.Equals(11111));
        }

        [TestMethod]
        //Format words - Ten-Two
        public void FormatWords_TenTwo_MustReturnCorrectNumbersAsWords()
        {
            // Arrange
            dataModelTest.Name = "Marvin Lacuna";
            dataModelTest.Numbers = 12112;

            // Act
            var result = converterControllerTest.Process(dataModelTest);
            var dataModelResult = result as OkNegotiatedContentResult<DataModel>;

            // Assert
            Assert.IsTrue(dataModelResult.Content.Name.Equals("Marvin Lacuna"));
            Assert.IsTrue(dataModelResult.Content.Words.Equals("TWELVE THOUSAND ONE HUNDRED TWELVE DOLLARS"));
            Assert.IsTrue(dataModelResult.Content.Numbers.Equals(12112));
        }

        [TestMethod]
        //Format words - Ten-Three
        public void FormatWords_TenThree_MustReturnCorrectNumbersAsWords()
        {
            // Arrange
            dataModelTest.Name = "Marvin Lacuna";
            dataModelTest.Numbers = 13113;

            // Act
            var result = converterControllerTest.Process(dataModelTest);
            var dataModelResult = result as OkNegotiatedContentResult<DataModel>;

            // Assert
            Assert.IsTrue(dataModelResult.Content.Name.Equals("Marvin Lacuna"));
            Assert.IsTrue(dataModelResult.Content.Words.Equals("THIRTEEN THOUSAND ONE HUNDRED THIRTEEN DOLLARS"));
            Assert.IsTrue(dataModelResult.Content.Numbers.Equals(13113));
        }

        [TestMethod]
        //Format words - Ten-Four
        public void FormatWords_TenFour_MustReturnCorrectNumbersAsWords()
        {
            // Arrange
            dataModelTest.Name = "Marvin Lacuna";
            dataModelTest.Numbers = 14114;

            // Act
            var result = converterControllerTest.Process(dataModelTest);
            var dataModelResult = result as OkNegotiatedContentResult<DataModel>;

            // Assert
            Assert.IsTrue(dataModelResult.Content.Name.Equals("Marvin Lacuna"));
            Assert.IsTrue(dataModelResult.Content.Words.Equals("FOURTEEN THOUSAND ONE HUNDRED FOURTEEN DOLLARS"));
            Assert.IsTrue(dataModelResult.Content.Numbers.Equals(14114));
        }

        [TestMethod]
        //Format words - Ten-Five
        public void FormatWords_TenFive_MustReturnCorrectNumbersAsWords()
        {
            // Arrange
            dataModelTest.Name = "Marvin Lacuna";
            dataModelTest.Numbers = 15115;

            // Act
            var result = converterControllerTest.Process(dataModelTest);
            var dataModelResult = result as OkNegotiatedContentResult<DataModel>;

            // Assert
            Assert.IsTrue(dataModelResult.Content.Name.Equals("Marvin Lacuna"));
            Assert.IsTrue(dataModelResult.Content.Words.Equals("FIFTEEN THOUSAND ONE HUNDRED FIFTEEN DOLLARS"));
            Assert.IsTrue(dataModelResult.Content.Numbers.Equals(15115));
        }

        [TestMethod]
        //Format words - Ten-Six
        public void FormatWords_TenSix_MustReturnCorrectNumbersAsWords()
        {
            // Arrange
            dataModelTest.Name = "Marvin Lacuna";
            dataModelTest.Numbers = 16116;

            // Act
            var result = converterControllerTest.Process(dataModelTest);
            var dataModelResult = result as OkNegotiatedContentResult<DataModel>;

            // Assert
            Assert.IsTrue(dataModelResult.Content.Name.Equals("Marvin Lacuna"));
            Assert.IsTrue(dataModelResult.Content.Words.Equals("SIXTEEN THOUSAND ONE HUNDRED SIXTEEN DOLLARS"));
            Assert.IsTrue(dataModelResult.Content.Numbers.Equals(16116));
        }

        [TestMethod]
        //Format words - Ten-Seven
        public void FormatWords_TenSeven_MustReturnCorrectNumbersAsWords()
        {
            // Arrange
            dataModelTest.Name = "Marvin Lacuna";
            dataModelTest.Numbers = 17117;

            // Act
            var result = converterControllerTest.Process(dataModelTest);
            var dataModelResult = result as OkNegotiatedContentResult<DataModel>;

            // Assert
            Assert.IsTrue(dataModelResult.Content.Name.Equals("Marvin Lacuna"));
            Assert.IsTrue(dataModelResult.Content.Words.Equals("SEVENTEEN THOUSAND ONE HUNDRED SEVENTEEN DOLLARS"));
            Assert.IsTrue(dataModelResult.Content.Numbers.Equals(17117));
        }

        [TestMethod]
        //Format words - Ten-Eight
        public void FormatWords_TenEight_MustReturnCorrectNumbersAsWords()
        {
            // Arrange
            dataModelTest.Name = "Marvin Lacuna";
            dataModelTest.Numbers = 18118;

            // Act
            var result = converterControllerTest.Process(dataModelTest);
            var dataModelResult = result as OkNegotiatedContentResult<DataModel>;

            // Assert
            Assert.IsTrue(dataModelResult.Content.Name.Equals("Marvin Lacuna"));
            Assert.IsTrue(dataModelResult.Content.Words.Equals("EIGHTEEN THOUSAND ONE HUNDRED EIGHTEEN DOLLARS"));
            Assert.IsTrue(dataModelResult.Content.Numbers.Equals(18118));
        }

        [TestMethod]
        //Format words - Ten-Nine
        public void FormatWords_TenNine_MustReturnCorrectNumbersAsWords()
        {
            // Arrange
            dataModelTest.Name = "Marvin Lacuna";
            dataModelTest.Numbers = 19119;

            // Act
            var result = converterControllerTest.Process(dataModelTest);
            var dataModelResult = result as OkNegotiatedContentResult<DataModel>;

            // Assert
            Assert.IsTrue(dataModelResult.Content.Name.Equals("Marvin Lacuna"));
            Assert.IsTrue(dataModelResult.Content.Words.Equals("NINETEEN THOUSAND ONE HUNDRED NINETEEN DOLLARS"));
            Assert.IsTrue(dataModelResult.Content.Numbers.Equals(19119));
        }

        #endregion Format Words

        [TestCleanup]
        public void CleanUp_ControllerTest()
        {
            dataModelTest = null;
            converterControllerTest = null;
        }
    }
}