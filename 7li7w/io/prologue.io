#消息在右，接受者在左
"Hi hi, Io" println

#通过Object对象原型创建一个新对象
Vehicle := Object clone
Vehicle println

#为对象添加槽(slot) (如果没有该槽，:= 会创建一个，而=不会) 
Vehicle description := "Something to take you places"
Vehicle description println

#获取所有slots
Vehicle slotNames println

#获取类型（和ruby中的class不是一回事）
Vehicle type println
Object type println