--Sample for Spatial query for proximity search with paging
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [SEARCH].[ProfileSearchDistance]
(
	@Criteria NVARCHAR(512)
	,@Lat float
	,@Long float
	,@IsKM bit
	,@CityID int
	,@PageNum int
	,@PageSize int
	,@TotalRowCount int output
)
AS

DECLARE @g GEOGRAPHY
DECLARE @d FLOAT
SET @g = geography::Point(@Lat, @Long, 4326);

IF (@IsKM = 1)
BEGIN
	SET @d = 1000
END
ELSE
BEGIN
	SET @d = 1609.344
END;

SELECT 
	ProfileRN.ID
	,ProfileRN.FirstName
	,ProfileRN.LastName
	,ProfileRN.Slogan
	,ProfileRN.ProfileDescription
	,CAST(ProfileRN.MinimumRate AS DECIMAL(18,2)) AS MinimumRate
	,ProfileRN.Longitude
	,ProfileRN.Latitude
	,ProfileRN.SmallProfilePicture
	,ProfileRN.Website
	,ProfileRN.AddressLine2
	,ProfileRN.AddressLine1
	,ProfileRN.ReviewCount
	,ProfileRN.ReviewScore
	--IDs
	,ProfileRN.CategoryID
	,ProfileRN.JobUnitID
	,ProfileRN.MemberShipTypeID
	,ProfileRN.SexID
	,ProfileRN.Currency_CountryID
	,ProfileRN.CityID
	,ProfileRN.RegionID
	,ProfileRN.CountryID
   ,CAT.Name AS CategoryName
   ,JU.JobUnit AS JobUnitName
   ,MST.Name AS MembershipTypeName
   ,SX.Name AS SexName
   ,CT.CurrencyCode AS CurrencyCode
   ,CT1.Country AS Country
   ,CTY.City AS City
   ,RG.Region AS Region
   ,CAST((PFL.Location.STDistance(@g)/@d) AS DECIMAL(18,2))AS Distance
FROM 
	(
		SELECT 
			ROW_NUMBER() OVER(ORDER BY PF.ID) AS RowNum
			, CTable.[RANK] AS [Rank]
			, PF.Hits
			, PF.ID
			, PF.FirstName
			, PF.LastName
			, PF.Slogan
			, PF.ProfileDescription
			, PF.MinimumRate
			, PF.Longitude
			, PF.Latitude
			, PF.SmallProfilePicture
			, PF.Website
			, PF.AddressLine2
			, PF.AddressLine1
			, PF.ReviewCount
			, PF.ReviewScore
			--IDs
			, PF.CategoryID
			, PF.JobUnitID
			, PF.MemberShipTypeID
			, PF.SexID
			, PF.Currency_CountryID
			, PF.CityID
			, PF.RegionID
			, PF.CountryID
		FROM CONTAINSTABLE(PROFILE.tblProfile, *, @Criteria) AS CTable
			INNER JOIN PROFILE.tblProfile PF ON CTable.[KEY] = PF.ID
		WHERE 
			PF.IsActive = 1 AND PF.IsPublic = 1 AND  PF.CityID = @CityID AND
			PF.Longitude IS NOT NULL AND 
			PF.Latitude IS NOT NULL AND 
			PF.Longitude <> 0 AND 
			PF.Latitude <> 0
	)ProfileRN
	LEFT JOIN PROFILE.tlkpCategory CAT ON ProfileRN.CategoryID = CAT.ID
	LEFT JOIN PROFILE.tlkpJobUnit JU ON ProfileRN.JobUnitID = JU.ID
	LEFT JOIN PROFILE.tblMemberShipType MST ON ProfileRN.MemberShipTypeID = MST.ID
	LEFT JOIN PROFILE.tlkpSex SX ON ProfileRN.SexID = SX.ID
	LEFT JOIN GEO.tblCountry CT ON ProfileRN.Currency_CountryID = CT.ID
	LEFT JOIN GEO.tblCountry CT1 ON ProfileRN.CountryID = CT1.ID
	LEFT JOIN GEO.tblCity CTY ON ProfileRN.CityID = CTY.ID
	LEFT JOIN GEO.tblRegion RG ON ProfileRN.RegionID = RG.ID
	LEFT JOIN PROFILE.tblProfileLocation PFL ON ProfileRN.ID = PFL.ProfileID
WHERE RowNum BETWEEN (@PageNum - 1) * @PageSize + 1 AND @PageNum * @PageSize
ORDER BY Distance, ProfileRN.[Rank], ProfileRN.Hits

SELECT @TotalRowCount = COUNT(*)
FROM CONTAINSTABLE(PROFILE.tblProfile, *, @Criteria) AS CTable
	INNER JOIN PROFILE.tblProfile PF ON CTable.[KEY] = PF.ID
WHERE 
	PF.IsActive = 1 AND PF.IsPublic = 1 AND  PF.CityID = @CityID AND
	PF.Longitude IS NOT NULL AND 
	PF.Latitude IS NOT NULL AND 
	PF.Longitude <> 0 AND 
	PF.Latitude <> 0