using StudentMngCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMngCore.Repository
{
    public class UnitOfWork : IDisposable
    {
        private StudentMngContext context;
        //public UnitOfWork()
        //{
        //    context = new StudentMngContext();
        //}
        public UnitOfWork(StudentMngContext _context)
        {
            this.context = _context;
        }
        //
        public StudentRepository _studentRepository;
        public StudentRepository StudentRepository
        {
            get
            {
                if (this._studentRepository == null)
                {
                    this._studentRepository = new StudentRepository(context);
                }
                return _studentRepository;
            }
        }

        public CourseRepository _courseRepository;
        public CourseRepository CourseRepository
        {
            get
            {
                if (this._courseRepository == null)
                {
                    this._courseRepository = new CourseRepository(context);
                }
                return _courseRepository;
            }
        }
        //
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
