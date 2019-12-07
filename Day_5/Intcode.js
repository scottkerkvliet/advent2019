runOpCode1 = function (index, program, modes) {
  const index1 = program[index + 1];
  const index2 = program[index + 2];
  const index3 = program[index + 3];

  const value1 = modes[0] ? index1 : program[index1];
  const value2 = modes[1] ? index2 : program[index2];

  program[index3] = value1 + value2;
  return index + 4;
}

runOpCode2 = function (index, array, modes) {
  const index1 = array[index + 1];
  const index2 = array[index + 2];
  const index3 = array[index + 3];

  const value1 = modes[0] ? index1 : array[index1];
  const value2 = modes[1] ? index2 : array[index2];

  array[index3] = value1 * value2;
  return index + 4;
}

exports.runProgram = function (program) {

  if (array[index] === 99) {
    return -1;
  }
  const index1 = array[index + 1];
  const index2 = array[index + 2];
  const index3 = array[index + 3];

  if (array[index] === 1) {
    array[index3] = array[index1] + array[index2];
  } else if (array[index] === 2) {
    array[index3] = array[index1] * array[index2];
  }

  return index + 4;
};

getInstruction = function (index, program) {
  var input = program[index];

  if (input < 100) {
    return [input, [0, 0, 0]];
  }

  var inputString = input.toString()
  var opcode = inputString.substr()

}