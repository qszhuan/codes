Object ancestors := method(
       prototype := self proto
       if(prototype != Object,
       prototype ancestors
        writeln("Slots of", prototype type, "\n------------")		
       prototype slotNames foreach(slotName, writeln(slotName))
       writeln,

       "END"))

Animal := Object clone
Animal speak := method("ambiguous animal noise" println)
Duck := Animal clone
Duck speak := method("quack" println)
Duck walk := method("waddle" println)
disco := Duck clone
disco ancestors println

