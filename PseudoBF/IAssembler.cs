using System.IO;

namespace PseudoBF {
    public interface IAssembler {
        string Assemble(IntermediateCode code);
    }
}
