﻿using CloudinaryDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.BusinessLogic.Services.Interfaces
{
    public interface ICloudinaryService
    {
        Cloudinary GetCloudinaryInstance();
    }
}
