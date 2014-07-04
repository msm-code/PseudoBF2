namespace PseudoBF.Frontend.C.Statements {
    class Return : IStatement {
        IExpression value;

        public Return(IExpression value) {
            this.value = value;
        }

        public void Generate(StructuredCodeVisitor writer) {
            var voidctx = writer.Context.Fork();

            value.Generate(writer);
            writer.Context.ExitScopeWithValue(writer.ReturnContext);
            writer.PushSymbol(writer.ReturnContext.Name);

            writer.Context = voidctx;
        }

        public void Dump(SourceWriter writer) {
            writer.WriteLine("return {0};", value.Dump);
        }
    }
}
