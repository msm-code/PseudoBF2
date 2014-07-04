namespace PseudoBF {
    public interface ISyntaxTree {
        string Dump();
        void Accept(ICodeVisitor visitor);
    }
}
