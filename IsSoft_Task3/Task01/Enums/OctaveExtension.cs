public static class OctaveExtension
{
    public static string GetStringPerformance(this Octave octave)
    {
        return octave switch
        {
            Octave.SubContr => "sub_controctave",
            Octave.Contr => "controctave",
            Octave.Great => "great",
            Octave.Small => "small",
            Octave.First => "1st",
            Octave.Second => "2nd",
            Octave.Third => "3rd",
            Octave.Fourth => "4th",
            Octave.Fifth => "5th"
        };
    }
}
