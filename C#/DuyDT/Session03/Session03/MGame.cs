using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Session03
{
    partial class OnlineGame
    {
        //default constructor
        public OnlineGame()
        {
            name = "";
            client = 0;
        }
        public OnlineGame(string name, int client)
        {
            this.client = client;
            this.name = name;
        }
        //destructor
        ~OnlineGame()
        {
            name = "";
            client = 0;
        }
    }
}
