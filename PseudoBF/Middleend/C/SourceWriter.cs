using System.Text;
using System;
namespace PseudoBF.Frontend.C {
    class SourceWriter {
        int indent;
        StringBuilder source = new StringBuilder();

        public void Indent(Action writer) { indent++; writer(); indent--; }
        public void WriteLine(string line, params object[] parameters) {
            source.Append(' ', indent * 2);
            source.AppendLine(string.Format(line, parameters));
        }

        public string Code { get { return source.ToString(); } }
    }
}
