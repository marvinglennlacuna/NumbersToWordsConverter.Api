using NumbersToWordsConverter.Api.Models;
using NumbersToWordsConverter.Api.Services;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;

namespace NumbersToWordsConverter.Api.Controllers
{
    public class ConverterController : ApiController
    {
        private ResponseMessageService responseMessageService;
        private ConverterService cs;

        public ConverterController()
        {
            responseMessageService = new ResponseMessageService();
            cs = new ConverterService();
        }

        [HttpPost]
        public IHttpActionResult Process(DataModel dataModel)
        {
            ValidateModel(dataModel);

            return Ok(cs.ProcessConversion(dataModel));
        }

        private void ValidateModel(DataModel dataModel)
        {
            Regex regex = new Regex(@"^[a-zA-Z\s-]+$");
            if ((dataModel.Name == null) || (dataModel.Name == string.Empty))
            {
                
                var message = Request.CreateResponse(HttpStatusCode.BadRequest,
                responseMessageService.BadRequestErrorMessage("Name cannot be null or Model is invalid format."));
                throw new HttpResponseException(message);
            }
            else if (!regex.IsMatch(dataModel.Name))
            {
                var message = Request.CreateResponse(HttpStatusCode.BadRequest,
                responseMessageService.BadRequestErrorMessage("Name must be alphabet and space only and cannot be null."));
                throw new HttpResponseException(message);
            }

            regex = new Regex(@"^[0-9,\.]+$");
            if (!regex.IsMatch(dataModel.Numbers.ToString()) || dataModel.Numbers <= 0)
            {
                var message = Request.CreateResponse(HttpStatusCode.BadRequest,
                responseMessageService.BadRequestErrorMessage("Numbers must be numberic value from 1 up to 9,999,999 million"));
                throw new HttpResponseException(message);
            }
        }
    }
}