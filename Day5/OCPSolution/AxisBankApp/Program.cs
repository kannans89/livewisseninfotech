
using AxisBankApp;
using FDCoreLib.Model;

FixedDeposit fd1 = new FixedDeposit(1001, "Srinivas", 100000, 10, new Q1Poliyc());
Console.WriteLine(fd1.SimpleInterest);
