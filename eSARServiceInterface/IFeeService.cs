using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSARServiceModels;
namespace eSARServiceInterface
{
    public interface IFeeService
    {
        
        Boolean UpdateFee(ref Fee fee, ref string message);
        
        Boolean CreateFee(ref Fee fee, ref string message);
        
        List<Fee> GetAllFees();
        
        List<Fee> GetAllFeesForGradeLevel(string gradeLevel, string currSY);
        
        List<GradeLevel> GetAllGradeLevels();
        
        List<SchoolYear> GetLastFiveSY();
        
        Fee GetFeeForAll(string currSY);
    }
}
