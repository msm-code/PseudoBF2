using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PseudoBF.Middleend;
using PseudoBF.Middleend.Core;

namespace PseudoBF.Frontend {
    class StructureContext {
        StackFrame frame;

        public StructureContext(ICodeVisitor visitor) {
            this.Visitor = visitor;
            this.frame = new StackFrame();
        }

        public StructureContext(StructureContext parent, int stackFix) {
            this.Visitor = parent.Visitor.Fork(stackFix);
            this.frame = parent.frame;
        }

        public string Name { get { return Visitor.Name; } }

        public StructureContext Fork(int stackFix = 0) {
            return new StructureContext(this, stackFix);
        }

        public void AllocVar(string name, int cells) {
            frame.Register(name, Visitor.StackOffset);
            for (int i = 0; i < cells; i++) { Visitor.PushConstant(0); }
        }

        public void DeclareVar(string name, int offset) {
            frame.Register(name, offset);
        }

        public void EnterScope() {
            frame = new StackFrame(frame, Visitor.StackOffset);
        }

        public void ExitScope(StructureContext context) {
            while (Visitor.StackOffset > context.frame.StartNdx) {
                Visitor.PopToLocal(Visitor.StackOffset);
            }

            while (frame != context.frame) { frame = frame.Parent; }
            frame = frame.Parent;
        }

        internal void ExitScopeWithValue(StructureContext context) {
            while (Visitor.StackOffset > context.frame.StartNdx + 1) {
                Visitor.PopToLocal(Visitor.StackOffset - 2);
            }

            while (frame != context.frame) { frame = frame.Parent; }
            frame = frame.Parent;
        }

        public int GetVariableOffset(string name) {
            return frame.VariablePos(name);
        }

        public ICodeVisitor Visitor { get; private set; }
    }

    static class ExtFork {
        static Dictionary<string, int> subroutines = new Dictionary<string, int>();

        public static ICodeVisitor Fork(this ICodeVisitor context, int stackFix = 0) {
            var dot = context.Name.LastIndexOf('.');
            var name = dot < 0 ? context.Name : context.Name.Substring(0, dot);

            if (!subroutines.ContainsKey(name)) { subroutines[name] = 0; }
            return context.Fork(name + "." + subroutines[name]++.ToString(), stackFix);
        }
    }
}
