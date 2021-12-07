const fs = require("fs");

let input = fs
	.readFileSync("input.txt", "ascii")
	.split(",")
	.map(x => parseInt(x));

input.sort((x, y) => x - y);
let minFuel = Number.MAX_VALUE;

for (let i = input[0]; i < input[input.length - 1]; i++) {
	let fuel = input
		.map(x => { let t = Math.abs(i - x); return t * (t + 1) / 2; })
		.reduce((x, y) => x + y);
	
	if (fuel < minFuel) {
		minFuel = fuel;
	}
}

console.log(minFuel);
