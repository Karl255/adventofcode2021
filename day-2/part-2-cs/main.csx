using System.Linq;

System.Console.WriteLine(System.IO.File
	.ReadAllText("../input.txt")
	.Split('\n')
	.SkipLast(1)
	.Select(x => (instruction: x[0], value: int.Parse(x.Split(' ')[1])))
	.Aggregate(
		(x: 0, z: 0, aim: 0),
		(sub, cmd) => cmd.instruction switch
		{
			'f' => sub with { x = sub.x + cmd.value, z = sub.z + cmd.value * sub.aim },
			'u' => sub with { aim = sub.aim - cmd.value },
			'd' => sub with { aim = sub.aim + cmd.value },
			_ => sub
		},
		sub => sub.x * sub.z)
);
