namespace PseudoBF {
    public class Opcode {
        public enum Type {
            LoadLocal,
            LoadImmediate,
            StoreLocal,
            Conditional
        }

        public Type Operation { get; private set; }
        public int Parameter { get; private set; }
        public int StackLocation { get; private set; }

        public int StackDelta {
            get {
                switch (Operation) {
                    case Type.LoadLocal: return 1;
                    case Type.LoadImmediate: return 1;
                    case Type.StoreLocal: return -1;
                    case Type.Conditional: return -2;
                    default: throw new System.InvalidOperationException("Unknown opcode type");
                }
            }
        }
        public int StackLocationAfter { get { return StackLocation + StackDelta; } }

        private Opcode(Type operation, int position, int parameter) {
            this.Operation = operation;
            this.Parameter = parameter;
            this.StackLocation = position;
        }

        public static Opcode LoadLocal(int stackLoc, int param) { return new Opcode(Type.LoadLocal, stackLoc, param);  }
        public static Opcode LoadImmediate(int stackLoc, int param) { return new Opcode(Type.LoadImmediate, stackLoc, param); }
        public static Opcode StoreLocal(int stackLoc, int param) { return new Opcode(Type.StoreLocal, stackLoc, param); }
        public static Opcode If(int stackLoc) { return new Opcode(Type.Conditional, stackLoc, 0); }

        public override string ToString() { return string.Format("{0} {1} ({2})", Operation, Parameter, StackLocation); }
    }
}
