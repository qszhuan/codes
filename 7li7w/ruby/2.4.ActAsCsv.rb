class ActAsCsv
	def read
		puts self.class.to_s
		file = File.new(self.class.to_s.downcase + '.txt')
		@headers = file.gets.chomp.split(',')
		file.each do | row |
			@result << row.chomp.split(',')
		end
	end

	def headers
		@headers
	end

	def csv_contents
		@result
	end

	def initialize
		@result = []
		read
	end

	def each
		@result.each do | row |
			yield CsvRow.new(@headers, row)
		end
	end
end

class CsvRow
	attr_accessor :headers, :contents
	def initialize(headers, contents)
		@headers = headers
		@contents = contents
	end

	def method_missing name, *args
		index = @headers.index("#{name}")
		super unless index != nil
		contents[index]
	end
end

