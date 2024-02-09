
CREATE PROCEDURE UpdateSalaries
    @DeptNo INT,
    @HikePercentage FLOAT
AS
BEGIN
    UPDATE EMP
    SET SAL = SAL + (SAL * @HikePercentage / 100)
    WHERE DEPTNO = @DeptNo;
END;

EXEC UpdateSalaries 10, 10;