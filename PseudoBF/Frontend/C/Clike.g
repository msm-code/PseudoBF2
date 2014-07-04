grammar Clike;

options {
    output = AST;
    language = CSharp3;
}

tokens {
    PROGRAM; VARDEF; ARRDEF; FUNCALL; IDLIST; EXPRLIST; FUNCDEF; FUNCDECL; STATLIST; IF; WHILE; STANDALONE; VARNAME; RETURN;
    LT = '<'; GT = '>'; EQ = '=='; NEQ = '!='; ADD = '+'; SUB = '-'; MUL = '*'; ASSIGN = '='; NOT = '!'; AND = '&&'; OR = '||';
}

public program: fdef+ EOF                 -> ^(PROGRAM fdef+);
fdef: 'func' ID idlist stat               -> ^(FUNCDEF ID idlist stat)
    | 'extern' ID idlist ';'              -> ^(FUNCDECL ID idlist);
stat: 'if' expr stat                      -> ^(IF expr stat)
    | 'while' expr stat                   -> ^(WHILE expr stat)
    | 'return' expr ';'                   -> ^(RETURN expr)
    | expr ';'                            -> ^(STANDALONE expr)
    | ID '=' expr ';'                     -> ^(ASSIGN ID expr)
    | '{' stat* '}'                       -> ^(STATLIST stat*)
	| 'var' vdcl (',' vdcl)* ';'          ->   vdcl+
    | ';'                                 -> ;
vdcl: ID ('=' expr)?                      -> ^(VARDEF ID) ^(ASSIGN ID expr)?
    | ID '[' NUMBER ']'                   -> ^(ARRDEF ID NUMBER);
idlist:   '(' (ID (',' ID)*)? ')'         -> ^(IDLIST ID*);
exprlist: '(' (expr (',' expr)*)? ')'     -> ^(EXPRLIST expr*);
atom: (ID '(') => ID exprlist             -> ^(FUNCALL ID exprlist)
    | ID                                  -> ^(VARNAME ID)
    | NUMBER                              ->   NUMBER
    | CHARLIT                             ->   CHARLIT
    | '(' expr ')'                        ->   expr;
      
expr:     equ_expr ((AND|OR)^ equ_expr)*;
equ_expr: cmp_expr ((EQ|NEQ)^ cmp_expr)*;
cmp_expr: add_expr ((LT|GT)^ add_expr)*;
add_expr: mul_expr ((ADD|SUB)^ mul_expr)*;
mul_expr: neg_expr (MUL^ neg_expr)*;
neg_expr: (NOT^ atom) | atom;

ID: ('a'..'z' | 'A'..'Z' | '_')+;
NUMBER: ('0'..'9')+;
CHARLIT: '\'' (' '..'~') '\'';
COMMENT: '/*' (' '..'~')* '*/' { $channel = Hidden; };
WHITESPACE: (' '|'\t'|'\n'|'\r')+ { $channel = Hidden; };
