namespace PseudoBF.Frontend.C.Statements {
    class While : IStatement {
        IExpression Condition { get; set; }
        IStatement Body { get; set; }

        public While(IExpression condition, IStatement body) {
            this.Condition = condition;
            this.Body = body;
        }

        public void Generate(StructuredCodeVisitor writer) {
            var bodyContext = writer.Context.Fork();
            var conditionContext = writer.Context.Fork();
            var continuationContext = writer.Context.Fork();

            writer.PushSymbol(conditionContext.Name);

            writer.Context = conditionContext;
            writer.PushSymbol(bodyContext.Name);
            writer.PushSymbol(continuationContext.Name);
            Condition.Generate(writer);
            writer.If();

            writer.BreakStack.Push(continuationContext);
            writer.ContinueStack.Push(conditionContext);

            writer.Context = bodyContext;
            Body.Generate(writer);
            writer.PushSymbol(conditionContext.Name);

            writer.BreakStack.Pop();
            writer.ContinueStack.Pop();

            writer.Context = continuationContext;
        }

        public void Dump(SourceWriter writer) {
            writer.WriteLine("while ({0})", Condition.Dump);

            if (Body is Block) {
                Body.Dump(writer);
            } else {
                writer.Indent(() => Body.Dump(writer));
            }
        }
    }
}
