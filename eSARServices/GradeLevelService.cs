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
    public class GradeLevelService : IGradeLevelService
    {
        GradeLevelLogic glogic = new GradeLevelLogic();
        public List<GradeLevel> GetAllGradeLevels()
        {
            List<GradeLevelBDO> glBDOList = glogic.GetAllGradeLevels();
            List<GradeLevel> glList = new List<GradeLevel>();
            foreach (GradeLevelBDO glBDo in glBDOList)
            {
                GradeLevel g = new GradeLevel();
                TranslateGradeLevelBDOToeGradeLevelDTo(glBDo, g);
                glList.Add(g);
            }
            return glList;
        }    

        public string GetGradeLevel(string gradeLevel)
        {
            return glogic.GetGradeLevel(gradeLevel);
        }

        public GradeLevel NextGradeLevel(string grade)
        {
            GradeLevel gl = new GradeLevel();
            TranslateGradeLevelBDOToeGradeLevelDTo(glogic.NextGradeLevel(grade), gl);
            return gl;
        }

        public void TranslateGradeLevelToGradeLevelBDO(GradeLevel gl, GradeLevelBDO g)
        {
            FeeService fs = new FeeService();
            TraitService ts = new TraitService();
            g.Description = gl.Description;
            g.GradeLev = gl.GradeLev;
            g.Category = gl.Category;
            g.StudentFees = fs.ToFeeBDOList(gl.StudentFees);
            //  g.Traits = ts.ToTraitBDOList(gl.Traits);
        }

        private void TranslateGradeLevelBDOToeGradeLevelDTo(GradeLevelBDO glBDO, GradeLevel gradeLevel)
        {
            gradeLevel.Description = glBDO.Description;
            gradeLevel.GradeLev = glBDO.GradeLev;
            gradeLevel.Category = glBDO.Category;
        }
    }
}
