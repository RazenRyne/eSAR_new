using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSARBDO;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace eSARDAL
{
    public class TeacherDAO
    {
        public TeacherBDO GetTeacherBDO(string teacherId)
        {
            TeacherBDO teacherBDO = null;
            try{ 
            using (var DCEnt = new DCFIEntities())
            {
                Teacher teacher = (from t in DCEnt.Teachers
                                   where t.TeacherId == teacherId
                                   select t).FirstOrDefault();
                if (teacher != null)
                {
                    teacherBDO = new TeacherBDO();
                    ConvertTeacherToTeacherBDO(teacher, teacherBDO);

                }
            }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
            return teacherBDO;
        }

        public TeacherBDO GetTeacherBDO(string lastname, string firstname)
        {
            TeacherBDO teacherBDO = null;
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                Teacher teacher = (from t in DCEnt.Teachers
                                   where (t.LastName == lastname) && (t.FirstName == firstname)
                                   select t).FirstOrDefault();
                if (teacher != null)
                {
                    teacherBDO = new TeacherBDO();
                    ConvertTeacherToTeacherBDO(teacher, teacherBDO);

                }
            }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
            return teacherBDO;
        }

        public TeacherBDO GetTeacherBDO(string lastname, string firstname, string mname)
        {
            TeacherBDO teacherBDO = null;
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                Teacher teacher = (from t in DCEnt.Teachers
                                   where (t.LastName.Equals(lastname) && t.FirstName.Equals(firstname) && t.MiddleName.Equals(mname))
                                   select t).FirstOrDefault();
                if (teacher != null)
                {
                    teacherBDO = new TeacherBDO();
                    ConvertTeacherToTeacherBDO(teacher, teacherBDO);

                }
            }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
            return teacherBDO;
        }


        public List<TeacherBDO> GetAllTeachers()
        {
            List<Teacher> teacherList = new List<Teacher>();
            List<TeacherBDO> teacherBDOList = new List<TeacherBDO>();
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                teacherList = (from t in DCEnt.Teachers
                               where t.Deactivated == false
                               orderby t.LastName
                               select t).ToList<Teacher>();

            }

       
            foreach (Teacher t in teacherList)
            {
                TeacherBDO teacherBDO = new TeacherBDO();
                ConvertTeacherToTeacherBDO(t, teacherBDO);
                teacherBDOList.Add(teacherBDO);
            }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
            return teacherBDOList;
        }

        public List<TeacherBDO> GetFilteredTeachers(string searchType, string search)
        {
            List<Teacher> teacherList = new List<Teacher>();
            List<TeacherBDO> teacherBDOList = new List<TeacherBDO>();
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                if (searchType == "Teacher ID")
                {
                    teacherList = (from t in DCEnt.Teachers
                                   where t.Deactivated == false
                                   && t.TeacherId.Contains(search)
                                   select t).ToList<Teacher>();
                }

                if (searchType == "First Name")
                {
                    teacherList = (from t in DCEnt.Teachers
                                   where t.Deactivated == false
                                   && t.FirstName.Contains(search)
                                   select t).ToList<Teacher>();
                }

                if (searchType == "Middle Name")
                {
                    teacherList = (from t in DCEnt.Teachers
                                   where t.Deactivated == false
                                   && t.MiddleName.Contains(search)
                                   select t).ToList<Teacher>();
                }

                if (searchType == "Last Name")
                {
                    teacherList = (from t in DCEnt.Teachers
                                   where t.Deactivated == false
                                   && t.LastName.Contains(search)
                                   select t).ToList<Teacher>();
                }

            }

         
            foreach (Teacher t in teacherList)
            {
                TeacherBDO teacherBDO = new TeacherBDO();
                ConvertTeacherToTeacherBDO(t, teacherBDO);
                teacherBDOList.Add(teacherBDO);
            }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
            return teacherBDOList;
        }

        public string GetLatestTeacherId()
        {
            string teacherId = "none";
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                teacherId = (from t in DCEnt.Teachers
                             orderby t.TeacherId descending
                             select t.TeacherId).FirstOrDefault();
            }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
            if (teacherId == null) teacherId = "none";
                
                return teacherId;
        }

        public Boolean CreateTeacher(ref TeacherBDO teacher, ref string message)
        {
            message = "Teacher Added Successfully";
            bool ret = true;
            Teacher t = new Teacher();
            try { 
            ConvertTeacherBDOToTeacher(teacher, t);
            using (var DCEnt = new DCFIEntities())
            {
                DCEnt.Teachers.Add(t);

                DCEnt.SaveChanges();
              }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
            return ret;
        }

        public Boolean UpdateTeacher(ref TeacherBDO teacher, ref string message)
        {
            message = "Teacher updated successfully.";
            Boolean ret = true;
            Teacher t = new Teacher();
            try {
               ConvertTeacherBDOToTeacher(teacher, t);
            Teacher teacherInDB = new Teacher();
            using (var DCEnt = new DCFIEntities())
            {
                var teacherID = teacher.TeacherId;
                teacherInDB = (from tea in DCEnt.Teachers
                               where tea.TeacherId.Equals(teacherID)
                               select tea).FirstOrDefault();


                if (teacherInDB == null)
                {
                    throw new Exception("No teacher with ID " + teacher.TeacherId);
                }

                //1st Part
                if (teacherInDB.TeacherChildrens.Count == 0)
                {
                    foreach (TeacherChildren tc in t.TeacherChildrens)
                    {
                        teacherInDB.TeacherChildrens.Add(tc);
                    }
                }
                else if (teacherInDB.TeacherChildrens.Count < t.TeacherChildrens.Count)
                {
                    //compare 2 lists check the non existing to the other
                    IEnumerable<TeacherChildren> tcToAdd = t.TeacherChildrens.Except(teacherInDB.TeacherChildrens);
                    if (tcToAdd != null)
                    {
                        foreach (TeacherChildren child in tcToAdd)
                        {
                            teacherInDB.TeacherChildrens.Add(child);
                        }
                    }

                    IEnumerable<TeacherChildren> tcToRemove = teacherInDB.TeacherChildrens.Except(t.TeacherChildrens);
                    if (tcToRemove != null)
                    {
                        foreach (TeacherChildren child in tcToRemove)
                        {
                            teacherInDB.TeacherChildrens.Add(child);
                        }
                    }

                }
                else if (teacherInDB.TeacherChildrens.Count > t.TeacherChildrens.Count)
                {
                    //compare 2 lists check the non existing to the other
                    IEnumerable<TeacherChildren> tcToAdd = t.TeacherChildrens.Except(teacherInDB.TeacherChildrens);
                    if (tcToAdd != null)
                    {
                        foreach (TeacherChildren child in tcToAdd)
                        {
                            teacherInDB.TeacherChildrens.Add(child);
                        }
                    }

                    IEnumerable<TeacherChildren> tcToRemove = teacherInDB.TeacherChildrens.Except(t.TeacherChildrens);
                    if (tcToRemove != null)
                    {
                        foreach (TeacherChildren child in tcToRemove)
                        {
                            teacherInDB.TeacherChildrens.Add(child);
                        }
                    }
                }
                else if (teacherInDB.TeacherChildrens.Count == t.TeacherChildrens.Count)
                {
                    //compare 2 lists check the non existing to the other
                    IEnumerable<TeacherChildren> tcToAdd = t.TeacherChildrens.Except(teacherInDB.TeacherChildrens);
                    if (tcToAdd != null)
                    {
                        foreach (TeacherChildren child in tcToAdd)
                        {
                            teacherInDB.TeacherChildrens.Add(child);
                        }
                    }

                    IEnumerable<TeacherChildren> tcToRemove = teacherInDB.TeacherChildrens.Except(t.TeacherChildrens);
                    if (tcToRemove != null)
                    {
                        foreach (TeacherChildren child in tcToRemove)
                        {
                            teacherInDB.TeacherChildrens.Add(child);
                        }
                    }

                }

                //2nd Part
                if (teacherInDB.TeacherEligibilities.Count == 0)
                {
                    foreach (TeacherEligibility te in t.TeacherEligibilities)
                    {
                        teacherInDB.TeacherEligibilities.Add(te);
                    }
                }
                else if (teacherInDB.TeacherEligibilities.Count < t.TeacherEligibilities.Count)
                {
                    //compare 2 lists check the non existing to the other
                    IEnumerable<TeacherEligibility> tcToAdd = t.TeacherEligibilities.Except(teacherInDB.TeacherEligibilities);
                    if (tcToAdd != null)
                    {
                        foreach (TeacherEligibility child in tcToAdd)
                        {
                            teacherInDB.TeacherEligibilities.Add(child);
                        }
                    }

                    IEnumerable<TeacherEligibility> tcToRemove = teacherInDB.TeacherEligibilities.Except(t.TeacherEligibilities);
                    if (tcToRemove != null)
                    {
                        foreach (TeacherEligibility child in tcToRemove)
                        {
                            teacherInDB.TeacherEligibilities.Add(child);
                        }
                    }

                }
                else if (teacherInDB.TeacherEligibilities.Count > t.TeacherEligibilities.Count)
                {
                    //compare 2 lists check the non existing to the other
                    IEnumerable<TeacherEligibility> tcToAdd = t.TeacherEligibilities.Except(teacherInDB.TeacherEligibilities);
                    if (tcToAdd != null)
                    {
                        foreach (TeacherEligibility child in tcToAdd)
                        {
                            teacherInDB.TeacherEligibilities.Add(child);
                        }
                    }

                    IEnumerable<TeacherEligibility> tcToRemove = teacherInDB.TeacherEligibilities.Except(t.TeacherEligibilities);
                    if (tcToRemove != null)
                    {
                        foreach (TeacherEligibility child in tcToRemove)
                        {
                            teacherInDB.TeacherEligibilities.Add(child);
                        }
                    }
                }
                else if (teacherInDB.TeacherEligibilities.Count == t.TeacherEligibilities.Count)
                {
                    //compare 2 lists check the non existing to the other
                    IEnumerable<TeacherEligibility> tcToAdd = t.TeacherEligibilities.Except(teacherInDB.TeacherEligibilities);
                    if (tcToAdd != null)
                    {
                        foreach (TeacherEligibility child in tcToAdd)
                        {
                            teacherInDB.TeacherEligibilities.Add(child);
                        }
                    }

                    IEnumerable<TeacherEligibility> tcToRemove = teacherInDB.TeacherEligibilities.Except(t.TeacherEligibilities);
                    if (tcToRemove != null)
                    {
                        foreach (TeacherEligibility child in tcToRemove)
                        {
                            teacherInDB.TeacherEligibilities.Add(child);
                        }
                    }

                }


                //3rd Part
                if (teacherInDB.TeacherEducationalBackgrounds.Count == 0)
                {
                    foreach (TeacherEducationalBackground eb in t.TeacherEducationalBackgrounds)
                    {
                        teacherInDB.TeacherEducationalBackgrounds.Add(eb);
                    }
                }

                else if (teacherInDB.TeacherEducationalBackgrounds.Count < t.TeacherEducationalBackgrounds.Count)
                {
                    //compare 2 lists check the non existing to the other
                    IEnumerable<TeacherEducationalBackground> tcToAdd = t.TeacherEducationalBackgrounds.Except(teacherInDB.TeacherEducationalBackgrounds);
                    if (tcToAdd != null)
                    {
                        foreach (TeacherEducationalBackground child in tcToAdd)
                        {
                            teacherInDB.TeacherEducationalBackgrounds.Add(child);
                        }
                    }

                    IEnumerable<TeacherEducationalBackground> tcToRemove = teacherInDB.TeacherEducationalBackgrounds.Except(t.TeacherEducationalBackgrounds);
                    if (tcToRemove != null)
                    {
                        foreach (TeacherEducationalBackground child in tcToRemove)
                        {
                            teacherInDB.TeacherEducationalBackgrounds.Add(child);
                        }
                    }

                }
                else if (teacherInDB.TeacherEducationalBackgrounds.Count > t.TeacherEducationalBackgrounds.Count)
                {
                    //compare 2 lists check the non existing to the other
                    IEnumerable<TeacherEducationalBackground> tcToAdd = t.TeacherEducationalBackgrounds.Except(teacherInDB.TeacherEducationalBackgrounds);
                    if (tcToAdd != null)
                    {
                        foreach (TeacherEducationalBackground child in tcToAdd)
                        {
                            teacherInDB.TeacherEducationalBackgrounds.Add(child);
                        }
                    }

                    IEnumerable<TeacherEducationalBackground> tcToRemove = teacherInDB.TeacherEducationalBackgrounds.Except(t.TeacherEducationalBackgrounds);
                    if (tcToRemove != null)
                    {
                        foreach (TeacherEducationalBackground child in tcToRemove)
                        {
                            teacherInDB.TeacherEducationalBackgrounds.Add(child);
                        }
                    }
                }
                else if (teacherInDB.TeacherEducationalBackgrounds.Count == t.TeacherEducationalBackgrounds.Count)
                {
                    //compare 2 lists check the non existing to the other
                    IEnumerable<TeacherEducationalBackground> tcToAdd = t.TeacherEducationalBackgrounds.Except(teacherInDB.TeacherEducationalBackgrounds);
                    if (tcToAdd != null)
                    {
                        foreach (TeacherEducationalBackground child in tcToAdd)
                        {
                            teacherInDB.TeacherEducationalBackgrounds.Add(child);
                        }
                    }

                    IEnumerable<TeacherEducationalBackground> tcToRemove = teacherInDB.TeacherEducationalBackgrounds.Except(t.TeacherEducationalBackgrounds);
                    if (tcToRemove != null)
                    {
                        foreach (TeacherEducationalBackground child in tcToRemove)
                        {
                            teacherInDB.TeacherEducationalBackgrounds.Add(child);
                        }
                    }

                }


                //4th Part
                if (teacherInDB.TrainingSeminars.Count == 0)
                {
                    foreach (TrainingSeminar ts in t.TrainingSeminars)
                    {
                        teacherInDB.TrainingSeminars.Add(ts);
                    }
                }
                else if (teacherInDB.TrainingSeminars.Count < t.TrainingSeminars.Count)
                {
                    //compare 2 lists check the non existing to the other
                    IEnumerable<TrainingSeminar> tcToAdd = t.TrainingSeminars.Except(teacherInDB.TrainingSeminars);
                    if (tcToAdd != null)
                    {
                        foreach (TrainingSeminar child in tcToAdd)
                        {
                            teacherInDB.TrainingSeminars.Add(child);
                        }
                    }

                    IEnumerable<TrainingSeminar> tcToRemove = teacherInDB.TrainingSeminars.Except(t.TrainingSeminars);
                    if (tcToRemove != null)
                    {
                        foreach (TrainingSeminar child in tcToRemove)
                        {
                            teacherInDB.TrainingSeminars.Add(child);
                        }
                    }

                }
                else if (teacherInDB.TrainingSeminars.Count > t.TrainingSeminars.Count)
                {
                    //compare 2 lists check the non existing to the other
                    IEnumerable<TrainingSeminar> tcToAdd = t.TrainingSeminars.Except(teacherInDB.TrainingSeminars);
                    if (tcToAdd != null)
                    {
                        foreach (TrainingSeminar child in tcToAdd)
                        {
                            teacherInDB.TrainingSeminars.Add(child);
                        }
                    }

                    IEnumerable<TrainingSeminar> tcToRemove = teacherInDB.TrainingSeminars.Except(t.TrainingSeminars);
                    if (tcToRemove != null)
                    {
                        foreach (TrainingSeminar child in tcToRemove)
                        {
                            teacherInDB.TrainingSeminars.Add(child);
                        }
                    }
                }
                else if (teacherInDB.TrainingSeminars.Count == t.TrainingSeminars.Count)
                {
                    //compare 2 lists check the non existing to the other
                    IEnumerable<TrainingSeminar> tcToAdd = t.TrainingSeminars.Except(teacherInDB.TrainingSeminars);
                    if (tcToAdd != null)
                    {
                        foreach (TrainingSeminar child in tcToAdd)
                        {
                            teacherInDB.TrainingSeminars.Add(child);
                        }
                    }

                    IEnumerable<TrainingSeminar> tcToRemove = teacherInDB.TrainingSeminars.Except(t.TrainingSeminars);
                    if (tcToRemove != null)
                    {
                        foreach (TrainingSeminar child in tcToRemove)
                        {
                            teacherInDB.TrainingSeminars.Add(child);
                        }
                    }

                }


                //5th Part
                if (teacherInDB.WorkExperiences.Count == 0)
                {
                    foreach (WorkExperience we in t.WorkExperiences)
                    {
                        teacherInDB.WorkExperiences.Add(we);
                    }
                }
                else if (teacherInDB.WorkExperiences.Count < t.WorkExperiences.Count)
                {
                    //compare 2 lists check the non existing to the other
                    IEnumerable<WorkExperience> tcToAdd = t.WorkExperiences.Except(teacherInDB.WorkExperiences);
                    if (tcToAdd != null)
                    {
                        foreach (WorkExperience child in tcToAdd)
                        {
                            teacherInDB.WorkExperiences.Add(child);
                        }
                    }

                    IEnumerable<WorkExperience> tcToRemove = teacherInDB.WorkExperiences.Except(t.WorkExperiences);
                    if (tcToRemove != null)
                    {
                        foreach (WorkExperience child in tcToRemove)
                        {
                            teacherInDB.WorkExperiences.Add(child);
                        }
                    }

                }
                else if (teacherInDB.WorkExperiences.Count > t.WorkExperiences.Count)
                {
                    //compare 2 lists check the non existing to the other
                    IEnumerable<WorkExperience> tcToAdd = t.WorkExperiences.Except(teacherInDB.WorkExperiences);
                    if (tcToAdd != null)
                    {
                        foreach (WorkExperience child in tcToAdd)
                        {
                            teacherInDB.WorkExperiences.Add(child);
                        }
                    }

                    IEnumerable<WorkExperience> tcToRemove = teacherInDB.WorkExperiences.Except(t.WorkExperiences);
                    if (tcToRemove != null)
                    {
                        foreach (WorkExperience child in tcToRemove)
                        {
                            teacherInDB.WorkExperiences.Add(child);
                        }
                    }
                }
                else if (teacherInDB.WorkExperiences.Count == t.WorkExperiences.Count)
                {
                    //compare 2 lists check the non existing to the other
                    IEnumerable<WorkExperience> tcToAdd = t.WorkExperiences.Except(teacherInDB.WorkExperiences);
                    if (tcToAdd != null)
                    {
                        foreach (WorkExperience child in tcToAdd)
                        {
                            teacherInDB.WorkExperiences.Add(child);
                        }
                    }

                    IEnumerable<WorkExperience> tcToRemove = teacherInDB.WorkExperiences.Except(t.WorkExperiences);
                    if (tcToRemove != null)
                    {
                        foreach (WorkExperience child in tcToRemove)
                        {
                            teacherInDB.WorkExperiences.Add(child);
                        }
                    }
                }
                using (var DC = new DCFIEntities())
                {
                    //   DC.Teachers.Remove(teacherInDB);
                    teacherInDB = t;

                    foreach (TeacherChildren tc in teacherInDB.TeacherChildrens)
                        DC.Entry(tc).State = tc.ChildId == 0 ? System.Data.Entity.EntityState.Added : System.Data.Entity.EntityState.Modified;

                    foreach (TeacherEducationalBackground tc in teacherInDB.TeacherEducationalBackgrounds)
                        DC.Entry(tc).State = tc.TEBId == 0 ? System.Data.Entity.EntityState.Added : System.Data.Entity.EntityState.Modified;

                    foreach (TeacherEligibility tc in teacherInDB.TeacherEligibilities)
                        DC.Entry(tc).State = tc.EligibilityId == 0 ? System.Data.Entity.EntityState.Added : System.Data.Entity.EntityState.Modified;

                    foreach (TrainingSeminar tc in teacherInDB.TrainingSeminars)
                        DC.Entry(tc).State = tc.TSID == 0 ? System.Data.Entity.EntityState.Added : System.Data.Entity.EntityState.Modified;

                    foreach (WorkExperience tc in teacherInDB.WorkExperiences)
                        DC.Entry(tc).State = tc.WEId == 0 ? System.Data.Entity.EntityState.Added : System.Data.Entity.EntityState.Modified;

                    DC.Entry(teacherInDB).State = System.Data.Entity.EntityState.Modified;
                    
                    int num = DC.SaveChanges();

                    if (num > 0)
                    {
                        //  ret = false;
                        message = "No teacher is updated.";
                    }
                }
            }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
            return ret;

        }

        public List<TeacherChildrenBDO> GetAllChildren(string teacherId)
        {
            List<TeacherChildrenBDO> childrenList = new List<TeacherChildrenBDO>();
            try { 
            ICollection<TeacherChildren> children;
            using (var DCEnt = new DCFIEntities())
            {
                children = (from t in DCEnt.TeacherChildrens
                            where t.TeacherId.Equals(teacherId)
                            select t).ToList<TeacherChildren>();
            }
            childrenList = ToChildrenBDOList(children);
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
            return childrenList;
        }

        public List<TeacherEligibilityBDO> GetAllEligibility(string teacherId)
        {
            List<TeacherEligibilityBDO> eligibilityList = new List<TeacherEligibilityBDO>();
            ICollection<TeacherEligibility> eligibility;
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                eligibility = (from t in DCEnt.TeacherEligibilities
                               where t.TeacherId.Equals(teacherId)
                               select t).ToList<TeacherEligibility>();
            }
            eligibilityList = ToEligibilityBDOList(eligibility);
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
            return eligibilityList;
        }

        public List<TeacherEducationalBackgroundBDO> GetAllEducationalBackground(string teacherId)
        {
            List<TeacherEducationalBackgroundBDO> educList = new List<TeacherEducationalBackgroundBDO>();
            ICollection<TeacherEducationalBackground> education;
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                education = (from t in DCEnt.TeacherEducationalBackgrounds
                             where t.TeacherId.Equals(teacherId)
                             select t).ToList<TeacherEducationalBackground>();
            }
            educList = ToEducationalBackBDOList(education);
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
            return educList;
        }

        public List<TrainingSeminarBDO> GetAllTrainingSeminars(string teacherId)
        {
            List<TrainingSeminarBDO> trainList = new List<TrainingSeminarBDO>();
            ICollection<TrainingSeminar> training;
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                training = (from t in DCEnt.TrainingSeminars
                            where t.TeacherId.Equals(teacherId)
                            select t).ToList<TrainingSeminar>();
            }
            trainList = ToTrainingSeminarBDOList(training);
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
            return trainList;
        }

        public List<WorkExperienceBDO> GetAllWorkExperience(string teacherId)
        {
            List<WorkExperienceBDO> workList = new List<WorkExperienceBDO>();
            ICollection<WorkExperience> work;
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                work = (from t in DCEnt.WorkExperiences
                        where t.TeacherId.Equals(teacherId)
                        select t).ToList<WorkExperience>();
            }
            workList = ToWorkExperienceBDOList(work);
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
            return workList;
        }

        private ICollection<TrainingSeminar> ToTrainingSeminarList(List<TrainingSeminarBDO> tcl)
        {
            ICollection<TrainingSeminar> tsList = new List<TrainingSeminar>();
            try { 
            foreach (TrainingSeminarBDO tsb in tcl)
            {
                TrainingSeminar ts = new TrainingSeminar();
                ConvertTrainingSeminarBDOToTrainingSeminar(tsb, ts);
                tsList.Add(ts);
            }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
            return tsList;
        }

        private List<TrainingSeminarBDO> ToTrainingSeminarBDOList(ICollection<TrainingSeminar> tcl)
        {
            List<TrainingSeminarBDO> tsList = new List<TrainingSeminarBDO>();
            foreach (TrainingSeminar tsb in tcl)
            {
                TrainingSeminarBDO ts = new TrainingSeminarBDO();
                ConvertTrainingSeminarToTrainingSeminarBDO(tsb, ts);
                tsList.Add(ts);
            }
            return tsList;
        }

        private ICollection<WorkExperience> ToWorkExperienceList(List<WorkExperienceBDO> tcl)
        {
            ICollection<WorkExperience> weList = new List<WorkExperience>();
            foreach (WorkExperienceBDO web in tcl)
            {
                WorkExperience we = new WorkExperience();
                ConvertWorkExperienceBDOToWorkExperience(web, we);
                weList.Add(we);
            }
            return weList;
        }


        private List<WorkExperienceBDO> ToWorkExperienceBDOList(ICollection<WorkExperience> tcl)
        {
            List<WorkExperienceBDO> weList = new List<WorkExperienceBDO>();
            foreach (WorkExperience web in tcl)
            {
                WorkExperienceBDO we = new WorkExperienceBDO();
                ConvertWorkExperienceToWorkExperienceBDO(web, we);
                weList.Add(we);
            }
            return weList;
        }

        private ICollection<TeacherEducationalBackground> ToEducationalBackList(List<TeacherEducationalBackgroundBDO> tcl)
        {
            ICollection<TeacherEducationalBackground> ebList = new List<TeacherEducationalBackground>();
            foreach (TeacherEducationalBackgroundBDO tc in tcl)
            {
                TeacherEducationalBackground eb = new TeacherEducationalBackground();
                ConvertTeacherEducationalBackgroundBDOToTeacherEducationalBackground(tc, eb);
                ebList.Add(eb);
            }
            return ebList;
        }

        private List<TeacherEducationalBackgroundBDO> ToEducationalBackBDOList(ICollection<TeacherEducationalBackground> tcl)
        {
            List<TeacherEducationalBackgroundBDO> ebList = new List<TeacherEducationalBackgroundBDO>();
            foreach (TeacherEducationalBackground tc in tcl)
            {
                TeacherEducationalBackgroundBDO eb = new TeacherEducationalBackgroundBDO();
                ConvertTeacherEducationalBackgroundToTeacherEducationalBackgroundBDO(tc, eb);
                ebList.Add(eb);
            }
            return ebList;
        }


        private ICollection<TeacherChildren> ToChildrenList(List<TeacherChildrenBDO> tcl)
        {
            ICollection<TeacherChildren> tcList = new List<TeacherChildren>();
            foreach (TeacherChildrenBDO tc in tcl)
            {
                TeacherChildren tchild = new TeacherChildren();
                ConvertTeacherChildrenBDOToTeacherChildren(tc, tchild);
                tcList.Add(tchild);
            }
            return tcList;
        }

        private List<TeacherChildrenBDO> ToChildrenBDOList(ICollection<TeacherChildren> tcl)
        {
            List<TeacherChildrenBDO> tcList = new List<TeacherChildrenBDO>();
            foreach (TeacherChildren tc in tcl)
            {
                TeacherChildrenBDO tchild = new TeacherChildrenBDO();
                ConvertTeacherChildrenToTeacherChildrenBDO(tc, tchild);
                tcList.Add(tchild);
            }
            return tcList;
        }

        private ICollection<TeacherEligibility> ToEligibilityList(List<TeacherEligibilityBDO> tcl)
        {
            ICollection<TeacherEligibility> teList = new List<TeacherEligibility>();
            foreach (TeacherEligibilityBDO tc in tcl)
            {
                TeacherEligibility telig = new TeacherEligibility();
                ConvertTeacherEligibilityBDOToTeacherEligibility(tc, telig);
                teList.Add(telig);
            }
            return teList;
        }

        private List<TeacherEligibilityBDO> ToEligibilityBDOList(ICollection<TeacherEligibility> tcl)
        {
            List<TeacherEligibilityBDO> teList = new List<TeacherEligibilityBDO>();
            foreach (TeacherEligibility tc in tcl)
            {
                TeacherEligibilityBDO telig = new TeacherEligibilityBDO();
                ConvertTeacherEligibilityToTeacherEligibilityBDO(tc, telig);
                teList.Add(telig);
            }
            return teList;
        }


        public void ConvertTeacherToTeacherBDO(Teacher teacher, TeacherBDO tb)
        {
            tb.TeacherId = teacher.TeacherId;
            tb.LastName = teacher.LastName;
            tb.FirstName = teacher.FirstName;
            tb.MiddleName = teacher.MiddleName;
            tb.Deactivated = teacher.Deactivated;
            tb.Gender = teacher.Gender;
            tb.DOB = teacher.DOB;
            tb.TIN = teacher.TIN;
            tb.DateOfAppointment = teacher.DateOfAppointment;
            tb.EmploymentStatus = teacher.EmploymentStatus;
            tb.POBProvince = teacher.POBProvince;
            tb.POBMunicipality = teacher.POBMunicipality;
            tb.CivilStatus = teacher.CivilStatus;
            tb.HeightCm = teacher.HeightCm;
            tb.WeightKg = teacher.WeightKg;
            tb.BloodType = teacher.BloodType;
            tb.SSSNum = teacher.SSSNum;
            tb.PagIBIGNo = teacher.PagIBIGNo;
            tb.PhilHealthNo = teacher.PhilHealthNo;
            tb.RAStreetName = teacher.RAStreetName;
            tb.RARegion = teacher.RARegion;
            tb.RAProvince = teacher.RAProvince;
            tb.RAMunicipality = teacher.RAMunicipality;
            tb.ResTelephoneNo = teacher.ResTelephoneNo;
            tb.PAStreetName = teacher.PAStreetName;
            tb.PARegion = teacher.PARegion;
            tb.PAProvince = teacher.PAProvince;
            tb.PAMunicipality = teacher.PAMunicipality;
            tb.EmailAddress = teacher.EmailAddress;
            tb.MobileNo = teacher.MobileNo;
            tb.PreviousSchool = teacher.PreviousSchool;
            tb.DialectSpoken = teacher.DialectSpoken;
            tb.SpouseLastName = teacher.SpouseLastName;
            tb.SpouseFirstName = teacher.SpouseFirstName;
            tb.SpouseMiddleName = teacher.SpouseMiddleName;
            tb.SpouseOccupation = teacher.SpouseOccupation;
            tb.SpouseBusinessAdd = teacher.SpouseBusinessAdd;
            tb.SpouseEmployerName = teacher.SpouseEmployerName;
            tb.SpouseTelephoneNo = teacher.SpouseTelephoneNo;
            tb.PERAA = teacher.PERAA;
            tb.Image = teacher.Image;
            if (teacher.Academic == null)
                tb.Academic = true;
            else
                tb.Academic = (bool)teacher.Academic;
            if (teacher.Salary == null)
                tb.Salary = 0.00;
            else tb.Salary = teacher.Salary;

            tb.Department = teacher.Department;
            

        }

        public void ConvertTeacherBDOToTeacher(TeacherBDO teacher, Teacher tb)
        {
            ICollection<TeacherChildren> tc = new List<TeacherChildren>();
            tc = ToChildrenList(teacher.TeacherChildrens);

            ICollection<TeacherEligibility> te = new List<TeacherEligibility>();
            te = ToEligibilityList(teacher.TeacherEligibilities);

            ICollection<TeacherEducationalBackground> eb = new List<TeacherEducationalBackground>();
            eb = ToEducationalBackList(teacher.TeacherEducationalBackgrounds);

            ICollection<TrainingSeminar> ts = new List<TrainingSeminar>();
            ts = ToTrainingSeminarList(teacher.TrainingSeminars);

            ICollection<WorkExperience> we = new List<WorkExperience>();
            we = ToWorkExperienceList(teacher.WorkExperiences);

            tb.TeacherId = teacher.TeacherId;
            tb.LastName = teacher.LastName;
            tb.FirstName = teacher.FirstName;
            tb.MiddleName = teacher.MiddleName;
            tb.Deactivated = teacher.Deactivated;
            tb.Gender = teacher.Gender;
            tb.DOB = teacher.DOB;
            tb.TIN = teacher.TIN;
            tb.DateOfAppointment = teacher.DateOfAppointment;
            tb.EmploymentStatus = teacher.EmploymentStatus;
            tb.POBProvince = teacher.POBProvince;
            tb.POBMunicipality = teacher.POBMunicipality;
            tb.CivilStatus = teacher.CivilStatus;
            tb.HeightCm = teacher.HeightCm;
            tb.WeightKg = teacher.WeightKg;
            tb.BloodType = teacher.BloodType;
            tb.SSSNum = teacher.SSSNum;
            tb.PagIBIGNo = teacher.PagIBIGNo;
            tb.PhilHealthNo = teacher.PhilHealthNo;
            tb.RAStreetName = teacher.RAStreetName;
            tb.RARegion = teacher.RARegion;
            tb.RAProvince = teacher.RAProvince;
            tb.RAMunicipality = teacher.RAMunicipality;
            tb.ResTelephoneNo = teacher.ResTelephoneNo;
            tb.PAStreetName = teacher.PAStreetName;
            tb.PARegion = teacher.PARegion;
            tb.PAProvince = teacher.PAProvince;
            tb.PAMunicipality = teacher.PAMunicipality;
            tb.EmailAddress = teacher.EmailAddress;
            tb.MobileNo = teacher.MobileNo;
            tb.PreviousSchool = teacher.PreviousSchool;
            tb.DialectSpoken = teacher.DialectSpoken;
            tb.SpouseLastName = teacher.SpouseLastName;
            tb.SpouseFirstName = teacher.SpouseFirstName;
            tb.SpouseMiddleName = teacher.SpouseMiddleName;
            tb.SpouseOccupation = teacher.SpouseOccupation;
            tb.SpouseBusinessAdd = teacher.SpouseBusinessAdd;
            tb.SpouseEmployerName = teacher.SpouseEmployerName;
            tb.SpouseTelephoneNo = teacher.SpouseTelephoneNo;
            tb.PERAA = teacher.PERAA;
            tb.Image = teacher.Image;
            tb.TeacherChildrens = tc;
            tb.TeacherEligibilities = te;
            tb.TeacherEducationalBackgrounds = eb;
            tb.TrainingSeminars = ts;
            tb.WorkExperiences = we;
            tb.Academic = teacher.Academic;
            tb.Salary = teacher.Salary;
            tb.Department = teacher.Department;

        }

        private void ConvertTeacherChildrenBDOToTeacherChildren(TeacherChildrenBDO tc, TeacherChildren t, string teacherId)
        {
            t.ChildId = tc.ChildId;
            t.DOB = tc.DOB;
            t.FirstName = tc.FirstName;
            t.LastName = tc.LastName;
            t.MiddleName = tc.MiddleName;
            t.TeacherId = teacherId;
        }

        private void ConvertTeacherChildrenBDOToTeacherChildren(TeacherChildrenBDO tc, TeacherChildren t)
        {
            t.ChildId = tc.ChildId;
            t.DOB = tc.DOB;
            t.FirstName = tc.FirstName;
            t.LastName = tc.LastName;
            t.MiddleName = tc.MiddleName;
            t.TeacherId = tc.TeacherId;
        }


        private void ConvertTeacherChildrenToTeacherChildrenBDO(TeacherChildren tc, TeacherChildrenBDO t)
        {
            t.ChildId = tc.ChildId;
            t.DOB = (DateTime)tc.DOB;
            t.FirstName = tc.FirstName;
            t.LastName = tc.LastName;
            t.MiddleName = tc.MiddleName;
            t.TeacherId = tc.TeacherId;
        }
        private void ConvertTeacherEligibilityBDOToTeacherEligibility(TeacherEligibilityBDO tc, TeacherEligibility telig, string teacherId)
        {
            telig.DateOfExam = tc.DateOfExam;
            telig.Eligibility = tc.Eligibility;
            telig.EligibilityId = tc.EligibilityId;
            telig.IssueDate = tc.IssueDate;
            telig.LicenseNumber = tc.LicenseNumber;
            telig.PlaceOfExam = tc.PlaceOfExam;
            telig.Rating = tc.Rating;
            telig.TeacherId = teacherId;
        }

        private void ConvertTeacherEligibilityBDOToTeacherEligibility(TeacherEligibilityBDO tc, TeacherEligibility telig)
        {
            telig.DateOfExam = tc.DateOfExam;
            telig.Eligibility = tc.Eligibility;
            telig.EligibilityId = tc.EligibilityId;
            telig.IssueDate = tc.IssueDate;
            telig.LicenseNumber = tc.LicenseNumber;
            telig.PlaceOfExam = tc.PlaceOfExam;
            telig.Rating = tc.Rating;
            telig.TeacherId = tc.TeacherId;
        }

        public void ConvertTeacherEligibilityToTeacherEligibilityBDO(TeacherEligibility tc, TeacherEligibilityBDO telig)
        {
            telig.DateOfExam = (DateTime)tc.DateOfExam;
            telig.Eligibility = tc.Eligibility;
            telig.EligibilityId = tc.EligibilityId;
            telig.IssueDate = (DateTime)tc.IssueDate;
            telig.LicenseNumber = tc.LicenseNumber;
            telig.PlaceOfExam = tc.PlaceOfExam;
            telig.Rating = tc.Rating;
            telig.TeacherId = tc.TeacherId;
        }

        public void ConvertTeacherEducationalBackgroundBDOToTeacherEducationalBackground(TeacherEducationalBackgroundBDO tc, TeacherEducationalBackground eb, string teacherId)
        {
            eb.Course = tc.Course;
            eb.Deactivated = tc.Deactivated;
            eb.EducLevel = tc.EducLevel;
            eb.HonorsReceived = tc.HonorsReceived;
            eb.NameOfSchool = tc.NameOfSchool;
            eb.TeacherId = teacherId;
            eb.TEBId = tc.TEBId;
            eb.TEBYearFrom = tc.TEBYearFrom;
            eb.TEBYearTo = tc.TEBYearTo;
        }

        public void ConvertTeacherEducationalBackgroundBDOToTeacherEducationalBackground(TeacherEducationalBackgroundBDO tc, TeacherEducationalBackground eb)
        {
            eb.Course = tc.Course;
            eb.Deactivated = tc.Deactivated;
            eb.EducLevel = tc.EducLevel;
            eb.HonorsReceived = tc.HonorsReceived;
            eb.NameOfSchool = tc.NameOfSchool;
            eb.TeacherId = tc.TeacherId;
            eb.TEBId = tc.TEBId;
            eb.TEBYearFrom = tc.TEBYearFrom;
            eb.TEBYearTo = tc.TEBYearTo;
        }

        public void ConvertTeacherEducationalBackgroundToTeacherEducationalBackgroundBDO(TeacherEducationalBackground tc, TeacherEducationalBackgroundBDO eb)
        {
            eb.Course = tc.Course;
            eb.Deactivated = tc.Deactivated;
            eb.EducLevel = tc.EducLevel;
            eb.HonorsReceived = tc.HonorsReceived;
            eb.NameOfSchool = tc.NameOfSchool;
            eb.TeacherId = tc.TeacherId;
            eb.TEBId = tc.TEBId;
            eb.TEBYearFrom = (DateTime)tc.TEBYearFrom;
            eb.TEBYearTo = (DateTime)tc.TEBYearTo;
        }

        public void ConvertTrainingSeminarBDOToTrainingSeminar(TrainingSeminarBDO tsb, TrainingSeminar ts, string teacherId)
        {
            ts.AreaOfTraining = tsb.AreaOfTraining;
            ts.ConductedBy = tsb.ConductedBy;
            ts.DateFrom = tsb.DateFrom;
            ts.DateTo = tsb.DateTo;
            ts.NoOfHours = tsb.NoOfHours;
            ts.TeacherId = teacherId;
            ts.Title = tsb.Title;
            ts.TSID = tsb.TSID;
        }

        public void ConvertTrainingSeminarBDOToTrainingSeminar(TrainingSeminarBDO tsb, TrainingSeminar ts)
        {
            ts.AreaOfTraining = tsb.AreaOfTraining;
            ts.ConductedBy = tsb.ConductedBy;
            ts.DateFrom = tsb.DateFrom;
            ts.DateTo = tsb.DateTo;
            ts.NoOfHours = tsb.NoOfHours;
            ts.TeacherId = tsb.TeacherId;
            ts.Title = tsb.Title;
            ts.TSID = tsb.TSID;
        }

        public void ConvertTrainingSeminarToTrainingSeminarBDO(TrainingSeminar tsb, TrainingSeminarBDO ts)
        {
            ts.AreaOfTraining = tsb.AreaOfTraining;
            ts.ConductedBy = tsb.ConductedBy;
            ts.DateFrom = (DateTime)tsb.DateFrom;
            ts.DateTo = (DateTime)tsb.DateTo;
            ts.NoOfHours = (double)tsb.NoOfHours;
            ts.TeacherId = tsb.TeacherId;
            ts.Title = tsb.Title;
            ts.TSID = tsb.TSID;
        }

        public void ConvertWorkExperienceBDOToWorkExperience(WorkExperienceBDO web, WorkExperience we, string teacherId)
        {
            we.CompanyName = web.CompanyName;
            we.MonthlySalary = web.MonthlySalary;
            we.Position = web.Position;
            we.StatusOfEmployment = web.StatusOfEmployment;
            we.TeacherId = teacherId;
            we.WEId = web.WEId;
            we.WorkExpFrom = web.WorkExpFrom;
            we.WorkExpTo = web.WorkExpTo;
        }

        public void ConvertWorkExperienceBDOToWorkExperience(WorkExperienceBDO web, WorkExperience we)
        {
            we.CompanyName = web.CompanyName;
            we.MonthlySalary = web.MonthlySalary;
            we.Position = web.Position;
            we.StatusOfEmployment = web.StatusOfEmployment;
            we.TeacherId = web.TeacherId;
            we.WEId = web.WEId;
            we.WorkExpFrom = web.WorkExpFrom;
            we.WorkExpTo = web.WorkExpTo;
        }

        public void ConvertWorkExperienceToWorkExperienceBDO(WorkExperience web, WorkExperienceBDO we)
        {
            we.CompanyName = web.CompanyName;
            we.MonthlySalary = web.MonthlySalary;
            we.Position = web.Position;
            we.StatusOfEmployment = web.StatusOfEmployment;
            we.TeacherId = web.TeacherId;
            we.WEId = web.WEId;
            we.WorkExpFrom = web.WorkExpFrom;
            we.WorkExpTo = web.WorkExpTo;
        }

        public Boolean CreateTeacherChildren(List<TeacherChildrenBDO> tcbdo, string teacherId)
        {
            Boolean ret = true;
            try { 
            foreach (TeacherChildrenBDO t in tcbdo)
            {
                TeacherChildren tc = new TeacherChildren();
                ConvertTeacherChildrenBDOToTeacherChildren(t, tc, teacherId);
                using (var DCEnt = new DCFIEntities())
                {
                    DCEnt.TeacherChildrens.Attach(tc);
                    int num = DCEnt.SaveChanges();
                    if (num != 1)
                        ret = false;
                }
            }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
            return ret;
        }

        public Boolean CreateTeacherEligibilities(List<TeacherEligibilityBDO> tcbdo, string teacherId)
        {
            Boolean ret = true;
            try { 
            foreach (TeacherEligibilityBDO t in tcbdo)
            {
                TeacherEligibility te = new TeacherEligibility();
                ConvertTeacherEligibilityBDOToTeacherEligibility(t, te, teacherId);
                using (var DCEnt = new DCFIEntities())
                {
                    DCEnt.TeacherEligibilities.Attach(te);
                    int num = DCEnt.SaveChanges();
                    if (num != 1)
                        ret = false;
                }
            }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
            return ret;
        }

        public Boolean CreateTeacherEducationalBackground(List<TeacherEducationalBackgroundBDO> tcbdo, string teacherId)
        {
            Boolean ret = true;
            try { 
            foreach (TeacherEducationalBackgroundBDO t in tcbdo)
            {
                TeacherEducationalBackground te = new TeacherEducationalBackground();
                ConvertTeacherEducationalBackgroundBDOToTeacherEducationalBackground(t, te, teacherId);
                using (var DCEnt = new DCFIEntities())
                {
                    DCEnt.TeacherEducationalBackgrounds.Attach(te);
                    int num = DCEnt.SaveChanges();
                    if (num != 1)
                        ret = false;
                }
            }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
            return ret;
        }

        public Boolean CreateTrainingSeminars(List<TrainingSeminarBDO> tcbdo, string teacherId)
        {
            Boolean ret = true;
            try { 
            foreach (TrainingSeminarBDO t in tcbdo)
            {
                TrainingSeminar te = new TrainingSeminar();
                ConvertTrainingSeminarBDOToTrainingSeminar(t, te, teacherId);
                using (var DCEnt = new DCFIEntities())
                {
                    DCEnt.TrainingSeminars.Attach(te);
                    int num = DCEnt.SaveChanges();
                    if (num != 1)
                        ret = false;
                }
            }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
            return ret;
        }


        public Boolean CreateWorkExperiences(List<WorkExperienceBDO> tcbdo, string teacherId)
        {
            Boolean ret = true;
            try { 
            foreach (WorkExperienceBDO t in tcbdo)
            {
                WorkExperience te = new WorkExperience();
                ConvertWorkExperienceBDOToWorkExperience(t, te, teacherId);
                using (var DCEnt = new DCFIEntities())
                {
                    DCEnt.WorkExperiences.Attach(te);
                    int num = DCEnt.SaveChanges();
                    if (num != 1)
                        ret = false;
                }
            }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
            return ret;
        }
    }
}
