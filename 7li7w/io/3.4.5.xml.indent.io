XmlBuilder := Object clone
XmlBuilder indent := List clone

XmlBuilder forward := method(
	   indent join print
	   writeln("<", call message name, ">")
	   indent push(" ")
	   call message arguments foreach(
	   	arg,
		content := self doMessage(arg);
		if(content type == "Sequence", writeln(indent join, content)))
	   indent pop
	   indent join print
	   writeln("</", call message name, ">")
)


XmlBuilder doc(
		ul(
			   li("ruby")
			   li("python")
			   li("io")
	   	)
	      ) println
