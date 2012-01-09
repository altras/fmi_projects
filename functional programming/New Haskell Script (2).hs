type Polinom = [(Float, Int)]
polinomSum :: Polinom -> Polinom -> Polinom
polinomSum [] [] = []
polinomSum l1 [] = l1
polinomSum [] l2 = l2
polinomSum ((koef1, stepen1):ls1) ((koef2, stepen2):ls2)
 | stepen1 == stepen2 = if koef1 /= -koef2 then (koef1 + koef2, stepen1) : polinomSum ls1 ls2 else polinomSum ls1 ls2
 | stepen1 > stepen2 = (koef1, stepen1) : polinomSum ls1 ((koef2, stepen2):ls2)
 | otherwise = (koef2, stepen2) : polinomSum ((koef1, stepen1):ls1) ls2
 

revThree [] = []
revThree (h:t) 
 | h `mod` 3 /= 0 =  h:revThree t
 | otherwise = revThree t  

 
myFilterFunc [] = []
myFilterFunc (x:xs)
 | x `mod` 3 /= 0 = x : myFilterFunc xs
 | otherwise = myFilterFunc xs