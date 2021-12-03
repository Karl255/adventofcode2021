depths = readlines("../input.txt") .|>
	x -> parse(Int, x)

n = 0

for i = 4:length(depths)
	if depths[i - 3] < depths[i]
		global n += 1
	end
end

print(n)
