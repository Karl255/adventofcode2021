console.log(require("fs").readFileSync("input.txt", "ascii").slice(0, -1).split("\n").map(l=>l.split(" | ")[1].split(" ").filter(x=>x.length-5&6).length).reduce((x, y)=>x+y));
