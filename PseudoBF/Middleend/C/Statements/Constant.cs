namespace PseudoBF.Frontend.C.Statements {
    class Constant : IExpression {
        public int Value { get; private set; }

        public Constant(int value) {
            this.Value = value;
        }

        public void Generate(StructuredCodeVisitor writer) {
            writer.PushConstant(Value);
        }

        public string Dump {
            get { return Value.ToString(); }
        }
    }
}
