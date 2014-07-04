using System.Collections.Generic;

namespace PseudoBF.Frontend.C {
    class FunctionDef : IStatement {
        public FunctionDef(string Name, string[] parameters, IStatement body) {
            this.Name = Name;
            this.Body = body;
            this.Parameters = new List<string>(parameters);
        }

        public string Name { get; private set; }
        public List<string> Parameters { get; private set; }
        public IStatement Body { get; private set; }

        public void Generate(StructuredCodeVisitor visitor) {
            visitor.ReturnContext = visitor.Context.Fork(1);

            visitor.Context.EnterScope();
            visitor.RegisterParameters(Parameters);

            Body.Generate(visitor);

            visitor.Context.ExitScope(visitor.ReturnContext);
            visitor.PushConstant(0);
            visitor.PushSymbol(visitor.ReturnContext.Name);

            visitor.Context = visitor.ReturnContext;
            visitor.Epilogue(Parameters.Count);
        }

        public void Dump(SourceWriter writer) {
            writer.WriteLine("func {0}({1})", Name, string.Join(", ", Parameters));
            writer.Indent(() => { 
                Body.Dump(writer);
            });
        }
    }
}
