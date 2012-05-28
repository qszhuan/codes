XmlBuilder := Object clone

XmlBuilder forward := method(
	   writeln("<", call message name, ">")
	   call message arguments foreach(
	   	arg,
		content := self doMessage(arg);
		if(content type == "Sequence", writeln(content)))
	   writeln("</", call message name, ">")
)


XmlBuilder doc(
		ul(
			   li("ruby")
			   li("python")
			   li("io")
	   	)
	      ) println
