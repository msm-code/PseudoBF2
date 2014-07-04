using Antlr.Runtime;
using Antlr.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using Tokens = ClikeLexer;
using PseudoBF.Frontend.C.Statements;

namespace PseudoBF.Frontend.C {
    class Parser : IParser {
        Dictionary<int, Func<ITree, object>> handlers;

        public Parser() {
            handlers = new Dictionary<int, Func<ITree, object>>();

            handlers[Tokens.PROGRAM] = tree => {
                var program = new Program();
                for (int i = 0; i < tree.ChildCount; i++) {
                    var declarator = Handle<object>(tree.GetChild(i));
                    if (declarator is FunctionDecl) {
                        program.Declarations.Add(declarator as FunctionDecl);
                    } else {
                        program.Definitions.Add(declarator as FunctionDef);
                    }
                } return program;
            };

            handlers[Tokens.FUNCDEF] = tree => new FunctionDef(tree.GetChild(0).Text,
                            Handle<string[]>(tree.GetChild(1)),
                            Handle<IStatement>(tree.GetChild(2)));

            handlers[Tokens.FUNCDECL] = tree => new FunctionDecl(tree.GetChild(0).Text,
                            (Handle<string[]>(tree.GetChild(1))).Length);

            handlers[Tokens.IDLIST] = tree => tree.ChildCount > 0 ?
                (tree as CommonTree).Children.Select(x => Handle<string>(x)).ToArray() : new string[0];

            handlers[Tokens.EXPRLIST] = tree => tree.ChildCount > 0 ?
                (tree as CommonTree).Children.Select(x => Handle<IExpression>(x)).ToArray() : new IExpression[0];

            handlers[Tokens.STATLIST] = tree => new Block(tree.ChildCount > 0 ? 
                (tree as CommonTree).Children.Select(x => Handle<IStatement>(x)).ToList() 
                : new List<IStatement>());

            handlers[Tokens.VARDEF] = tree => new VariableDeclaration(tree.GetChild(0).Text);
            handlers[Tokens.ARRDEF] = tree => new VariableDeclaration(tree.GetChild(0).Text, int.Parse(tree.GetChild(1).Text));
            handlers[Tokens.VARNAME] = tree => new IntVariable(tree.GetChild(0).Text);
            handlers[Tokens.STANDALONE] = tree => new StandaloneExpression(Handle<IExpression>(tree.GetChild(0)));
            handlers[Tokens.ASSIGN] = tree => new Assignment(tree.GetChild(0).Text, Handle<IExpression>(tree.GetChild(1)));
            handlers[Tokens.RETURN] = tree => new Return(Handle<IExpression>(tree.GetChild(0)));
            handlers[Tokens.NOT] = tree => new FunctionCall("_not", Handle<IExpression>(tree.GetChild(0)));
            handlers[Tokens.IF] = tree => new If(Handle<IExpression>(
                tree.GetChild(0)), Handle<IStatement>(tree.GetChild(1)));
            handlers[Tokens.WHILE] = tree => new While(Handle<IExpression>(
                tree.GetChild(0)), Handle<IStatement>(tree.GetChild(1)));

            Action<int, string> handleOperator = (opId, func) => {
                handlers[opId] = tree => new FunctionCall(func, Handle<IExpression>(
                    tree.GetChild(0)), Handle<IExpression>(tree.GetChild(1)));
            };

            handleOperator(Tokens.ADD, "_add");
            handleOperator(Tokens.SUB, "_sub");
            handleOperator(Tokens.MUL, "_mul");
            handleOperator(Tokens.EQ, "_eq");
            handleOperator(Tokens.NEQ, "_neq");
            handleOperator(Tokens.LT, "_lt");
            handleOperator(Tokens.GT, "_gt");
            handleOperator(Tokens.AND, "_and");
            handleOperator(Tokens.OR, "_or");

            handlers[Tokens.FUNCALL] = tree => new FunctionCall(
                tree.GetChild(0).Text, Handle<IExpression[]>(tree.GetChild(1)));
            handlers[Tokens.NUMBER] = tree => new Constant(int.Parse(tree.Text));
            handlers[Tokens.CHARLIT] = tree => new Constant(tree.Text[1]);
            handlers[Tokens.ID] = tree => tree.Text;
        }

        T Handle<T>(ITree tree) {
            return (T)handlers[tree.Type](tree);
        }

        public ISyntaxTree Parse(string source) {
            var input = new ANTLRStringStream(source);
            var lexer = new ClikeLexer(input);
            var tokens = new CommonTokenStream(lexer);
            var parser = new ClikeParser(tokens);

            var result = parser.program();
            return Handle<ISyntaxTree>(result.Tree as ITree);
        }
    }
}
