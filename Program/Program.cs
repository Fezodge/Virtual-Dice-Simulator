/* 
Virtual Dice Simulator
By Joseph Pullan (Fezodge III)
Version 1.0.1

Lisensing:
You are free to use this code wherever you wish, as long as 
You don't claim this as your own, make sure you include a reference to me, 
And a link to this code on GitHub. You are not allowed to sell or make money from any parts of this code
and distributing without my permision is prohibited. if you would like to send it to someone, 
please point them to this GitHub file.

You are, however, free to manipulate, change, or edit this code in any way,
As long as the same rules aplly as above.
*/

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//adds the System.Threading namespace so we can use the Thread.Sleep function
using System.Threading;

namespace Virtual_Dice
{
    class Program
    {

        #region CustomFunctions
        //Creates a Randomised Generator that we can use everywhere in the class 'Program'
        public static Random randomGenerator = new Random();

        //creates a function Sleep so we can use this block of code lots of times, without having to type it all out
        public static void Rolling()
        {
            //tells the user that the die is rolling
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Rolling...");
            Console.ForegroundColor = ConsoleColor.White;

            //using our Randomised Generator we created earlier, it will generate a random number between 0 and 9, adding 1 to the result
            int sleepTime = randomGenerator.Next(3) + 1;

            //tells the application to sleep (pause) for the random number amount times 1000, as Thread.Sleep counts in milliseconds
            Thread.Sleep(sleepTime * 1000);
        }


        #endregion

        public static void Main(string[] args)
        {
            //Creates the boolean variable for seeing if the user wants to change die, and initially sdets it to false
            bool chooseDie = false;
            Console.ForegroundColor = ConsoleColor.White;

            #region Welcome
            //creates a variable oldColor and makes it store the current console color, so we can revert back to it later
            ConsoleColor oldColor = Console.ForegroundColor;

            //Tells the user about the application
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Hello and welcome to the Virtual Dice Simulator application, made by Fezodge III");
            Console.ForegroundColor = oldColor;
            Console.WriteLine("In this application you will be able to roll virtual dice, just in case a real  one isn't at hand!");
            Console.Write("The dice to choose from are:  ");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("4 sided, 6 sided, 8 sided, 10 sided, 12 sided and 20 sided");
            Console.ForegroundColor = oldColor;
            Console.Write("Type ");
            //changes the color of 'choose die' to magenta
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("'choose die' ");
            //reverts color 
            Console.ForegroundColor = oldColor;
            Console.WriteLine("to begin!");

            //changes the color to dark red
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("(Please Note: Type ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("'exit' ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("at any time to exit the application!)");
            //reverts the color back to the origional one
            Console.ForegroundColor = oldColor;
            #endregion
        ChooseDie:
            //Creates a variable to check if the user wants to initially choose their die
            string start = Console.ReadLine();

            //So if the user does want to change the die (by typing 'choose die')
            if (start == "choose die")
            {
                //then it will set the 'chooseDie' variable to true, so then the code inside of the chooseDie while loop will run,
                //until this is set back to false
                chooseDie = true;
            }

            //checks to see if the user typed 'exit'
            else if (start == "exit")
            {
                //if they did then it will tell them that they can't do that
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Bye!");
                Thread.Sleep(3000);
            }

            else
            {
                goto ChooseDie;
            }


            #region Main Loops
            #region ChooseDie

            //Here we make a while loop, to make the application run infinately, until chooseDie variable equals false
            while (chooseDie == true)
            {
            Start:
            ChangeDie:

                //Tells the user to to choose a die, giving all the available options
                Console.Write("Choose your die: ");

                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write("4, 6, 8, 10, 12 or 20: ");
                Console.ForegroundColor = oldColor;

                //Then stores the answer in the dieTyped variable, to use later
                string dieTyped = Console.ReadLine();
            #endregion

                #region Typed4?

                //checks to see if the user typed '4'
                if (dieTyped == "4")
                {
                    //if they did, then it will confirm to them that there request has been processed, and tells them how to roll 
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("{0} ", dieTyped);
                    Console.ForegroundColor = oldColor;
                    Console.Write("it is! Type ");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("'roll' ");
                    Console.ForegroundColor = oldColor;
                    Console.WriteLine("to roll the virtual die!");

                RollFour:
                    //stores what they typed inside fourRoll
                    string fourRoll = Console.ReadLine();

                FourRoll:

                    //if they typed 'roll'
                    if (fourRoll == "roll")
                    {
                        //then it will generate a random integer (the die roll) between 0 - 3, adding 1 to the result
                        int fourDieRoll = (int)(randomGenerator.Next(4) + 1);

                        //calls the function Rolling, which we defined above
                        Rolling();

                        //then telling the user what the result is
                        Console.Write("The die result is ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("{0}", fourDieRoll);
                        Console.ForegroundColor = oldColor;
                    }

                    else if (fourRoll == "exit")
                    {
                        goto End;
                    }

                    //but if they type anything else
                    else
                    {
                        //then go back to the RollFour label and wait for 'roll' to be typed
                        goto RollFour;
                    }

                    //it then asks whether or not they want to roll again, or change die, and tells them how to do so
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("'Roll' ");
                    Console.ForegroundColor = oldColor;
                    Console.Write("again, or ");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("'change die'");
                    Console.ForegroundColor = oldColor;
                    Console.WriteLine("?");

                FourRollA:
                    //stores the user answer
                    string rollAgain = Console.ReadLine();

                    //if they typed 'roll'
                    if (rollAgain == "roll")
                    {
                        //then the code will go to the FourRoll label we made earlier (FourRoll:)
                        goto FourRoll;
                    }

                    //but if they type 'change die'
                    else if (rollAgain == "change die")
                    {
                        //then the code will go to the ChangeDie label
                        goto ChangeDie;
                    }

                    else if (rollAgain == "exit")
                    {
                        goto End;
                    }

                    //but if they type anything else
                    else
                    {
                        //it will do the same as before; jump back up to where the system awaits an answer (either 'roll' or 'change die')
                        //and waits for it. It will do nothing if neither of the two valid statements are typed
                        goto FourRollA;
                    }
                }

                #endregion
                #region Typed6?
                else if (dieTyped == "6")
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("{0} ", dieTyped);
                    Console.ForegroundColor = oldColor;
                    Console.Write("it is! Type ");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("'roll' ");
                    Console.ForegroundColor = oldColor;
                    Console.WriteLine("to roll the virtual die!");
                RollSix:
                    string sixRoll = Console.ReadLine();

                SixRoll:
                    if (sixRoll == "roll")
                    {
                        int sixDieRoll = (int)(randomGenerator.Next(6) + 1);
                        Rolling();
                        Console.Write("The die result is ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("{0}", sixDieRoll);
                        Console.ForegroundColor = oldColor;
                    }

                    else if (sixRoll == "exit")
                    {
                        goto End;
                    }

                    else
                    {

                        goto RollSix;
                    }

                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("'Roll' ");
                    Console.ForegroundColor = oldColor;
                    Console.Write("again, or ");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("'change die'");
                    Console.ForegroundColor = oldColor;
                    Console.WriteLine("?");
                SixRollA:
                    string rollAgain = Console.ReadLine();

                    if (rollAgain == "roll")
                    {
                        goto SixRoll;
                    }

                    else if (rollAgain == "change die")
                    {
                        goto ChangeDie;
                    }

                    else if (rollAgain == "exit")
                    {
                        goto End;
                    }

                    else
                    {
                        goto SixRollA;
                    }
                }
                #endregion
                #region Typed8?
                else if (dieTyped == "8")
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("{0} ", dieTyped);
                    Console.ForegroundColor = oldColor;
                    Console.Write("it is! Type ");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("'roll' ");
                    Console.ForegroundColor = oldColor;
                    Console.WriteLine("to roll the virtual die!");
                RollEight:
                    string eightRoll = Console.ReadLine();

                EightRoll:
                    if (eightRoll == "roll")
                    {
                        int eightDieRoll = (int)(randomGenerator.Next(8) + 1);
                        Rolling();
                        Console.Write("The die result is ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("{0}", eightDieRoll);
                        Console.ForegroundColor = oldColor;
                    }

                    else if (eightRoll == "exit")
                    {
                        goto End;
                    }

                    else
                    {

                        goto RollEight;
                    }

                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("'Roll' ");
                    Console.ForegroundColor = oldColor;
                    Console.Write("again, or ");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("'change die'");
                    Console.ForegroundColor = oldColor;
                    Console.WriteLine("?");
                EightRollA:
                    string rollAgain = Console.ReadLine();

                    if (rollAgain == "roll")
                    {
                        goto EightRoll;
                    }

                    else if (rollAgain == "change die")
                    {
                        goto ChangeDie;
                    }

                    else if (rollAgain == "exit")
                    {
                        goto End;
                    }

                    else
                    {
                        goto EightRollA;
                    }
                }
                #endregion
                #region Typed10?
                else if (dieTyped == "10")
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("{0} ", dieTyped);
                    Console.ForegroundColor = oldColor;
                    Console.Write("it is! Type ");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("'roll' ");
                    Console.ForegroundColor = oldColor;
                    Console.WriteLine("to roll the virtual die!");
                RollTen:
                    string tenRoll = Console.ReadLine();

                TenRoll:
                    if (tenRoll == "roll")
                    {
                        int tenDieRoll = (int)(randomGenerator.Next(10) + 1);
                        Rolling();
                        Console.Write("The die result is ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("{0}", tenDieRoll);
                        Console.ForegroundColor = oldColor;
                    }

                    else if (tenRoll == "exit")
                    {
                        goto End;
                    }

                    else
                    {
                        goto RollTen;
                    }

                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("'Roll' ");
                    Console.ForegroundColor = oldColor;
                    Console.Write("again, or ");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("'change die'");
                    Console.ForegroundColor = oldColor;
                    Console.WriteLine("?");
                TenRollA:
                    string rollAgain = Console.ReadLine();

                    if (rollAgain == "roll")
                    {
                        goto TenRoll;
                    }

                    else if (rollAgain == "change die")
                    {
                        goto ChangeDie;
                    }

                    else if (rollAgain == "exit")
                    {
                        goto End;
                    }

                    else
                    {
                        goto TenRollA;
                    }
                }
                #endregion
                #region Typed12?
                else if (dieTyped == "12")
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("{0} ", dieTyped);
                    Console.ForegroundColor = oldColor;
                    Console.Write("it is! Type ");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("'roll' ");
                    Console.ForegroundColor = oldColor;
                    Console.WriteLine("to roll the virtual die!");
                RollTwelve:
                    string twelveRoll = Console.ReadLine();

                TwelveRoll:
                    if (twelveRoll == "roll")
                    {
                        int twelveDieRoll = (int)(randomGenerator.Next(12) + 1);
                        Rolling();
                        Console.Write("The die result is ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("{0}", twelveDieRoll);
                        Console.ForegroundColor = oldColor;
                    }

                    else if (twelveRoll == "exit")
                    {
                        goto End;
                    }

                    else
                    {
                        goto RollTwelve;
                    }

                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("'Roll' ");
                    Console.ForegroundColor = oldColor;
                    Console.Write("again, or ");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("'change die'");
                    Console.ForegroundColor = oldColor;
                    Console.WriteLine("?");
                TwelveRollA:
                    string rollAgain = Console.ReadLine();

                    if (rollAgain == "roll")
                    {
                        goto TwelveRoll;
                    }

                    else if (rollAgain == "change die")
                    {
                        goto ChangeDie;
                    }

                    else if (rollAgain == "exit")
                    {
                        goto End;
                    }

                    else
                    {
                        goto TwelveRollA;
                    }
                }
                #endregion
                #region Typed20?
                else if (dieTyped == "20")
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("{0} ", dieTyped);
                    Console.ForegroundColor = oldColor;
                    Console.Write("it is! Type ");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("'roll' ");
                    Console.ForegroundColor = oldColor;
                    Console.WriteLine("to roll the virtual die!");
                RollTwenty:
                    string twentyRoll = Console.ReadLine();

                TwentyRoll:
                    if (twentyRoll == "roll")
                    {
                        int twentyDieRoll = (int)(randomGenerator.Next(20) + 1);
                        Rolling();
                        Console.Write("The die result is ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("{0}", twentyDieRoll);
                        Console.ForegroundColor = oldColor;
                    }

                    else if (twentyRoll == "exit")
                    {
                        goto End;
                    }

                    else
                    {
                        goto RollTwenty;
                    }

                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("'Roll' ");
                    Console.ForegroundColor = oldColor;
                    Console.Write("again, or ");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("'change die'");
                    Console.ForegroundColor = oldColor;
                    Console.WriteLine("?");
                TwentyRollA:
                    string rollAgain = Console.ReadLine();

                    if (rollAgain == "roll")
                    {
                        goto TwentyRoll;
                    }

                    else if (rollAgain == "change die")
                    {
                        goto ChangeDie;
                    }

                    else if (rollAgain == "exit")
                    {
                        goto End;
                    }

                    else
                    {
                        goto TwentyRollA;
                    }
                }

                else if (dieTyped == "exit")
                {
                    goto End;
                }
                #endregion
                #region TypedInvalidExpression
                //but if all else fails and the user dosn't type a valid die, it will tell them there errors and tell them which dice are available 
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("{0} ", dieTyped);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("is not an available die. Please choose an available die to continue.");
                    Console.ForegroundColor = oldColor;
                    goto Start;
                }
                #endregion
            #endregion
            End:
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Bye!");
                Thread.Sleep(3000);
                break;

            }

        }
    }
}

