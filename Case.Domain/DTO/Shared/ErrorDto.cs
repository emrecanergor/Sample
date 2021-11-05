using System;
using System.Collections.Generic;

namespace Case.Domain.DTO.Shared
{
    public class ErrorDto
    {
        public ErrorDto()
        {
            Errors = new List<string>();
        }

        public List<String> Errors { get; set; }
        public int StatusCode { get; set; }
    }
}
