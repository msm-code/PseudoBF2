namespace PseudoBF {
    class ExternalChunk : IChunk {
        public ExternalChunk(string name, int parameters) {
            this.Name = name;
            this.Parameters = parameters;
        }

        public string Name { get; private set; }
        public int Parameters { get; private set; }
    }
}
