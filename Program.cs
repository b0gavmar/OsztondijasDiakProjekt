using OsztondijasDiakProjekt.Models;

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