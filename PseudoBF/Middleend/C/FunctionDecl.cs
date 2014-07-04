namespace PseudoBF.Frontend.C {
    class FunctionDecl {
        public FunctionDecl(string name, int paramCt) {
            this.Name = name;
            this.ParameterCount = paramCt;
        }

        public string Name { get; private set; }
        public int ParameterCount { get; private set; }

        public void Dump(SourceWriter writer) {
            writer.WriteLine("extern {0}/{1};", Name, ParameterCount);
        }
    }
}
