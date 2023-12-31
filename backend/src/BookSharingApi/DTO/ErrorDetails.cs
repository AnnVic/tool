﻿using Newtonsoft.Json;

namespace BookSharingApi.DTO;

public class ErrorDetails
{
    public string Code { get; set; }
    public string Message { get; set; }
    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}
