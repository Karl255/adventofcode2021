use Bitwise

report =
	File.read!("input.txt")
	|> String.split("\n", trim: true)
	|> Enum.map(fn line -> line |> String.to_charlist end)

bit_count = length List.first report

gamma =
	Enum.reduce((0..bit_count - 1), report, fn i, list ->
		len = length list
		
		if len <= 1 do
			list
		else
			ones_count = Enum.count(list, &(Enum.at(&1, i) === ?1))
			next_bit = if ones_count >= len / 2, do: ?1, else: ?0
			Enum.filter(list, &(Enum.at(&1, i) === next_bit))
		end
	end)

epsilon =
	Enum.reduce((0..bit_count - 1), report, fn i, list ->
		len = length list
		
		if len <= 1 do
			list
		else
			ones_count = Enum.count(list, &(Enum.at(&1, i) === ?1))
			next_bit = if ones_count < len / 2, do: ?1, else: ?0
			Enum.filter(list, &(Enum.at(&1, i) === next_bit))
		end
	end)

[gamma | epsilon]
|> Enum.map(fn x -> x |> List.to_string |> Integer.parse(2) |> elem(0) end)
|> Enum.reduce(&*/2)
|> IO.puts
