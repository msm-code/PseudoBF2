PseudoBF2
=========

The Language
------------

Complete rewrite of PseudoBF (which is previous version of this project) - https://github.com/msm-code/PseudoBF

PseudoBF is simple high-level, C-like language:

```
func print_digit(dig)
    _echo(dig + '0');

func main() {
    var foo = 0;
    while foo < 5 {
        print_digit(foo);
		foo = foo + 1;
    }
}
```

PseudoBF compiler can convert above code directly to brainf..k (creating this monstrosity):

```
+[>+<[-[-[-[-[-[-[-[-[-[-[-[-[-[-[-[-[-[-[-[-[-[-[-[-[-[-[-[-[-[-[-[-[-[-[-[-[-[
-[-[-[-[-[-[-[-[-[-[-[-[-[-[-[-[-[-[-[-[-[-[-[-[-[-[-[-[-[-[-[-[-[-[-[-[-[-[-[-[
-[-[-[-[-[...]>[<<<[-]>[-<+>][-]++++++++++++++++++++++++++++++++++++++++++++++++
++++++++++++++++++++++++++++++>[-]>[-]]<]>[<[-]<[->+<][-]>[-]<<[->+>+<<]>>[-<<+>
>][-]+>[-]++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
++++++++++++>[-]++++>[-]>[-]]<]>[<[-]>[-]<<[->+>+<<]>[-<+>]+>[<->[-]]<[<<<[-]>[-
<+>]>>-]<<[-]>[-]]<]>[<[-]<[->+<][-]>[-]++++++++++++++++++++++++++++++++++++++++
++++++++++++++++++++++++++++++++++++>[-]>[-]]<]>[<[-]+++++++++++++++++++++++++++
++++++++++++++++++++++++++++++++++++++++++++++++++>[-]++++++++++++++++++++++++++
+++++++++++++++++++++++++++++++++++++++++++++++++++++>[-]>[-]<<<<[->>>+>+<<<<]>>
>>[-<<<<+>>>>][-]+++++>[-]++++++++++++++++++++++++++++++++++++++++++++++++++++++
++++++++++++++++++++++++++>[-]++++++++++++++++++++++++++++++++++++++++++++>[-]>[
-]]<]>[<[-]>[-]<<[->+>+<<]>>[-<<+>>][-]+++++++++++++++++++++++++++++++++++++++++
++++++++++++++++++++++++++++++++++++++++>[-]++++++++++++++++++++++++++++++++++++
+++++++++++++++++++++++++++++++++++>[-]>[-]]<]>[<[-]>[-]<<[->+>+<<]>>[-<<+>>][-]
>[-]<<<<[->>>+>+<<<<]>>>>[-<<<<+>>>>]<<<[-]>>[-<<+>>]<<<[-]>>[-<<+>>][-]>[-]]<]>
[<[-]>[-]><<[-]>[-<+>][-]+++++++++++++++++++++++++++++++++++++++++++++++++++++++
+++++++++++++++++++++++>[-]>[-]]<]>[<[-]++++++++++++++++++++++++++++++++++++++++
+++++++++++++++++++++++++++++++++>[-]++>[-]>[-]]<]>[<[-]<[->+<][-]>[-]++++++++++
++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++>[-]>[-]]<]>[<[-]>
[-]<<<[->>+>+<<<]>>>[-<<<+>>>]<<<[-]>>[-<<+>>][-]>[-]<<[->+>+<<]>>[-<<+>>]<<<<[-
]>>>[-<<<+>>>][-]<[->+<][-]>[-]]<]>[<[-]>[-]<<<[->>+>+<<<]>>>[-<<<+>>>][-]++++++
++++++++++++++++++++++++++++++++++++++++++>[-]++++++++++++++++++++++++++++++++++
++++++++++++++++++++++++++++++++++++++++>[-]++++>[-]>[-]]<]>[<[-]<[->+<][-]>[-]+
+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++>[-]>[-]]<]>[<<<<
<[-]>>>[-<<<+>>>][-]++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
++++++>[-]>[-]]<]>[<<<[-]>[-<+>][-]>[-]<<<<[->>>+>+<<<<]>>>>[-<<<<+>>>>][-]+>[-]
+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++>[-]+++>[-]
>[-]]<]>[<[-]>[-]<<[->+>+<<]>>[-<<+>>]<<[-]>[-<+>][-]+++++++++++++++++++++++++++
+++++++++++++++++++++++++++++++++++++>[-]>[-]]<]>[<[-]++++++++++++++++++++++++++
+++++++++++++++++++++++++++++++++++++++>[-]+++++++++++++++++++++++++++++++++++++
++++++++++++++++++++++++++++++>[-]>[-]<<<<<<[->>>>>+>+<<<<<<]>>>>>>[-<<<<<<+>>>>
>>][-]>[-]<<[->+>+<<]>[-<+>]+>[<->[-]]<[<<<[-]>[-<+>]>>-]<<[-]>[-]]<]>[<[-]>[-]<
<[->+>+<<]>>[-<<+>>][-]>[-]<<<<<<[->>>>>+>+<<<<<<]>>>>>>[-<<<<<<+>>>>>>][-]+++++
+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++>[-]++++>[-]>[-]]
<]>[<[-]>[-]<<<[->>+>+<<<]>>>[-<<<+>>>]<<<<[-]>>>[-<<<+>>>][-]>[-]<<[->+>+<<]>>[
-<<+>>]<<<<<[-]>>>>[-<<<<+>>>>][-]<[->+<][-]<[->+<][-]>[-]]<]>[<[-]>[-]><<[-]>[-
<+>][-]++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++>[-]>[-
]]<]>[<[-]++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++>[-]>[-]]<
]>[<[-]>[-]++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++>[-]>[-]]
<]>[<[-]>[-]<<<[->>+>+<<<]>>>[-<<<+>>>]<<<<[-]>>>[-<<<+>>>][-]>[-]<<[->+>+<<]>>[
-<<+>>]<<<<<[-]>>>>[-<<<<+>>>>][-]<[->+<][-]<[->+<][-]>[-]]<]>[<[-]>[-]<<<[->>+>
+<<<]>>>[-<<<+>>>][-]>[-]<<<<<[->>>>+>+<<<<<]>>>>>[-<<<<<+>>>>>][-]+++++++++++++
+++++++++++++++++++++++++++++++++++++++++++++++++>[-]+++++++++++++++++++++++++++
+++++++++++++++++>[-]>[-]]<]>[<<<<[-]>>[-<<+>>][-]++++++++++++++++++++++++++++++
+++++++++++++++++>[-]>[-]]<]>[<<<<<[-]>>>[-<<<+>>>][-]>[-]<<<[->>+>+<<<]>>>[-<<<
+>>>][-]+>[-]++++++++++++++++++++++++++++++++++++++++++++++++++++++++++>[-]+++>[
-]>[-]]<]>[<[-]++++++++++++++++++++++++++++++++++++++++++++++++++++++>[-]>[-]]<]
>[<[-]>[-]<<[->+>+<<]>[-<+>]+>[<->[-]]<[<<<[-]>[-<+>]>>-]<<[-]>[-]]<]>[<[-]>[-]<
<<<[->>>+>+<<<<]>>>>[-<<<<+>>>>][-]+>[-]++++++++++++++++++++++++++++++++++++++++
+++++++++++++++++>[-]+++>[-]>[-]]<]>[<[-]>[-]+++++++++++++++++++++++++++++++++++
++++++++++>[-]>[-]]<]>[<[-]++++++++++++++++++++++++++++++++++++++++++++++++++>[-
]>[-]]<]>[<[-]>[-]<<[->+>+<<]>[-<+>]+>[<->[-]]<[<<<[-]>[-<+>]>>-]<<[-]>[-]]<]>[<
[-]+++++++++++++++++++++++++++++++++++++++++++++++++++++>[-]++++++++++++++++++++
++++++++++++++++++++++++++++++++++>[-]>[-]<<<<<[->>>>+>+<<<<<]>>>>>[-<<<<<+>>>>>
][-]+++++++++++++++++++++++++++++++++++++++++++++++++++++++>[-]+++++++++>[-]>[-]
]<]>[<[-]+>[-]+++++++++++++++++++++++++++++++++++++++++++++>[-]>[-]]<]>[<[-]>[-]
+++++++++++++++++++++++++++++++++++++++++++++>[-]>[-]]<]>[<[-]++++++++++++++++++
++++++++++++++++++++++++++++>[-]++++++++++++++++++++++++++++++++++++++++++++++++
>[-]+>[-]>[-]<<[->+>+<<]>[-<+>]+>[<->[-]]<[<<<[-]>[-<+>]>>-]<<[-]>[-]]<]>[<[-]++
+++++++++++++++++++++++++++++++++++++++++++++++>[-]+++++++++++++++++++++++++++++
+++++++++++++++++++++>[-]>[-]<<<<<<[->>>>>+>+<<<<<<]>>>>>>[-<<<<<<+>>>>>>][-]+++
++++++++++++++++++++++++++++++++++++++++++++++++>[-]+++++++++>[-]>[-]]<]>[<[-]>[
-]<<<[->>+>+<<<]>>>[-<<<+>>>]<<<<[-]>>>[-<<<+>>>][-]>[-]<<[->+>+<<]>>[-<<+>>]<<<
<<[-]>>>>[-<<<<+>>>>][-]<[->+<][-]<[->+<][-]>[-]]<]>[<[-]+++++++++++++++++++++++
++++++++++++++++++++++++>[-]>[-]]<]>[<[-]>[-]+++++++++++++++++++++++++++++++++++
+>[-]>[-]]<]>[<[-]+++++++++++++++++++++++++++++++++++++++++>[-]>[-]]<]>[<[-]>[-]
++++++++++++++++++++++++++++++++++++>[-]>[-]]<]>[<[-]+>[-]++++++++++++++++++++++
++++++++++++++>[-]>[-]]<]>[<[-]++++++++++++++++++++++++++++++++++++++>[-]>[-]]<]
>[<[-]++++++++++++++++++++++++++++++++++++++++>[-]++++++++++++++++++++++++++++++
+++++++++++>[-]>[-]<<<<<[->>>>+>+<<<<<]>>>>>[-<<<<<+>>>>>][-]>[-]<<[->+>+<<]>[-<
+>]+>[<->[-]]<[<<<[-]>[-<+>]>>-]<<[-]>[-]]<]>[<[-]+>[-]+++++++++++++++++++++++++
+++++++++++>[-]>[-]]<]>[<[-]>[-]<<<[->>+>+<<<]>>>[-<<<+>>>]<<<<[-]>>>[-<<<+>>>][
-]>[-]<<[->+>+<<]>>[-<<+>>]<<<<<[-]>>>>[-<<<<+>>>>][-]<[->+<][-]<[->+<][-]>[-]]<
]>[<[-]+++++++++++++++++++++++++++++++++++++>[-]++++++++++++++++++++++++++++++++
++++++>[-]>[-]<<<<<<[->>>>>+>+<<<<<<]>>>>>>[-<<<<<<+>>>>>>][-]>[-]<<[->+>+<<]>[-
<+>]+>[<->[-]]<[<<<[-]>[-<+>]>>-]<<[-]>[-]]<]>[<[-]>[-]+++++++++++++++++++++++++
>[-]>[-]]<]>[<[-]+++++++++++++++++++++++++++++++>[-]>[-]]<]>[<[-]>[-]<<[->+>+<<]
>[-<+>]+>[<->[-]]<[<<<[-]>[-<+>]>>-]<<[-]>[-]]<]>[<[-]+>[-]+++++++++++++++++++++
++++>[-]>[-]]<]>[<[-]>[-]+++++++++++++++++++++++++>[-]>[-]]<]>[<[-]+++++++++++++
++++++++++++++>[-]>[-]]<]>[<[-]>[-]<<[->+>+<<]>[-<+>]+>[<->[-]]<[<<<[-]>[-<+>]>>
-]<<[-]>[-]]<]>[<[-]++++++++++++++++++++++++++++++>[-]++++++++++++++++++++++++++
+++++>[-]>[-]<<<<<[->>>>+>+<<<<<]>>>>>[-<<<<<+>>>>>][-]+++++++++++++++++++++++++
+++++++>[-]+++++++++>[-]>[-]]<]>[<[-]>[-]+++++++++++++++++++++++++>[-]>[-]]<]>[<
[-]>[-]<<<[->>+>+<<<]>>>[-<<<+>>>]<<<<[-]>>>[-<<<+>>>][-]>[-]<<[->+>+<<]>>[-<<+>
>]<<<<<[-]>>>>[-<<<<+>>>>][-]<[->+<][-]<[->+<][-]>[-]]<]>[<[-]++++++++++++++++++
++++++++>[-]+++++++++++++++++++++++++++>[-]>[-]<<<<<<[->>>>>+>+<<<<<<]>>>>>>[-<<
<<<<+>>>>>>][-]++++++++++++++++++++++++++++>[-]+++++++++>[-]>[-]]<]>[<[-]+++++++
+++++++++++++++>[-]+++++++++>[-]>[-]]<]>[<[-]++++++++++++++++++++>[-]>[-]]<]>[<[
-]>[-]++++++++++++++++++++>[-]>[-]]<]>[<[-]>[-]<<<[->>+>+<<<]>>>[-<<<+>>>]<<<<[-
]>>>[-<<<+>>>][-]>[-]<<[->+>+<<]>>[-<<+>>]<<<<<[-]>>>>[-<<<<+>>>>][-]<[->+<][-]<
[->+<][-]>[-]]<]>[<[-]>[-]<<<<[->>>+>+<<<<]>>>>[-<<<<+>>>>][-]>[-]<<<<[->>>+>+<<
<<]>>>>[-<<<<+>>>>][-]+++++++++++++++++++++++>[-]+++++++++++++++>[-]>[-]]<]>[<[-
]++++++++++++++++>[-]>[-]]<]>[<[-]>[-]++++++++++++++++>[-]>[-]]<]>[<[-]>[-]<<<[-
>>+>+<<<]>>>[-<<<+>>>]<<<<[-]>>>[-<<<+>>>][-]>[-]<<[->+>+<<]>>[-<<+>>]<<<<<[-]>>
>>[-<<<<+>>>>][-]<[->+<][-]<[->+<][-]>[-]]<]>[<[-]>[-]<<<<[->>>+>+<<<<]>>>>[-<<<
<+>>>>][-]>[-]<<<<[->>>+>+<<<<]>>>>[-<<<<+>>>>][-]++++++++++++++++++>[-]+++>[-]>
[-]]<]>[<[-]>[-]++++++++++>[-]>[-]]<]>[<[-]++++++++++++>[-]>[-]]<]>[<[-]+>[-]+++
+++++++>[-]>[-]]<]>[<[-]>[-]++++++++++>[-]>[-]]<]>[<[-]>[-]<<<[->>+>+<<<]>>>[-<<
<+>>>]<<<[-]>>[-<<+>>][-]>[-]<<[->+>+<<]>>[-<<+>>]<<<<[-]>>>[-<<<+>>>][-]<[->+<]
[-]>[-]]<]>[<[-]+++++++++++>[-]++++++++++++>[-]>[-]<<<<<[->>>>+>+<<<<<]>>>>>[-<<
<<<+>>>>>][-]>[-]<<[->+>+<<]>[-<+>]+>[<->[-]]<[<<<[-]>[-<+>]>>-]<<[-]>[-]]<]>[<[
-]+++++++>[-]+++>[-]>[-]]<]>[<[-]+++++>[-]>[-]]<]>[<[-]>[-]+++++>[-]>[-]]<]>[<[-
]>[-]<<<[->>+>+<<<]>>>[-<<<+>>>]<<<<[-]>>>[-<<<+>>>][-]>[-]<<[->+>+<<]>>[-<<+>>]
<<<<<[-]>>>>[-<<<<+>>>>][-]<[->+<][-]<[->+<][-]>[-]]<]>[<[-]>[-]<<<<[->>>+>+<<<<
]>>>>[-<<<<+>>>>][-]>[-]>[-]<<<<<[->>>>+>+<<<<<]>>>>>[-<<<<<+>>>>>][-]++++++++>[
-]+++>[-]>[-]]<]>[<<<[-<->]>[-<+>][-]>[-]]<]>[<<<.[-]>>[-]>[-]]<]>[<[-]>[-]+++++
++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++>[-]>[-]]<
]<]
```

Improvements over PseudoBF1
---------------------------

PseudoBF is very extensible, that is it builds on very small set of builtins.
In fact, most of above code is compiled subset of standard library:

```
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
```

Except _echo and _sub (substraction), every operator can and should be programmed in language itself.

Other improvements:
 - better designed and more extensible code (with intermediate code layer)
 - allows recursive functions (in PseudoBF1 every function was in fact a macro)
 - debuggability is really improved. Code can be introspected at intermediate level,
    traced with graphical debugger, syntax tree can be dumped, and brainf..k output can be commented.

Todo
----
 - emulated 16bit version (create new ICodeGenerationStrategy)
 - generated brainf..k code optimization and minification
 - pointers and arays
 - for loop
