# Derico C# exercise

I have created a solution with two console projects, one for each question.

## Question 1
    * I have created a static class for transcode methods.
    * Use of better names for methods and variables
    * Main was always was calling the line to indicate that the test has failed.
    * Code formatting.
    * Init
        - Change the order of if conditions. 
        - Set the correct value for the serie.
    * Encode
        - Create output arrya using Enumerable.Repeat method.
        - No need to create invert variable.
        - Create primate method to calculate output length.
    * Decode        
        - Create primate method to calculate output length.



## Question 2
    * In order to support ties I have created an enum instead of returing true or false.
    * I can use the text value of this enum to write the result of the game.
    * To have the possibility to resolve a tie checking the preivous suit, I have created a private attribute to store the result of the previous suit.
    * I'm allowing multiple decks asking by consolue the number of decks that the user want to play.
    * I have added a property to indicate if tie is allowed or not. In case the it is not allowed then I call again Play method recursively.
    * I have added a property to HighCard to indicate the possibility of having a wild card.
    * I have included another property to set the number of cards to use. It has a default value of 52.
    I have created a private method to include all the logic of a tie.