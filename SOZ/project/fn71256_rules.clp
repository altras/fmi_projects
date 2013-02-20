;;****************
;;* DEFFUNCTIONS *
;;****************

; definition of global variable
(defglobal ?*logging* = 1)

(deffunction logmsg (?msg $?args)
	(if (= ?*logging* 1) 
		then
		(printout t ?msg ?args crlf)))
			

(deffunction symbolToString (?symb)
	(implode$ (create$ ?symb))
)

(deffunction ask-question (?question)
	(printout t ?question)
	(read)
)

; asks a multiple-choice question
(deffunction ask-multiple-choice-question (?question $?allowed-values)
   (bind ?answer (ask-question ?question))
;   (logmsg "Given answer is: " ?answer " Allowed values are: " ?allowed-values)
   (while (not (member ?answer ?allowed-values)) do
      (bind ?answer (ask-question ?question))
      (logmsg "Bad answer: " ?answer  " Allowed values are: " ?allowed-values)
	  )
   ?answer
)

; function string search
(deffunction ask-open-question (?question)
	(bind ?answer (ask-question ?question))
	(while (not (lexemep ?answer)) do
		(bind ?answer (ask-question ?question)))
	?answer
)

; function float search
(deffunction ask-float-question (?question)
	(bind ?answer (ask-question ?question))
	(while (not (floatp ?answer)) do
 		(bind ?answer (ask-question ?question)))
 	?answer
)

;;**********************
;;  DEFTEMPLATE
;;**********************

; deftemplate - current search status
(deftemplate status 
	(slot searched-paradigm)
	(slot searched-version)
	(slot searched-langName)
	(slot searched-hasGender)
	(slot searched-has-one-item)
	(slot searching-state)
	(slot end-get-all-instances)
 	(multislot found-instances)
)

;;**********************
;;  DEFRULES 
;;**********************

(defrule begin-init (declare (salience 150))
	=>
	(assert (status (end-get-all-instances no)))
)

(defrule getAllInstances (declare (salience 100))
	?status-fact <- (status (found-instances $?x) (end-get-all-instances no))
	?instance <- (object (is-a Language))
	(test (not (member ?instance (create$ $?x))))
	=>
	(modify ?status-fact (found-instances ?instance $?x))
)

(defrule end-init (declare (salience 50))
	?status-fact <- (status (end-get-all-instances no))
	=>
	(modify ?status-fact 	(end-get-all-instances yes) 
				(searched-paradigm unknown) 
				(searched-langName unknown) 
				(searched-version unknown) 
				(searched-has-one-item unknown) 
				(searching-state insearch)
	)
)

; asks a question about the paradigm of the Language
(defrule specify-paradigm (declare (salience 20))
	?status-fact <- (status (found-instances $?allfound) (searching-state insearch)(searched-paradigm unknown))
	=>
	(if (<> (length$ $?allfound) 1)
		then
		(bind ?search (ask-multiple-choice-question "Specify the paradigm of the language (OOP / Functional / Declarative / Procedural / Markup): " OOP Functional Declarative Procedural Markup  ))
		(modify ?status-fact (searched-paradigm ?search))
		else
		(modify ?status-fact (searched-has-one-item known))
	)
)

; searching for languages with the specified paradigm
(defrule search-paradigm (declare (salience 19))
	?status-fact <- (status (found-instances $?allfound) (searched-paradigm ?search&~unknown))
	?found <- (object (is-a Language) (paradigm ?sp&~?search))
	=>
	(bind ?memberposition (member ?found (create$ $?allfound)))
	(if ?memberposition
		then
		(modify ?status-fact (found-instances (delete$ (create$ $?allfound) ?memberposition ?memberposition)))
	)
)

; asks question about the version
(defrule specify-version (declare (salience 18))
	?status-fact <- (status (found-instances $?allfound) (searching-state insearch) (searched-version unknown))
	=>
	(if (<> (length$ $?allfound) 1)
		then
		(bind ?search (ask-float-question "Specify the version (float): "))
		(modify ?status-fact (searched-version ?search))
		else
		(modify ?status-fact (searched-has-one-item known))
	)
)

; searching for version
(defrule search-version (declare (salience 17))
	?status-fact <- (status (found-instances $?allfound) (searched-version ?search&~unknown))
	?found <- (object (is-a Language) (version ?v&~?search))
	=>
	(bind ?memberposition (member ?found (create$ $?allfound)))
	(if ?memberposition
		then
		(modify ?status-fact (found-instances (delete$ (create$ $?allfound) ?memberposition ?memberposition)))
	)
)

;ask questions about the name language
(defrule specify-langName (declare (salience 16))
	?status-fact <- (status (searching-state insearch) (searched-langName unknown))
	=>
	(bind ?search (symbolToString (ask-open-question "Name of language : ")))
	(modify ?status-fact (searched-langName ?search))
)

; searching for langName
(defrule search-langName (declare (salience 15))
	?status-fact <- (status (found-instances $?allfound) (searched-langName ?search&~unknown))
	?found <- (object (is-a Language) (langName ?lName&~?search))
	=>
	(bind ?memberposition (member ?found (create$ $?allfound)))
	(if ?memberposition
		then
		(modify ?status-fact (found-instances (delete$ (create$ $?allfound) ?memberposition ?memberposition)))
	)
)

; terminates the search when there is only one instance
(defrule end-search-one-found (declare (salience 30))
	?status-fact <- (status (found-instances $?x&:(= (length$ $?x) 1)) (searching-state insearch) (searched-has-one-item known))
	=>
	(modify ?status-fact (searching-state endsearch))
	(send (instance-name (nth$ 1 $?x)) print)
)

; terminates the search when there is no instance
(defrule end-search-fail (declare (salience 25))
	?status-fact <- (status (found-instances) (searching-state insearch))
	=>
	(modify ?status-fact (searching-state endsearch))
	(printout t "No match found! " crlf)
)

; displays the found instances
(defrule end-search-found (declare (salience 5))
	?status-fact <- (status (found-instances $?x) (searching-state insearch))
	=>
	(modify ?status-fact (searching-state endsearch))
	(printout t "Found results: " crlf)
	(bind ?allfound $?x)
	(while (> (length$ ?allfound) 0)
		do
		(send (instance-name (nth$ 1 ?allfound)) print)
		(bind ?allfound (rest$ ?allfound))
	)
)
