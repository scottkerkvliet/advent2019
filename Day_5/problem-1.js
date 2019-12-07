var fs = require('fs');
var Intcode = require('./Intcode');

var array = fs.readFileSync('./program.txt').toString().split(",");
var program = array.map((value) => parseInt(value));

Intcode.runProgram(program)
