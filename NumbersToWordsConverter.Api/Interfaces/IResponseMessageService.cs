using NumbersToWordsConverter.Api.Models;

namespace NumbersToWordsConverter.Api.Interfaces
{
    public interface IResponseMessageService
    {
        ResponseMessageModel BadRequestErrorMessage(string message);
    }
}