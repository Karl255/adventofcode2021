let exclude = (set, remove) => set.filter(x=>!remove.includes(x));
let intersect = (a, b) => a.filter(x=>b.includes(x));

function decode(entry) {
	let t = entry.split(" | ");
	let p = t[0].split(" ").map(x=>x.split("")).sort((x, y) => x.length - y.length);
	let value = t[1].split(" ").map(x => x.split("").sort().join(""));
	
	let digits = [];
	digits[1] = p[0];
	digits[4] = p[2];
	digits[7] = p[1];
	digits[8] = p[9];
	digits[3] = p.slice(3, 6).filter(x => intersect(x, p[0]).length == 2)[0];
	let digits25 = exclude(p.slice(3, 6), [digits[3]]);
	digits[2] = digits25.filter(x => intersect(x, p[2]).length == 2)[0];
	digits[5] = exclude(digits25, [digits[2]])[0];
	digits[9] = p.slice(6, 9).filter(x => intersect(x, p[2]).length == 4)[0];
	digits[6] = p.slice(6, 9).filter(x => intersect(x, p[1]).length == 2)[0];
	digits[0] = exclude(exclude(p.slice(6, 9), [digits[6]]), [digits[9]])[0];
	digits = digits.map(x => x.sort().join(""));
	
	return +value.map(x => digits.indexOf(x)+"").join("");
}

console.log(require("fs")
	.readFileSync("input.txt","ascii")
	.trim()
	.split("\n")
	.map(decode)
	.reduce((x,y)=>x+y));
