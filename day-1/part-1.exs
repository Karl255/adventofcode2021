items =
	File.read!("input.txt")
	|> String.split("\n", trim: true)
	|> Enum.map(fn x -> elem(Integer.parse(x), 0) end)

Stream.zip(items, Stream.drop(items, 1))
|> Enum.count(&(elem(&1, 0) < elem(&1, 1)))
|> IO.puts
