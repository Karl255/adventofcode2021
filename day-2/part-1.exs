File.read!("input.txt")
|> String.split("\n", trim: true)
|> Enum.map(fn l ->
	%{ :dir => String.first(l), :value => l |> String.last |> Integer.parse |> elem(0) }
end)
|> Enum.reduce(%{:x => 0, :z => 0}, fn cmd, acc ->
	case cmd.dir do
		"f" -> %{ acc | :x => acc.x + cmd.value}
		"d" -> %{ acc | :z => acc.z + cmd.value}
		"u" -> %{ acc | :z => acc.z - cmd.value}
		_ -> acc
	end
end)
|> (fn sub -> sub.x * sub.z end).()
|> IO.puts
