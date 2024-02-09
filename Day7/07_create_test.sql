-- Create the test class
EXEC tSQLt.NewTestClass 'SalaryTests';

-- Create the test procedure
CREATE PROCEDURE SalaryTests.[test UpdateSalaries]
AS
BEGIN
    -- Arrange
    -- Insert test data into the EMP table
    INSERT INTO EMP (EMPNO, ENAME, JOB, MGR, HIREDATE, SAL, COMM, DEPTNO)
    VALUES (1, 'Test', 'Test', NULL, GETDATE(), 1000, NULL, 10);

    DECLARE @DeptNo INT = 10;
    DECLARE @HikePercentage FLOAT = 10;
    DECLARE @expectedSalary MONEY = 1100; -- Original salary (1000) plus 10%

    -- Act
    EXEC UpdateSalaries @DeptNo, @HikePercentage;

    -- Assert
    DECLARE @actualSalary MONEY = (SELECT SAL FROM EMP WHERE EMPNO = 1);
    EXEC tSQLt.AssertEquals @expectedSalary, @actualSalary;
END;
GO

-- Run the tests
EXEC tSQLt.RunAll;

SELECT * FROM emp;