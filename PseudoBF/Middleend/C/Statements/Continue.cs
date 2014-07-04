namespace PseudoBF.Frontend.C.Statements {
    class Continue : IStatement {
        public void Generate(StructuredCodeVisitor writer) {
            writer.PushSymbol(writer.ContinueContext.Name);
            writer.Context = writer.Context.Fork();
        }

        public void Dump(SourceWriter writer) {
            writer.WriteLine("continue;");
        }
    }
}
