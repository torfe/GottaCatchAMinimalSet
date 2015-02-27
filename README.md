 There are quite a lot of [Pokémon](http://pokeapi.co/api/v1/pokedex/) now. Let the set of all Pokémon be the Pokédex.   
 We can take the power set of the Pokédex, giving us a set of all subsets of Pokémon, and then define a sort of order on the subsets:
 
 S1 < S2 <=> The number of Pokémon in S1 is less than the number in S2, or, if they are equal, then the total number of characters in the names of S1 is less than those in S2
 
 So:
 * {xatu}  < {smeargle}
 * {smeargle} < {xatu, ratatta}
 * {ratatta} == {geodude}
 * {charmeleon} < {muk, grimer}
 
 So, the challenge is – can you find a minimal set S of all subsets of the Pokédex, such that all the letters of the alphabet appear in S?