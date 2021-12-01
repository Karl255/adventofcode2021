const fs = require("fs");

let depths = fs.readFileSync("../input.txt", "ascii").split("\n").map(x => parseInt(x));
let count = 0;

for (let i = 1; i < depths.length; i++) {
	if (depths[i - 1] < depths[i]) {
		count++;
	}
}

console.log(count);
