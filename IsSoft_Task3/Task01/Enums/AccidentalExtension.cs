public static class AccidentalExtension
{
    public static string GetStringPerformance(this Accidental accidental)
    {
        return accidental switch
        {
            Accidental.Flat => "b",
            Accidental.Sharp => "#",
            _ => ""
        };
    }
}
