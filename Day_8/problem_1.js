var fs = require('fs');

var rawImage = fs.readFileSync('./image.txt').toString();
var layers = [];

var minZero = Number.MAX_VALUE;
var answer = 0;
while (layers.length * 150 < rawImage.length) {
  var layer = []
  var zeroCount = 0;
  var oneCount = 0;
  var twoCount = 0;
  for (var i = 0; i < 6; i++) {
    var row = [];
    for (var j = 0; j < 25; j++) {
      var pixel = parseInt(rawImage[(layers.length * 150) + (i * 25) + j]);
      if (pixel === 0) {
        zeroCount++;
      }
      else if (pixel === 1) {
        oneCount++;
      }
      else if (pixel === 2) {
        twoCount++;
      }
      row.push(pixel);
    }
    layer.push(row);
  }
  if (zeroCount < minZero) {
    minZero = zeroCount;
    answer = oneCount * twoCount;
  }
  layers.push(layer);
}

console.log(minZero);
console.log(answer);
