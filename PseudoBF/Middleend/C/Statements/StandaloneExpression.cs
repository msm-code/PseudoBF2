namespace PseudoBF.Frontend.C.Statements {
    class StandaloneExpression : IStatement {
        IExpression expression;

        public StandaloneExpression(IExpression expression) {
            this.expression = expression;
        }

        public void Generate(StructuredCodeVisitor writer) {
            expression.Generate(writer);
            writer.PopDiscard();
        }

        public void Dump(SourceWriter writer) {
            writer.WriteLine(expression.Dump + ";");
        }
    }
}
