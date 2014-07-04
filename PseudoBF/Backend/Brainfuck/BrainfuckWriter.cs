using System.Text;
using System;
using System.Linq;

namespace PseudoBF.Backend.Brainfuck {
    class BrainfuckWriter : IBrainfuckWriter {
        StringBuilder code = new StringBuilder();
        int head;

        public BrainfuckWriter(int head = 0) {
            this.head = head;
        }

        #region Basic
        public void MoveHead(int position) {
            int diff = position - head;
            code.Append(diff > 0 ? '>' : '<', diff > 0 ? diff : -diff);
            head = position;
        }

        public void Inc(int position, int count = 1) {
            MoveHead(position);
            code.Append('+', count);
        }

        public void Dec(int position, int count = 1) {
            MoveHead(position);
            code.Append('-', count);
        }

        public void While(int position, Action operation) {
            MoveHead(position);
            code.Append('[');

            operation();

            MoveHead(position);
            code.Append(']');
        }
        #endregion

        public string GetCode() { return code.ToString(); }
    }
}
