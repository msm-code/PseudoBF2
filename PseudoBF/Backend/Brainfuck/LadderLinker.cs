using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PseudoBF.Backend.Brainfuck {
    class LadderLinker : ILinker {
        public string Link(List<string> chunks) {
            var result = new StringBuilder();
            result.Append("+[>+<");

            foreach (var chunk in chunks) { result.Append("[-"); }
            result.Append("[...]");

            foreach (var chunk in chunks.Reverse<string>()) {
                result.Append(">[<");
                result.Append(chunk);
                result.Append("[-]>[-]]<]");
            }
            result.Append("<]");
            
            return result.ToString();
        }
    }
}
