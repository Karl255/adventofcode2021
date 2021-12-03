depths = readlines("../input.txt") .|>
	x -> parse(Int, x)

n = 0

for i = 2:length(depths)
	if depths[i - 1] < depths[i]
		global n += 1
	end
end

print(n)
