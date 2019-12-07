var fs = require('fs');
var Intcode = require('./Intcode');

var array = fs.readFileSync('./program.txt').toString().split(",");
var program = array.map((value) => parseInt(value));

// Set state to 1202 program alarm state
program[1] = 12
program[2] = 2

Intcode.runProgram(program)

console.log(program[0]);
