namespace PseudoBF.Frontend.C.Statements {
    class Break : IStatement {
        public void Generate(StructuredCodeVisitor writer) {
            writer.PushSymbol(writer.BreakContext.Name);
            writer.Context = writer.Context.Fork();
        }

        public void Dump(SourceWriter writer) {
            writer.WriteLine("break;");
        }
    }
}
