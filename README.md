# AVC3 Forth

This is by far my biggest achievement with the Virtual Computer series for SmileBASIC. This is a complete interactive Forth environment with two programs, a snake game and bf esoteric programming language compiler. If you want to get these working, see my other repository containing most AVC3 programs. FORTH.txt is the Forth compiler itself. FORTH.txt with a bunch of dashes is the words defined in Forth itself. SNAKE.fs and BF2.fs are the programs.

I based my Forth on Jonesforth, which is so easy to follow that I could port it, line by line, to a completely different assembly language. I did change a few things about the data layout and call/return mechanism to better fit AVC3 but it's mostly a straightforward port.
