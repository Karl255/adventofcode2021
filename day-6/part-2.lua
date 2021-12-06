io = require("io")

local input = io.open("input.txt", "r"):read()
local ageCounts = { 0, 0, 0, 0, 0, 0, 0, 0, 0 }

for match in input:gmatch("[^,]+") do
	local index = tonumber(match) + 1
	ageCounts[index] = ageCounts[index] + 1
end

for i = 1, 256 do
	local dead = ageCounts[1]
	
	for j = 2, #ageCounts do
		ageCounts[j - 1] = ageCounts[j]
	end
	
	ageCounts[6 + 1] = ageCounts[6 + 1] + dead
	ageCounts[8 + 1] = dead
end

local sum = 0
for i = 1, #ageCounts do
	sum = sum + ageCounts[i]
end

print(sum)
