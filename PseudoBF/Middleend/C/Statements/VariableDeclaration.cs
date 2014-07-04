namespace PseudoBF.Frontend.C.Statements {
    class VariableDeclaration : IStatement {
        string variableName;
        int? cells;

        public VariableDeclaration(string variableName, int? cells = null) {
            this.variableName = variableName;
            this.cells = cells;
        }

        public void Generate(StructuredCodeVisitor writer) {
            writer.AllocVar(variableName, cells ?? 1);
        }

        public void Dump(SourceWriter writer) {
            writer.WriteLine("var {0}{1};", variableName, cells.HasValue ? "[" + cells.Value + "]" : "");
        }
    }
}
