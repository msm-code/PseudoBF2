using System.Collections.Generic;
using System.Text;
using Antlr.Runtime.Misc;
using System.Linq;
using System;

namespace PseudoBF.Backend.Brainfuck {
    class Assembler : IAssembler {
        ICodeGenerationStrategy codeStrategy;
        Dictionary<Opcode.Type, Action<BrainfuckWriter, Opcode>> operations;

        public Assembler() {
            codeStrategy = new StandardCodeGenerator();

            operations = new Dictionary<Opcode.Type, Action<BrainfuckWriter, Opcode>>();
            operations[Opcode.Type.LoadLocal] = LoadLocal;
            operations[Opcode.Type.StoreLocal] = StoreLocal;
            operations[Opcode.Type.LoadImmediate] = LoadImmediate;
            operations[Opcode.Type.Conditional] = Conditional;
        }

        string AssembleChunk(CodeChunk chunk) {
            var opcodes = chunk.Opcodes;
            var writer = new BrainfuckWriter(opcodes.Count > 0 ? opcodes[0].StackLocation : 0);

            foreach (var opcode in opcodes) {
                operations[opcode.Operation](writer, opcode);
                writer.MoveHead(opcode.StackLocationAfter);
            }

            return writer.GetCode();
        }

        string InsertExternal(ExternalChunk chunk) {
            return codeStrategy.Builtin(chunk.Name);
        }

        string CombineChunks(List<string> chunks) {
            var linker = codeStrategy.CreateLinker();
            return linker.Link(chunks);
        }

        public string Assemble(IntermediateCode code) {
            var chunks = new List<string>();

            foreach (var chunk in code.Chunks) {
                if (chunk is CodeChunk) {
                    chunks.Add(AssembleChunk(chunk as CodeChunk));
                } else {
                    chunks.Add(InsertExternal(chunk as ExternalChunk));
                }
            }

            return CombineChunks(chunks);
        }

        #region Opcodes
        void LoadLocal(BrainfuckWriter writer, Opcode opcode) {
            writer.SetValue(opcode.StackLocation, 0);
            writer.SetValue(opcode.StackLocation + 1, 0);
            writer.MoveValue(opcode.Parameter, opcode.StackLocation, opcode.StackLocation + 1);
            writer.MoveValue(opcode.StackLocation + 1, opcode.Parameter);
        }

        void StoreLocal(BrainfuckWriter writer, Opcode opcode) {
            writer.SetValue(opcode.Parameter, 0);
            writer.MoveValue(opcode.StackLocation - 1, opcode.Parameter);
        }

        void LoadImmediate(BrainfuckWriter writer, Opcode opcode) {
            writer.SetValue(opcode.StackLocation, opcode.Parameter);
        }

        void Conditional(BrainfuckWriter writer, Opcode opcode) {
            int ifTrue = opcode.StackLocation - 3;
            int ifFalse = opcode.StackLocation - 2;
            int top = opcode.StackLocation - 1;
            int temp0 = opcode.StackLocation;
            int temp1 = opcode.StackLocation + 1;

            writer.SetValue(temp0, 0);
            writer.SetValue(temp1, 0);

            writer.MoveValue(top, temp0, temp1);
            writer.MoveValue(temp0, top);
            writer.Inc(temp0);

            writer.While(temp1, () => {
                writer.Dec(temp0);
                writer.SetValue(temp1, 0);
            });

            writer.While(temp0, () => {
                writer.SetValue(ifTrue, 0);
                writer.MoveValue(ifFalse, ifTrue);
                writer.Dec(temp0);
            });
        }
        #endregion
    }
}
