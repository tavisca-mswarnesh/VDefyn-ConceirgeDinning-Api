﻿using ConceirgeDinning.Adapter.Geocoder.xyz.Models;
using ConceirgeDinning.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDinning.Adapter.Geocoder.xyz.Translator
{
    public static class LocalityGeocodeTranslator
    {
        public static LocalityGeocode GetLatLong(LocalityVerboseGeocode reply)
        {
            LocalityGeocode localityGeocode = new LocalityGeocode();
            localityGeocode.Latitude = reply.latt;
            localityGeocode.Longitude = reply.longt;
            localityGeocode.CountryName = reply.standard.countryname;
            return localityGeocode;
        }
    }
}
