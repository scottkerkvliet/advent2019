var fs = require('fs');
var Intcode = require('./Intcode');

var array = fs.readFileSync('./program.txt').toString().split(",");
var maxThruster = 0;
var maxThrusterPermutation = undefined;
var permutations = []
for (var i = 0; i < 5; i++) {
  for (var j = 0; j < 5; j++) {
    if (j === i) continue;
    for (var k = 0; k < 5; k++) {
      if ((k === i) || (k === j)) continue;
      for (var m = 0; m < 5; m++) {
        if ((m === i) || (m === j) || (m === k)) continue;
        for (var n = 0; n < 5; n++) {
          if ((n === i) || (n === j) || (n === k) || (n === m)) continue;
          permutations.push([i, j, k, m, n])
        }
      }
    }
  }
}

for (var permutation of permutations) {
  var input = 0;
  for (var setting of permutation) {
    var firstRun = true;
    var programInput = function () {
      if (firstRun) {
        firstRun = false;
        return setting;
      }
      return input;
    }
    var programOutput = function (thruster) {
      input = thruster;
    }
    var program = array.map((value) => parseInt(value));
    Intcode.runProgram(program, programInput, programOutput);
  }
  
  if (input > maxThruster) {
    maxThruster = input;
    maxThrusterPermutation = permutation;
  }
}

console.log(maxThruster);
console.log(maxThrusterPermutation);
