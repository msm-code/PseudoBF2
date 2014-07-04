using System.Collections.Generic;
using System.Text;

namespace PseudoBF {
    public class IntermediateCode {
        public IntermediateCode(List<IChunk> chunks) {
            Chunks = chunks;
        }

        public string Dump() {
            var result = new StringBuilder();
            foreach (var chunk in Chunks) {
                result.AppendFormat("Chunk {0}\n", chunk.Name);
                if (chunk is ExternalChunk) {
                    var external = chunk as ExternalChunk;
                    result.AppendFormat("    External Chunk ({0} parameters)\n", external.Parameters);
                } else {
                    var code = chunk as CodeChunk;
                    foreach (var opcode in code.Opcodes) {
                        result.AppendFormat("    {0}\n", opcode.ToString());
                    }
                }
                result.AppendLine();
            }

            return result.ToString();
        }

        public List<IChunk> Chunks { get; private set; }
    }
}
