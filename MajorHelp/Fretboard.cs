using System;
using System.Collections.Generic;
using System.Text;

namespace MajorHelp
{
    public class Fretboard
    {
        public static string GetFretboard(List<Note> notes)
        {

            StringBuilder sb = new StringBuilder();

            foreach (var note in notes)
            {
                sb.Append(note.ToString() + "  ");
            }
            sb.AppendLine();
            List<Note> eStringNotes = MoveNotesRelativeToPivot(Note.CreateChromaticNote(NoteEnum.E, NoteModifierEnum.NONE, (int)NoteEnum.E), notes);

            //sb.AppendLine("   0| 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | 10| 11|");
            sb.AppendLine("___0|_1_|_2_|_3_|_4_|_5_|_6_|_7_|_8_|_9_|_10|_11|");
            sb.Append("e: ");
            sb.AppendLine(GetStringNotes(eStringNotes));

            sb.Append("B: ");
            List<Note> bStringNotes = MoveNotesRelativeToPivot(Note.CreateChromaticNote(NoteEnum.B, NoteModifierEnum.NONE, (int)NoteEnum.B), notes);
            sb.AppendLine(GetStringNotes(bStringNotes));

            sb.Append("G: ");
            List<Note> gStringNotes = MoveNotesRelativeToPivot(Note.CreateChromaticNote(NoteEnum.G, NoteModifierEnum.NONE, (int)NoteEnum.G), notes);
            sb.AppendLine(GetStringNotes(gStringNotes));

            sb.Append("D: ");
            List<Note> dStringNotes = MoveNotesRelativeToPivot(Note.CreateChromaticNote(NoteEnum.D, NoteModifierEnum.NONE, (int)NoteEnum.D), notes);
            sb.AppendLine(GetStringNotes(dStringNotes));

            sb.Append("A: ");
            List<Note> aStringNotes = MoveNotesRelativeToPivot(Note.CreateChromaticNote(NoteEnum.A, NoteModifierEnum.NONE, (int)NoteEnum.A), notes);
            sb.AppendLine(GetStringNotes(aStringNotes));

            sb.Append("E: ");
            sb.Append(GetStringNotes(eStringNotes));

            return sb.ToString();
        }

        private static List<Note> MoveNotesRelativeToPivot(Note pivot, List<Note> notes)
        {
            List<Note> pivotedNotes = new List<Note>();
            foreach (var item in notes)
            {
                if (item.Position < pivot.Position)
                {
                    var movedNote = item.GetClone();
                    movedNote.MovePosition(item.Position + 12);
                    pivotedNotes.Add(movedNote);
                }
                else
                {
                    pivotedNotes.Add(item.GetClone());

                }
            }
            pivotedNotes.ForEach(x => x.MovePosition(x.Position - pivot.Position));
            return pivotedNotes;
        }

        private static string GetStringNotes(List<Note> notes)
        {
            bool[] playableNotes = new bool[12];
            StringBuilder sb = new StringBuilder();

            notes.ForEach(x => playableNotes[x.Position] = true);
            switch (playableNotes[0])
            {
                case true: sb.Append("0|"); break;
                case false: sb.Append("-|"); break;
            }
            for (int i = 1; i < playableNotes.Length; i++)
            {
                switch (playableNotes[i])
                {
                    case true: sb.Append("-0-|"); break;
                    case false: sb.Append("---|"); break;
                }
            }



            return sb.ToString();
        }
    }
}
