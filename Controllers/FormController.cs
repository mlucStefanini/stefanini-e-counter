using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using stefanini_e_counter.Logic;
using stefanini_e_counter.Models;

namespace stefanini_e_counter.Controllers
{
    [Route("api/[controller]")]
    public class FormController : ControllerBase
    {
        private readonly IFormRequestProcessor formProcessor;

        public FormController(IFormRequestProcessor formProcessor)
        {
            this.formProcessor = formProcessor;
        }
        [HttpPost]
        [Route("medical")]
        public FormRequestResponse RequestMedicalForm([FromBody] MedicalFormRequest medicalFormRequest)
        {
            return ProcessForm(medicalFormRequest);
        }

        [HttpPost]
        [Route("employee")]
        public FormRequestResponse RequestEmployeeForm([FromBody] EmployeeFormRequest employeeFormRequest)
        {
            //return ProcessForm(employeeFormRequest);
            return new FormRequestResponse() {
                ResponseType = FormRequestResponseType.EmailSent
            };
        }

        [HttpPost]
        [Route("bank")]
        public FormRequestResponse RequestBankForm([FromBody] BankFormRequest bankFormRequest)
        {
            return ProcessForm(bankFormRequest);
        }

        private FormRequestResponse ProcessForm(BaseFormRequest formRequest)
        {
            try
            {
                return formProcessor.ProcessForm(formRequest);
            }
            catch
            {
                return FormRequestResponse.ErrorResponse;
            }
        }
    }
}