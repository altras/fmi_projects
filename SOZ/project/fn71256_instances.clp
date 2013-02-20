(definstances Language
([fn71256_Class01] of  Programmer

	(firstName "Paul")
	(lastName "Schubert")
	(uses
		[fn71256_Class2]
		[fn71256_Class3]
		[fn71256_Class4]
		[fn71256_Class5]
		[fn71256_Class6]
		[fn71256_Class7])
	(position "CTO")
	(skills Frontend Backend))

([fn71256_Class0] of  Programmer

	(firstName "Robert")
	(lastName "Fackelman")
	(uses
		[fn71256_Class4]
		[fn71256_Class5]
		[fn71256_Class6])
	(position "Junior")
	(skills Backend))

([fn71256_Class1] of  Programmer

	(firstName "Albert")
	(lastName "Winderspon")
	(uses
		[fn71264_Class2]
		[fn71264_Class3]
		[fn71264_Class4])
	(position "Senior")
	(skills Frontend))

([fn71264_Class2] of  HTML
	
	(langName "HTML 5")
	(creator "W3C" "WHATWG")
	(paradigm Markup)
	(usedBy
		[fn71264_Class10004]
		[fn71264_Class10000])
	(yearOfMaking 2013) 
	(version 5.0))

([fn71264_Class3] of  HTML
	
	(langName "HTML 4.01")
	(creator "W3C")
	(paradigm Markup)
	(usedBy
		[fn71264_Class10004]
		[fn71264_Class10000])
	(yearOfMaking 1999) 
	(version 4.01))

([fn71264_Class4] of  Ruby
	
	(langName "Ruby")
	(creator "Matz")
	(paradigm OOP)
	(usedBy
		[fn71256_Class0]
		[fn71256_Class1])
	(yearOfMaking 1999) 
	(version 1.93))

([fn71264_Class5] of PHP
	
	(langName "PHP4")
	(creator "W3C")
	(paradigm Procedural)
	(usedBy
		[fn71256_Class0])
	(yearOfMaking 1999) 
	(version 4.0))

([fn71264_Class6] of  PHP
	
	(langName "PHP5")
	(creator "W3C")
	(paradigm OOP)
	(usedBy
		[fn71256_Class0])
	(yearOfMaking 1999) 
	(version 5.0))


([fn71264_Class7] of  Haskell
	
	(langName "Haskell")
	(creator "A lot of people")
	(paradigm Functional)
	(usedBy
		[fn71256_Class0])
	(yearOfMaking 1990) 
	(version 2010))
)