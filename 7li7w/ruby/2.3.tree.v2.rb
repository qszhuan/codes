class Tree
  attr_accessor :children, :node_name

  def initialize(tree = {})
    @node_name = tree.keys.first
    @children = tree[@node_name] unless @node_name == nil
  end

  def visit_all(&block)
    visit &block
    @children.each do |key, value|
      tc = Tree.new({key=>value})
      tc.visit_all &block
    end
  end

  def to_s
    puts "#{@node_name}"
  end

  def visit(&block)
    block.call self
  end
end

ruby_tree = Tree.new({'ruby'=>{'JRuby' => {}, 'MacRuby' => {}}})

puts "visit one node"
ruby_tree.visit { |node| puts node.node_name}

puts 'visit tree'
ruby_tree.visit_all {|node| puts node.node_name}
