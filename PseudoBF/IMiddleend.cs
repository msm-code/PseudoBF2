namespace PseudoBF {
    public interface IMiddleend {
        IntermediateCode Convert(ISyntaxTree syntaxTree);
    }
}
