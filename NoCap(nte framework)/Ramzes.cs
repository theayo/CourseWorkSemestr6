﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using Alexeev.Models;

namespace Alexeev
{
    class Ramzes
    {
        private static SoundPlayer Answer = new SoundPlayer(@"resources\Answer.wav");
        public string Close = "";
        public string Open = "";
        public string OpenBrov = "";

        public Ramzes()
        {
            this.initClose();
            this.initOpen();
            this.initOpenBrov();
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public void quest(string str, string answ1,string answ2, Ramzes ram)
        {
            
            string output = "";
            
            int i = 0;
            string str0 = " ";
            while (output.Length != str.Length)
            {
                this.paintRamzes();
                Console.SetCursorPosition(0, 0);
                if (i % 6 == 0) //моргнул
                {
                    this.paintRamzesOpenWid();
                    Console.SetCursorPosition(0, 0);
                }
                if (i % 8 == 0) //моргнул
                {
                    this.paintRamzesOpenWid();
                    Console.SetCursorPosition(0, 0);
                }
                if (i % 4 == 0 || i % 7 == 0)
                this.paintRamzesOpenMouse();
                Console.SetCursorPosition(5, 50);
                output += str[i];
                ++i;
                output += str[i];
                ++i;
                output += str[i];
                Console.WriteLine("\n");
                Console.WriteLine(output);
                Console.SetCursorPosition(0, 0);
                ++i;
            }
            Menu menu = new Menu();
            while (true)
            {
                ram.paintRamzes();
                Console.WriteLine();
                Console.SetCursorPosition(0, 52);
                Console.WriteLine(str + " \n");
                str0 = menu.drawMenu(answ1, answ2, 55);

                if (str0 == answ1 || str0 == answ2)
                    break;
                
            }
            if (str0 == answ1 || str0 == answ2)
            {
                Answer.Play();
                return;
            }
           
        }

        public async Task quest(string str, string answ1, Ramzes ram, ResponseCompanion resp)
        {

            string output = "";

            int i = 0;
            string str0 = " ";

            paintRamzes();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(str);
            
            Menu menu = new Menu();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            var answ2 = Console.ReadLine();

            while (true)
            {
                ram.paintRamzes();
                Console.WriteLine(); 
                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine(str + " \n");
                str0 = menu.drawMenu(answ1, answ2, 55);

                if (str0 == answ1 || str0 == answ2)
                    break;

            }
            if (str0 == answ2)
            {
                resp.Context.Add(new Companion(){content = answ2, role = "user"});
                ServiceApi serv = new ServiceApi();

                var res = await serv.GenerateChatGptResponse(resp.Context);

                await quest(res.Answer.content, "Fuck you", ram, resp);
                return;
            }

            if (str0 == answ1)
            {
                return;
            }

        }
        public void initOpenBrov()
        {
            OpenBrov += "############################# =  :-----.......-....--..--:**-.....--..........--:  ###################";
            OpenBrov += "####################################  ------.-..--..-.--..--:-..............--*   ####################";
            OpenBrov += "#########################=---------.--...-.-------.-------::::-------........----:* ##################";
            OpenBrov += "###################### -----------..---.---:-::::::::**::--:**::------..---------- ###################";
            OpenBrov += "#################### ------..-.-.---::.----::***:***::*:**:::*--:------.----------  ##################";
            OpenBrov += "################## -.--.----....----:----::*++********++*****:::::--:---.........---:#################";
            OpenBrov += "#################:---..-.-----.-------:-:::=++*%++++**+==+***::**:*::----...-........-  ##############";
            OpenBrov += "################ --..---.----------::**:***=%+=%+*==+=%%=**++***+=++*:----:...-......--  #############";
            OpenBrov += "############### -------------:::-::**+++=*+@==%@+====@@%++===+++=%%=+*:-:::::--...------: ############";
            OpenBrov += "############### --.--::---:--:**::*++*==%+=%%=@@=%%%@#@===%%%====@@%=*:::-*:---.----.----  ###########";
            OpenBrov += "############### ----::---:****+=*+*=%*=%%%%%%=@@=%%@#@%%%%@@%=%%%@@%==***:::::----..-----: ###########";
            OpenBrov += "###############:--:*:*:::***++==+++=%%=@@%@%%%@#%%@@#%%@%@#@%%@@@@@=%==*++*:*:::...-------  ##########";
            OpenBrov += "############## ---:**++*:**++==%%+==%@=%@@%@%%%#%@@##%@@@#@%%%@#@@%%@%%=+==*:*::-...--.:--:  #########";
            OpenBrov += "############### --:**+==++*++==%%===%%%=@#@@%%%@@@@#@@@@##@%@@##@%@@%%%%+%%+:*:*:-.....----*##########";
            OpenBrov += "################ --:++=%=====%=%%%===%%%%@#@@@%@%@@#@@@#@@@@@@#@@@@@@%%%+%%%+++=+::-..----  ##########";
            OpenBrov += "################# .-*+=%%%%%%%%%=%%=%%%@%%@##@%@@@@@%@##@@@@@@@@@@@@@%%=+%%%@%@==*:*-.. ##############";
            OpenBrov += "################## -:*==%%%@@@@@%===%%%%%@%@@@@@@@@@@@@@%@@%%%%%%%%%====%%%%@@@@%=**:-.###############";
            OpenBrov += "################## --:+=%%%@@@@%%=====%%%%@@%@@@@%%%%%%=%=====++=+++++===%%%@%%%===+*--###############";
            OpenBrov += "###################-:*+=%==%%%=+++++++++===%%========+**************++++++==%====%=+*--###############";
            OpenBrov += "################### :+===%%%%=+*:*******************::::::::::::**********+=====%=+*:- ###############";
            OpenBrov += "####################:**+=%==+**::::*:::::::::::::::::::::::::::::*********++=====++*:-################";
            OpenBrov += "####################--:++++++**:::**::::::::::::::::::::::::::::::::******+=+++++**::#################";
            OpenBrov += "####################=-:*****+**:::****:::::::::::::::::::::::::::::::*******++***:::-#################";
            OpenBrov += "#################### -:********::*****:::::::::::::::::::::::::::::::************:---#################";
            OpenBrov += "#####################-:++*****::******:::::::::::::::::::::::::::::::******::::**::- #################";
            OpenBrov += "#####################:-++**::::::*****::::::::::::::::::::::::*****+++++**::---:*::-=#################";
            OpenBrov += "##################### -*=*::::::::::**::::::::::::::::::::::::@#@@@@%%%%*::----:*:----#######+########";
            OpenBrov += "########+############*--++::::::::@@@@@###@@@%**********+++%%@@#=+=+++++%%+:----****:-- ######++######";
            OpenBrov += "######++############ --*++:-:::*%%+++***+++**++=++*****+==%%%%%==++========+:---:***=+--######+#+#####";
            OpenBrov += "####++####++##++####:-++*+:-::*+====%%%%%@@@@%%%==+****+=%%%@@@@####@@%%==++*:---***++--##++#+#+#++###";
            OpenBrov += "######+#+########### -*+:+*-::*+=%%%@%%####%%@@@%%+*:::*===%%==+%%%====+*****::--***-*:-##++##+##+####";
            OpenBrov += "#######++########### -:*:*::::*+++++======++++++==*:::::****++===+==+++******::--:++*:--###+##++######";
            OpenBrov += "########++###########-:*+=*::::***+++======+*****+*:::::***::*********:::::::::--::*::- ####++########";
            OpenBrov += "#####################:-*==::::::***********::::**+**::::***:::::::::::::::::::::-::*::- #############";
            OpenBrov += "######################-*+=+::::::::::::::::::::****:::::***::::::::::::::::*:::--**:--:###############";
            OpenBrov += "######################=-::=*:::::::::::::::::***+*:::::::*****:::::::::::*:::::--***--################";
            OpenBrov += "####################### -:**:::::::::::::::******:::::::*********::::::******:::-**:--################";
            OpenBrov += "########################--**::::***********+*+=+==+***+++=+=******************:::=+:- ################";
            OpenBrov += "######################## -:=*****++++++++=++*+=%%%%%==@@@@%+*****++*+++++++++*::--- ##################";
            OpenBrov += "##########################---**+++==+===%++++++=%%%%%%%%=+******++=++++++++++**:--####################";
            OpenBrov += "########################### -:*++====+======+++++===%=+******++===+++++++==+++*:--####################";
            OpenBrov += "############################--*++===++*+==@@@%%%%%%%%=%%=%%%@@@%=+++*+++++++++*--#####################";
            OpenBrov += "#############################--*+====++*+*++======++==++*++==+*****+++++====++:-######################";
            OpenBrov += "##############################--*+=====++++++==+==++++++++++++*****+++======+--#######################";
            OpenBrov += "###############################--*+======+++++============++*******++======:- ########################";
            OpenBrov += "################################ -:+======++***+++++=++***********++====++* ##########################";
            OpenBrov += "###############################################%%%%%%@%%%%%%%#########################################";
            OpenBrov += "##################################%*++=====++********::::::*****++====+==%############################";
            OpenBrov += "#####################################%==+====++**************+++=====%################################";
            OpenBrov += "########################################%========++++++++++==%%%==%%##################################";
            OpenBrov += "###########################################%===%%%%%%%%%@@@@@%%%%#####################################";
        }
        public void initOpen()
        {
            Open += "############################# =  :-----.......-....--..--:**-.....--..........--:  ###################";
            Open += "####################################  ------.-..--..-.--..--:-..............--*   ####################";
            Open += "#########################=---------.--...-.-------.-------::::-------........----:* ##################";
            Open += "###################### -----------..---.---:-::::::::**::--:**::------..---------- ###################";
            Open += "#################### ------..-.-.---::.----::***:***::*:**:::*--:------.----------  ##################";
            Open += "################## -.--.----....----:----::*++********++*****:::::--:---.........---:#################";
            Open += "#################:---..-.-----.-------:-:::=++*%++++**+==+***::**:*::----...-........-  ##############";
            Open += "################ --..---.----------::**:***=%+=%+*==+=%%=**++***+=++*:----:...-......--  #############";
            Open += "############### -------------:::-::**+++=*+@==%@+====@@%++===+++=%%=+*:-:::::--...------: ############";
            Open += "############### --.--::---:--:**::*++*==%+=%%=@@=%%%@#@===%%%====@@%=*:::-*:---.----.----  ###########";
            Open += "############### ----::---:****+=*+*=%*=%%%%%%=@@=%%@#@%%%%@@%=%%%@@%==***:::::----..-----: ###########";
            Open += "###############:--:*:*:::***++==+++=%%=@@%@%%%@#%%@@#%%@%@#@%%@@@@@=%==*++*:*:::...-------  ##########";
            Open += "############## ---:**++*:**++==%%+==%@=%@@%@%%%#%@@##%@@@#@%%%@#@@%%@%%=+==*:*::-...--.:--:  #########";
            Open += "############### --:**+==++*++==%%===%%%=@#@@%%%@@@@#@@@@##@%@@##@%@@%%%%+%%+:*:*:-.....----*##########";
            Open += "################ --:++=%=====%=%%%===%%%%@#@@@%@%@@#@@@#@@@@@@#@@@@@@%%%+%%%+++=+::-..----  ##########";
            Open += "################# .-*+=%%%%%%%%%=%%=%%%@%%@##@%@@@@@%@##@@@@@@@@@@@@@%%=+%%%@%@==*:*-.. ##############";
            Open += "################## -:*==%%%@@@@@%===%%%%%@%@@@@@@@@@@@@@%@@%%%%%%%%%====%%%%@@@@%=**:-.###############";
            Open += "################## --:+=%%%@@@@%%=====%%%%@@%@@@@%%%%%%=%=====++=+++++===%%%@%%%===+*--###############";
            Open += "###################-:*+=%==%%%=+++++++++===%%========+**************++++++==%====%=+*--###############";
            Open += "################### :+===%%%%=+*:*******************::::::::::::**********+=====%=+*:- ###############";
            Open += "####################:**+=%==+**::::*:::::::::::::::::::::::::::::*********++=====++*:-################";
            Open += "####################--:++++++**:::**::::::::::::::::::::::::::::::::******+=+++++**::#################";
            Open += "####################=-:*****+**:::****:::::::::::::::::::::::::::::::*******++***:::-#################";
            Open += "#################### -:********::*****:::::::::::::::::::::::::::::::************:---#################";
            Open += "#####################-:++*****::******:::::::::::::::::::::::::::::::******::::**::- #################";
            Open += "#####################:-++**::::::*****::::::::::::::::::::::::::::::::****::---:*::-=#################";
            Open += "##################### -*=*::::::::::**::::::::::::::::::::::::*****+++++*::----:*:----################";
            Open += "#####################*--++::::::::**++++****************+++%%@@#@@@@%%%%%%+:----****:-- ##############";
            Open += "#################### --*++:-:::*%%@@@@@###@@@@%=++*****+==%%%%%==++========+:---:***=+--##############";
            Open += "####################:-++*+:-::*+====%%%%%@@@@%%%==+****+=%%%@@@@####@@%%==++*:---***++--##############";
            Open += "#################### -*+:+*-::*+=%%%@%%####%%@@@%%+*:::*===%%==+%%%====+*****::--***-*:-##############";
            Open += "#################### -:*:*::::*+++++======++++++==*:::::****++===+==+++******::--:++*:--##############";
            Open += "#####################-:*+=*::::***+++======+*****+*:::::***::*********:::::::::--::*::- ##############";
            Open += "#####################:-*==::::::***********::::**+**::::***:::::::::::::::::::::-::*::- ##############";
            Open += "######################-*+=+::::::::::::::::::::****:::::***::::::::::::::::*:::--**:--:###############";
            Open += "######################=-::=*:::::::::::::::::***+*:::::::*****:::::::::::*:::::--***--################";
            Open += "####################### -:**:::::::::::::::******:::::::*********::::::******:::-**:--################";
            Open += "########################--**::::***********+*+=+==+***+++=+=******************:::=+:- ################";
            Open += "######################## -:=*****++++++++=++*+=%%%%%==@@@@%+*****++*+++++++++*::--- ##################";
            Open += "##########################---**+++==+===%++++++=%%%%%%%%=+******++=++++++++++**:--####################";
            Open += "########################### -:*++====+======+++++===%=+******++===+++++++==+++*:--####################";
            Open += "############################--*++===++*+==@@@%%%%%%%%=%%=%%%@@@%=+++*+++++++++*--#####################";
            Open += "#############################--*+====++*+*++%=====++==++*++=%+*****+++++====++:-######################";
            Open += "##############################--*+=====++++++=%+==++++++++%+++*****+++======+--#######################";
            Open += "###############################--*+======+++++============++*******++======:- ########################";
            Open += "################################ -:+======++***+++++=++***********++====++* ##########################";
            Open += "###############################################%%%%%%@%%%%%%%#########################################";
            Open += "##################################%*++=====++********::::::*****++====+==%############################";
            Open += "#####################################%==+====++**************+++=====%################################";
            Open += "########################################%========++++++++++==%%%==%%##################################";
            Open += "###########################################%===%%%%%%%%%@@@@@%%%%#####################################";
        }

        public void initClose()
        {
            Close += "############################# =  :-----.......-....--..--:**-.....--..........--:  ###################";
            Close += "####################################  ------.-..--..-.--..--:-..............--*   ####################";
            Close += "#########################=---------.--...-.-------.-------::::-------........----:* ##################";
            Close += "###################### -----------..---.---:-::::::::**::--:**::------..---------- ###################";
            Close += "#################### ------..-.-.---::.----::***:***::*:**:::*--:------.----------  ##################";
            Close += "################## -.--.----....----:----::*++********++*****:::::--:---.........---:#################";
            Close += "#################:---..-.-----.-------:-:::=++*%++++**+==+***::**:*::----...-........-  ##############";
            Close += "################ --..---.----------::**:***=%+=%+*==+=%%=**++***+=++*:----:...-......--  #############";
            Close += "############### -------------:::-::**+++=*+@==%@+====@@%++===+++=%%=+*:-:::::--...------: ############";
            Close += "############### --.--::---:--:**::*++*==%+=%%=@@=%%%@#@===%%%====@@%=*:::-*:---.----.----  ###########";
            Close += "############### ----::---:****+=*+*=%*=%%%%%%=@@=%%@#@%%%%@@%=%%%@@%==***:::::----..-----: ###########";
            Close += "###############:--:*:*:::***++==+++=%%=@@%@%%%@#%%@@#%%@%@#@%%@@@@@=%==*++*:*:::...-------  ##########";
            Close += "############## ---:**++*:**++==%%+==%@=%@@%@%%%#%@@##%@@@#@%%%@#@@%%@%%=+==*:*::-...--.:--:  #########";
            Close += "############### --:**+==++*++==%%===%%%=@#@@%%%@@@@#@@@@##@%@@##@%@@%%%%+%%+:*:*:-.....----*##########";
            Close += "################ --:++=%=====%=%%%===%%%%@#@@@%@%@@#@@@#@@@@@@#@@@@@@%%%+%%%+++=+::-..----  ##########";
            Close += "################# .-*+=%%%%%%%%%=%%=%%%@%%@##@%@@@@@%@##@@@@@@@@@@@@@%%=+%%%@%@==*:*-.. ##############";
            Close += "################## -:*==%%%@@@@@%===%%%%%@%@@@@@@@@@@@@@%@@%%%%%%%%%====%%%%@@@@%=**:-.###############";
            Close += "################## --:+=%%%@@@@%%=====%%%%@@%@@@@%%%%%%=%=====++=+++++===%%%@%%%===+*--###############";
            Close += "###################-:*+=%==%%%=+++++++++===%%========+**************++++++==%====%=+*--###############";
            Close += "################### :+===%%%%=+*:*******************::::::::::::**********+=====%=+*:- ###############";
            Close += "####################:**+=%==+**::::*:::::::::::::::::::::::::::::*********++=====++*:-################";
            Close += "####################--:++++++**:::**::::::::::::::::::::::::::::::::******+=+++++**::#################";
            Close += "####################=-:*****+**:::****:::::::::::::::::::::::::::::::*******++***:::-#################";
            Close += "#################### -:********::*****:::::::::::::::::::::::::::::::************:---#################";
            Close += "#####################-:++*****::******:::::::::::::::::::::::::::::::******::::**::- #################";
            Close += "#####################:-++**::::::*****::::::::::::::::::::::::::::::::****::---:*::-=#################";
            Close += "##################### -*=*::::::::::**::::::::::::::::::::::::*****+++++*::----:*:----################";
            Close += "#####################*--++::::::::**++++****************+++%%@@#@@@@%%%%%%+:----****:-- ##############";
            Close += "#################### --*++:-:::*%%@@@@@###@@@@%=++*****+==%%%%%==++========+:---:***=+--##############";
            Close += "####################:-++*+:-::*+====%%%%%@@@@%%%==+****+=%%%@@@@####@@%%==++*:---***++--##############";
            Close += "#################### -*+:+*-::*+=%%%@%%####%%@@@%%+*:::*===%%==+%%%====+*****::--***-*:-##############";
            Close += "#################### -:*:*::::*+++++======++++++==*:::::****++===+==+++******::--:++*:--##############";
            Close += "#####################-:*+=*::::***+++======+*****+*:::::***::*********:::::::::--::*::- ##############";
            Close += "#####################:-*==::::::***********::::**+**::::***:::::::::::::::::::::-::*::- ##############";
            Close += "######################-*+=+::::::::::::::::::::****:::::***::::::::::::::::*:::--**:--:###############";
            Close += "######################=-::=*:::::::::::::::::***+*:::::::*****:::::::::::*:::::--***--################";
            Close += "####################### -:**:::::::::::::::******:::::::*********::::::******:::-**:--################";
            Close += "########################--**::::***********+*+=+==+***+++=+=******************:::=+:- ################";
            Close += "######################## -:=*****++++++++=++*+=%%%%%==@@@@%+*****++*+++++++++*::--- ##################";
            Close += "##########################---**+++==+===%++++++=%%%%%%%%=+******++=++++++++++**:--####################";
            Close += "########################### -:*++====+======+++++===%=+******++===+++++++==+++*:--####################";
            Close += "############################--*++===++*+==@@@%%%%%%%%=%%=%%%@@@%=+++*+++++++++*--#####################";
            Close += "#############################--*+====++*+*++=%%%%%%%%%%%%%%%=+*****+++++====++:-######################";
            Close += "##############################--*+=====++++++++++++%+++++++++*****+++======+--#######################";
            Close += "###############################--*+======+++++==============*******++======:- ########################";
            Close += "################################ -:+======++***========***********++====++* ##########################";
            Close += "###############################################%%%%%%@%%%%%%%#########################################";
            Close += "##################################%*++=====++********::::::*****++====+==%############################";
            Close += "#####################################%==+====++**************+++=====%################################";
            Close += "########################################%========++++++++++==%%%==%%##################################";
            Close += "###########################################%===%%%%%%%%%@@@@@%%%%#####################################";
        }


        public void paintRamzes()
        {
            Console.Clear();
            int i = 0;
            while (Close.Length != i)
            {
                Console.Write(Close[i]);
                if (i % 102 == 0 && i != 0)
                    Console.WriteLine();
                i++;
            }
        }

        public void paintRamzesOpenMouse()
        {
            int i = 0;
            while (Open.Length != i)
            {
                Console.Write(Open[i]);
                if (i % 102 == 0 && i != 0)
                    Console.WriteLine();
                i++;
            }
        }

        public void paintRamzesOpenWid()
        {
            int i = 0;
            while (OpenBrov.Length != i)
            {
                Console.Write(OpenBrov[i]);
                if (i % 102 == 0 && i != 0)
                    Console.WriteLine();
                i++;
            }
        }
    }
}
