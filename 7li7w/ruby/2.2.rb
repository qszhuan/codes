puts "hello, world"

puts "Hello, Ruby.".index('Ruby.')

10.times {puts "Zhuan Qingshan"}

i = 1
while i < 11
  puts "This is sentence number #{i}"
  i += 1
end


r = rand(10)
puts "Guess Number (1-10), Start!"
input = gets

while r != input.to_i
  puts "Small" if input.to_i < r
  puts "Big" if input.to_i > r
  input = gets
end
puts "bingo!"
