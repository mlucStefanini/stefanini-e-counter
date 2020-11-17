using System;
using Microsoft.Extensions.Options;
using stefanini_e_counter.Models;

namespace stefanini_e_counter.Logic
{
    public interface IFormRequestProcessor
    {
        FormRequestResponse ProcessForm(BaseFormRequest request);
    }

    public class FormRequestProcessor : IFormRequestProcessor
    {
        private readonly FormProcessingStrategy processingStrategy;

        public FormRequestProcessor(IOptions<FormProcessingStrategy> processingStrategy)
        {
            this.processingStrategy = processingStrategy.Value;
        }

        public FormRequestResponse ProcessForm(BaseFormRequest request)
        {
            switch (request)
            {
                case MedicalFormRequest medicalFormRequest:
                    return ProcessMedicalFormRequest(medicalFormRequest);
                case EmployeeFormRequest employeeFormRequest:
                    return ProcessEmployeeFormRequest(employeeFormRequest);
                case BankFormRequest bankFormRequest:
                    return ProcessBankFormRequest(bankFormRequest);
                default:
                    throw new ArgumentException($"Unkown type of request {request.GetType()}");
            }
        }

        private FormRequestResponse ProcessMedicalFormRequest(MedicalFormRequest request)
        {
            switch (processingStrategy.MedicalForm)
            {
                case FormProcessingStrategyType.Email:
                    return FormRequestResponse.ErrorResponse;

                case FormProcessingStrategyType.FillAndReturn:
                case FormProcessingStrategyType.PrefillAndEmail:
                    throw new InvalidOperationException($"Cannot process a medical form request using {processingStrategy.MedicalForm} strategy");
                default :
                    throw new ArgumentException($"Unkown type of strategy for Medical Form Request {processingStrategy.MedicalForm}");
            }
        }

        private FormRequestResponse ProcessEmployeeFormRequest(EmployeeFormRequest request)
        {
            switch (processingStrategy.EmployeeForm)
            {
                case FormProcessingStrategyType.Email:
                    return FormRequestResponse.ErrorResponse;

                case FormProcessingStrategyType.FillAndReturn:
                case FormProcessingStrategyType.PrefillAndEmail:
                    throw new InvalidOperationException($"Cannot process a employee form request using {processingStrategy.EmployeeForm} strategy");
                default :
                    throw new ArgumentException($"Unkown type of strategy for Employee Form Request {processingStrategy.EmployeeForm}");
            }
        }

        private FormRequestResponse ProcessBankFormRequest(BankFormRequest request)
        {
            switch (processingStrategy.BankForm)
            {
                case FormProcessingStrategyType.Email:
                    return FormRequestResponse.ErrorResponse;

                case FormProcessingStrategyType.FillAndReturn:
                case FormProcessingStrategyType.PrefillAndEmail:
                    throw new InvalidOperationException($"Cannot process a bank form request using {processingStrategy.BankForm} strategy");
                default :
                    throw new ArgumentException($"Unkown type of strategy for Bank Form Request {processingStrategy.BankForm}");
            }
        }
    }
}