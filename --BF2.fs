( BF COMPILER )

( DEFINE CODE AND INPUT HERE )

: PROGRAM S" >>>+[[-]>>[-]++>+>+++++++[<++++>>++<-]++>>+>+>+++++[>++>++++++<<-]+>>>,<++[[>[->>]<[>>]<<-]<[<]<+>>[>]>[<+>-[[<+>-]>]<[[[-]<]++<-[<+++++++++>[<->-]>>]>>]]<<]<]<[[<]>[[>]>>[>>]+[<<]<[<]<+>>-]>[>]+[->>]<<<<[[<<]<[<]+<<[+>+<<-[>-->+<<-[>+<[>>+<<-]]]>[<+>-]<]++>>-->[>]>>[>>]]<<[>>+<[[<]<]>[[<<]<[<]+[-<+>>-[<<+>++>-[<->[<<+>>-]]]<[>+<-]>]>[>]>]>[>>]>>]<<[>>+>>+>>]<<[->>>>>>>>]<<[>.>>>>>>>]<<[>->>>>>]<<[>,>>>]<<[>+>]<<[+<<]<]" ;

: INPUT S" >>>>>>>>>>+>++<[[[<<+>+>-]++++++[<++++++++>-]<-.[-]<<<]++++++++++.[-]>>>>>[>>>>]<<<<[[<<<+>+>>-]<<<-<]>>++[[<<<++++++++++[>>>[->>+<]>[<]<<<<-]>>>[>>[-]>>+<<<<[>>+<<-]]>>>>]<<-[+>>>>]+[<<<<]>]>>>[>>>>]<<<<-<<+<<]!" ;

( ACTUAL INTERPRETER )

( VARIABLES )

: CELLS 10000 ALLOT ;

PROGRAM DROP LDP!

CELLS VARIABLE POINTER
POINTER !
PROGRAM DROP VARIABLE PKPOINT
PKPOINT ! ( SET PKPOINT TO ADDRESS )

INPUT DROP VARIABLE IPOINT
IPOINT !

( OUTPUT NEW CHARACTER OF PROGRAM ON EACH CALL )

: PKEY
 PROGRAM + ( GET UPPER LIMIT )
 PKPOINT @ ( GET CURRENT POINTER )
 > IF ( POINTER MUST BE BELOW LIMIT )
  PKPOINT @ @ ( PROVIDE OUTPUT )
  1 PKPOINT +! ( INCREMENT POINTER )
 ELSE
  0
 THEN
;

( DO THE SAME FOR INPUT )

: IKEY
 INPUT + ( GET UPPER LIMIT )
 IPOINT @ ( GET CURRENT POINTER )
 > IF ( POINTER MUST BE BELOW LIMIT )
  IPOINT @ @ ( PROVIDE OUTPUT )
  1 IPOINT +! ( INCREMENT POINTER )
 ELSE
  0
 THEN
;

: COMPILE
 S" BF" CREATE ( CREATE THE PROGRAM WORD )
 ' POINTER ,
 ' @ ,
 
 ( EVERY INSTRUCTION ALREADY HAS ACCESS TO THE POINTER NOW )
 
 BEGIN
  PKEY ?DUP
 WHILE
  CASE
   [ CHAR . ] LITERAL OF
    ' DUP ,
    ' @ ,
    ' EMIT ,
    ." ."
   ENDOF
   [ CHAR , ] LITERAL OF
    ' IKEY ,
    ' OVER ,
    ' ! ,
    ." ,"
   ENDOF
   [ CHAR < ] LITERAL OF
     ' 1- ,
    ." <"
   ENDOF
   [ CHAR > ] LITERAL OF
    ' 1+ ,
    ." >"
   ENDOF
   [ CHAR - ] LITERAL OF
     -1 [COMPILE] LITERAL
    ' OVER ,
    ' +! ,
    ." -"
   ENDOF
   [ CHAR + ] LITERAL OF
     1 [COMPILE] LITERAL
    ' OVER ,
    ' +! ,
    ." +"
   ENDOF
   [ CHAR [ ] LITERAL OF
    [COMPILE] BEGIN
    ' DUP ,
    ' @ ,
    0 [COMPILE] LITERAL
    ' <> ,
    [COMPILE] WHILE
    ." ["
   ENDOF
   [ CHAR ] ] LITERAL OF
    ' REFR ,
    [COMPILE] REPEAT
    ." ]"
   ENDOF
  ENDCASE
 REPEAT
 ' EXIT ,
;

COMPILE
CR ." END" CR

BF

