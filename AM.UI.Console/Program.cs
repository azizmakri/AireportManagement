// See https://aka.ms/new-console-template for more information
using AM.ApplicatinCore.Domain;
using AM.ApplicatinCore.Services;
using AM.ApplicationCore;
using AM.Infrastructure;

//Plane plane1 = new Plane(5,new DateTime(2022,09,29), "pt");

//Passenger ps1 = new Passenger("moahmedazizmlakri@yahoof.fr", "mohamed aziz","makri");

//Console.WriteLine(ps1.CheckEmailProfile("makri", "mohamed aziz","moahmedazizmlakri@yahoof.fr"));

//Staff stf1 = new Staff("ghassenmakri@gmail.com","ghassen","makri");

//Traveller trv1 = new Traveller("faiezmakri@gmail.com", "faiez", "makri");

//Console.WriteLine(stf1.PassengerType);
/*
ServiceFlight sf = new ServiceFlight();
sf.Flights = TestData.listFlights;

foreach (var flight in sf.GetFlightsDates("Madrid"))
    Console.WriteLine(flight);
Console.WriteLine("*****************************");
foreach (var flight in sf.GetFlights("Destination", "Paris"))
    Console.WriteLine(flight);
*/

AMContext context = new AMContext();
/*context.Flights.Add(TestData.flight2);
context.SaveChanges();
Console.WriteLine(context.Flights.First());*/


GenericRepository<Plane> genericRepository=new GenericRepository<Plane>(context);
UnitOfWork unitOfWork = new UnitOfWork(context,typeof(GenericRepository<>));
//ServicePlane servicePlane=new ServicePlane(genericRepository);
ServicePlane servicePlane = new ServicePlane(unitOfWork);

//servicePlane.Add(TestData.BoingPlane);
//unitOfWork.Save();
//genericRepository.SubmitChanges();

void insertData() {
    AMContext ctx = new AMContext();
    UnitOfWork uw = new UnitOfWork(ctx, typeof(GenericRepository<>));
    ServicePlane sp = new ServicePlane(uw);
    sp.Add(TestData.Airbusplane);
    sp.Add(TestData.BoingPlane);
    sp.Commit();

    //Insert Flight
    ServiceFlight srvf = new ServiceFlight(uw);
    TestData.flight2.airLine = "trukishAirline";
    TestData.flight2.Departure = "Tunis";
    TestData.flight2.Destination = "Paris";
    srvf.Add(TestData.flight2);

    TestData.flight3.Departure = "Tunis";
    TestData.flight3.Destination = "Paris";
    TestData.flight3.airLine = "trukishAirline";
    srvf.Add(TestData.flight3);

    TestData.flight4.Departure = "Tunis";
    TestData.flight4.Destination = "Paris";
    TestData.flight4.airLine = "AirFrance";
    srvf.Add(TestData.flight4);

    //Insert Traveller
    ServicePassenger srvp = new ServicePassenger(uw);
    TestData.traveller1.PassportNumber = "ZWFF12";
    TestData.traveller1.Nationality = "Tunisien";
    TestData.traveller1.TelNumber = 12345678;
    srvp.Add(TestData.traveller1);


    TestData.traveller2.PassportNumber = "ZWFF12";
    TestData.traveller2.Nationality = "Tunisien";
    TestData.traveller2.TelNumber = 12345678;
    srvp.Add(TestData.traveller2);


    TestData.traveller3.PassportNumber = "ZWFF12";
    TestData.traveller3.Nationality = "Tunisien";
    TestData.traveller3.TelNumber = 12345678;
    srvp.Add(TestData.traveller3);

    srvp.Commit();

    ////Insert Ticket

    Ticket ticket1 = new Ticket()
    {
        prix = 250,
        siege = "15",
        vip = false,
        Passenger = TestData.traveller1,
        Flight = TestData.flight2

    };
    Ticket ticket2 = new Ticket()
    {
        prix = 250,
        siege = "14",
        vip = false,
        Passenger = TestData.traveller2,
        Flight = TestData.flight2

    };

    Ticket ticket3 = new Ticket()
    {
        prix = 250,
        siege = "13",
        vip = false,
        Passenger = TestData.traveller3,
        Flight = TestData.flight2
    };

    ServiceTicket srvt = new ServiceTicket(uw);
    srvt.Add(ticket1);
    srvt.Add(ticket2);
    srvt.Add(ticket3);
    srvt.Commit();
}