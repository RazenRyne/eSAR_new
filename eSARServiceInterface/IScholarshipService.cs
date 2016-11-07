using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSARServiceModels;

namespace eSARServiceInterface
{
    public interface IScholarshipService
    {
         
        List<ScholarshipDiscount> GetAllScholarships();
         
        Boolean CreateScholarship(ref ScholarshipDiscount scholarship, ref string message);
         
        Boolean AddScholarshipDiscount(ref ScholarshipDiscount scholarshipDiscount, int scholarshipCode, ref string message);
         
        Boolean UpdateScholarship(ref ScholarshipDiscount scholarship, ref string message);
         
        List<Student> GetAllScholarsOfScholarship(int scholarshipCode);
         
        List<Student> GetAllScholars();
         
        List<ScholarshipDiscount> GetAllScholarshipDiscount(int scholarshipCode);
         
        Boolean DeleteScholarshipDiscount(int scholarshipDiscountId);
         
        Boolean UpdateScholarshipDiscount(ref ScholarshipDiscount scholarshipDiscount, ref string message);

    }
}
