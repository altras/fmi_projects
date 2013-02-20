(defclass %3ACLIPS_TOP_LEVEL_SLOT_CLASS "Fake class to save top-level slot information"
	(is-a USER)
	(role abstract)
	(single-slot langName
		(type STRING)
;+		(cardinality 1 1)
		(create-accessor read-write))
	(multislot creator
		(type STRING)
		(cardinality 1 ?VARIABLE)
		(create-accessor read-write))
	(multislot paradigm
		(type SYMBOL)
		(allowed-values OOP Functional Declarative Markup Procedural)
		(cardinality 1 ?VARIABLE)
		(create-accessor read-write))
	(multislot usedBy
		(type INSTANCE)
		(allowed-classes Programmer)
		(cardinality 1 ?VARIABLE)
		(create-accessor read-write))
	(single-slot yearOfMaking
		(type INTEGER)
		(range 1950 ?VARIABLE)
;+		(cardinality 1 1)
		(create-accessor read-write))
	(single-slot version
		(type FLOAT)
;+		(cardinality 1 1)
		(create-accessor read-write))
	(single-slot firstName
		(type STRING)
;+		(cardinality 1 1)
		(create-accessor read-write))
	(single-slot lastName
		(type STRING)
;+		(cardinality 1 1)
		(create-accessor read-write))
	(multislot uses
		(type INSTANCE)
		(cardinality 1 ?VARIABLE)
		(create-accessor read-write)))

(defclass Language
	(is-a USER)
	(role abstract)
	(single-slot langName
		(type STRING)
;+		(cardinality 1 1)
		(create-accessor read-write))
	(multislot creator
		(type STRING)
		(cardinality 1 ?VARIABLE)
		(create-accessor read-write))
	(multislot paradigm
		(type SYMBOL)
		(allowed-values OOP Functional Declarative Markup Procedural)
		(cardinality 1 ?VARIABLE)
		(create-accessor read-write))
	(multislot usedBy
		(type INSTANCE)
		(allowed-classes Programmer)
		(cardinality 1 ?VARIABLE)
		(create-accessor read-write))
	(single-slot yearOfMaking
		(type INTEGER)
		(range 1950 ?VARIABLE)
;+		(cardinality 1 1)
		(create-accessor read-write))
	(single-slot version
		(type FLOAT)
;+		(cardinality 1 1)
		(create-accessor read-write)))

(defclass Programmer
	(is-a USER)
	(role concrete)
   (pattern-match reactive)
	(single-slot firstName
		(type STRING)
;+		(cardinality 1 1)
		(create-accessor read-write))
	(single-slot lastName
		(type STRING)
;+		(cardinality 1 1)
		(create-accessor read-write))
	(multislot uses
		(type INSTANCE)
		(allowed-classes Language)
		(cardinality 1 ?VARIABLE)
		(create-accessor read-write))
	(single-slot position
		(type STRING)
;+		(cardinality 1 1)
		(create-accessor read-write))
	(multislot skills
		(type SYMBOL)
		(allowed-values Frontend Backend)
		(cardinality 1 2)
		(create-accessor read-write)))

(defclass HTML
	(is-a Language)
	(role concrete)
	(pattern-match reactive)
	(single-slot langName
		(type STRING)
;+		(cardinality 1 1)
		(create-accessor read-write))
	(multislot creator
		(type STRING)
		(cardinality 1 ?VARIABLE)
		(create-accessor read-write))
	(multislot paradigm
		(type SYMBOL)
		(allowed-values Markup)
		(cardinality 1 ?VARIABLE)
		(create-accessor read-write))
	(multislot usedBy
		(type INSTANCE)
		(allowed-classes Programmer)
		(cardinality 1 ?VARIABLE)
		(create-accessor read-write))
	(single-slot yearOfMaking
		(type INTEGER)
		(range 1950 ?VARIABLE)
;+		(cardinality 1 1)
		(create-accessor read-write))
	(single-slot version
		(type FLOAT)
;+		(cardinality 1 1)
		(create-accessor read-write)))

(defclass Ruby
	(is-a Language)
	(role concrete)
    (pattern-match reactive)
	(single-slot langName
		(type STRING)
;+		(value "Ruby")
;+		(cardinality 1 1)
		(create-accessor read-write))
	(multislot creator
		(type STRING)
;+		(value "Yukihiro")
		(cardinality 1 ?VARIABLE)
		(create-accessor read-write))
	(multislot paradigm
		(type SYMBOL)
		(allowed-values OOP)
;+		(value OOP)
		(cardinality 1 ?VARIABLE)
		(create-accessor read-write))
	(multislot usedBy
		(type INSTANCE)
		(allowed-classes Programmer)
		(cardinality 1 ?VARIABLE)
		(create-accessor read-write))
	(single-slot yearOfMaking
		(type INTEGER)
		(range 1950 ?VARIABLE)
;+		(cardinality 1 1)
		(create-accessor read-write))
	(single-slot version
		(type FLOAT)
;+		(cardinality 1 1)
		(create-accessor read-write)))

(defclass PHP
	(is-a Language)
	(role concrete)
    (pattern-match reactive)
	(single-slot langName
		(type STRING)
;+		(cardinality 1 1)
		(create-accessor read-write))
	(multislot creator
		(type STRING)
		(cardinality 1 ?VARIABLE)
		(create-accessor read-write))
	(multislot paradigm
		(type SYMBOL)
		(allowed-values Procedural OOP)
		(cardinality 1 ?VARIABLE)
		(create-accessor read-write))
	(multislot usedBy
		(type INSTANCE)
		(allowed-classes Programmer)
		(cardinality 1 ?VARIABLE)
		(create-accessor read-write))
	(single-slot yearOfMaking
		(type INTEGER)
		(range 1950 ?VARIABLE)
;		(value 1995)
;+		(cardinality 1 1)
		(create-accessor read-write))
	(single-slot version
		(type FLOAT)
;+		(cardinality 1 1)
		(create-accessor read-write)))

(defclass Haskell
	(is-a Language)
	(role concrete)
    (pattern-match reactive)
	(single-slot langName
		(type STRING)
;+		(value Haskell)
;+		(cardinality 1 1)
		(create-accessor read-write))
	(multislot creator
		(type STRING)
		(cardinality 1 ?VARIABLE)
		(create-accessor read-write))
	(multislot paradigm
		(type SYMBOL)
		(allowed-values Functional)
		(cardinality 1 ?VARIABLE)
		(create-accessor read-write))
	(multislot usedBy
		(type INSTANCE)
		(allowed-classes Programmer)
		(cardinality 1 ?VARIABLE)
		(create-accessor read-write))
	(single-slot yearOfMaking
		(type INTEGER)
		(range 1950 ?VARIABLE)
;+		(cardinality 1 1)
		(create-accessor read-write))
	(single-slot version
		(type FLOAT)
;+		(cardinality 1 1)
		(create-accessor read-write)))