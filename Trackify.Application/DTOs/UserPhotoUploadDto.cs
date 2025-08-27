using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackify.Application.DTOs
{
    public class UserPhotoUploadDto
    {
        public IFormFile PhotoFile { get; set; }
    }
}
