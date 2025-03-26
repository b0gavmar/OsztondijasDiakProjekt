using OsztondijasDiakProjekt.Models;
using OsztondijasDiakProjekt.Repos;

try
{
    ScholarshipApplicant emptyApplicant = new ScholarshipApplicant(string.Empty,string.Empty);
}catch(Exception e)
{
    Console.WriteLine(e.Message);
}

ScholarshipApplicant odon = new ScholarshipApplicant("odon@nyertes.hu", "Ösztöndíj Ödön");
Console.WriteLine(odon);

try
{
    odon.IncreaseAmount(-3000);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

odon.IncreaseAmount(20000);
odon.IncreaseAmount(30000);
Console.WriteLine(odon);

Console.WriteLine("\nkieg.\n");

ScholarshipRepo repo = new ScholarshipRepo(new ScholarshipContext());
Console.WriteLine("1.");
foreach (ScholarshipApplicant applicant in await repo.GetAll())
{
    Console.WriteLine(applicant);
}
Console.WriteLine("2.");
//Console.WriteLine("Kérek egy összeget");
//int amount = int.Parse(Console.ReadLine());
foreach (ScholarshipApplicant applicant in await repo.GetScholarshipApplicantsWithGreaterAmountThan(1800))
{
    Console.WriteLine(applicant);
}

Console.WriteLine("3.");

foreach (ScholarshipApplicant applicant in await repo.GetAllOrderedByAmount())
{
    Console.WriteLine(applicant);
}

Console.WriteLine("4.");
try
{
    await repo.Add("eva@example.com", "Eva Green", 1700);
    foreach (ScholarshipApplicant applicant in await repo.GetAll())
    {
        Console.WriteLine(applicant);
    }
}
catch(Exception e)
{
    Console.WriteLine(e.Message);
}

Console.WriteLine("5.");
await repo.ChangeAmount("charlie@example.com", 2500);
foreach (ScholarshipApplicant applicant in await repo.GetAllOrderedByAmount())
{
    Console.WriteLine(applicant);
}

Console.WriteLine("6.");
try
{

    await repo.Remove("bob@example.com");
    foreach (ScholarshipApplicant applicant in await repo.GetAllOrderedByAmount())
    {
        Console.WriteLine(applicant);
    }
}
catch(Exception e)
{
    Console.WriteLine(e.Message);
}

Console.WriteLine("7.");
repo.AverageAndSum();

Console.WriteLine("8.");
foreach(ScholarshipGroup category in await repo.GroupedBy())
{
    Console.WriteLine(category.Category + ": " + category.Count+" fő");
}

Console.WriteLine("9.");
foreach (ScholarshipApplicant applicant in await repo.GetHighAmountAndExample())
{
    Console.WriteLine(applicant);
}

Console.WriteLine("10.");
foreach (ScholarshipApplicant applicant in await repo.GetAmountOrEmail())
{
    Console.WriteLine(applicant);
}
