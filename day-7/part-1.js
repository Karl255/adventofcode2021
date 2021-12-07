const fs = require("fs");

let input = fs
	.readFileSync("input.txt", "ascii")
	.split(",")
	.map(x => parseInt(x));

input.sort((x, y) => y - x)

let med;

if (input.length % 2 === 0) {
	let i = input.length / 2;
	med = (input[i] + input[i - 1]) / 2;
} else {
	med = input[(input.length + 1) / 2];
}

console.log(input
	.map(x => Math.abs(med - x))
	.reduce((x, y) => x + y)
	);
