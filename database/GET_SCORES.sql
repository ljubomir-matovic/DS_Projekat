IF(NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_TYPE='FUNCTION' AND ROUTINE_SCHEMA='dbo' AND ROUTINE_NAME='GET_SCORES'))
BEGIN
	EXEC ('CREATE FUNCTION [dbo].[GET_SCORES] (@podela VARCHAR(20),@slika VARCHAR(100)) RETURNS 
@scores TABLE 
(
	[id] [int] NOT NULL,
	[ime] [varchar](50) NOT NULL,
	[broj_poteza] [int] NOT NULL,
	[vreme] [VARCHAR](10) NOT NULL
) AS 	BEGIN 	RETURN;	END')
END
GO

ALTER FUNCTION [dbo].[GET_SCORES] 
(
	@podela VARCHAR(20),
	@slika VARCHAR(100)
)
RETURNS 
@scores TABLE 
(
	[id] [int] NOT NULL,
	[ime] [varchar](50) NOT NULL,
	[broj_poteza] [int] NOT NULL,
	[vreme] [VARCHAR](10) NOT NULL
)
AS
BEGIN
	INSERT INTO @scores 
	SELECT 
		ROW_NUMBER() OVER(ORDER BY broj_poteza + DATEPART(SECOND, vreme) + 60 * DATEPART(MINUTE, vreme) ASC) as broj_reda,
		ime,
		broj_poteza,
		CONCAT(CASE 
        WHEN DATEPART(MINUTE, vreme)< 10
        THEN CONCAT('0', DATEPART(MINUTE, vreme))
        ELSE CONCAT('',DATEPART(MINUTE, vreme))
    END,':',CASE 
        WHEN DATEPART(SECOND, vreme)< 10
        THEN CONCAT('0', DATEPART(SECOND, vreme))
        ELSE CONCAT('',DATEPART(SECOND, vreme))
    END) as vreme
	FROM rezlutati
	WHERE podela=@podela /*AND ((slika IS NULL AND @slika IS NULL) OR slika=@slika)*/
	ORDER BY broj_reda ASC

	RETURN;
END
