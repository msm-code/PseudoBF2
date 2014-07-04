namespace PseudoBF.Frontend.C.Statements {
    class Assignment : IStatement {
        public string Destination { get; private set; }
        public IExpression Expression { get; private set; }

        public Assignment(string destination, IExpression expression) {
            this.Destination = destination;
            this.Expression = expression;
        }

        public void Generate(StructuredCodeVisitor writer) {
            Expression.Generate(writer);
            writer.PopToVar(Destination);
        }

        public void Dump(SourceWriter writer) {
            writer.WriteLine("{0} = {1};", Destination, Expression.Dump);
        }
    }
}
