course = readlines("input.txt") .|>
	line -> (dir = line[1], value = parse(Int, split(line)[2]))

submarine = (x = 0, z = 0)

for cmd in course
	if cmd.dir == 'f'
		global submarine = merge(submarine, (x = submarine.x + cmd.value,))
	elseif cmd.dir == 'u'
		global submarine = merge(submarine, (z = submarine.z - cmd.value,))
	elseif cmd.dir == 'd'
		global submarine = merge(submarine, (z = submarine.z + cmd.value,))
	end
end

print(submarine.x * submarine.z)
