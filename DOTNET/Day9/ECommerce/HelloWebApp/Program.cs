using HR;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
var emp =new Loginpage(){ Id=29, FirstName="Shubhangi", LastName="Tambade"} ;
var Loginpages=new List<Loginpage>();

Loginpages.Add( new Loginpage(){ Id=23, FirstName="Ravi", LastName="Tambade"});
Loginpages.Add( new Loginpage(){ Id=24, FirstName="Sachin", LastName="Nene"});
Loginpages.Add( new Loginpage(){ Id=25, FirstName="Shivani", LastName="Pande"});
Loginpages.Add( new Loginpage(){ Id=26, FirstName="Madhu", LastName="Sharma"});

app.MapGet("/", () => "Hello World!");
app.MapGet("/api/hello",()=>"Transflower Store");
app.MapGet("/api/Loginpages", ()=>Loginpages);
app.MapGet("/api/Loginpage",()=>emp);
app.Run();
