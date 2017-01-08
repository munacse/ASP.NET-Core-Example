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
    public class CourseRepository : IRepository<Course>
    {
        StudentMngContext context;

        //public CourseRepository()
        //    : this(new StudentMngContext())
        //{

        //}
        public CourseRepository(StudentMngContext context)
        {

            this.context = context;
        }

        public IQueryable<Course> All
        {
            get { return context.Courses; }
        }

        public IQueryable<Course> AllIncluding(params Expression<Func<Course, object>>[] includeProperties)
        {
            IQueryable<Course> query = context.Courses;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public List<Course> GetAll()
        {
            return context.Courses.Include(c => c.StudentCourses).ToList();
        }

        public Course Find(long id)
        {
            //return context.Students.Find(id);
            return context.Courses.Where(c => c.CourseId == id ).FirstOrDefault();
        }

        public void InsertOrUpdate(Course course)
        {
            if (course.CourseId == default(long))
            {
                // New entity
                context.Courses.Add(course);
            }
            else
            {
                // Existing entity
                context.Entry(course).State = EntityState.Modified;
            }
        }

        public void Delete(long id)
        {
            var course = context.Courses.Where(c=>c.CourseId==id);
            context.Remove(course);
            Save();
            //context.Courses.Remove(course);
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
