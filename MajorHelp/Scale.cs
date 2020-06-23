using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Text;

namespace MajorHelp
{
    public class Scale
    {

        public readonly List<Note> Major;
        public readonly List<Note> Minor;
        private readonly NoteEnum Root;
        private readonly NoteModifierEnum Modifier;

        public Scale(NoteEnum rootNote, NoteModifierEnum modifier)
        {
            Root = rootNote;
            Modifier = modifier;
            Major = ChromaticScale.GetMajorScale(rootNote, modifier);
            Minor = ChromaticScale.GetMinorScale(rootNote, modifier);
            
        }

        public List<Note> GetMajorPentatonicScale()
        {
            return new List<Note> { Major[0], Major[1], Major[2], Major[4], Major[5], Major[0] };
        }

        public List<Note> GetMinorPentatonicScale()
        {
            return new List<Note> { Minor[0], Minor[2], Minor[3], Minor[4], Minor[6], Minor[0] };
        }

        public List<Note> GetArpeggio()
        {
            return new List<Note> { Major[0], Major[2], Major[4]};
        }

        public List<Note> GetChord()
        {
            return GetArpeggio();
        }

        public List<Note> GetMinorOrMajorSevenChord()
        {
            return new List<Note> { Major[0], Major[2], Major[4], Major[6] };
        }

        public List<Note> GetMinorBluesScale()
        {
            var bluesChoard = new List<Note> { Minor[0].GetClone(), Minor[2].GetClone(), Minor[3].GetClone(), Minor[4].GetFlattened(), Minor[4], Minor[6], Minor[0] };
                return bluesChoard;
        }

        public List<Note> GetMajorBluesScale()
        {
            var bluesChoard = new List<Note> { Major[0].GetClone(), Major[1], Major[2].GetFlattened(), Major[2], Major[4], Major[5], Major[0] };
            return bluesChoard;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Root: {Root}{(Modifier == NoteModifierEnum.NONE ? "" : (Modifier == NoteModifierEnum.SHARP) ? "#" : "b")}");
            sb.Append("Major: ");
            foreach (var note in Major) { sb.Append(note.ToString() + " "); }
            sb.AppendLine();

            sb.Append("Minor: ");
            foreach (var note in Minor) { sb.Append(note.ToString() + " "); }
            sb.AppendLine();

            sb.Append("Major Pentatonic: ");
            foreach (var note in GetMajorPentatonicScale()) { sb.Append(note.ToString() + " "); }
            sb.AppendLine();

            sb.Append("Minor Pentatonic: ");
            foreach (var note in GetMinorPentatonicScale()) { sb.Append(note.ToString() + " "); }
            sb.AppendLine();

            sb.AppendLine($"Major Arpeggio: {Major[0].ToString()} {Major[2].ToString()} {Major[4].ToString()}");
            sb.AppendLine($"Minor Arpeggio: {Minor[0].ToString()} {Minor[2].ToString()} {Minor[4].ToString()}");
            sb.AppendLine();
            sb.AppendLine($"Major7: {Major[0].ToString()} {Major[2].ToString()} {Major[4].ToString()} {Major[6].ToString()}");
            sb.AppendLine($"Minor7: {Minor[0].ToString()} {Minor[2].ToString()} {Minor[4].ToString()} {Minor[6].ToString()}");
            sb.AppendLine();

            sb.Append("Major Blues: ");
            foreach (var note in GetMajorBluesScale()) { sb.Append(note.ToString() + " "); }
            sb.AppendLine();

            sb.Append("Minor Blues: ");
            foreach (var note in GetMinorBluesScale()) { sb.Append(note.ToString() + " "); }
            sb.AppendLine();

            return sb.ToString();
        }


    }
}
