using System.Collections.Generic;

namespace PseudoBF {
    public interface ICodeVisitor {
        ICodeVisitor Fork(string routine, int stackFix);

        string Name { get; }
        int StackOffset { get; }

        void If();
        void PushLocal(int offset);
        void PopToLocal(int offset);
        void PushSymbol(string routine);
        void PushConstant(int constant);

        void RegisterExternal(string name, int parameterCount);
    }
}
