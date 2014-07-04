using System.Collections.Generic;
namespace PseudoBF {
    class OpcodeWriter {
        List<Opcode> opcodes = new List<Opcode>();

        public OpcodeWriter(List<Opcode> drain, int stackPtr = 0) {
            this.opcodes = drain;
            this.StackLoc = stackPtr;
        }

        public void LoadLocal(int source) {
            opcodes.Add(Opcode.LoadLocal(StackLoc, source));
            StackLoc++;
        }

        public void LoadImmediate(int value) {
            opcodes.Add(Opcode.LoadImmediate(StackLoc, value));
            StackLoc++;
        }

        public void StoreLocal(int destination) {
            opcodes.Add(Opcode.StoreLocal(StackLoc, destination));
            StackLoc--;
        }

        public void If() {
            opcodes.Add(Opcode.If(StackLoc));
            StackLoc -= 2;
        }

        public int StackLoc { get; set; }
        public List<Opcode> Code { get { return opcodes; } }
    }
}
