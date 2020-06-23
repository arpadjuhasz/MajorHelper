using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MajorHelp
{
    public static class ChromaticScale
    {
        public static Dictionary<int, Note[]> Notes = new Dictionary<int, Note[]>
        {
            {0, new Note[]{ Note.CreateChromaticNote(NoteEnum.A, NoteModifierEnum.NONE, 0),  } },
            {1, new Note[]{ Note.CreateChromaticNote(NoteEnum.A, NoteModifierEnum.SHARP, 1), Note.CreateChromaticNote(NoteEnum.B, NoteModifierEnum.FLAT, 1) } },
            {2, new Note[]{ Note.CreateChromaticNote(NoteEnum.B, NoteModifierEnum.NONE, 2), Note.CreateChromaticNote(NoteEnum.C, NoteModifierEnum.FLAT, 2) } },
            {3, new Note[]{ Note.CreateChromaticNote(NoteEnum.C, NoteModifierEnum.NONE, 3), Note.CreateChromaticNote(NoteEnum.B, NoteModifierEnum.SHARP, 3) } },
            {4, new Note[]{ Note.CreateChromaticNote(NoteEnum.C, NoteModifierEnum.SHARP, 4), Note.CreateChromaticNote(NoteEnum.D, NoteModifierEnum.FLAT, 4) } },
            {5, new Note[]{ Note.CreateChromaticNote(NoteEnum.D, NoteModifierEnum.NONE, 5),  } },
            {6, new Note[]{ Note.CreateChromaticNote(NoteEnum.D, NoteModifierEnum.SHARP, 6), Note.CreateChromaticNote(NoteEnum.E, NoteModifierEnum.FLAT, 6) } },
            {7, new Note[]{ Note.CreateChromaticNote(NoteEnum.E, NoteModifierEnum.NONE, 7), Note.CreateChromaticNote(NoteEnum.F, NoteModifierEnum.FLAT, 7) } },
            {8, new Note[]{ Note.CreateChromaticNote(NoteEnum.F, NoteModifierEnum.NONE, 8), Note.CreateChromaticNote(NoteEnum.E, NoteModifierEnum.SHARP, 8) } },
            {9, new Note[]{ Note.CreateChromaticNote(NoteEnum.F, NoteModifierEnum.SHARP, 9), Note.CreateChromaticNote(NoteEnum.G, NoteModifierEnum.FLAT, 9) } },
            {10, new Note[]{ Note.CreateChromaticNote(NoteEnum.G, NoteModifierEnum.NONE, 10),  } },
            {11, new Note[]{ Note.CreateChromaticNote(NoteEnum.G, NoteModifierEnum.SHARP, 11), Note.CreateChromaticNote(NoteEnum.A, NoteModifierEnum.FLAT, 11)  } }
        };

        private static readonly int[] MajorSteps = { 2, 2, 1, 2, 2, 2, 1 };
        private static readonly int[] MinorSteps = { 2, 1, 2, 2, 1, 2, 2 };
        //private readonly int[] MajorPentatonicSteps = { 2, 2, 3, 2, 3 };
        //private readonly int[] MinorPentatonicSteps = { 3, 2, 2, 3, 2 };

        private static List<Note> GetScale(NoteEnum rootNote, NoteModifierEnum modifier, int[] steps)
        {
            var notes = new List<Note>();
            int rootNotePosition = (int)rootNote;
            switch (modifier)
            {
                case NoteModifierEnum.FLAT: rootNotePosition -= 1; break;
                case NoteModifierEnum.SHARP: rootNotePosition += 1; break;
            }

            int counter = 0;
            int notePosition = rootNotePosition;
            notes.Add(Notes[notePosition][0]);
            for (; ; )
            {

                notePosition += steps[counter];

                if (notePosition > Notes.Count - 1)
                {
                    notePosition -= Notes.Count;
                }
                notes.Add(Notes[notePosition][0]);
                counter++;
                if (counter >= steps.Length)
                {
                    break;
                }
            }
            return notes;
        }

        public static List<Note> GetMajorScale(NoteEnum rootNote, NoteModifierEnum modifier)
        {
            return GetScale(rootNote, modifier, MajorSteps);
        }

        public static List<Note> GetMinorScale(NoteEnum rootNote, NoteModifierEnum modifier)
        {
            return GetScale(rootNote, modifier, MinorSteps);
        }

        //public List<Note> GetMajorPentatonicScale(NoteEnum rootNote, NoteModifierEnum modifier)
        //{
        //    return GetScale(rootNote, modifier, MajorPentatonicSteps);
        //}

        //public List<Note> GetMinorPentatonicScale(NoteEnum rootNote, NoteModifierEnum modifier)
        //{
        //    return GetScale(rootNote, modifier, MinorPentatonicSteps);
        //}

        

    }
}
