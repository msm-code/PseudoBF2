using System.Collections.Generic;

namespace PseudoBF.Backend.Brainfuck {
    interface ILinker {
        string Link(List<string> chunks);
    }
}
