using NumericTicTacToe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericTicTacToe
{
    internal class UndoRedoManager
    {
        private Stack<Move> undoStack = new Stack<Move>();
        private Stack<Move> redoStack = new Stack<Move>();

        public void RecordMove(Move move)
        {
            undoStack.Push(move);
            redoStack.Clear();
        }

        public Move Undo()
        {
            if (undoStack.Count > 0)
            {
                Move move = undoStack.Pop();
                redoStack.Push(move);
                return move;
            }
            return null;
        }

        public Move Redo()
        {
            if (redoStack.Count > 0)
            {
                Move move = redoStack.Pop();
                undoStack.Push(move);
                return move;
            }
            return null;
        }
    }
}
