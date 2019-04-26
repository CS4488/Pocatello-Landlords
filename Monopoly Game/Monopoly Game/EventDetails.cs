using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly_Game
{
    class EventDetails
    {
        string _Id;
        string _Message;
        int _Cost;
        Boolean _AffectMultiple;
        int _SpaceIndex;
        Boolean _IsLootCrate;
        Boolean _StaysInHand;

        public EventDetails()
        {

        }

        public EventDetails(string id, string message, int cost, Boolean affectMultiple, int spaceIndex, Boolean isLootCrate, Boolean staysInHand)
        {
            Id = id;
            Message = message;
            Cost = cost;
            AffectMultiple = affectMultiple;
            SpaceIndex = spaceIndex;
            IsLootCrate = isLootCrate;
            StaysInHand = staysInHand;
        }

        public string Id { get => _Id; set => _Id = value; }
        public string Message { get => _Message; set => _Message = value; }
        public bool AffectMultiple { get => _AffectMultiple; set => _AffectMultiple = value; }
        public int SpaceIndex { get => _SpaceIndex; set => _SpaceIndex = value; }
        public bool IsLootCrate { get => _IsLootCrate; set => _IsLootCrate = value; }
        public bool StaysInHand { get => _StaysInHand; set => _StaysInHand = value; }
        public int Cost { get => _Cost; set => _Cost = value; }
    }
}
