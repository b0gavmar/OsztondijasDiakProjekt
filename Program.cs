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
List<ScholarshipApplicant> allapplicants = new List<ScholarshipApplicant>(await repo.GetAll());
foreach (ScholarshipApplicant applicant in allapplicants)
{
    Console.WriteLine(applicant);
}
Console.WriteLine("2.");
//Console.WriteLine("Kérek egy összeget");
//int amount = int.Parse(Console.ReadLine());
allapplicants = new List<ScholarshipApplicant>(await repo.GetScholarshipApplicantsWithGreaterAmountThan(1800));
foreach (ScholarshipApplicant applicant in allapplicants)
{
    Console.WriteLine(applicant);
}

Console.WriteLine("3.");
allapplicants = new List<ScholarshipApplicant>(await repo.GetAllOrderedByAmount());
foreach (ScholarshipApplicant applicant in allapplicants)
{
    Console.WriteLine(applicant);
}

Console.WriteLine("4.");
await repo.Add("eva@example.com","Eva Green", 1700);
foreach(ScholarshipApplicant applicant in await repo.GetAll())
{
    Console.WriteLine(applicant);
}

Console.WriteLine("5.");
await repo.ChangeAmount("charlie@example.com", 2500);
foreach (ScholarshipApplicant applicant in await repo.GetAllOrderedByAmount())
{
    Console.WriteLine(applicant);
}