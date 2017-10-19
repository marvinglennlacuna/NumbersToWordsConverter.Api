using NumbersToWordsConverter.Api.Interfaces;
using NumbersToWordsConverter.Api.Models;

namespace NumbersToWordsConverter.Api.Services
{
    public class ResponseMessageService : IResponseMessageService
    {
        private ResponseMessageModel responseMessage;

        public ResponseMessageService()
        {
            responseMessage = new ResponseMessageModel();
        }

        public ResponseMessageModel BadRequestErrorMessage(string message)
        {
            responseMessage.Message = message;
            responseMessage.StatusCode = (int)StatusCode.BadRequest;

            return responseMessage;
        }

        private enum StatusCode
        {
            BadRequest = 400,
        }
    }
}