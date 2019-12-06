exports.calculateFuel = function (module) {
    if (isNaN(module)) {
        return 0
    }
    return Math.max(Math.floor(module / 3) - 2, 0);
};