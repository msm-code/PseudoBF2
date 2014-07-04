using System.Collections.Generic;
namespace PseudoBF.Frontend.C.Statements {
    class Block : IStatement {
        List<IStatement> statements;

        public Block(List<IStatement> statements) {
            this.statements = statements;
        }

        public void Generate(StructuredCodeVisitor writer) {
            writer.Context.EnterScope();

            foreach (var statement in statements) {
                statement.Generate(writer);
            }

            writer.Context.ExitScope(writer.Context);
        }

        public void Dump(SourceWriter writer) {
            writer.WriteLine("{{");
            writer.Indent(() => {
                foreach (var statement in statements) {
                    statement.Dump(writer);
                }
            });
            writer.WriteLine("}}");
        }
    }
}
