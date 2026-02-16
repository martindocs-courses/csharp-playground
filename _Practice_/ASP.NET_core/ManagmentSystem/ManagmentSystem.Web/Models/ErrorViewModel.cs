namespace ManagmentSystem.Web.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        /*
            In C#, properties represent data or state, while methods represent actions.

            ShowRequestId isn’t performing an action — it’s just returning a derived value based on existing data (RequestId).

            Therefore, conceptually, it is data (a value you can query), not an operation you perform. 
        
        The official .NET Design Guidelines recommend using properties instead of methods when:

            The operation is simple and fast.

            It does not have observable side effects.

            It represents data or state.
         */
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
