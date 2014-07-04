namespace PseudoBF.Frontend.C.Statements {
    class IntVariable : IExpression {
        string localName;

        public IntVariable(string localName) {
            this.localName = localName;
        }

        public void Generate(StructuredCodeVisitor writer) {
            writer.PushVar(localName);
        }

        public string Dump {
            get { return localName; }
        }
    }
}
