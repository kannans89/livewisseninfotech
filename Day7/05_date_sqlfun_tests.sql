-- Create the test class
EXEC tSQLt.NewTestClass 'DateConversionTests';

-- Create the test procedure
CREATE PROCEDURE DateConversionTests.[test ConvertDateToString]
AS
BEGIN
    -- Arrange
    DECLARE @inputDate DATETIME = '2024-02-04';
    DECLARE @expectedOutput CHAR(8) = '20240204';

    -- Act
    DECLARE @actualOutput CHAR(8) = dbo.ConvertDateToString(@inputDate);

    -- Assert
    EXEC tSQLt.AssertEquals @expectedOutput, @actualOutput;
END;
GO

-- Run the tests
EXEC tSQLt.RunAll;