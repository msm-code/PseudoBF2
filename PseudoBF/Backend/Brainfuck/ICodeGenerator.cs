using System.Collections.Generic;

namespace PseudoBF.Backend.Brainfuck {
    interface ICodeGenerationStrategy {
        IBrainfuckWriter CreateWriter(int head);
        ILinker CreateLinker();
        string Builtin(string name);
    }

    interface ICodeGenerationStrategy2 {
        string LoadLocal(int relativePos);
        string LoadImmediate(int value);
        string StoreLocal(int relativePos);
    }
}
