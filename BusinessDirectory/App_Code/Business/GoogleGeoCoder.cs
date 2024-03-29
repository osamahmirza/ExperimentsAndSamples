﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;

namespace GoProGo.Business.GoogleGeoCoder
{
    public interface ISpatialCoordinate
    {
        decimal Latitude { get; set; }
        decimal Longitude { get; set; }
    }
    /// <summary>
    /// Coordiate structure. Holds Latitude and Longitude.
    /// </summary>
    public struct Coordinate : ISpatialCoordinate
    {
        private decimal _latitude;
        private decimal _longitude;

        public Coordinate(decimal latitude, decimal longitude)
        {
            _latitude = latitude;
            _longitude = longitude;
        }

        #region ISpatialCoordinate Members

        public decimal Latitude
        {
            get
            {
                return _latitude;
            }
            set
            {
                this._latitude = value;
            }
        }

        public decimal Longitude
        {
            get
            {
                return _longitude;
            }
            set
            {
                this._longitude = value;
            }
        }

        #endregion
    }
    public class Geocode
    {
        private const string _googleUri = "http://maps.google.com/maps/geo?q=";
        //ABQIAAAA6_thtSBfIifvLrs5UEYLtRT2yXp_ZAY8_ufC3CFXhHIE1NvwkxS27BdVwZECOY_jrKfu3jFz2x4TOQ (LocalhostKey)
        private const string _googleKey = "ABQIAAAA6_thtSBfIifvLrs5UEYLtRT2yXp_ZAY8_ufC3CFXhHIE1NvwkxS27BdVwZECOY_jrKfu3jFz2x4TOQ";
        private const string _outputType = "csv"; // Available options: csv, xml, kml, json

        private static Uri GetGeocodeUri(string address)
        {
            address = HttpUtility.UrlEncode(address);
            return new Uri(String.Format("{0}{1}&output={2}&key={3}", _googleUri, address, _outputType, _googleKey));
        }

        /// <summary>
        /// Gets a Coordinate from a address.
        /// </summary>
        /// <param name="address">An address.
        /// <remarks>
        /// <example>1600 Amphitheatre Parkway Mountain View, CA 94043</example>
        /// </remarks>
        /// </param>
        /// <returns>A spatial coordinate that contains the latitude and longitude of the address.</returns>
        public static Coordinate GetCoordinates(string address)
        {
            WebClient client = new WebClient();
            
            Uri uri = GetGeocodeUri(address);
            /* The first number is the status code, 
            * the second is the accuracy, 
            * the third is the latitude, 
            * the fourth one is the longitude.
            */
            string[] geocodeInfo = client.DownloadString(uri).Split(',');
            return new Coordinate(Convert.ToDecimal(geocodeInfo[2]), Convert.ToDecimal(geocodeInfo[3]));
        }

    }
}