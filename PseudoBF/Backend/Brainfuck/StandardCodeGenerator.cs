using System.Collections.Generic;
using System.Text;
using System;
namespace PseudoBF.Backend.Brainfuck {
    class StandardCodeGenerator : ICodeGenerationStrategy {
        Dictionary<string, string> builtins;

        public StandardCodeGenerator() {
            this.builtins = new Dictionary<string,string>();
            builtins.Add("_echo", "<<.[-]>>");
            builtins.Add("_sub", "<<[-<->]>[-<+>]");
        }

        public string Builtin(string name) {
            return builtins[name];
        }

        public ILinker CreateLinker() {
            return new LadderLinker();
        }

        public IBrainfuckWriter CreateWriter(int head) {
            return new BrainfuckWriter(head);
        }
    }

    interface IFluentBf {
        IFluentBf And(string variable, int value);
        string Execute(string script);
    }

    class BfWriter : IFluentBf {
        Dictionary<string, int> variables = new Dictionary<string, int>();

        public static IFluentBf With(string variable, int value) {
            return (new BfWriter() as IFluentBf).And(variable, value);
        }

        IFluentBf IFluentBf.And(string variable, int value) {
            variables[variable] = value;
            return this;
        }

        string IFluentBf.Execute(string script) {
            return "";
        }
    }

    class SimpleCodeGenerator : ICodeGenerationStrategy2 {
        public string LoadLocal(int relativePos) {
            return BfWriter.With("top", 0).And("tmp", 1).And("src", relativePos)
                .Execute("top[-] tmp[-] src[top+tmp+src-] tmp[src+tmp-] tmp");
        }

        public string LoadImmediate(int value) {
            return new string('+', value) + ">";
        }

        public string StoreLocal(int relativePos) {
            return BfWriter.With("top", 0).And("dst", relativePos).And("prev", -1)
                .Execute("dst[-] top[dst+top-] prev");
        }
    }
}