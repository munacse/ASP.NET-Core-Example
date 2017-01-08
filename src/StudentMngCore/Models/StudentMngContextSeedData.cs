using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMngCore.Models
{
    public class StudentMngContextSeedData
    {
        private StudentMngContext _context;
        public StudentMngContextSeedData(StudentMngContext context)
        {
            _context = context;
        }

        public async Task EnsureSeedData()
        {
            if(!_context.Courses.Any())
            {
                var courses = new List<Course>()
                {
                    new Course() { Name = "English 1", Code ="E1232"},
                    new Course() { Name = "Physics 1", Code ="P3249"},
                    new Course() { Name = "Physics 2", Code ="P3250"},
                    new Course() { Name = "Algorithm", Code ="CSE1207"},
                    new Course() { Name = "Data Structure", Code ="CSE9871"},
                    new Course() { Name = "Java", Code ="CSE7354"},
                    new Course() { Name = "Database", Code ="CSE9826"},
                    new Course() { Name = "Web Programming", Code ="CSE9825"},
                    new Course() { Name = "Web Security", Code ="CSE4309"}
                };

                _context.Courses.AddRange(courses);
                await _context.SaveChangesAsync();
            }
        }
    }
}
