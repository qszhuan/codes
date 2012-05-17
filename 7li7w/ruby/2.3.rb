#using block
File.open(__FILE__, 'r') do |file|
#  puts file.readlines
  puts __LINE__
  # puts  file.methods()
end

#not using block 
file = File.open(__FILE__, 'r')
# puts file.readlines
file.close


a = {:one => 1, :two => 2}
# puts a.methods
puts a.to_a

b = [1,2,3,4]
puts Hash[*b]
