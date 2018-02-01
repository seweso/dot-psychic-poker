# dot-psychic-poker
Implementation of https://github.com/btccom/Hire/blob/master/exercise/psychic-poker-en.md

Implemented as a command line application, where you can either type input (keyboard) or pipe in an input file. 


Build instructions:
* Open project in visual studio >= 2012
* Update NUGet packages
* Switch to 64 bit (for command line / pipe support)
* Build solution 
* Run NUnit test project
* Goto bin/x64/Debug folder and run dot-psychic-poker-console.exe and enter input followed by enter


This does not implement: 
* Checking whether cards are duplicate
* Showing the cards of the best hand in the output
* Calculating and displaying detailed rank 
* Does not fail gracefully, anything outside of the spec throws an exception (fail early)
