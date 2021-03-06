﻿
using ACE.Network.Enum;

namespace ACE.Network.GameAction.Actions
{
    [GameAction(GameActionType.RaiseAbility)]
    public class GameActionRaiseAbility : GameActionPacket
    {
        private Entity.Enum.Ability ability;
        private uint xpSpent;

        public GameActionRaiseAbility(Session session, ClientPacketFragment fragment) : base(session, fragment) { }

        public override void Read()
        {
            var networkAbility = (Ability)Fragment.Payload.ReadUInt32();
            switch (networkAbility)
            {
                case Ability.Strength:
                    ability = Entity.Enum.Ability.Strength;
                    break;
                case Ability.Endurance:
                    ability = Entity.Enum.Ability.Endurance;
                    break;
                case Ability.Coordination:
                    ability = Entity.Enum.Ability.Coordination;
                    break;
                case Ability.Quickness:
                    ability = Entity.Enum.Ability.Quickness;
                    break;
                case Ability.Focus:
                    ability = Entity.Enum.Ability.Focus;
                    break;
                case Ability.Self:
                    ability = Entity.Enum.Ability.Self;
                    break;
                case Ability.Undefined:
                    return;
            }
            xpSpent = Fragment.Payload.ReadUInt32();
        }

        public override void Handle()
        {
            Session.Player.SpendXp(ability, xpSpent);
        }
    }
}
