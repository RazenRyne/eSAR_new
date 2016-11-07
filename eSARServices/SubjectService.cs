using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSARBDO;
using eSARLogic;
using eSARServiceInterface;
using eSARServiceModels;

namespace eSARServices
{
    public class SubjectService : ISubjectService
    {
        SubjectLogic slogic = new SubjectLogic();
        public List<Subject> GetAllSubjects()
        {
            List<Subject> sList = new List<Subject>();
            sList = ToSubjectList(slogic.GetAllSubjects());
            return sList;
        }

        public Subject GetSubject(string subjectCode)
        {
            Subject s = new Subject();
            TranslateSubjectBDOToSubject(slogic.GetSubject(subjectCode), s);
            return s;
        }

        public List<Subject> GetAllSubjectsOfGradeLevel(string gradeLevel)
        {
            List<Subject> sList = new List<Subject>();
            sList = ToSubjectList(slogic.GetAllSubjectsOfGradeLevel(gradeLevel));
            return sList;
        }

        public List<Subject> GetAllSubjectsOfLearningArea(string learningAreaCode)
        {
            List<Subject> sList = new List<Subject>();
            sList = ToSubjectList(slogic.GetAllSubjectsOfLearningArea(learningAreaCode));
            return sList;
        }

        public List<Subject> ToSubjectList(List<SubjectBDO> sList)
        {
            List<Subject> slist = new List<Subject>();
            foreach (SubjectBDO s in sList)
            {
                Subject sbdo = new Subject();
                sbdo.SubjectID = s.SubjectID;
                sbdo.LearningAreaCode = s.LearningAreaCode;
                sbdo.Description = s.Description;
                sbdo.GradeLevel = s.GradeLevel;
                sbdo.SubjectCode = s.SubjectCode;
                sbdo.Academic = s.Academic;// s.LearningArea.Academic ?? false;
                sbdo.MPW = s.MPW;
                slist.Add(sbdo);
            }
            return slist;
        }

        public List<SubjectBDO> ToSubjectBDOList(List<Subject> sList)
        {
            List<SubjectBDO> slist = new List<SubjectBDO>();
            foreach (Subject s in sList)
            {
                SubjectBDO sbdo = new SubjectBDO();
                sbdo.LearningAreaCode = s.LearningAreaCode;
                sbdo.Description = s.Description;
                sbdo.GradeLevel = s.GradeLevel;
                sbdo.SubjectCode = s.SubjectCode;
                sbdo.MPW = s.MPW;
                sbdo.Academic = s.Academic;
                slist.Add(sbdo);
            }
            return slist;
        }

        public void TranslateSubjectToSubjectBDO(Subject sub, SubjectBDO sbdo)
        {
            LearningAreaService las = new LearningAreaService();
            LearningAreaBDO lb = new LearningAreaBDO();
            sbdo.SubjectID = sub.SubjectID;
            sbdo.Description = sub.Description;
            sbdo.GradeLevel = sub.GradeLevel;
            sbdo.LearningAreaCode = sub.LearningAreaCode;
            sbdo.SubjectCode = sub.SubjectCode;
            sbdo.MPW = sub.MPW;
            sbdo.Academic = sub.Academic;
            las.TranslateLearningAreaToLearningAreaBDO(sub.LArea, lb);
            sbdo.LearningArea = lb;
        }

        public void TranslateSubjectBDOToSubject(SubjectBDO sub, Subject sbdo)
        {
            //LearningAreaService las = new LearningAreaService();
            //LearningArea lb = new LearningArea();
            sbdo.SubjectID = sub.SubjectID;
            sbdo.Description = sub.Description;
            sbdo.GradeLevel = sub.GradeLevel;
            sbdo.LearningAreaCode = sub.LearningAreaCode;
            sbdo.SubjectCode = sub.SubjectCode;
            sbdo.Academic = sub.Academic;
            sbdo.MPW = sub.MPW;
            //  las.TranslateLearningAreaBDOToLearningArea(sub.LearningArea, lb);
            // sbdo.LArea = lb;
        }
    }
}
