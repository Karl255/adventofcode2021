const fs = require("fs");

class Board {
	constructor(values) {
		this.values = values;
		this.rows = [0, 0, 0, 0, 0];
		this.cols = [0, 0, 0, 0, 0];
	}
	
	draw(number) {
		let i = this.values.indexOf(number);
		
		if (i !== -1) {
			this.cols[i % 5]++;
			this.rows[Math.floor(i / 5)]++;
		}
		
		return this.cols[i % 5] === 5 || this.rows[Math.floor(i / 5)] === 5;
	}
}

let input = fs.readFileSync("input.txt", "ascii").split("\n\n");
let drawnNumbers = input[0].split(",").map(x => parseInt(x))
let boards = input.filter((x, i) => i != 0).map(b => new Board(b.replace(/\n/g, " ").trim().split(/ +/).map(x => parseInt(x))));
let i;
let j;

outer: for (i = 0; i < drawnNumbers.length; i++) {
	for (j = 0; j < boards.length; j++) {
		if (boards[j].draw(drawnNumbers[i])) break outer;
	}
}

drawnNumbers = drawnNumbers.slice(0, i + 1);
console.log(boards[j].values.filter(x => drawnNumbers.indexOf(x) === -1).reduce((x, y) => x + y, 0) * drawnNumbers[i]);
