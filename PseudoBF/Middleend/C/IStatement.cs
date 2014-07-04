namespace PseudoBF.Frontend.C {
    interface IStatement {
        void Generate(StructuredCodeVisitor writer);
        void Dump(SourceWriter writer);
    }
}
