using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSARBDO;
using eSARDAL;

namespace eSARLogic
{
    public class GradeSectionLogic
    {
        GradeSectionDAO gsDao = new GradeSectionDAO();
        public List<GradeSectionBDO> GetAllGradeSections(string currentSY) {
            return gsDao.GetAllGradeSections(currentSY);
        }

        public List<GradeSectionBDO> GetAllGradeSections()
        {
            return gsDao.GetAllGradeSections();
        }
        public List<GradeSectionBDO> GetAllSectionsofGrade(string gradeLevel) {
            List<GradeSectionBDO> g = new List<GradeSectionBDO>();
            g = GetAllGradeSections().FindAll(gs=> gs.GradeLevel==gradeLevel);
            return g;
        }
        public String GetSection(int sectioncode)
        {
            int index;
            List<GradeSectionBDO> sections = new List<GradeSectionBDO>();
            sections=GetAllGradeSections();
            index =sections.FindIndex(gs => gs.GradeSectionCode== sectioncode);
            return sections[index].Section;
            
        }
        public Boolean CreateGradeSection(ref GradeSectionBDO gsbdo, ref string message) {
            return gsDao.CreateGradeSection(ref gsbdo, ref message);
        }

        public Boolean UpdateGradeSection(ref GradeSectionBDO gsbdo, ref string message) {
            return gsDao.UpdateGradeSection(ref gsbdo, ref message);
        }
    }
}