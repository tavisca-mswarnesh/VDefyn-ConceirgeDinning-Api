﻿using System;
using System.Collections.Generic;
using System.Text;
using ConceirgeDinning.Core.Models;

namespace ConceirgeDinning.Services
{
    public interface IFetchGeocode
    {
        LocalityGeocode FetchCoordinates(string locality);
    }
}
