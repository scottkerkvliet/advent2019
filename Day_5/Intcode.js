var readline = require('readline-sync');

runOpCode1 = function (index, program, modes) {
  const index1 = program[index + 1];
  const index2 = program[index + 2];
  const index3 = program[index + 3];

  const value1 = modes[0] ? index1 : program[index1];
  const value2 = modes[1] ? index2 : program[index2];

  program[index3] = value1 + value2;
  return index + 4;
}

runOpCode2 = function (index, program, modes) {
  const index1 = program[index + 1];
  const index2 = program[index + 2];
  const index3 = program[index + 3];

  const value1 = modes[0] ? index1 : program[index1];
  const value2 = modes[1] ? index2 : program[index2];

  program[index3] = value1 * value2;
  return index + 4;
}

runOpCode3 = function (index, program, modes) {
  var input = readline.prompt();

  program[program[index + 1]] = parseInt(input);

  return index + 2;
}

runOpCode4 = function (index, program, modes) {
  const index1 = program[index + 1];
  const value1 = modes[0] ? index1 : program[index1];

  console.log(value1);

  return index + 2;
}

runOpCode5 = function (index, program, modes) {
  const index1 = program[index + 1];
  const index2 = program[index + 2];

  const value1 = modes[0] ? index1 : program[index1];
  const value2 = modes[1] ? index2 : program[index2];

  return value1 != 0 ? value2 : index + 3;
}

runOpCode6 = function (index, program, modes) {
  const index1 = program[index + 1];
  const index2 = program[index + 2];

  const value1 = modes[0] ? index1 : program[index1];
  const value2 = modes[1] ? index2 : program[index2];

  return value1 == 0 ? value2 : index + 3;
}

runOpCode7 = function (index, program, modes) {
  const index1 = program[index + 1];
  const index2 = program[index + 2];
  const index3 = program[index + 3];

  const value1 = modes[0] ? index1 : program[index1];
  const value2 = modes[1] ? index2 : program[index2];

  program[index3] = value1 < value2 ? 1 : 0;
  return index + 4;
}

runOpCode8 = function (index, program, modes) {
  const index1 = program[index + 1];
  const index2 = program[index + 2];
  const index3 = program[index + 3];

  const value1 = modes[0] ? index1 : program[index1];
  const value2 = modes[1] ? index2 : program[index2];

  program[index3] = value1 == value2 ? 1 : 0;
  return index + 4;
}

exports.runProgram = function (program) {
  var index = 0;

  while (index < program.length) {
    var instruction = getInstruction(program[index]);

    if (instruction[0] === 99) {
      break;
    }
    else if (instruction[0] === 1) {
      index = runOpCode1(index, program, instruction[1]);
    }
    else if (instruction[0] === 2) {
      index = runOpCode2(index, program, instruction[1]);
    }
    else if (instruction[0] === 3) {
      index = runOpCode3(index, program, instruction[1]);
    }
    else if (instruction[0] === 4) {
      index = runOpCode4(index, program, instruction[1]);
    }
    else if (instruction[0] === 5) {
      index = runOpCode5(index, program, instruction[1]);
    }
    else if (instruction[0] === 6) {
      index = runOpCode6(index, program, instruction[1]);
    }
    else if (instruction[0] === 7) {
      index = runOpCode7(index, program, instruction[1]);
    }
    else if (instruction[0] === 8) {
      index = runOpCode8(index, program, instruction[1]);
    }
  }
};

getInstruction = function (input) {
  var modes = [0, 0, 0];

  if (input < 100) {
    return [input, modes];
  }

  var inputString = input.toString();
  var opcode = parseInt(inputString.substring(inputString.length - 2));
  var rawModes = inputString.substring(0, inputString.length - 2);
  for (var i = 0; i < rawModes.length; i++) {
    modes[i] = parseInt(rawModes[rawModes.length - 1 - i]);
  }

  return [opcode, modes];
}