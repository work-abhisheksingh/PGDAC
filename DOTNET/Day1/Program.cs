using ComplexNumber;
Console.WriteLine("ABC");
Console.WriteLine("Hello this is my first programm");
Complex  c1=new Complex(2,5);
Complex c2=new Complex(1,8);
Complex c3=c1 + c2;
Console.WriteLine(c3.Real+ " " +c3.Imaginary);
Account acc123=new Account(50000);
acc123.Deposit(30000);
float  currentBalance123=acc123.GetBalance();
 
Account acc124=new Account(20000);
acc124.Deposit(80000);
float  currentBalance124=acc124.GetBalance();
 
//Collection 

List<Account> accounts=new List<Account>();
accounts.Add(acc123);
accounts.Add(acc124);

foreach( Account theAccount in accounts){
  float result=theAccount.GetBalance();
  Console.WriteLine("Current Balance={0}",result);
}
