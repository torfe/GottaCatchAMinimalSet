 There are quite a lot of [Pok�mon](http://pokeapi.co/api/v1/pokedex/) now. Let the set of all Pok�mon be the Pok�dex.   
 We can take the power set of the Pok�dex, giving us a set of all subsets of Pok�mon, and then define a sort of order on the subsets:
 
 S1 < S2 <=> The number of Pok�mon in S1 is less than the number in S2, or, if they are equal, then the total number of characters in the names of S1 is less than those in S2
 
 So:
 * {xatu}  < {smeargle}
 * {smeargle} < {xatu, ratatta}
 * {ratatta} == {geodude}
 * {charmeleon} < {muk, grimer}
 
 So, the challenge is � can you find a minimal set S of all subsets of the Pok�dex, such that all the letters of the alphabet appear in S?