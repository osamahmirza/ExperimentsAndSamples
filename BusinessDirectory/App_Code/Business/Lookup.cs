using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Web;
using GoProGo.Data;
using GoProGo.Data.Entity;
using GoProGo.Business.Enums.Database;
using System.ComponentModel;
using GoProGo.Data.Entity.Profile;
using GoProGo.Data.Entity.Geo;
using GoProGo.Utility;

namespace GoProGo.Business.Lookup
{
    
    public class Profile
    {
        public static List<tlkpCategory> GetAllCategories()
        {
            return GoProGoDC.ProfileDC.GetAllCategories().ToList();
        }
        public static List<tlkpCategory> GetCategoriesByName(string name)
        {
            return GoProGoDC.ProfileDC.GetCategoriesByName(name).ToList();
        }
        public static List<tlkpJobUnit> GetAllJobUnits()
        {
            return GoProGoDC.ProfileDC.GetAllJobUnits().ToList();
        }
        public static List<tlkpSex> GetAllSexes()
        {
            return GoProGoDC.ProfileDC.GetAllSexes().ToList();
        }
        public static List<tblMemberShipType> GetAllMembershipTypes()
        {
            return GoProGoDC.ProfileDC.GetAllMembershipTypes().ToList();
        }
        public static List<tlkpDemandType> GetAllDemandTypes()
        {
            return GoProGoDC.ProfileDC.GetAllDemandTypes().ToList();
        }
    }

    public class Geo
    {
        
        public static List<tblCountry> GetEnabledCountries()
        {
            return GoProGoDC.GeoDC.GetEnabledCountries().ToList();
        }
        public static List<tblRegion> GetRegionsByCountryID(int countryId)
        {
            return GoProGoDC.GeoDC.GetRegionByCountry(countryId).ToList();
        }
        public static List<tblCity> GetCitiesByRegionID(int regionId)
        {
            return GoProGoDC.GeoDC.GetCityByRegion(regionId).ToList();
        }

        
        public static List<tblCountry> GetAllCountries()
        {
            return GoProGoDC.GeoDC.GetAllCountries().ToList();
        }
        public static List<tblCountry> GetCountriesByName(string name)
        {
            return GoProGoDC.GeoDC.GetCountriesByName(name).ToList();
        }
        public static List<tblCountry> GetEnabledCountriesByName(string country)
        {
            return GoProGoDC.GeoDC.GetEnabledCountriesByName(country).ToList();
        }

        public static List<tblRegion> GetAllRegions()
        {
            return GoProGoDC.GeoDC.GetAllRegions().ToList();
        }
        public static List<tblRegion> GetRegionsByNameAndCountryID(string name, int id)
        {
            return GoProGoDC.GeoDC.GetRegionsByNameAndCountryID(name, id).ToList();
        }

        public static List<tblCity> GetAllCities()
        {
            return GoProGoDC.GeoDC.GetAllCitites().ToList();
        }
        public static List<tblCity> GetCitiesByNameAndRegionID(string name,int id)
        {
            return GoProGoDC.GeoDC.GetCitiesByNameAndRegionID(name,id).ToList();
        }
    }
}