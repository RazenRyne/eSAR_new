using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSARServiceModels;

namespace eSARServiceInterface
{
    public interface ITraitService
    {
         
        List<Trait> GetAllTraits(); // with no gradelevel
         
        List<Trait> GetAllTraitsOfCategory(int cat);//with gradelevel
         
        Boolean CreateTrait(ref Trait trait, ref string message);//with no gradelevel
         
        Boolean UpdateTrait(ref Trait trait, ref string message);


    }

}
