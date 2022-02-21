use Bitwise

gamma =
	File.read!("input.txt")
	|> String.split("\n", trim: true)
	|> Enum.map(fn line -> line |> String.to_charlist |> Enum.map(fn x -> x - ?0 end) end)
	|> Enum.zip_reduce(0, fn elems, acc ->
		acc <<< 1 |||
			if Enum.count(elems, &(&1 == 1)) >= length(elems) / 2 do
				1
			else
				0
			end
	end)

IO.puts(gamma * bxor(gamma, 0xfff))
