// See https://aka.ms/new-console-template for more information

internal class RDV
{
    public DateTime DateTime { get; set; }
    public int Duration { get; set; }

    internal void Print()
    {
        Console.WriteLine(DateTime.ToString() + " " + Duration);
    }

    public bool OverLap(RDV anotherRDV)
    {
        if (this.DateTime == anotherRDV.DateTime ||
            (this.DateTime.AddMinutes(Duration) > anotherRDV.DateTime &&
            this.DateTime.AddMinutes(Duration) <= anotherRDV.DateTime.AddMinutes(anotherRDV.Duration)))
        {
            return true;
        }
        return false;
    }
}