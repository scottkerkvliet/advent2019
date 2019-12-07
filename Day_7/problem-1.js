var fs = require('fs');
var Intcode = require('./Intcode');
var readline = require('readline-sync');

getInput = function () {
  return parseInt(readline.prompt());
}

sendOutput = function (output) {
  console.log(output);
}

var array = fs.readFileSync('./program.txt').toString().split(",");
var program = array.map((value) => parseInt(value));

Intcode.runProgram(program, getInput, sendOutput);
