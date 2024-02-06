
using FDCoreLib.Model;
using HDFCClientApp;

FixedDeposit fd1 = new FixedDeposit(1001, "Srinivas", 100000, 10,new DiwaliPolicy());
Console.WriteLine(fd1.SimpleInterest);
