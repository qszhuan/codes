require './2.4.ActAsCsv.rb'

class RubyCsv < ActAsCsv
end	

a = RubyCsv.new
p a.headers
p a.csv_contents

a.each do | row | 
	puts "#{row.name} ===> #{row.city}"
end