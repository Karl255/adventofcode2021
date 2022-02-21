File.read!("input.txt")
|> String.split("\n", trim: true)
|> Enum.map(fn l ->
	%{ :dir => String.first(l), :value => l |> String.last |> Integer.parse |> elem(0) }
end)
|> Enum.reduce(%{:x => 0, :z => 0, :aim => 0}, fn cmd, acc ->
	case cmd.dir do
		"f" -> %{ acc | :x => acc.x + cmd.value, :z => acc.z + acc.aim * cmd.value}
		"d" -> %{ acc | :aim => acc.aim + cmd.value}
		"u" -> %{ acc | :aim => acc.aim - cmd.value}
		_ -> acc
	end
end)
|> (fn sub -> sub.x * sub.z end).()
|> IO.puts
