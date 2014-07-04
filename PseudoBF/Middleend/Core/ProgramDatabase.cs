using System.Collections.Generic;
using System.Linq;

namespace PseudoBF.Middleend.Core {
    class ProgramDatabase {
        List<IChunk> chunks = new List<IChunk>();

        public int RegisterChunk(IChunk chunk) {
            this.chunks.Add(chunk);
            return chunks.Count;
        }

        public IntermediateCode Code { get { return new IntermediateCode(chunks); } }

        public int GetSymbol(string symbol) {
            int index = chunks.FindIndex(c => c.Name == symbol);

            if (index >= 0) {
                return index + 1;
            } else {
                throw new System.InvalidOperationException("Symbol " + symbol + " not found");
            }
        }
    }
}
