someRandomFunction :: Int -> Int 
someRandomFunction x = x+5

sumAll :: [Int] -> Int

sumAll x = sumAll_i x 0
sumAll_i [] n = n
sumAll_i (x:y) n = sumAll_i y (x+n)

revThree :: [Int] -> [Int]
revThree x = [ i | i <- x , i `mod` 3 == 0]

isMono :: [Int] -> Bool
isMono [] = True
isMono (_:[]) = True
isMono (h1:(h2:t))
 | h1 <= h2 = isMono (h2:t)
 | otherwise = False
 
type Polynom = [(Float,Int)]
sumPoly :: Polynom -> Polynom -> Polynom
sumPoly [] [] = []
sumPoly x [] = x
sumPoly [] y = y
sumPoly ((k1:s1):t1) ((k2:s2):t2)       
 | s1 > s2 = (k1,s1) : sumPoly t1 ((k2:s2):t2)
 | s1 == s2 = if k1 /= -k2 then (k1+k2,s1):sumPoly t1 t2 else sumPoly t1 t2       
 | otherwise = (k2,s2) : sumPoly ((k1:s1):t1) t2
 
 