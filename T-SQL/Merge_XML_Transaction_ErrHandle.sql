--Update through XML, very important style of SQL for MVC or MVVM

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [Security].[UpdateIdentity]
(
	@IdentityXML XML,
	@UserID INT,
	@IsResource BIT
)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE 
		@PersonID INT,
		@AssociateID NVARCHAR(16),
		@ResourceXML XML,
		@UserXML XML,
		@Output Common.OutputList
	
	BEGIN TRY
	
		SELECT 
			 @PersonID = ISNULL(psn.value('(ID/text())[1]','int'),0)
		FROM @IdentityXML.nodes('(Identity)[1]') AS Per(psn)

		DECLARE @PersonInfo TABLE
		(	[PK] int IDENTITY,
			[ID] [int] NOT NULL,
			[FirstName] [nvarchar](64) NOT NULL,
			[LastName] [nvarchar](64) NOT NULL,
			[Initials] [nvarchar](5) NULL,
			[AssociateID] [nvarchar](16) NULL,
			[EMail] [nvarchar](128) NULL,
			[Phone] [varchar](20) NULL,
			[PhoneExtension] [int] NULL,
			[Fax] [varchar](20) NULL,
			[MSNorChatID] [nvarchar](256) NULL,
			PRIMARY KEY (ID,PK) 
		)
		
		INSERT INTO @PersonInfo
		(	
			[ID],
			[FirstName],
			[LastName],
			[Initials],
			[AssociateID],
			[EMail],
			[Phone],
			[PhoneExtension],
			[Fax],
			[MSNorChatID] 
		)
		SELECT	rn.value('(ID/text())[1]', 'int'),
				rn.value('(FirstName/text())[1]', 'nvarchar(64)'),
				rn.value('(LastName/text())[1]', 'nvarchar(64)'),
				rn.value('(Initials/text())[1]', 'nvarchar(5)'),		
				rn.value('(AssociateID/text())[1]', 'nvarchar(16)'),		
				rn.value('(Email/text())[1]', 'nvarchar(128)'),				
				rn.value('(Phone/text())[1]', 'varchar(20)'),	
				rn.value('(PhoneExtension/text())[1]', 'int'),	
				rn.value('(Fax/text())[1]', 'varchar(20)'),		
				rn.value('(ChatID/text())[1]', 'nvarchar(256)')	
		FROM @IdentityXML.nodes('(/Identity)[1]') AS Res(rn)
										
							
		SELECT @AssociateID = AssociateID	FROM @PersonInfo
		
		-- Validate AssociateID uniqueness
		set @AssociateID=ISNULL(LTRIM(RTRIM(@AssociateID)),'')
		IF LEN(@AssociateID) > 0 AND @PersonID = 0
		BEGIN
			IF EXISTS(SELECT 1 FROM [GoProGo_Master].[Security].[Person] ptVal WHERE (ptVal.AssociateID = @AssociateID))
			BEGIN
				RAISERROR('Duplicate AssociateID found.',16,1)
			END
		END
		BEGIN
			IF EXISTS(SELECT 1 FROM [GoProGo_Master].[Security].[Person] ptVal WHERE (ptVal.AssociateID = @AssociateID) AND ptVal.ID != @PersonID)
			BEGIN
				RAISERROR('Duplicate AssociateID found.',16,1)
			END
		END
		
		BEGIN TRAN
		
			MERGE [GoProGo_Master].[Security].[Person] pt
			USING @PersonInfo ps ON pt.[ID] = ps.[ID] 
			WHEN MATCHED THEN
			UPDATE
			SET 
					[FirstName] = ps.[FirstName]
				   ,[LastName] = ps.[LastName]
				   ,[Initials] = ps.[Initials]
				   ,[AssociateID] = ps.[AssociateID]
				   ,[EMail] = ps.[EMail]
				   ,[Phone] = ps.[Phone]
				   ,[PhoneExtension] = ps.[PhoneExtension]
				   ,[Fax] = ps.[Fax]
				   ,[MSNorChatID] = ps.[MSNorChatID]
			WHEN NOT MATCHED THEN
			INSERT
				   ([FirstName]
				   ,[LastName]
				   ,[Initials]
				   ,[AssociateID]
				   ,[EMail]
				   ,[Phone]
				   ,[PhoneExtension]
				   ,[Fax]
				   ,[MSNorChatID])
			VALUES
				   (ps.[FirstName]
				   ,ps.[LastName]
				   ,ps.[Initials]
				   ,ps.[AssociateID]
				   ,ps.[EMail]
				   ,ps.[Phone]
				   ,ps.[PhoneExtension]
				   ,ps.[Fax]
				   ,ps.[MSNorChatID])
				   OUTPUT INSERTED.ID,DELETED.ID INTO @Output(InsertedID,DeletedID);

			IF @PersonID = 0
				SELECT TOP 1 @PersonID = InsertedID 
				FROM @Output
				WHERE DeletedID IS NULL
			delete from @Output

			SELECT @ResourceXML = @IdentityXML.query('/Identity/Resource') 
			SELECT @UserXML = @IdentityXML.query('/Identity/User') 
			
			IF @IsResource = 1
				EXEC [Resource].[UpdateResource] @ResourceXML, @UserID, @PersonID
			ELSE
				EXEC [Security].[UpdateUser] @UserXML, @UserID, @PersonID
		
		COMMIT TRAN
		RETURN @PersonID
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0 ROLLBACK TRAN
		DECLARE @ErrorMessage NVARCHAR(2048)
		SET @ErrorMessage = [ErrorHandling].[GetCustomMessage](ERROR_NUMBER(),ERROR_MESSAGE(),NULL,0)
		RAISERROR(@ErrorMessage,16,1)
	END CATCH
END