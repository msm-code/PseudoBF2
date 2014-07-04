using System.Collections.Generic;
namespace PseudoBF.Middleend.Core {
    class StackFrame {
        public StackFrame Parent { get; set; }
        Dictionary<string, int> locals = new Dictionary<string, int>();

        public StackFrame() { }

        public StackFrame(StackFrame parent, int startNdx) {
            this.Parent = parent;
            this.StartNdx = startNdx;
        }

        public int VariablePos(string local) {
            if (locals.ContainsKey(local)) {
                return locals[local];
            } else {
                return Parent.VariablePos(local);
            }
        }

        public void Register(string id, int loc) {
            locals[id] = loc;
        }

        public int StartNdx { get; private set; }
    }
}
