namespace stefanini_e_counter.Models
{
    public class FormRequestResponse
    {
        public FormRequestResponseType ResponseType { get; init; }

        public static FormRequestResponse ErrorResponse => new FormRequestResponse() { ResponseType = FormRequestResponseType.Error};
    }

    public enum FormRequestResponseType
    {
        Error,
        EmailSent,
    }
}