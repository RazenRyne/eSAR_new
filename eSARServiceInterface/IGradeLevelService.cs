using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSARServiceModels;

namespace eSARServiceInterface
{
    public interface IGradeLevelService
    {
       List<GradeLevel> GetAllGradeLevels();
        GradeLevel NextGradeLevel(String grade);
    }
}
