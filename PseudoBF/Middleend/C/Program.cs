using System.Collections.Generic;
namespace PseudoBF.Frontend.C {
    sealed class Program : ISyntaxTree {
        public Program() {
            this.Definitions = new List<FunctionDef>();
            this.Declarations = new List<FunctionDecl>();
        }

        public void Accept(ICodeVisitor visitor) {
            foreach (var decl in Declarations) {
                visitor.RegisterExternal(decl.Name, decl.ParameterCount);
            }

            foreach (var def in Definitions) {
                var writer = new StructuredCodeVisitor(visitor.Fork(def.Name, 0));
                def.Generate(writer);
            }

            visitor.PushConstant(0);
            visitor.PushSymbol("main");
        }

        public string Dump() {
            var writer = new SourceWriter();

            foreach (var decl in Declarations) {
                decl.Dump(writer);
            } writer.WriteLine("");

            foreach (var func in Definitions) {
                func.Dump(writer);
                writer.WriteLine("");
            }
            return writer.Code;
        }

        public List<FunctionDecl> Declarations { get; private set; }
        public List<FunctionDef> Definitions { get; private set; }
    }
}
