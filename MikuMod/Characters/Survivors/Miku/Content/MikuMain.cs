using EntityStates;
using IL.RoR2;
using MikuMod.Survivors.Miku;
using RoR2;
using UnityEngine;

namespace MikuMod.Survivors.Miku
{
    
    public class MikuMain : GenericCharacterMain
    {
        private int enemyCount;
        private float timer = 0;
        public override void OnEnter()
        {
            base.OnEnter();
            
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            timer += Time.deltaTime;
      //      int buffCount = characterBody.GetBuffCount(MikuBuffs.popularity);
            enemyCount = RoR2.TeamComponent.GetTeamMembers(TeamIndex.Monster).Count;
            characterBody.SetBuffCount(MikuBuffs.popularity.buffIndex, enemyCount);
      //      while(buffCount != enemyCount){
      //          if(buffCount < enemyCount)
      //          {
      //              characterBody.AddBuff(MikuBuffs.popularity);
      //          }
      //          else
      //          {
      //              characterBody.RemoveBuff(MikuBuffs.popularity.buffIndex);
      //          }
      //      }
            
    //       for(int i = 0; i < enemyCount; i++)
    //       {
    //           characterBody.AddBuff(MikuBuffs.popularity);
    //       }
            
        }

        public override void OnExit()
        {
            base.OnExit();
        }
    }
}
