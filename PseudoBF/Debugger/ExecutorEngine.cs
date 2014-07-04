using System.Collections.Generic;
using System;

namespace PseudoBF.Debugger {
    class ExecutorEngine {
        static readonly ExternalChunk exitState = new ExternalChunk("exit", 0);

        IntermediateCode program;
        IExternalProvider provider;
        OpcodeExecutor opcodeExecutor;

        public ProgramStack Stack { get; private set; }
        public IChunk CurrentChunk { get; private set; }
        public int CurrentOpcode { get; private set; }

        public ExecutorEngine(IntermediateCode program, IExternalProvider external) {
            this.program = program;
            this.provider = external;
            this.Stack = new ProgramStack();
            this.CurrentChunk = program.Chunks[0];
            this.opcodeExecutor = new OpcodeExecutor(Stack);
        }

        void JumpToChunk(int ndx) {
            CurrentChunk = (ndx == 0) ? exitState : program.Chunks[ndx - 1];
            CurrentOpcode = 0;
        }

        void ExecuteExternalChunk(ExternalChunk external) {
            int returnLoc = Stack.Pop();

            var parameters = new List<int>();
            for (int i = 0; i < external.Parameters; i++) {
                parameters.Add(Stack.Pop());
            }

            int returnVal = provider.Execute(external, parameters);
            Stack.Push(returnVal);

            JumpToChunk(returnLoc);
        }

        void ExecuteCodeChunk(CodeChunk code) {
            if (CurrentOpcode >= code.Opcodes.Count) {
                JumpToChunk(Stack.Pop());
            } else {
                var opcode = code.Opcodes[CurrentOpcode];
                opcodeExecutor.Execute(opcode);
                CurrentOpcode++;
            }
        }

        public void SingleStep() {
            if (!this.Finished) {
                if (CurrentChunk is ExternalChunk) {
                    ExecuteExternalChunk(CurrentChunk as ExternalChunk);
                } else {
                    ExecuteCodeChunk(CurrentChunk as CodeChunk);
                }
            }
        }

        public bool Finished { get { return CurrentChunk == exitState; } }
    }
}
