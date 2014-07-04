using System.Collections.Generic;

namespace PseudoBF.Middleend.Core {
    class CodeVisitor : ICodeVisitor {
        CodeChunk chunk;
        ProgramDatabase database;
        OpcodeWriter writer;

        public CodeVisitor(ProgramDatabase database, string name, int stackptr = 0) {
            this.Name = name;
            this.chunk = new CodeChunk(name);
            this.database = database;
            this.writer = new OpcodeWriter(chunk.Opcodes, stackptr);
            database.RegisterChunk(chunk);
        }

        private CodeVisitor(CodeVisitor prototype, string name, int stackFix)
            : this(prototype.database, name, prototype.writer.StackLoc + stackFix) { }

        public ICodeVisitor Fork(string name, int stackFix) {
            return new CodeVisitor(this, name, stackFix);
        }

        public void If() { writer.If(); }
        public void PushSymbol(string symbol) { writer.LoadImmediate(GetSymbol(symbol)); }
        public void PushConstant(int constant) { writer.LoadImmediate(constant); }
        public void PushLocal(int offset) { writer.LoadLocal(offset); }
        public void PopToLocal(int offset) { writer.StoreLocal(offset); }
        public int StackOffset { get { return writer.StackLoc; } }
        int GetSymbol(string symbol) { return database.GetSymbol(symbol); }

        public void RegisterExternal(string name, int parameterCount) {
            database.RegisterChunk(new ExternalChunk(name, parameterCount));
        }

        public string Name { get; private set; }
    }
}
