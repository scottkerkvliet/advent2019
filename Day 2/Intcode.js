exports.runCommand = function (index, array) {
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