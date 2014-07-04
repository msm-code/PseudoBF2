using PseudoBF.Middleend;
using System.Collections.Generic;
namespace PseudoBF.Frontend {
    class StructuredCodeVisitor {
        public StructuredCodeVisitor(ICodeVisitor visitor) {
            this.Context = new StructureContext(visitor);
            this.BreakStack = new Stack<StructureContext>();
            this.ContinueStack = new Stack<StructureContext>();
        }

        public void If() { Context.Visitor.If(); }
        public void PopDiscard() { Context.Visitor.PopToLocal(Context.Visitor.StackOffset); }
        public void AllocVar(string var, int cells) { Context.AllocVar(var, cells); }
        public void PushSymbol(string symbol) { Context.Visitor.PushSymbol(symbol); }
        public void PushConstant(int constant) { Context.Visitor.PushConstant(constant); }

        public void PushVar(string var) {
            int offset = Context.GetVariableOffset(var);
            Context.Visitor.PushLocal(offset);
        }

        public void PopToVar(string var) {
            int offset = Context.GetVariableOffset(var);
            Context.Visitor.PopToLocal(offset);
        }

        public void Epilogue(int parameters) {
            if (parameters > 0) {
                Context.Visitor.PushLocal(-1);
                Context.Visitor.PopToLocal(-parameters);
                Context.Visitor.PushLocal(0);
                Context.Visitor.PopToLocal(-parameters - 1);
                for (int i = 0; i < parameters; i++) { PopDiscard(); }
            } else {
                Context.Visitor.PushLocal(0);
                Context.Visitor.PushLocal(-1);
                Context.Visitor.PopToLocal(0);
                Context.Visitor.PopToLocal(-1);
            }
        }

        public void RegisterParameters(IList<string> Parameters) {
            for (int i = 0; i < Parameters.Count; i++) {
                Context.DeclareVar(Parameters[i], i - Parameters.Count - 1);
            }
        }

        public StructureContext Context { get; set; }

        public Stack<StructureContext> BreakStack { get; private set; }
        public Stack<StructureContext> ContinueStack { get; private set; }

        public StructureContext BreakContext { get { return BreakStack.Peek(); } }
        public StructureContext ContinueContext { get { return ContinueStack.Peek(); } }
        public StructureContext ReturnContext { get; set; }
    }
}
