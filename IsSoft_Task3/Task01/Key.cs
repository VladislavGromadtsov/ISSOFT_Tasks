using System;

public readonly struct Key : IComparable<Key>
{
    public Note Note { get; }
    public Accidental Accidental { get; }
    public Octave Octave { get; }

    public Key(Note note, Accidental accidental, Octave octave)
    {
        if (!Enum.IsDefined(typeof(Note), note) || !Enum.IsDefined(typeof(Accidental), accidental) || !Enum.IsDefined(typeof(Octave), octave))
        {
            throw new ArgumentException("Invalid value of note or accidental or octave. Check it.");
        }

        if (!Check(note, accidental, octave))
        {
            throw new ArgumentException("There are no key with such value");
        }
        (Note, Accidental, Octave) = (note, accidental, octave);
    }

    private static bool Check(Note note, Accidental accidental, Octave octave) =>
        !(octave == Octave.Contr && note < Note.A) && !(octave == Octave.Fifth &&
                                                        (note > Note.C ||
                                                         (note == Note.C && accidental != Accidental.None)));

    public override bool Equals(object? obj)
    {
        if (obj is not Key key)
        {
            return false;
        }

        return CheckKeyPosition(this) == CheckKeyPosition(key);
    }

    private static double CheckKeyPosition(Key key)
    {
        double position = (int)key.Octave * 7 + (int)key.Note;
        if (key.Accidental == Accidental.Flat)
        {
            position += key.Note is Note.C or Note.F ? -1 : -0.5;
        }

        if (key.Accidental == Accidental.Sharp)
        {
            position += key.Note is Note.E or Note.B ? 1 : 0.5;
        }

        return position;
    }

    public override int GetHashCode() => CheckKeyPosition(this).GetHashCode();
    public override string ToString() => $"{Note}{Accidental.GetStringPerformance()} {Octave.GetStringPerformance()}";

    public int CompareTo(Key other) => Math.Sign(CheckKeyPosition(this) - CheckKeyPosition(other));

}