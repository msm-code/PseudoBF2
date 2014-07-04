using System.Collections.Generic;
using System;

namespace PseudoBF.Debugger {
    class OpcodeExecutor {
        ProgramStack stack;
        Dictionary<Opcode.Type, Action<int, int>> actions;

        public OpcodeExecutor(ProgramStack stack) {
            this.stack = stack;

            this.actions = new Dictionary<Opcode.Type, Action<int, int>>();
            actions[Opcode.Type.Conditional] = Conditional;
            actions[Opcode.Type.LoadImmediate] = LoadImmediate;
            actions[Opcode.Type.LoadLocal] = LoadLocal;
            actions[Opcode.Type.StoreLocal] = StoreLocal;
        }

        void LoadImmediate(int value, int _) {
            stack.Push(value);
        }

        void LoadLocal(int localNdx, int stackNdx) {
            stack.Push(stack[stack.Count - stackNdx + localNdx]);
        }

        void StoreLocal(int localNdx, int stackNdx) {
            if (localNdx >= stackNdx) {
                stack.Pop();
            } else { // if (stack.Count - 1 != localNdx + stackNdx) {
                int top = stack.Pop();
                stack[stack.Count - stackNdx + localNdx + 1] = top;
            }
        }

        void Conditional(int _, int __) {
            var condition = stack.Pop() != 0;
            var ifFalse = stack.Pop();
            var ifTrue = stack.Pop();
            stack.Push(condition ? ifTrue : ifFalse);
        }

        public void Execute(Opcode opcode) {
            actions[opcode.Operation](opcode.Parameter, opcode.StackLocation);
        }
    }

}
