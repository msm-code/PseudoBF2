using System.Collections.Generic;

namespace PseudoBF {
    public class CodeChunk : IChunk {
        public CodeChunk(string name) {
            this.Opcodes = new List<Opcode>();
            this.Name = name;
        }

        public List<Opcode> Opcodes { get; private set; }
        public string Name { get; private set; }

        public override string ToString() {
            return "[chunk: " + Name + "]";
        }
    }
}
