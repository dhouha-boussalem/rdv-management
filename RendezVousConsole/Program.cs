// See https://aka.ms/new-console-template for more information

using System.Globalization;


List<RDV> rdvs = new List<RDV>();
List<RDV> rdvsOverlaping = new List<RDV>();
List<RDV> cleanRDVs = new List<RDV>();
List<string> invalidRdvs = new List<string>();

Console.Write("Quel est ton nom ? ");
string? nom = Console.ReadLine();

Console.WriteLine($"Salut, {nom} !, donnez moi vos rdvs format yyyy-MM-dd HH:mm duration in minutes, # à la fin pour terminer");

string? input = Console.ReadLine();

while (input != "#")
{
    if (input is not null)
    {
        string[] parts = input.Split(' ');

        if (parts.Length == 3 && DateTime.TryParseExact(parts[0] + " " + parts[1], "yyyy-MM-dd HH:mm",
            CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateTime) && int.TryParse(parts[2], out int duration))
        {
            rdvs.Add(new RDV { DateTime = dateTime, Duration = duration });
        }

        else
        {
            if (!String.IsNullOrEmpty(input)) invalidRdvs.Add(input);
        }
    }
    input = Console.ReadLine();

}
if (rdvs.Count > 0)
{
    var sortedRDVs = rdvs.OrderBy(r => r.DateTime).ToList();
    for(int i = 0; i < sortedRDVs.Count; i++)
    {
        if (i < sortedRDVs.Count - 1)
        {
            var current = sortedRDVs[i]; var next = sortedRDVs[i + 1];
            if (current.OverLap(next))
            {
                rdvsOverlaping.Add(current);
                rdvsOverlaping.Add(next);
            }
            else if (!rdvsOverlaping.Contains(current)) cleanRDVs.Add(current);
        }
        else if (!rdvsOverlaping.Contains(sortedRDVs[i])) cleanRDVs.Add(sortedRDVs[i]);
    } 
    
}
if (cleanRDVs.Count > 0)
{
    Console.WriteLine("⚠️ Les Rdvs valides");
    foreach (var cleanRDV in cleanRDVs)
    {
        cleanRDV.Print();
    }
}

if (rdvsOverlaping.Count > 0)
{
    Console.WriteLine("⚠️ Les Rdvs overlapings");
    foreach (var overlap in rdvsOverlaping)
    {
        overlap.Print();
    }
}

if (invalidRdvs.Count > 0)
{
    Console.WriteLine("⚠️ Les Rdvs Invalides");
    foreach (var invalidRdv in invalidRdvs)
    {
        Console.WriteLine(invalidRdv);
    }
}








