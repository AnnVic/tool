using Newtonsoft.Json;

namespace BookSharingApi.DTO;

public class ValidationErrorDetails
{
    public int StatusCode { get; set; }
    public string PropertyName { get; set; }
    public string ErrorMessage { get; set; }
    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}
