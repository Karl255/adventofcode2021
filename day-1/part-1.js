const fs = require("fs");

let depths = fs
	.readFileSync("input.txt", "ascii")
	.split("\n")
	.map(x => parseInt(x));

console.log(depths
	.filter((x, i, a) => x > a[i - 1])
	.length);
