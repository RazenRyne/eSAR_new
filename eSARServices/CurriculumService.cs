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
    public class CurriculumService : ICurriculumService
    {
        CurriculumLogic clogic = new CurriculumLogic();


        public List<GradeLevel> GetAllGradeLevels()
        {
            GradeLevelService gs = new GradeLevelService();
            return gs.GetAllGradeLevels();
        }

        public List<CurriculumSubject> GetAllSubjectDetails()
        {
            SubjectService ss = new SubjectService();
            List<CurriculumSubject> csList = new List<CurriculumSubject>();
            List<Subject> sList = new List<Subject>(ss.GetAllSubjects());
            foreach (Subject s in sList)
            {
                CurriculumSubject cs = new CurriculumSubject();
                TranslateCurrSub(s, cs);
                csList.Add(cs);
            }
            return csList;
        }

        public List<CurriculumSubject> GetAllSubjectsOfGradeLevel(string gradeLevel)
        {
            SubjectService ss = new SubjectService();
            List<CurriculumSubject> csList = new List<CurriculumSubject>();
            List<Subject> sList = new List<Subject>();
            sList = ss.GetAllSubjectsOfGradeLevel(gradeLevel);
            foreach (Subject s in sList)
            {
                CurriculumSubject cs = new CurriculumSubject();
                TranslateCurrSub(s, cs);
                csList.Add(cs);
            }
            return csList;
        }

        public void TranslateCurrSub(Subject s, CurriculumSubject cs)
        {
            LearningAreaService las = new LearningAreaService();
            LearningArea la = new LearningArea();
            SubjectService ss = new SubjectService();
            Subject subj = new Subject();
            subj = ss.GetSubject(s.SubjectCode);
            cs.Subj = s;
            cs.SubjectCode = s.SubjectCode;
            la = las.GetLearningArea(s.LearningAreaCode);
            cs.Academic = la.Academic;
            cs.RatePerUnit = la.RatePerUnit;
            cs.Units = la.Units;
            cs.SubjectDescription = subj.Description;
            cs.GradeLevel = subj.GradeLevel;
            cs.LearningAreaCode = subj.LearningAreaCode;
        }

        public bool CreateCurriculum(ref Curriculum curriculum, ref string message)
        {
            CurriculumBDO cbdo = new CurriculumBDO();
            TranslateCurriculumToCurriculumBDO(curriculum, cbdo);
            return clogic.CreateCurriculum(ref cbdo, ref message);
        }

        public List<Curriculum> GetAllCurriculums()
        {
            List<Curriculum> curList = new List<Curriculum>();
            foreach (CurriculumBDO curr in clogic.GetAllCurriculums())
            {
                Curriculum c = new Curriculum();
                TranslateCurriculumBDOToCurriculum(curr, c);
                curList.Add(c);
            }
            return curList;
        }

        public List<CurriculumSubject> GetCurriculumSubjects(string currCode)
        {
            List<CurriculumSubject> csList = new List<CurriculumSubject>();
            foreach (CurriculumSubjectBDO cb in clogic.GetAllCurriculumSubjects(currCode))
            {
                CurriculumSubject cs = new CurriculumSubject();
                TranslateCurriculumSubjectBDOToCurriculumSubject(cb, cs);
                csList.Add(cs);
            }
            return csList;
        }

        public bool UpdateCurriculum(ref Curriculum curriculum, ref string message)
        {
            CurriculumBDO cb = new CurriculumBDO();
            TranslateCurriculumToCurriculumBDO(curriculum, cb);
            return clogic.UpdateCurriculum(ref cb, ref message);
        }

        private void TranslateCurriculumToCurriculumBDO(Curriculum curriculum, CurriculumBDO cbdo)
        {
            cbdo.CurrentCurr = curriculum.CurrentCurr;
            cbdo.CurriculumCode = curriculum.CurriculumCode;
            cbdo.Description = curriculum.Description;
            cbdo.CurriculumSubjects = ToCurriculumSubjectBDOList(curriculum.CurriculumSubjects.ToList<CurriculumSubject>());

        }
        private void TranslateCurriculumBDOToCurriculum(CurriculumBDO curriculum, Curriculum cbdo)
        {
            cbdo.CurrentCurr = curriculum.CurrentCurr;
            cbdo.CurriculumCode = curriculum.CurriculumCode;
            cbdo.Description = curriculum.Description;
            cbdo.CurriculumSubjects = ToCurriculumSubjectList(curriculum.CurriculumSubjects);

        }

        private List<CurriculumSubjectBDO> ToCurriculumSubjectBDOList(List<CurriculumSubject> csList)
        {
            List<CurriculumSubjectBDO> csbdoList = new List<CurriculumSubjectBDO>();
            foreach (CurriculumSubject cs in csList)
            {
                CurriculumSubjectBDO csbdo = new CurriculumSubjectBDO();
                TranslateCurriculumSubjectToCurriculumSubjectBDO(cs, csbdo);
                csbdoList.Add(csbdo);
            }
            return csbdoList;
        }
        private List<CurriculumSubject> ToCurriculumSubjectList(List<CurriculumSubjectBDO> csList)
        {
            List<CurriculumSubject> csbList = new List<CurriculumSubject>();
            foreach (CurriculumSubjectBDO cs in csList)
            {
                CurriculumSubject csbdo = new CurriculumSubject();
                TranslateCurriculumSubjectBDOToCurriculumSubject(cs, csbdo);
                csbList.Add(csbdo);
            }
            return csbList;
        }

        private void TranslateCurriculumSubjectToCurriculumSubjectBDO(CurriculumSubject cs, CurriculumSubjectBDO csbdo)
        {
            csbdo.CurriculumCode = cs.CurriculumCode;
            csbdo.CurrSubCode = cs.CurrSubCode;
            csbdo.Deactivated = cs.Deactivated;
            csbdo.CurriculumSubjectsID = cs.CurriculumSubjectsID;
            csbdo.SubjectCode = cs.SubjectCode;
        }

        private void TranslateCurriculumSubjectBDOToCurriculumSubject(CurriculumSubjectBDO cs, CurriculumSubject csbdo)
        {
            Subject sbdo = new Subject();
            SubjectService ss = new SubjectService();
            LearningAreaService las = new LearningAreaService();
            LearningArea la = new LearningArea();
            csbdo.CurriculumSubjectsID = cs.CurriculumSubjectsID;
            csbdo.CurriculumCode = cs.CurriculumCode;
            csbdo.CurrSubCode = cs.CurrSubCode;
            csbdo.Deactivated = cs.Deactivated;
            ss.TranslateSubjectBDOToSubject(cs.Sub, sbdo);
            csbdo.Subj = sbdo;
            csbdo.SubjectCode = cs.SubjectCode;
            la = las.GetLearningArea(sbdo.LearningAreaCode);
            csbdo.Academic = la.Academic;
            csbdo.RatePerUnit = la.RatePerUnit;
            csbdo.Units = la.Units;
            csbdo.SubjectDescription = sbdo.Description;
            csbdo.GradeLevel = sbdo.GradeLevel;
            csbdo.LearningAreaCode = sbdo.LearningAreaCode;

        }

        private void TranslateLearningAreaToLearningAreaBDO(LearningArea la, LearningAreaBDO labdo)
        {
            SubjectService ss = new SubjectService();
            labdo.Academic = la.Academic;
            labdo.Description = la.Description;
            labdo.LearningAreaCode = la.LearningAreaCode;
            labdo.RatePerUnit = la.RatePerUnit;
            labdo.Units = la.Units;
            labdo.Subjects = ss.ToSubjectBDOList(la.Subjects);
        }
    }
}
