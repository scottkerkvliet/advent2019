var http = require('http');
var fs = require('fs');
var calculator = require('./fuelCalc');

http.createServer(function (req, res) {
    res.writeHead(200, {'Content-Type': 'text/html'});
    var totalFuel = 0
    var array = fs.readFileSync('./modules.txt').toString().split("\r\n");
    console.log(array)
    for (var index in array) {
        var moduleWeight = array[index]
        var fuel = calculator.calculateFuel(parseInt(moduleWeight))
        totalFuel += fuel
    }
    res.write("<p>Total Fuel: " + totalFuel + "</p>")
    res.end();
}).listen(8080); 