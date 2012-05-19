def grep(file_name, pattern)
	File.open(file_name, 'r') do |file|
		i = 1
		file.readlines.each do | line|
			if line =~ /#{pattern}/
				puts "#{i}: #{line}"
			end
			i += 1
		end
	end
end

grep(__FILE__, 'line')