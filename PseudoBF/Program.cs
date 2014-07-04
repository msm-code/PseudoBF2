using PseudoBF.Backend.Brainfuck;
using System;
using System.Collections.Generic;
using PseudoBF.Frontend.C;
using Prog = PseudoBF.Frontend.C.Program;
using PseudoBF.Frontend.C.Statements;
using PseudoBF.Middleend;
using PseudoBF.Debugger;
using PseudoBF.Middleend.Core;
using System.IO;
using System.Windows.Forms;

namespace PseudoBF {
    class Program {
        static string stdlibCode = @"
extern _echo(chr);
extern _sub(a, b);

func _add(a, b) { return a - (0 - b); }
func _not(a) { if a return 0; return 1; }
func _neq(a, b) { return a - b; }
func _eq(a, b) { return !(a != b); }
func _and(a, b) { if !a return 0; if !b return 0; return 1; }
func _or(a, b) { if a return 1; if b return 1; return 0; }
func _lt(a, b) {
    while 1 {
        if !a return 1;
        if !b return 0;
        a = a - 1; b = b - 1;
    }
}
func _gt(a, b) return b < a;
func _mul(a, b) {
    var result = 0;
    while b {
        result = result + a;
        b = b - 1;
    } return result;
}
";

        static void ParseArgs(string[] args,
                out string source,
                out bool debug,
                out bool gui) {
            var arglist = new List<string>(args);
            bool stdlib = !arglist.Contains("--nostdlib");
            debug = arglist.Contains("--debug");
            gui = arglist.Contains("--gui");
            source = null;

            try {
                source = File.ReadAllText(arglist.Find(s => !s.StartsWith("--")));
            } catch (IOException) {
                Console.WriteLine("Could not read source");
            } catch (ArgumentNullException) {
                Console.WriteLine("Usage: bfc srcfile [--debug] [--gui] [--nostdlib]");
            }

            if (stdlib && source != null) {
                source = stdlibCode + source;
            }
        }

        static IEnumerable<string> Chunks(string str, int maxChunkSize) {
            for (int i = 0; i < str.Length; i += maxChunkSize) {
                yield return str.Substring(i, Math.Min(maxChunkSize, str.Length - i));
            }
        }

        static void Main(string[] args) {
            var assembler = new Assembler();
            var engine = new CompilerEngine();
            var parser = new Parser();

            string source; bool debug; bool gui;
            ParseArgs(args, out source, out debug, out gui);
            if (source == null) { return; }

            var prog = parser.Parse(source) as Prog;

            var dbgSyntreeDump = prog.Dump();
            if (debug) { File.WriteAllText("syntree.dump", dbgSyntreeDump); }

            var intermediate = engine.Convert(prog);

            var ildump = intermediate.Dump();
            if (debug) { File.WriteAllText("il.dump", ildump); }

            if (gui) {
                var dbgGui = new ExecutorGui(intermediate);

                Application.EnableVisualStyles();
                Application.Run(dbgGui);
            }

            var output = assembler.Assemble(intermediate);

            foreach (var chunk in Chunks(output, 70)) {
                Console.WriteLine(chunk);
            }
        }
    }
}