--XML dataset creation, Must have for RESTful webservice with Entity Framework to consume such result sets. 
--Let SQL Server generate XML rather than app server, its faster in my experience

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER Procedure [Config].[GetIdentity]
(
	@PersonID INT,
	@ResourceID INT,
	@IdentityUserID INT,
	@UserID int
)
AS
BEGIN
SET NOCOUNT ON

IF ISNULL(@PersonID, 0) = 0
BEGIN
	SELECT @PersonID = u.PersonID from Security.vUser u 
	where (u.ID = @IdentityUserID) OR (u.ResourceID = @ResourceID)
	
	IF @PersonID is null
	BEGIN
		RAISERROR('Person not found.',16,1)
	END
END

SELECT 
		CAST(
				(
				SELECT 
					ID, 
					FirstName, 
					LastName, 
					Initials, 
					EmployeeID, 
					EMail, 
					Phone, 
					PhoneExtension, 
					Fax, 
					MSNorChatID,
					CAST(																									--User
							(	SELECT
									UserView.PersonID,
									UserView.GlobalUserID,
									UserView.ID AS LocalID,
									CASE WHEN UserView.AllowMultiLogin = 1 THEN 'true' ELSE 'false' END AS IsAllowMultiLogin,
									CASE WHEN UserView.IsActive = 1 THEN 'true' ELSE 'false' END AS IsActive,
									UserView.Login,
									UserView.CreatedBy,
									UserView.CreatedDate,
									UserView.ModifiedBy,
									UserView.ModifiedDate,
									CAST(
											(
											 SELECT 
												POL.ID, 
												POL.Name, 
												POL.Description, 
												CASE WHEN POL.IsCreatorPolicy = 1 THEN 'true' ELSE 'false' END AS IsCreatorPolicy, 
												CASE WHEN POL.IsSystem = 1 THEN 'true' ELSE 'false' END AS IsSystem, 
												POL.PermissionTypeID, 
												POL.DataObjectID, 
												POL.CreatedDate, 
												POL.CreatedBy, 
												POL.ModifiedDate, 
												POL.ModifiedBy 
											FROM Security.Policy POL
											INNER JOIN Security.UserPolicy UP
												ON UP.PolicyId = POL.ID
											WHERE UP.UserId = UserView.ID
											AND POL.PermissionTypeId = 1
											FOR XML PATH ('ApplicationPolicy')
											) AS XML
										) AS ApplicationPolicies,
									CAST(
											(SELECT 
												  UG.ID,
												  UG.Name,
												  UG.Description,
												  CASE WHEN UG.IsSystem = 1 THEN 'true' ELSE 'false' END AS IsSystem,
												  UG.CreatedDate,
												  UG.CreatedBy,
												  UG.ModifiedDate,
												  UG.ModifiedBy
											FROM Security.UserGroup UG
											INNER JOIN Security.UserGroupMember UGM
												ON UG.ID = UGM.UserGroupID
											WHERE UGM.UserId = UserView.ID
											FOR XML PATH ('UserGroup')
											) AS XML
										) AS UserGroups
								FROM Security.vUser UserView
								WHERE UserView.PersonID = @PersonID
								FOR XML PATH ('User')
							) AS XML
						),
					CAST(																									--Resource
							(	SELECT 
									RR.ID,
									RR.Version,
									RR.Description,
									ISNULL(U.ID,0) UserID,
									RR.PersonID,
									S.ID as StatusID,
									ISNULL(S.Name,'') as StatusName,
									CASE WHEN RR.IsFullTime = 1 THEN 'true' ELSE 'false' END AS IsFullTime,
									CASE WHEN RR.IsManager = 1 THEN 'true' ELSE 'false' END AS IsManager,
									RR.Comments,
									RR.Position,
									ISNULL(RR.ManagerID,0) as ManagerID,
									ISNULL(PManager.FirstName,'') as ManagerFirstName,
									ISNULL(PManager.LastName,'') as ManagerLastName,
									RR.OrganizationUnitId as OrganizationUnitID,
									ISNULL(OU.Name,'') as OrganizationUnit,
									RR.CreatedBy,
									RR.CreatedDate,
									CAST																					--ResourceTypes
									(
										(SELECT 
											T.Id AS TypeID,
											T.Name AS TypeName,
											ISNULL(RT1.Rate,0) AS Rate,
											ISNULL(RT1.OvertimeRate,0) AS OvertimeRate,
											CASE WHEN RT1.IsDefault = 1 THEN 'true' ELSE 'false' END AS IsDefault
										FROM
											Resource.Resource RR1
											INNER JOIN Resource.ResourceType RT1 ON RR1.ID = RT1.ResourceId
											INNER JOIN Resource.Type T ON T.ID = RT1.ResourceTypeId
										WHERE RR1.ID = RR.ID
										FOR XML PATH ('ResourceType')
										) AS XML
									) AS ResourceTypes,
									CAST
									(																						--Properties
										(
										SELECT 
											pp.ID, 
											pp.ResourceID, 
											pp.PropertyTypeID, 
											CASE WHEN pp.IsRequired = 1 THEN 'true' ELSE 'false' END AS IsRequired,
											pp.SortOrder,
											pp.CreatedBy,
											pp.CreatedDate,
											pp.ModifiedBy,
											pp.ModifiedDate,
											COUNT(DISTINCT ppCnt.ID) AS ResourceLinkCount,
											CAST																			--PropertyValues
												(
													(
														SELECT 
															ID, 
															ResourcePropertyTypeID, 
															Value, 
															ppv.CreatedBy,
															ppv.CreatedDate,
															ppv.ModifiedBy,
															ppv.ModifiedDate
														FROM Resource.[PropertyValue] ppv
															WHERE ppv.ResourcePropertyTypeID = pp.ID 
														FOR XML PATH('Value')								
													) AS XML
												)
											FROM Resource.[Property] pp
											LEFT JOIN [Resource].[Property] ppCnt ON pp.PropertyTypeID = ppCnt.PropertyTypeID
											INNER JOIN Resource.Resource RR ON pp.ResourceID = RR.ID
											WHERE RR.PersonID = @PersonID
											GROUP BY pp.ID, pp.ResourceID, pp.PropertyTypeID, pp.IsRequired, pp.SortOrder, pp.CreatedBy,	pp.CreatedDate, pp.ModifiedBy, pp.ModifiedDate
											FOR XML PATH('Property')								
										) AS XML
									) AS Properties
								FROM
									Resource.Resource RR
									INNER JOIN [MasterDB].[Security].Person R ON RR.PersonID = R.ID
									LEFT OUTER JOIN Resource.Resource RRManager  ON RR.ManagerID = RRManager.ID
									LEFT OUTER JOIN [[MasterDB].[Security].Person PManager ON PManager.ID = RRManager.PersonID 
									LEFT OUTER JOIN Organization.OrganizationUnit OU ON OU.ID = RR.OrganizationUnitId
									LEFT OUTER JOIN Security.vUser U ON U.PersonID = RR.PersonID
									LEFT OUTER JOIN Resource.ResourceType RT ON RR.ID = RT.ResourceID and RT.IsDefault!=0
									INNER JOIN Resource.Status S ON S.ID = RR.StatusID
									INNER JOIN Security.vUser C ON C.ID = RR.CreatedBy
									INNER JOIN Security.vUser M ON M.ID = RR.ModifiedBy
								WHERE R.ID = @PersonID
								FOR XML PATH('Resource')				
								)AS XML)	
			FROM [[MasterDB].Security.[Person]
			WHERE ID = @PersonID
			FOR XML PATH ('Person')
		 ) AS XML) 
END