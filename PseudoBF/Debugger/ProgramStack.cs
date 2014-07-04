using System.Collections.Generic;

namespace PseudoBF.Debugger {
    class ProgramStack {
        List<int> stack = new List<int>();

        public int this[int ndx] {
            get { return stack[ndx]; }
            set { stack[ndx] = value; }
        }

        public int Count { get { return stack.Count; } }

        public void Push(int value) {
            stack.Add(value);
        }

        public int Pop() {
            var value = stack[stack.Count - 1];
            stack.RemoveAt(stack.Count - 1);
            return value;
        }

        public List<int> Elems { get { return stack; } }
    }
}
