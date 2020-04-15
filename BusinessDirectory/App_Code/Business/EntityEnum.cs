using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoProGo.Business.Enums.Database
{
    public enum ProfileEntity
    {
        //tblFavourite
        Favourite,
        //tblInquiry
        Inquiry,
        //tblProfile
        Profile,
        //tblTraffic
        Traffic
    }
    public enum ProfileLookup
    {
        //tlkpCategory
        Category,
        //tlkpContentType
        ContentType,
        //tlkpJobUnit
        JobUnit,
        //tlkpKeywordType
        KeywordType,
        //tlkpSex
        Sex,
        //tblMembershipType
        MemberShipType
    }
    public enum GeoEntity
    {
        //tblCountry
        Country,
        //tblRegion
        Region,
        //tblCity
        City
    }
    public enum FileEntity
    {
        //tblFileInformation
        FileInformation,
        //tblAccessType
        AccessType,
        //FileExtention
        FileExtention,
        //FileType
        FileType
    }
}