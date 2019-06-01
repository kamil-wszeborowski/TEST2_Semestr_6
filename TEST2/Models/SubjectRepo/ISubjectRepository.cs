using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TEST2.Models.SubjectRepo
{
    public interface ISubjectRepository
    {
        Subject GetSubject(int Id);
        IEnumerable<Subject> GetAllSubject();
        Subject Create(Subject createSubject);
        Subject Update(Subject subjectChanges);
        Subject Delete(int Id);
        

        // IEnumerable<Subject> GetAllTeacherSubject(string TeacherId);
    }
}
