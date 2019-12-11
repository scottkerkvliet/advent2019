var fs = require('fs');

var rawImage = fs.readFileSync('./image.txt').toString();
var layers = [];

while (layers.length * 150 < rawImage.length) {
  var layer = []
  for (var i = 0; i < 6; i++) {
    var row = [];
    for (var j = 0; j < 25; j++) {
      var pixel = parseInt(rawImage[(layers.length * 150) + (i * 25) + j]);
      row.push(pixel);
    }
    layer.push(row);
  }
  layers.push(layer);
}

var finalLayer = [];
for (var i = 0; i < 6; i++) {
  var row = [];
  for (var j = 0; j < 25; j++) {
    for (var k = 0; k < layers.length; k++) {
      var pixel = layers[k][i][j];
      if (pixel !== 2) {
        row.push(pixel);
        break;
      }
    }
  }
  finalLayer.push(row);
}

for (var i = 0; i < 6; i++) {
  var row = "";
  for (var j = 0; j < 25; j++) {
    row += finalLayer[i][j] ? "1" : " ";
  }
  console.log(row);
}
