using System.Linq;
using System;

namespace PseudoBF.Backend.Brainfuck {
    interface IBrainfuckWriter {
        void MoveHead(int position);
        void Inc(int position, int count = 1);
        void Dec(int position, int count = 1);
        void While(int position, Action operation);
        string GetCode();
    }

    static class WriterExt {
        #region Combined
        public static void MoveValue(this IBrainfuckWriter writer, int from, params int[] targets) {
            targets = targets.Where(x => x != from).ToArray();
            if (targets.Length == 0) { return; }

            writer.While(from, () => {
                writer.Dec(from);
                foreach (var target in targets) { writer.Inc(target); }
            });
        }

        public static void SetValue(this IBrainfuckWriter writer, int position, int value) {
            writer.While(position, () => writer.Dec(position));
            writer.Inc(position, value);
        }
        #endregion
    }
}
