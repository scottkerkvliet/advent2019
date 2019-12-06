var fs = require('fs');
var Intcode = require('./Intcode');

var array = fs.readFileSync('./program.txt').toString().split(",");
var program = array.map((value) => parseInt(value));

const copyProgram = () => {
    const newProgram = [];
    for (var index in program) {
        newProgram[index] = program[index];
    }
    return newProgram
}

const runProgram = (x, y) => {
    var programCopy = copyProgram();
    // Set state
    programCopy[1] = x;
    programCopy[2] = y;
    
    var currentIndex = 0;
    while (currentIndex !== -1) {
        currentIndex = Intcode.runCommand(currentIndex, programCopy);
    }
    return programCopy[0];
}

for (var x = 0; x < 100; x++) {
    for (var y = 0; y < 100; y++) {
        if (runProgram(x, y) === 19690720) {
            console.log("x: " + x + "   y: " + y);
        }
    }
}
