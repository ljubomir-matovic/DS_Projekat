using System;
using System.Collections.Generic;
using System.Linq;

namespace MG_58_2020
{
    public class Caretaker
    {
        public MemoryGameForm originator;
        private Stack<IMemento> undoStack = new Stack<IMemento>();
        private Stack<IMemento> redoStack = new Stack<IMemento>();

        public Caretaker(MemoryGameForm originator)
        {
            this.originator = originator;
        }

        public void Reset()
        {
            undoStack.Clear();
            redoStack.Clear();
        }

        public void Backup()
        {
            undoStack.Push(originator.Save());
            redoStack.Clear();
        }

        public void Undo()
        {
            if (undoStack.Count > 0)
            {
                redoStack.Push(originator.Save());
                IMemento memento = undoStack.Pop();
                originator.Restore(memento);
            }
        }

        public void Redo()
        {
            if (redoStack.Count > 0)
            {
                undoStack.Push(originator.Save());
                IMemento memento = redoStack.Pop();
                originator.Restore(memento);
            }
        }

        public bool CanUndo
        {
            get
            {
                return undoStack.Any();
            }
        }

        public bool CanRedo
        {
            get
            {
                return redoStack.Any();
            }
        }
    }
}