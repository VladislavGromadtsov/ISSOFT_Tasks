using System;

Key c = new Key(Note.C, Accidental.Sharp, Octave.First);
Console.WriteLine(c);

Key d = new Key(Note.D, Accidental.Flat, Octave.First);
Console.WriteLine(c.Equals(d));
Console.WriteLine(c.CompareTo(d));

Key f = new Key(Note.F, Accidental.None, Octave.Third);
Key e = new Key(Note.E, Accidental.Sharp, Octave.Third);
Console.WriteLine("\n" + e.Equals(f));
Console.WriteLine(f.Equals(e));
Console.WriteLine(e.CompareTo(f));
Console.WriteLine(e);
Console.WriteLine(f);

Key f2 = new Key(Note.F, Accidental.Flat, Octave.Third);
Key e2 = new Key(Note.E, Accidental.None, Octave.Third);
Console.WriteLine("\n" + e2.Equals(f2));
Console.WriteLine(f2.Equals(e2));
Console.WriteLine(e2.CompareTo(f2));
Console.WriteLine(e2);
Console.WriteLine(f2);

Key a = new Key(Note.A, Accidental.Flat, Octave.Second);
Key g = new Key(Note.G, Accidental.Flat, Octave.Second);
Console.WriteLine("\n" + a.Equals(g));
Console.WriteLine(a.Equals(g));
Console.WriteLine(g.CompareTo(a));
Console.WriteLine(g);
Console.WriteLine(a);