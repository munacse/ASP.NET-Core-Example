using Microsoft.EntityFrameworkCore;
using StudentMngCore.Interfaces;
using StudentMngCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudentMngCore.Repository
{
    public class StudentRepository : IRepository<Student>
    {
        StudentMngContext context;

        //public StudentRepository()
        //    : this(new StudentMngContext())
        //{

        //}
        public StudentRepository(StudentMngContext context)
        {

            this.context = context;
        }

        public IQueryable<Student> All
        {
            get { return context.Students; }
        }

        public IQueryable<Student> AllIncluding(params Expression<Func<Student, object>>[] includeProperties)
        {
            IQueryable<Student> query = context.Students;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public List<Student> GetAll()
        {
            return context.Students.ToList();
        }
        public Student Find(long id)
        {
            //return context.Students.Find(id);
            return context.Students.Where(s => s.StudentId == id)
                .Include(s => s.StudentCourses).FirstOrDefault();
        }

        public Student FindByRoll(string roll)
        {
            var stu = context.Students.Where(s => s.Roll == roll).FirstOrDefault();
            return stu;
        }

        public void InsertOrUpdate(Student student)
        {
            if (student.StudentId == default(long))
            {
                // New entity
                context.Students.Add(student);
            }
            else
            {
                // Existing entity
                context.Entry(student).State = EntityState.Modified;
            }
        }

        public void Delete(long id)
        {
            var student = context.Students.Where(s=>s.StudentId ==id);
            context.Remove(student);
            Save();
            //context.Students.Remove(student);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
