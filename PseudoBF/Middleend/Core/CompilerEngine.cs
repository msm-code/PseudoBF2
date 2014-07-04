namespace PseudoBF.Middleend.Core {
    class CompilerEngine : IMiddleend {
        public IntermediateCode Convert(ISyntaxTree syntaxTree) {
            var database = new ProgramDatabase();
            var visitor = new CodeVisitor(database, ".start");

            syntaxTree.Accept(visitor);

            return database.Code;
        }
    }
}
