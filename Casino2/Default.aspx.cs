﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Casino2
{
    public partial class Default : System.Web.UI.Page
    {
        Random random = new Random();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string[] reels = new string[] { spinReel(), spinReel(), spinReel() };
                displayReels(reels);
                ViewState.Add("PlayersMoney", 100);
                displayPlayersMoney();
            }
        }

        private void displayPlayersMoney()
        {
            moneyLabel.Text = String.Format("Player's Money: {0:C}", ViewState["PlayersMoney"]);
        }

        protected void leverButton_Click(object sender, EventArgs e)
        {
            int bet = 0;
            if (!int.TryParse(betTextBox.Text, out bet)) return;

            int winnings = pullLever(bet);
            displayResult(bet,winnings);
           
            adjustPlayersMoney(bet,winnings);
            displayPlayersMoney();

            if(int.Parse(ViewState["PlayersMoney"].ToString()) <= 0)
            {

                moneyLabel.Text = "Out of Credit";
                resultLabel.Text = "GAME OVER!";
            }
                 
        }
        private void displayResult(int bet, int winnings)
        {
            if (winnings > 0)
                resultLabel.Text = String.Format("You bet {0:C} and won {1:C}", bet, winnings);
            else
                resultLabel.Text = String.Format("Sorry you lost {0:C}, Better Luck Next Time", bet);
        }

        private void adjustPlayersMoney(int bet, int winnings)
        {
            int playersMoney = int.Parse(ViewState["PlayersMoney"].ToString());
            playersMoney -= bet;
            playersMoney += winnings;
            ViewState["PlayersMoney"] = playersMoney;



        }

        private int pullLever(int bet)
        {
            string[] reels = new string[] {spinReel(), spinReel(), spinReel()};
            displayReels(reels);
            int multiplier = evaluateSpin(reels);
            return bet * multiplier;

        }

        private int evaluateSpin(string[]reels)
        {
            if (isBar(reels)) return 0;
            if (isJackpot(reels)) return 100;
            int multiplier = 0;
            if (isWinner(reels, out multiplier)) return multiplier;
            return 0;
        }

        private bool isJackpot(string[] reels)
        {
            if (reels[0] == "Seven" && reels[1] == "Seven" && reels[2] == "Seven")
                return true;
            return false;
        }

        private bool isBar(string[]reels)
        {
            if (reels[0] == "Bar" || reels[1] == "Bar" || reels[2] == "Bar")
                return true;
            else return false;

            
        }

        private bool isWinner(string[]reels , out int multiplier)
        {
            multiplier = determineMultiplier(reels);
            if (multiplier > 0) return true;
            else return false;


            
        }
        private int determineMultiplier(string[]reels)
        {
            int cherryCount = determineCherryCount(reels);
            if (cherryCount == 1) return 2;
            if (cherryCount == 2) return 3;
            if (cherryCount == 3) return 4;
            return 0;

        }
        private int determineCherryCount(string[] reels)
        {
            int cherryCount = 0;
            if (reels[0] == "Cherry") cherryCount++;
            if (reels[1] == "Cherry") cherryCount++;
            if (reels[2] == "Cherry") cherryCount++;
            return cherryCount;
        }

        private string spinReel()
        {
            string[] images = new string[] { "Bar", "Bell", "Cherry", "Clover", "Diamond", "HorseShoe", "Lemon", "Orange", "Plum", "Seven", "Strawberry", "Watermellon" };
            return images[random.Next(11)];
        }
        private void displayReels(string[] reels)
        {
            Image1.ImageUrl = "/Images/" + reels[0] + ".png";
            Image2.ImageUrl = "/Images/" + reels[1] + ".png";
            Image3.ImageUrl = "/Images/" + reels[2] + ".png";
        }
    }
}