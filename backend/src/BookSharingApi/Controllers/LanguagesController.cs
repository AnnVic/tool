using BookSharing.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace BookSharingApi.Controllers;

[Route("[controller]")]
[ApiController]
public class LanguagesController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<LanguageEnum>> GetLanguages()
    {
        var languages = Enum.GetValues(typeof(LanguageEnum))
            .Cast<LanguageEnum>()
            .Select(e => e.ToString());

        return Ok(languages);
    }
}