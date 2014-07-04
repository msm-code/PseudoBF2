using System.IO;

namespace PseudoBF {
    public sealed class Compiler {
        IParser parser;
        IMiddleend middleend;
        IAssembler asembler;

        public Compiler(IParser parser, IMiddleend middleend, IAssembler asembler) {
            this.parser = parser;
            this.middleend = middleend;
            this.asembler = asembler;
        }

        public void Compile(string source, TextWriter destination) {
            var syntaxTree = parser.Parse(source);
            var assembly = middleend.Convert(syntaxTree);
            var result = asembler.Assemble(assembly);
            destination.Write(result);
        }
    }
}
