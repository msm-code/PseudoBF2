namespace PseudoBF.Frontend.C {
    interface IExpression {
        void Generate(StructuredCodeVisitor writer);
        string Dump { get; }
    }
}
