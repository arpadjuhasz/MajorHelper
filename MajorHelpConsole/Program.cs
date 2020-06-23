using MajorHelp;
using System;
using System.Linq;

namespace MajorHelpConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Scale scale = new Scale(NoteEnum.C , NoteModifierEnum.NONE);
            Console.WriteLine(scale.ToString());
            //Console.WriteLine();
            //Console.WriteLine(Fretboard.GetFretboard(scale.Major));

            //Console.WriteLine("Pentatonic");
            //Console.WriteLine(Fretboard.GetFretboard(scale.GetMajorPentatonicScale()));

            //Console.WriteLine("Arpeggio");
            //Console.WriteLine(Fretboard.GetFretboard(scale.GetArpeggio()));

            //Console.WriteLine("Minor7 chord");
            //Console.WriteLine(Fretboard.GetFretboard(scale.GetMinorOrMajorSevenChord()));

            Console.WriteLine("Major blues chord");
            Console.WriteLine(Fretboard.GetFretboard(scale.GetMinorBluesScale()));


            Console.ReadKey();
        }
    }
}
