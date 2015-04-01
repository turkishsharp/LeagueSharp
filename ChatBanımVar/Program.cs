using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueSharp;
using LeagueSharp.Common;
using SharpDX;
using System.Net;

namespace ChatBanımVar
{
    class Program
    {
        public static bool isSend = false;
        public static float gameTime1 = 0;
        public static string Revision = "230";
        static void Main(string[] args)
        {
            CustomEvents.Game.OnGameLoad += Game_OnGameLoad;
            CustomEvents.Game.OnGameEnd +=Game_OnGameEnd;
        }
        static void Update;

        private static void Game_OnGameLoad(EventArgs args)
        {
            Game.OnUpdate += Game_OnGameUpdate;
        }
        private static void Game_OnGameUpdate(EventArgs args)
        {
            Game.Say("Konuşma Banım Var Yazamam Oyun İçinde");
            isSend = true;
            gameTime1 = Game.Time + 1;

            if (Game.Time > gameTime1)
            {

                isSend = false;

            }
        }
        private static void Game_OnGameEnd(EventArgs args)
        {
            Game.Say("GG");
        }
        
        private static void Update()
            {
                var wc = new WebClient { Proxy = null };
                var gitrevision =
                    wc.DownloadString(
                        "C:\Users\excalibur05\Documents\Visual Studio 2013\Projects\ChatBanımVar\ChatBanımVar.txt");

                if (Revision != gitrevision)
                {
                    Game.PrintChat("<font color=\"#FFFFCC\"><b>Güncel Değil Lütfen Güncelle</b></font>");
                }
            }

        
    }
}
