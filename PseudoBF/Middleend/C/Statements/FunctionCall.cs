using System.Collections.Generic;
using System.Linq;

namespace PseudoBF.Frontend.C.Statements {
    class FunctionCall : IExpression {
        public List<IExpression> Parameters { get; private set; }
        public string FunctionName { get; private set; }

        public FunctionCall(string funcName, params IExpression[] parameters) {
            this.FunctionName = funcName;
            this.Parameters = parameters.ToList();
        }

        public void Generate(StructuredCodeVisitor writer) {
            var continuationContext = writer.Context.Fork(1);

            foreach (var param in Parameters) {
                param.Generate(writer);
            }

            writer.PushSymbol(continuationContext.Name);
            writer.PushSymbol(FunctionName);

            writer.Context = continuationContext;
        }

        public string Dump {
            get {
                return string.Format("{0}({1})", FunctionName,
                    string.Join(", ", Parameters.Select(x => x.Dump)));
            }
        }
    }
}
