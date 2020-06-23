using System;
using System.Dynamic;
using System.Linq;

namespace MajorHelp
{
    public class Note
    {
        public NoteEnum Name { get; set; }
        public NoteModifierEnum Modifier { get; set; }
        public int Position { get; private set; }
        
        public Note(NoteEnum name, NoteModifierEnum modifier, int position)
        {
            Name = name;
            Modifier = modifier;
            Position = position;
        }

        public override string ToString()
        {
            switch (Modifier)
            {
                case NoteModifierEnum.SHARP: return Name + "#";
                case NoteModifierEnum.FLAT: return Name + "b";
                case NoteModifierEnum.NONE: return Name + " ";
                default: return string.Empty;
            }
        }

        

        public static Note CreateChromaticNote(NoteEnum name, NoteModifierEnum modifier, int position)
        {
            return new Note(name, modifier, position);
        }

        public void MovePosition(int newPosition)
        {
            Position = newPosition;
        }

        public Note GetClone()
        {
            return new Note(Name, Modifier, Position);
        }

        public Note GetFlattened()
        {
            if (Position == 0)
            {
                return ChromaticScale.Notes[11].Last().GetClone();
            }
            else
            {
                var newNote = ChromaticScale.Notes[Position - 1][0].GetClone();
                return newNote;
            }
            

        }

        public Note GetSharpened()
        {
            if (Position == 11)
            {
                return ChromaticScale.Notes[0][0].GetClone();
            }
            else
            {
                return ChromaticScale.Notes[Position + 1].Last().GetClone();
            }
        }
    }
}
