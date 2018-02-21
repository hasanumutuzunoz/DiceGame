using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming1_Dice_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int userMoney = 200;
            string userName = GreetPlayer();

           //Game loop (while userMoney is between 0 and 100000, run the game)
            do 
            {
                //Bet types
                Console.WriteLine("You have ${0}", userMoney);
                Console.WriteLine("\nHere is your bet types");
                Console.WriteLine("=============================================");
                Console.WriteLine("Bet Types: \n 1.  Big         (1 to 1)       2.  Small     (1 to 1)       3.  Odd       (1 to 1)       4.  Even      (1 to 1)");
                Console.WriteLine(" 5.  All 1s      (180 to 1)     6.  All 2s    (180 to 1)     7.  All 3s    (180 to 1)     8.  All 4s    (180 to 1)");
                Console.WriteLine(" 9.  All 5s      (180 to 1)     10. All 6s    (180 to 1)     11. Double 1s (10 to 1)      12. Double 2s (10 to 1)");
                Console.WriteLine(" 13. Double 3s   (10 to 1)      14. Double 4s (10 to 1)      15. Double 5s (10 to 1)      16. Double 6s (10 to 1)");
                Console.WriteLine(" 17. Any triples (30 to 1)      18. 4 or 17   (60 to 1)      19. 5 or 16   (30 to 1)      20. 6 or 15   (18 to 1)");
                Console.WriteLine(" 21. 7 or 14     (12 to 1)      22. 8 or 13   (8 to 1)       23. 9 or 12   (7 to 1)       24. 10 or 11  (6 to 1)");
                Console.WriteLine("=============================================");

                int intUserBetType = GetPlayerBetType();
                int intUserBet = GetPlayerBetAmound(userMoney);
                
                //Roll 3 random dice
                Random rnd = new Random();
                int dice1 = rnd.Next(1, 7);
                int dice2 = rnd.Next(1, 7);
                int dice3 = rnd.Next(1, 7);
                int sum = dice1 + dice2 + dice3;

                Console.WriteLine("===============");
                Console.WriteLine("Rolling Dice...");
                Console.WriteLine("\nDice 1: " + dice1);
                Console.WriteLine("Dice 2: " + dice2);
                Console.WriteLine("Dice 3: " + dice3);
                Console.WriteLine("\nSum: " + sum);
                Console.WriteLine("===============");

                string message = "";

                //User bet type possibilities
                switch (intUserBetType)
                {

                    //If sum of dice is between 11 and 17 (Big)
                    case 1:
                        if (sum < 17 & sum > 11)
                        {
                            /*Exception of a triple dice control. If all dice are equal to each other, player will lost money; 
                            however, if two or none of them be equal, player will win.*/
                            if (dice1 != dice2 || dice1 != dice3 || dice2 != dice3)
                            {
                                userMoney += intUserBet;
                                message = "Bravo ! You selected Big and your dice sum is between 11 and 17. \nYou earn : " + intUserBet + "$ \nYour total money is : now " + userMoney + "$";
                            }
                                
                            else
                            {
                                userMoney -= intUserBet;
                                message = "You lost your money because this is triple dice. \nYou lost : " + intUserBet + "$ \nYour total money is : now " + userMoney + "$";
                            }
                                
                        }
                        //If sum of dice is not between 11 and 17
                        else
                        {
                            userMoney -= intUserBet;
                            message = "Sorry mate your dice sum is not between 11 and 17. You lost your money. Try next time. \nYou lost : " + intUserBet + "$ \nYour total money is now : " + userMoney + "$";
                        }

                        break;

                    //If sum of dice is between 4 and 10 (Small)
                    case 2:
                        if (sum < 10 & sum > 4)
                        {
                            /*Exception of a triple dice control. If all dice are equal to each other, player will lost money; 
                            however, if two or none of them be equal, player will win.*/
                            if (dice1 != dice2 || dice1 != dice3 || dice2 != dice3)
                            {
                                userMoney += intUserBet;
                                message = "Bravo ! You selected Small and your dice sum is between 4 and 10. \nYou earn : " + intUserBet + "$ \nYour total money is now : " + userMoney + "$";
                            }

                            else
                            {
                                userMoney -= intUserBet;
                                message = "You lost your money because this is triple dice. \nYou lost : " + intUserBet + "$ \nYour total money is now : " + userMoney + "$";
                            }
                        }
                        //If sum of dice is not between 4 and 10
                        else
                        {
                            userMoney -= intUserBet;
                            message = "Sorry mate your dice sum is not between 4 and 10. You lost your money. Try next time. \nYou lost : " + intUserBet + "$ \nYour total money is now : " + userMoney + "$";
                        }

                        break;

                    //If the sum of the dice is an odd number (Odd)
                    case 3:
                        if (sum % 2 == 0)
                        {
                            /*Exception of a triple dice control. If all dice are equal to each other, player will lost money; 
                            however, if two or none of them be equal, player will win.*/
                            if (dice1 != dice2 || dice1 != dice3 || dice2 != dice3)
                            {
                                userMoney += intUserBet;
                                message = "Bravo ! You won money. You selected Odd and your dice sum is an odd number. \nYou earn : " + intUserBet + "$ \nYour total money is now : " + userMoney + "$";
                            }
                                
                            else
                            {
                                userMoney -= intUserBet;
                                message = "You lost your money because this is triple dice. \nYou lost : " + intUserBet + "$ \nYour total money is now : " + userMoney + "$";
                            }
                                
                        }
                        //If the sum of the dice is not an odd number
                        else
                        {
                            userMoney -= intUserBet;
                            message = "Sorry mate you lost your money. Your dice sum is not an odd number. It is even!!! \nYou lost : " + intUserBet + "$ \nYour total money is now : " + userMoney + "$";
                        }
                        break;

                    //If the sum of the dice is an even number (Even)
                    case 4:
                        if (sum % 2 != 0)
                        {
                            /*Exception of a triple dice control. If all dice are equal to each other, player will lost money; 
                            however, if two or none of them be equal, player will win.*/
                            if (dice1 != dice2 || dice1 != dice3 || dice2 != dice3)
                            {
                                userMoney += intUserBet;
                                message = "Bravo ! You won money. You selected Even and your dice sum is an even number. \nYou earn : " + intUserBet + "$ \nYour total money is now : " + userMoney + "$";
                            }

                            else
                            {
                                userMoney -= intUserBet;
                                message = "You lost your money because this is triple dice. \nYou lost : " + intUserBet + "$ \nYour total money is now : " + userMoney + "$";
                            }
                        }
                        //If the sum of the dice is not an even number
                        else
                        {
                            userMoney -= intUserBet;
                            message = "Sorry mate you lost your money. Your dice sum is not an even number. It is odd!!! \nYou lost : " + intUserBet + "$ \nYour total money is now : " + userMoney + "$";
                        }
                        break;

                    //Specific triples are rolled (All 1s). All dice are 1.
                    case 5:
                        if (dice1 == 1 & dice2 == 1 & dice3 == 1)
                        {
                            userMoney += intUserBet * 180;
                            message = "WHATTT ALL 1s REALLY? !!!!! \nYou earn : " + intUserBet * 180 + "$ \nYour total money is now : " + userMoney + "$";
                        }
                        else
                        {
                            userMoney -= intUserBet;
                            message = "Sorry mate you lost your money. Your dice is not all 1s. \nYou lost : " + intUserBet + "$ \nYour total money is now : " + userMoney + "$";
                        }
                        break;

                    //Specific triples are rolled (All 2s). All dice are 2.
                    case 6:
                        if (dice1 == 2 & dice2 == 2 & dice3 == 2)
                        {
                            userMoney += intUserBet * 180;
                            message = "WHATTT ALL 1s REALLY? !!!!! \nYou earn : " + intUserBet * 180 + "$ \nYour total money is now : " + userMoney + "$";
                        }
                        else
                        {
                            userMoney -= intUserBet;
                            message = "Sorry mate you lost your money. Your dice is not all 2s. \nYou lost : " + intUserBet + "$ \nYour total money is now : " + userMoney + "$";
                        }
                        break;

                    //Specific triples are rolled (All 3s). All dice are 3.
                    case 7:
                        if (dice1 == 3 & dice2 == 3 & dice3 == 3)
                        {
                            userMoney += intUserBet * 180;
                            message = "WHATTT ALL 1s REALLY? !!!!! \nYou earn : " + intUserBet * 180 + "$ \nYour total money is now : " + userMoney + "$";
                        }
                        else
                        {
                            userMoney -= intUserBet;
                            message = "Sorry mate you lost your money. Your dice is not all 3s. \nYou lost : " + intUserBet + "$ \nYour total money is now : " + userMoney + "$";
                        }
                        break;

                    //Specific triples are rolled (All 4s). All dice are 4.
                    case 8:
                        if (dice1 == 4 & dice2 == 4 & dice3 == 4)
                        {
                            userMoney += intUserBet * 180;
                            message = "WHATTT ALL 1s REALLY? !!!!! \nYou earn : " + intUserBet * 180 + "$ \nYour total money is now : " + userMoney + "$";
                        }
                        else
                        {
                            userMoney -= intUserBet;
                            message = "Sorry mate you lost your money. Your dice is not all 4s. \nYou lost : " + intUserBet + "$ \nYour total money is now : " + userMoney + "$";
                        }
                        break;

                    //Specific triples are rolled (All 5s). All dice are 5.
                    case 9:
                        if (dice1 == 5 & dice2 == 5 & dice3 == 5)
                        {
                            userMoney += intUserBet * 180;
                            message = "WHATTT ALL 1s REALLY? !!!!! \nYou earn : " + intUserBet * 180 + "$ \nYour total money is now : " + userMoney + "$";
                        }
                        else
                        {
                            userMoney -= intUserBet;
                            message = "Sorry mate you lost your money. Your dice is not all 5s. \nYou lost : " + intUserBet + "$ \nYour total money is now : " + userMoney + "$";
                        }
                        break;

                    //Specific triples are rolled (All 6s). All dice are 6.
                    case 10:
                        if (dice1 == 6 & dice2 == 6 & dice3 == 6)
                        {
                            userMoney += intUserBet * 180;
                            message = "WHATTT ALL 1s REALLY? !!!!! \nYou earn : " + intUserBet * 180 + "$ \nYour total money is now : " + userMoney + "$";
                        }
                        else
                        {
                            userMoney -= intUserBet;
                            message = "Sorry mate you lost your money. Your dice is not all 6s. \nYou lost : " + intUserBet + "$ \nYour total money is now : " + userMoney + "$";
                        }
                        break;

                    //Specific doubles are rolled (Double 1s). Two dice are 1. 
                    case 11:
                        if ((dice1 == 1 || dice2 == 1 || dice3 == 1) & (dice1 == dice2 || dice1 == dice3 || dice2 == dice3))
                        {
                            /*Exception of a triple dice control. If all dice are equal to each other, player will lost money; 
                            however, if two or none of them be equal, player will win.*/
                            if (dice1 != dice2 || dice1 != dice3 || dice2 != dice3)
                            {
                                userMoney += intUserBet * 10;
                                message = "Waow man you selected Double 1s and you win!!. \nYou earn : " + intUserBet * 10 + "$ \nYour total money is now : " + userMoney + "$";
                            }

                            else
                            {
                                userMoney -= intUserBet;
                                message = "Owww sory mate this is triple dice. \nYou lost : " + intUserBet + "$ \nYour total money is now : " + userMoney + "$";
                            }

                        }
                        else
                        {
                            userMoney -= intUserBet;
                            message = "You lost your money because this is not Double 1s. \nYou lost : " + intUserBet + "$ \nYour total money is now : " + userMoney + "$";
                        }

                        break;

                    //Specific doubles are rolled (Double 2s). Two dice are 2. 
                    case 12:
                        if ((dice1 == 2 || dice2 == 2 || dice3 == 2) & (dice1 == dice2 || dice1 == dice3 || dice2 == dice3))
                        {
                            /*Exception of a triple dice control. If all dice are equal to each other, player will lost money; 
                            however, if two or none of them be equal, player will win.*/
                            if (dice1 != dice2 || dice1 != dice3 || dice2 != dice3)
                            {
                                userMoney += intUserBet * 10;
                                message = "Waow man you selected Double 2s and you win!!. \nYou earn : " + intUserBet * 10 + "$ \nYour total money is now : " + userMoney + "$";
                            }

                            else
                            {
                                userMoney -= intUserBet;
                                message = "Owww sory mate this is triple dice. \nYou lost : " + intUserBet + "$ \nYour total money is now : " + userMoney + "$";
                            }

                        }
                        else
                        {
                            userMoney -= intUserBet;
                            message = "You lost your money because this is not Double 2s. \nYou lost : " + intUserBet + "$ \nYour total money is now : " + userMoney + "$";
                        }

                        break;

                    //Specific doubles are rolled (Double 3s). Two dice are 3. 
                    case 13:
                        if ((dice1 == 3 || dice2 == 3 || dice3 == 3) & (dice1 == dice2 || dice1 == dice3 || dice2 == dice3))
                        {
                            /*Exception of a triple dice control. If all dice are equal to each other, player will lost money; 
                            however, if two or none of them be equal, player will win.*/
                            if (dice1 != dice2 || dice1 != dice3 || dice2 != dice3)
                            {
                                userMoney += intUserBet * 10;
                                message = "Waow man you selected Double 3s and you win!!. \nYou earn : " + intUserBet * 10 + "$ \nYour total money is now : " + userMoney + "$";
                            }

                            else
                            {
                                userMoney -= intUserBet;
                                message = "Owww sory mate this is triple dice. \nYou lost : " + intUserBet + "$ \nYour total money is now : " + userMoney + "$";
                            }

                        }
                        else
                        {
                            userMoney -= intUserBet;
                            message = "You lost your money because this is not Double 3s. \nYou lost : " + intUserBet + "$ \nYour total money is now : " + userMoney + "$";
                        }

                        break;

                    //Specific doubles are rolled (Double 4s). Two dice are 4. 
                    case 14:
                        if ((dice1 == 4 || dice2 == 4 || dice3 == 4) & (dice1 == dice2 || dice1 == dice3 || dice2 == dice3))
                        {
                            /*Exception of a triple dice control. If all dice are equal to each other, player will lost money; 
                            however, if two or none of them be equal, player will win.*/
                            if (dice1 != dice2 || dice1 != dice3 || dice2 != dice3)
                            {
                                userMoney += intUserBet * 10;
                                message = "Waow man you selected Double 4s and you win!!. \nYou earn : " + intUserBet * 10 + "$ \nYour total money is now : " + userMoney + "$";
                            }

                            else
                            {
                                userMoney -= intUserBet;
                                message = "Owww sory mate this is triple dice. \nYou lost : " + intUserBet + "$ \nYour total money is now : " + userMoney + "$";
                            }

                        }
                        else
                        {
                            userMoney -= intUserBet;
                            message = "You lost your money because this is not Double 4s. \nYou lost : " + intUserBet + "$ \nYour total money is now : " + userMoney + "$";
                        }

                        break;

                    //Specific doubles are rolled (Double 5s). Two dice are 5. 
                    case 15:
                        if ((dice1 == 5 || dice2 == 5 || dice3 == 5) & (dice1 == dice2 || dice1 == dice3 || dice2 == dice3))
                        {
                            /*Exception of a triple dice control. If all dice are equal to each other, player will lost money; 
                            however, if two or none of them be equal, player will win.*/
                            if (dice1 != dice2 || dice1 != dice3 || dice2 != dice3)
                            {
                                userMoney += intUserBet * 10;
                                message = "Waow man you selected Double 5s and you win!!. \nYou earn : " + intUserBet * 10 + "$ \nYour total money is now : " + userMoney + "$";
                            }

                            else
                            {
                                userMoney -= intUserBet;
                                message = "Owww sory mate this is triple dice. \nYou lost : " + intUserBet + "$ \nYour total money is now : " + userMoney + "$";
                            }

                        }
                        else
                        {
                            userMoney -= intUserBet;
                            message = "You lost your money because this is not Double 5s. \nYou lost : " + intUserBet + "$ \nYour total money is now : " + userMoney + "$";
                        }

                        break;

                    //Specific doubles are rolled (Double 6s). Two dice are 6. 
                    case 16:
                        if ((dice1 == 6 || dice2 == 6 || dice3 == 6) & (dice1 == dice2 || dice1 == dice3 || dice2 == dice3))
                        {
                            /*Exception of a triple dice control. If all dice are equal to each other, player will lost money; 
                            however, if two or none of them be equal, player will win.*/
                            if (dice1 != dice2 || dice1 != dice3 || dice2 != dice3)
                            {
                                userMoney += intUserBet * 10;
                                message = "Waow man you selected Double 6s and you win!!. \nYou earn : " + intUserBet * 10 + "$ \nYour total money is now : " + userMoney + "$";
                            }

                            else
                            {
                                userMoney -= intUserBet;
                                message = "Owww sory mate this is triple dice. \nYou lost : " + intUserBet + "$ \nYour total money is now : " + userMoney + "$";
                            }

                        }
                        else
                        {
                            userMoney -= intUserBet;
                            message = "You lost your money because this is not Double 6s. \nYou lost : " + intUserBet + "$ \nYour total money is now : " + userMoney + "$";
                        }

                        break;

                    //If it is triple (Triple). All dice are equal. 
                    case 17:
                        if (dice1 == dice2 & dice1 == dice3 & dice2 == dice3)
                        {
                            userMoney += intUserBet * 180;
                            message = "OMG DUDE YOU ROCK IT IS TRIPE !!!!! \nYou earn : " + intUserBet * 180 + "$ \nYour total money is now : " + userMoney + "$";
                        }
                        else
                        {
                            userMoney -= intUserBet;
                            message = "Sorry mate you lost your money. Your dice sum is no triple!!!. \nYou lost : " + intUserBet + "$ \nYour total money is now : " + userMoney + "$";
                        }
                        break;

                    //If sum of dice is 4 or 17
                    case 18:
                        if (sum == 4 || sum == 17)
                        {
                            userMoney += intUserBet * 60;
                            message = "Bravo ! You selected 4 or 17 and your dice sum is " + sum + ". \nYou earn : " + intUserBet * 60 + "$ \nYour total money is now : " + userMoney + "$";
                        }
                        else
                        {
                            userMoney -= intUserBet;
                            message = "Sorry mate your dice sum is not 4 or 17. You lost your money. Try next time. \nYou lost : " + intUserBet + "$ \nYour total money is now : " + userMoney + "$";
                        }

                        break;

                    //If sum of dice is 5 or 16
                    case 19:
                        if (sum == 5 || sum == 16)
                        {
                            userMoney += intUserBet * 30;
                            message = "Bravo ! You selected 5 or 16 and your dice sum is " + sum + ". \nYou earn : " + intUserBet * 30 + "$ \nYour total money is now : " + userMoney + "$";
                        }
                        else
                        {
                            userMoney -= intUserBet;
                            message = "Sorry mate your dice sum is not 5 or 16. You lost your money. Try next time. \nYou lost : " + intUserBet + "$ \nYour total money is now : " + userMoney + "$";
                        }

                        break;

                    //If sum of dice is 6 or 15
                    case 20:
                        if (sum == 6 || sum == 15)
                        {
                            userMoney += intUserBet * 18;
                            message = "Bravo ! You selected 6 or 15 and your dice sum is " + sum + ". \nYou earn : " + intUserBet * 18 + "$ \nYour total money is now : " + userMoney + "$";
                        }
                        else
                        {
                            userMoney -= intUserBet;
                            message = "Sorry mate your dice sum is not 6 or 15. You lost your money. Try next time. \nYou lost : " + intUserBet + "$ \nYour total money is now : " + userMoney + "$";
                        }

                        break;

                    //If sum of dice is 7 or 14
                    case 21:
                        if (sum == 7 || sum == 14)
                        {
                            userMoney += intUserBet * 12;
                            message = "Bravo ! You selected 7 or 14 and your dice sum is " + sum + ". \nYou earn : " + intUserBet * 12 + "$ \nYour total money is now : " + userMoney + "$";
                        }
                        else
                        {
                            userMoney -= intUserBet;
                            message = "Sorry mate your dice sum is not 7 or 14. You lost your money. Try next time. \nYou lost : " + intUserBet + "$ \nYour total money is now : " + userMoney + "$";
                        }

                        break;

                    //If sum of dice is 8 or 13
                    case 22:
                        if (sum == 8 || sum == 13)
                        {
                            userMoney += intUserBet * 8;
                            message = "Bravo ! You selected 8 or 13 and your dice sum is " + sum + ". \nYou earn : " + intUserBet * 8 + "$ \nYour total money is now : " + userMoney + "$";
                        }
                        else
                        {
                            userMoney -= intUserBet;
                            message = "Sorry mate your dice sum is not 8 or 13. You lost your money. Try next time. \nYou lost : " + intUserBet + "$ \nYour total money is now : " + userMoney + "$";
                        }

                        break;

                    //If sum of dice is 9 or 12
                    case 23:
                        if (sum == 9 || sum == 12)
                        {
                            userMoney += intUserBet * 7;
                            message = "Bravo ! You selected 9 or 12 and your dice sum is " + sum + ". \nYou earn : " + intUserBet * 7 + "$ \nYour total money is now : " + userMoney + "$";
                        }
                        else
                        {
                            userMoney -= intUserBet;
                            message = "Sorry mate your dice sum is not 9 or 12. You lost your money. Try next time. \nYou lost : " + intUserBet + "$ \nYour total money is now : " + userMoney + "$";
                        }

                        break;

                    //If sum of dice is 10 or 11
                    case 24:
                        if (sum == 10 || sum == 11)
                        {
                            userMoney += intUserBet * 6;
                            message = "Bravo ! You selected 10 or 11 and your dice sum is " + sum + ". \nYou earn : " + intUserBet * 6 + "$ \nYour total money is now : " + userMoney + "$";
                        }
                        else
                        {
                            userMoney -= intUserBet;
                            message = "Sorry mate your dice sum is not 10 or 11. You lost your money. Try next time. \nYou lost : " + intUserBet + "$ \nYour total money is now : " + userMoney + "$";
                        }

                        break;
                }

                Console.WriteLine(message);
                Console.ReadLine();
                Console.Clear();

            }
            while (userMoney > 0 & userMoney < 100000);
            
            Console.ForegroundColor = ConsoleColor.Red;

            //Finish the game when user money is equal or less than 0
            if (userMoney <= 0)
            {
                Console.WriteLine("HAHA sorry mate but you lost all your money. Try next time :)");
                Console.ReadLine();
            }

            //Finish the game when user money is equal or more than 100000
            if (userMoney >= 100000)
            {
                Console.WriteLine("OMG you stole all our money. I HATE YOU {0}, DONT COME BACK AGAIN !!!!!!!!!!!!!", userName);
                Console.ReadLine();
            }
        }
        

        //Get the player bet type and convert it to integer. If it`s not number, more or less than game bet types, ask bet type again. 
        static int GetPlayerBetType()
        {
            bool isPlayerBetValid = false;
            int intUserBetType = 0;
            while (isPlayerBetValid == false)
            {

                string[] betTypes = new string[] {" ", "Big", "Small", "Odd", "Even", "All 1s", "All 2s", "All 3s", "All 4s",
                            "All 5s", "All 6s", "Double 1s", "Double 2s", "Double 3s", "Double 4s", "Double 5s", "Double 6s",
                            "Any triples", "4 or 17", "5 or 16", "6 or 15", "7 or 14", "8 or 13", "9 or 12", "10 or 11"};

                //Get the player bet type and convert it to integer.
                Console.WriteLine("\nWhich bet type would you like to make ?");
                Console.ForegroundColor = ConsoleColor.Green;
                string betType = Console.ReadLine();
                Console.ResetColor();

                //Convert string betType to int intUserBetType
                if (int.TryParse(betType, out intUserBetType))
                {
                    //If user bet type is between 0 and 24
                    if (intUserBetType <= 24 && intUserBetType > 0)
                    {
                        Console.Write("\nYou have selected '{0}'. ", betTypes[intUserBetType]);
                        isPlayerBetValid = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("your bet was more than 24 or less than 1", ConsoleColor.Red);
                        Console.ResetColor();
                    }
                }
                //If input was not a number or had invalid characters
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("your input was not a number or had invalid characters", ConsoleColor.Red);
                    Console.ResetColor();
                }

            }
            return intUserBetType;
        }

        
        //Get the player bet amound and convert it to integer. If it`s not number, more than user money or negative number, ask bet amound again. 
        static int GetPlayerBetAmound (int userBalance)
        {
            bool isPlayerBetValid = false;
            int intUserBet = 0;
            while (isPlayerBetValid == false)
            {
                //Get the player bet and convert it to integer.
                Console.WriteLine("How much money would like to bet?");
                Console.ForegroundColor = ConsoleColor.Green;
                string bet = Console.ReadLine();
                Console.ResetColor();

                //Convert string betType to int intUserBetType
                if (int.TryParse(bet, out intUserBet))
                {
                    //If user bet is bigger than 0 and less than user total money
                    if (intUserBet <= userBalance && intUserBet > 0)
                    {
                        isPlayerBetValid = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("your bet was more than your owned or less than 0", ConsoleColor.Red);
                        Console.ResetColor();
                    }
                }
                //If input was not a number or had invalid characters
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("your input was not a number or had invalid characters", ConsoleColor.Red);
                    Console.ResetColor();
                }
                
            }
            return intUserBet;
        }
        
        //Get the player name and  it convert to integer. If it`s not string, ask user name again. 
        static string GreetPlayer()
        {
            Console.WriteLine("Welcome to my Dice Game");
            bool isPlayerName = false;
            string userName = "";
            int intUserName = 0;
            while (isPlayerName == false)
            {
                //Get the player name and convert it to integer.
                Console.Write("Please enter your name; ");
                Console.ForegroundColor = ConsoleColor.Green;
                userName = Console.ReadLine();
                Console.ResetColor();

                //If user input is a number
                if (int.TryParse(userName, out intUserName))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Come on man! Your name is a number ? What do you think ? I can be a computer but I`m not stupit, type your real name!!!! ");
                    Console.ResetColor();
                }

                //If user input is null
                else if (userName == "")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Are you kidding me ?");
                    Console.ResetColor();
                }

                //If user input is string
                else
                {
                    Console.Clear();
                    Console.WriteLine("Hello " + userName);
                    isPlayerName = true;
                }

            }
            return userName;
        }

    }
    }

