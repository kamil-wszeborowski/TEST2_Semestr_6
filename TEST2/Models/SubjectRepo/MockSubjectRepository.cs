using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TEST2.Models.SubjectRepo
{
    public class MockSubjectRepository : ISubjectRepository
    {
        private List<Subject> _subjectsList;
        

        public MockSubjectRepository()
        {
            _subjectsList = new List<Subject>()
            {
                new Subject()
                {
                    Id = 1,
                    SubjectName = "Matematyka 1",
                    TeacherId = "608b5260-37ca-49f5-a884-e8ee3e012cc5"
                },

                new Subject()
                {
                    Id = 2,
                    SubjectName = "Polski 1",
                    TeacherId = "608b5260-37ca-49f5-a884-e8ee3e012cc5"
                },

                new Subject()
                {
                    Id = 3,
                    SubjectName = "Angielski 1",
                    TeacherId = "1fcd2aa8-3196-468e-a3cf-064e5581a163"
                }
            };
            
        }

        public Subject Create(Subject createSubject)
        {
            Subject subject = _subjectsList.FirstOrDefault(s => s.Id == createSubject.Id);
            if (subject == null)
            {
                subject.SubjectName = createSubject.SubjectName;
                subject.TeacherId = createSubject.TeacherId;
                subject.Teacher = createSubject.Teacher;
            }
            return subject;
        }

        public Subject Delete(int Id)
        {
            Subject subject = _subjectsList.FirstOrDefault(s => s.Id == Id);
            if (subject != null)
            {
                _subjectsList.Remove(subject);
            }
            return subject;
        }

        public IEnumerable<Subject> GetAllSubject()
        {
            return _subjectsList;
        }

        public Subject GetSubject(int Id)
        {
            return _subjectsList.FirstOrDefault(s => s.Id == s.Id);
        }

        public Subject Update(Subject subjectChanges)
        {
            Subject subject = _subjectsList.FirstOrDefault(s => s.Id == subjectChanges.Id);
            if (subject != null)
            {
                subject.SubjectName = subjectChanges.SubjectName;
                subject.TeacherId = subjectChanges.TeacherId;
                subject.Teacher = subjectChanges.Teacher;
            }
            return subject;
        }

        /*
       public IEnumerable<Subject> GetAllTeacherSubject(string TeacherId)
       {
           var teacherSubjectsList = new List<Subject>();

           foreach (var i in _subjectsList)
           {
               teacherSubjectsList.Add(_subjectsList.FirstOrDefault(s => s.TeacherId == s.TeacherId));
           }

           return teacherSubjectsList;
       }
       */
    }
}
