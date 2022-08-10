Console.WriteLine("\nWelcome to Hangman Multiplayer\n");

string[] words = new string[]{"car" , "table" , "paper" , "ring" , "mickey" , "pig" , "aesthetic" , "player" , "boat" , "fish" , "white" , "television" , "nintendo" , "one" , "play" , "apple" , "zebra" , "house" , "architecture" , "computer"}; 
char[] guesses;
string[] fails;
string secretWord;
bool won1, won2, playerTwoGuess;
int score1 = 0;
int score2 = 0;

Random random = new Random();
int index = random.Next(words.Length);
secretWord = words[index];
guesses = new char[secretWord.Length];
Array.Fill(guesses, '*');
fails = new string[0];
won2 = false;
won1 = false;
playerTwoGuess = false; 

string playerone;
Console.WriteLine("Enter the name of the first player");
playerone = Console.ReadLine() ?? "";

string playertwo;
Console.WriteLine("Enter the name of the second player");
playertwo = Console.ReadLine() ?? "";

Console.WriteLine("\n\nStart Playing\n\n");
gameCycle();

void gameCycle()
{
    
    if (won1)
    {
        score1 += 1;
        Console.WriteLine($"The secret word is {new String(guesses)}");
        Console.WriteLine("\n\n" + playerone + " is the winner! CONGRATULATIONS!\n");
        Console.WriteLine(playerone + " wins:" + score1);
        Console.WriteLine(playertwo + " wins:" + score2 + "\n");
        Environment.Exit(0);
    } else if (won2)
    {
        score2 += 1;
        Console.WriteLine($"The secret word is {new String(guesses)}");
        Console.WriteLine("\n\n" + playertwo + " is the winner! CONGRATULATIONS!\n\n");
        Console.WriteLine(playerone + " wins:" + score1);
        Console.WriteLine(playertwo + " wins:" + score2 + "\n");
        Environment.Exit(0);
    }
    else
    {
        turns();
    }
}

turns();
void turns(){
    if (playerTwoGuess){
        playerTwoTurn();
        gameCycle();
    } else {
        playerOneTurn();
        gameCycle();
    }
}

playerOneTurn();
void playerOneTurn(){
    printHangman();
    playerOneAttempt();
}

playerTwoTurn();
void playerTwoTurn(){
    printHangman();
    playerTwoAttempt();
}


void playerOneAttempt()
{
    Console.WriteLine(playerone + ", enter a letter or guess the word: ");
    string attempt = Console.ReadLine() ?? "";
   if (attempt.Length == 0)
    {
         Console.WriteLine("Try again");
    }
    else if (attempt.Length == 1)
    {
       lookForLetter1(attempt[0]);
    }
      else
    {
       tryToGuess1(attempt);
    }
}

void playerTwoAttempt()
{
    Console.WriteLine(playertwo + ", enter a letter or guess the word: ");
    string attempt = Console.ReadLine() ?? "";
    if (attempt.Length == 0)
    {
         Console.WriteLine("Try again");
    }
    else if (attempt.Length == 1)
    {
       lookForLetter2(attempt[0]);
    }
      else 
    {
       tryToGuess2(attempt);
    }
}

void lookForLetter1(char letter)
{
    Console.WriteLine("Searching letter...\n\n");
    if (secretWord.IndexOf(letter) > -1)
    {
        Console.WriteLine($"The letter {letter} is correct");
        for (int i = 0; i < secretWord.Length; i++)
        {
            if (secretWord[i] == letter)
            {
                guesses[i] = letter; 
            }
        }
        won1 = (Array.IndexOf(guesses, '*') == -1); 
    }
    else
    {
        Console.WriteLine($"The letter {letter} is not in the word");
        Array.Resize(ref fails, fails.Length +1);
        fails.SetValue(letter.ToString(), fails.Length -1);
        playerTwoTurn(); 
    }  
    
}

void lookForLetter2(char letter)
{
    Console.WriteLine("Searching letter...\n\n");
    if (secretWord.IndexOf(letter) > -1)
    {
        Console.WriteLine($"The letter {letter} is correct");
        for (int i = 0; i < secretWord.Length; i++)
        {
            if (secretWord[i] == letter)
            {
                guesses[i] = letter; 
            }
        }
        won2 = (Array.IndexOf(guesses, '*') == -1);
        playerTwoGuess = true;
    }
    else
    {
        Console.WriteLine($"The letter {letter} is not in the word");
        Array.Resize(ref fails, fails.Length +1);
        fails.SetValue(letter.ToString(), fails.Length -1);
        playerOneTurn(); 
    }  
    
}

void tryToGuess1(string word)
{
    if (secretWord == word)
    {
        Console.WriteLine($"The word {word} is correct!");
        guesses = secretWord.ToCharArray();
        won1 = true;
    }
    else
    {
        Console.WriteLine($"The word {word} is not correct!");
        Array.Resize(ref fails, fails.Length +1);
        fails.SetValue(word, fails.Length -1);
        playerTwoTurn();
    }
}

void tryToGuess2(string word)
{
    if (secretWord == word)
    {
        Console.WriteLine($"The word {word} is correct!");
        guesses = secretWord.ToCharArray();
        won2 = true;
    }
    else
    {
        Console.WriteLine($"The word {word} is not correct!");
        Array.Resize(ref fails, fails.Length +1);
        fails.SetValue(word, fails.Length -1);
        playerOneTurn();
    }
}

void printHangman()
{
    Console.WriteLine($"The secret word is {new String(guesses)}");
    Console.WriteLine("Failed attempts: ");
    for (int i = 0; i < fails.Length; i++)
    {
        Console.Write(fails[i] + ' ');
    }

    int f = fails.Length;
    Console.WriteLine();
    Console.WriteLine("|---");
    Console.WriteLine($"|   {(f > 0 ? 'o' : ' ')}");
    Console.WriteLine($"| {(f > 2 ? '/' : ' ')} {(f > 1 ? '|' : ' ')} {(f > 3 ? '\\' : ' ')}");
    Console.WriteLine($"| {(f > 4 ? '/' : ' ')}   {(f > 5 ? '\\' : ' ')}");
    Console.WriteLine("|");
    Console.WriteLine("/--------\\");
}

