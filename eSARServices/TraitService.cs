using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSARServiceModels;
using eSARServiceInterface;
using eSARLogic;
using eSARBDO;

namespace eSARServices
{
    public class TraitService : ITraitService
    {
        TraitLogic tlogic = new TraitLogic();
        public bool CreateTrait(ref Trait trait, ref string message)
        {
            TraitBDO tbdo = new TraitBDO();
            TranslateTraitToTraitBDO(trait, tbdo);
            return tlogic.CreateTrait(ref tbdo, ref message);
        }

        public void TranslateTraitToTraitBDO(Trait trait, TraitBDO tbdo)
        {
            tbdo.Description = trait.Description;
            tbdo.CurrTrait = trait.CurrTrait;
            tbdo.TraitsID = trait.TraitsID;
            tbdo.Category = trait.Category;
        }
        public void TranslateTraitBDOToTrait(TraitBDO tbdo, Trait t)
        {
            t.Description = tbdo.Description;
            t.CurrTrait = tbdo.CurrTrait;
            t.TraitsID = tbdo.TraitsID;
            t.Category = tbdo.Category;
            switch (tbdo.Category)
            {
                case 1:
                    t.Cat = "Pre-School";
                    break;
                case 2:
                    t.Cat = "Elementary";
                    break;
                case 3:
                    t.Cat = "Secondary";
                    break;
            }
        }
        public List<Trait> GetAllTraits()
        {
            List<Trait> tList = new List<Trait>();
            tList = ToTraitList(tlogic.GetAllTraits());
            return tList;
        }

        public List<Trait> ToTraitList(List<TraitBDO> tbList)
        {
            List<Trait> tList = new List<Trait>();
            foreach (TraitBDO tbdo in tbList)
            {
                Trait t = new Trait();
                TranslateTraitBDOToTrait(tbdo, t);
                tList.Add(t);
            }
            return tList;
        }

        public List<TraitBDO> ToTraitBDOList(List<Trait> tbList)
        {
            List<TraitBDO> tList = new List<TraitBDO>();
            foreach (Trait t in tbList)
            {
                TraitBDO tb = new TraitBDO();
                TranslateTraitToTraitBDO(t, tb);
                tList.Add(tb);
            }
            return tList;

        }

        public List<Trait> GetAllTraitsOfCategory(int cat)
        {
            List<Trait> tList = new List<Trait>();
            tList = ToTraitList(tlogic.GetAllTraits(cat));
            return tList;
        }

        public bool UpdateTrait(ref Trait trait, ref string message)
        {
            TraitBDO tbdo = new TraitBDO();
            TranslateTraitToTraitBDO(trait, tbdo);
            return tlogic.UpdateTrait(ref tbdo, ref message);
        }
    }
}
