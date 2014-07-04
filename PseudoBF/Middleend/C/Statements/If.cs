namespace PseudoBF.Frontend.C.Statements {
    class If : IStatement {
        IExpression Condition { get; set; }
        IStatement Body { get; set; }

        public If(IExpression condition, IStatement body) {
            this.Condition = condition;
            this.Body = body;
        }

        public void Generate(StructuredCodeVisitor writer) {
            var bodyContext = writer.Context.Fork();
            var continuationContext = writer.Context.Fork();

            writer.PushSymbol(bodyContext.Name);
            writer.PushSymbol(continuationContext.Name);
            Condition.Generate(writer);
            writer.If();

            writer.Context = bodyContext;
            Body.Generate(writer);
            writer.PushSymbol(continuationContext.Name);

            writer.Context = continuationContext;
        }

        public void Dump(SourceWriter writer) {
            writer.WriteLine("if ({0})", Condition.Dump);

            writer.Indent(() => Body.Dump(writer));
        }
    }
}
