using EGovernance;
using Banking;
using BankManager;

CentralGov bjpGovt=new CentralGov();
//early binding
//compile linking
//bjpGovt.DeductIncomeTax();

//late binding 
//dynamic binding
//runtime binding

//register address of DeductIncomeTax  inside 
//instance of TaxOperation Delegate object

TaxOperation itOperation=new TaxOperation(bjpGovt.DeductIncomeTax);
TaxOperation proOperation=new TaxOperation(bjpGovt.DeductProfessionalTax);

//unicast delegate
/*
itOperation();
proOperation();

TaxOperation? generalOperation=null;
generalOperation=proOperation;
//Chaining delegate
generalOperation+=itOperation;
generalOperation();

generalOperation-=proOperation;
generalOperation();

*/

//Banking Logic
//ATM
Account  acct123=new Account(1000);
Account  acct456=new Account(500);
//Event Registration
//Event Configuration
acct123.overBalance+=itOperation;
acct123.overBalance+=proOperation;
acct456.underBalance+=itOperation;
acct456.underBalance+=proOperation;

Console.WriteLine("Enter Amount to be deposited");
double amount=double.Parse(Console.ReadLine());
acct123.Deposit(amount);

Console.WriteLine("Before Tax processing");
Console.WriteLine(acct123);

//performing action
acct123.ProcessTax();
Console.WriteLine("After Tax processing");
Console.WriteLine(acct123);

acct456.SendEmail();
Console.WriteLine(acct456);
acct456.BlockAccount();
Console.WriteLine(acct456);
acct456.SendSMS();
Console.WriteLine(acct456);


