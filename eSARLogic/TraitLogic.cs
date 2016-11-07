using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSARDAL;
using eSARBDO;

namespace eSARLogic
{
    public class TraitLogic
    {
        TraitDAO tdao = new TraitDAO();
        public List<TraitBDO> GetAllTraits() {
            return tdao.GetAllTraits();
        }

        public List<TraitBDO> GetAllTraits(int cat) {
            return tdao.GetAllTraitsForCategory(cat);
        }

        public Boolean CreateTrait(ref TraitBDO tbdo, ref string message) {
            return tdao.CreateTrait(ref tbdo, ref message);
        }

        public Boolean UpdateTrait(ref TraitBDO tbdo, ref string message) {
            return tdao.UpdateTrait(ref tbdo, ref message);
        }
    }
}
