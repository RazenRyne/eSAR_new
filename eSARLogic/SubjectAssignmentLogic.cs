using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSARBDO;
using eSARDAL;
namespace eSARLogic
{
    public class SubjectAssignmentLogic
    {
        SubjectAssignmentDAO schedDAO = new SubjectAssignmentDAO();

        public Boolean CreateSchedule(ref SubjectAssignmentBDO schedBDO, ref string message)
        {
            Boolean ret = false;

            ret = schedDAO.CreateSchedule(ref schedBDO, ref message);

            return ret;
        }

        public Boolean CreateSchedule(List<SubjectAssignmentBDO> schedBDO, ref string message) {
            Boolean ret = true;
            foreach (SubjectAssignmentBDO sa in schedBDO) {
                SubjectAssignmentBDO sab = sa;
                schedDAO.CreateSchedule(ref sab, ref message);
            }
            return ret;
        }

        public Boolean UpdateSchedule(List<SubjectAssignmentBDO> schedBDO, ref string message)
        {
            Boolean ret = true;
            foreach (SubjectAssignmentBDO sa in schedBDO)
            {
                SubjectAssignmentBDO sab = sa;
                schedDAO.UpdateSchedule(ref sab, ref message);
            }
            return ret;
        }

        public List<SubjectAssignmentBDO> GetAllSchedules(string sy) {
            return schedDAO.GetAllSchedules(sy);
        }

        public List<SubjectAssignmentBDO> GetAllSchedules()
        {
            return schedDAO.GetAllSchedules();
        }

        public List<SubjectAssignmentBDO> GetAllSchedulesbySection(int iGradeSection)
        {
            return schedDAO.GetAllSchedulesbySection(iGradeSection);
        }

        public Boolean DeleteSchedule(int schedID, ref string message) {
            return schedDAO.DeleteSchedule(schedID, ref message);
        }

        public List<SubjectAssignmentBDO> GetScheduleForGradeLevel(string Grade) {
             List<SubjectAssignmentBDO> allSched = new List<SubjectAssignmentBDO>();
            allSched = GetAllSchedules();

            List<SubjectAssignmentBDO> gradeSched = new List<SubjectAssignmentBDO>();
            gradeSched = allSched.FindAll(item => item.GradeLevel.Equals(Grade));
                     
                return gradeSched;
        }

        public List<SubjectAssignmentBDO> GetScheduleInfo(List<int> subjectAssignmentId) {
            List<SubjectAssignmentBDO> sched = new List<SubjectAssignmentBDO>();
            foreach (int i in subjectAssignmentId) {
                sched.Add(schedDAO.GetScheduleInfo(i));
            }

            return sched;
        }
    }
}
