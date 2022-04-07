using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using BlackJack.Shared;

namespace BlackJack.Server.Hubs
{
    public class BlackjackHub : Hub
    {
        private readonly static List<User> _users = new List<User>();
        private Deck Deck = new Deck();

        public async Task SendMessage(User user)
        {
            user.ts = DateTime.Now;
            await Clients.All.SendAsync("ReceiveMessage", user);
        }

        public async Task Ready(User user)
        {
            bool startGame = false;
            if (_users.All(x => x.Id != user.Id))
            {
                user.Id = DateTime.Now.Ticks;
                user.WinCount = 0;
                _users.Add(user);
            }

            UpdatePlayerState("Ready", user);
            


            if(_users.All(x => x.State == "Ready") && _users.Count > 1)
            {
                Deck.Shuffle();

                foreach (var p in _users)
                {
                    var drawnCards = Deck.TakeCards(2);
                    foreach (var card in drawnCards)
                    {
                        p.Hand.Add(card);
                        if (user.Score < 11 && card.CardNumber.GetHashCode() == 1)
                        {
                            user.Aces.Add(card);
                        }
                        p.Score += CheckIfSuit(card, user);
                    }
                }
                
                startGame = true;
            }

            await Clients.Caller.SendAsync("UpdatePlayer", user);
            await Clients.All.SendAsync("ReceivePlayerReady", _users, startGame);
        }

        public async Task Hit(User user)
        {
            bool over = false;
            bool stopGame = false;
            Deck.Shuffle();
            var drawnCard = Deck.TakeCard();
            user.Hand.Add(drawnCard);
            if(user.Score < 11 && drawnCard.CardNumber.GetHashCode() == 1)
            {
                user.Aces.Add(drawnCard);
            }

            UpdatePlayerState("Hit", user);

            user.Score += CheckIfSuit(drawnCard, user);

            if(user.Score > 21)
            {
               if(user.Aces.Count > 0)
                {
                    user.Score -= 10;
                    user.Aces.RemoveAt(0);
                }
               else
                {
                    over = true;
                    UpdatePlayerState("Stay", user);
                    if (_users.All(x => x.State == "Stay"))
                    {
                        User winner = new User();
                        int bestScore = 0;
                        foreach (var item in _users)
                        {
                            item.State = "Wait";
                            item.Hand.Clear();
                            if (item.Score > bestScore && item.Score <= 21)
                            {
                                bestScore = item.Score;
                                winner = item;
                            }
                            item.Score = 0;
                        }
                        if (bestScore > 0)
                        {

                            RaisePlayerWinCount(winner);
                        }
                        stopGame = true;
                    }
                }
            }



            await Clients.All.SendAsync("ReceivePlayerHit", _users, stopGame);
            await Clients.Caller.SendAsync("PlayerNewHit", user, over);
        }

        public async Task Stay(User user)
        {
            bool stopGame = false; 
            UpdatePlayerState("Stay", user);


            if(_users.All(x => x.State == "Stay"))
            {
                User winner = new User();
                int bestScore = 0;
                foreach (var item in _users)
                {
                    item.State = "Wait";
                    item.Hand.Clear();
                    if(item.Score > bestScore && item.Score <= 21)
                    {
                        bestScore = item.Score;
                        winner = item;
                    }
                    item.Score = 0;
                }
                if(bestScore > 0)
                {
                    
                    RaisePlayerWinCount(winner);
                }
                stopGame = true;
            }
            await Clients.Caller.SendAsync("PlayerStopped", true);
            await Clients.All.SendAsync("ReceivePlayerStay", _users, stopGame);
        }


        private void UpdatePlayerState(string state, User user)
        {
            var player = _users.FirstOrDefault(x => x.Id == user.Id);
            int index = _users.IndexOf(player);
            user.State = state;

            if (index != -1)
            {
                _users[index] = user;
            }

        }
        private void RaisePlayerWinCount(User winner)
        {

            var player = _users.FirstOrDefault(x => x.Id == winner.Id);
            int index = _users.IndexOf(player);
            player.WinCount++;

            if (index != -1)
            {
                _users[index] = player;
            }
 
          
        }
        private int CheckIfSuit(Card card, User user)
        {
            if(card.CardNumber.GetHashCode() == 1 && user.Score < 11)
            {
                return 11;
            }
            else if(card.CardNumber.GetHashCode() == 1 && user.Score > 10)
            {
                return 1;
            }
            else if (card.CardNumber.GetHashCode() > 10)
            {
                return 10;
            }
            else
            {
                return card.CardNumber.GetHashCode();
            }
        }


    }
}
