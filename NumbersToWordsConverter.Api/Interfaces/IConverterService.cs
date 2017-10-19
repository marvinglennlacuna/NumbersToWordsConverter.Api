using NumbersToWordsConverter.Api.Models;

namespace NumbersToWordsConverter.Api.Interfaces
{
    public interface IConverterService
    {
        DataModel ProcessConversion(DataModel dataModel);
    }
}