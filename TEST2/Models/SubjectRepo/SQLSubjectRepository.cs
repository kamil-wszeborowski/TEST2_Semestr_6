using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TEST2.Data;

namespace TEST2.Models.SubjectRepo
{
    public class SQLSubjectRepository : ISubjectRepository
    {
        private readonly ApplicationDbContext context;

        public SQLSubjectRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Subject Create(Subject createSubject)
        {
            /*
                var subject = context.Subjects.Add(createSubject);
                subject.State = Microsoft.EntityFrameworkCore.EntityState.Added;
                context.SaveChanges();
            */
            context.Subjects.Add(createSubject);
            context.SaveChanges();
            return createSubject;
        }

        public Subject Delete(int Id)
        {
            Subject subject = context.Subjects.Find(Id);
            if (subject != null)
            {
                context.Subjects.Remove(subject);
                context.SaveChanges();
            }
            return subject;
        }

        public IEnumerable<Subject> GetAllSubject()
        {
            return context.Subjects;
        }

        public Subject GetSubject(int Id)
        {
            return context.Subjects.Find(Id);
        }

        public Subject Update(Subject subjectChanges)
        {
            var subject = context.Subjects.Attach(subjectChanges);
            subject.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return subjectChanges;
        }
    }
}
