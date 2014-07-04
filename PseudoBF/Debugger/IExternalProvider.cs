using System.Collections.Generic;

namespace PseudoBF.Debugger {
    interface IExternalProvider {
        int Execute(ExternalChunk chunk, List<int> parameters);
    }
}
