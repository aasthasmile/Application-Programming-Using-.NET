using Mm.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mm.BusinessLayer
{
    public class BuinessLayer : IBusinessLayer
    {
        private readonly IGenericDataRepository<Standard> _standardRepository;
        private readonly IGenericDataRepository<Student> _studentRepository;
        public SchoolDBEntities globalEntities;
        public DbSet<Standard> standardTable;
        public DbSet<Student> studentTable;

        public BuinessLayer()
        {
            globalEntities = new SchoolDBEntities();
            _standardRepository = new GenericDataRepository<Standard>(globalEntities);
            _studentRepository = new GenericDataRepository<Student>(globalEntities);
            standardTable = globalEntities.Set<Standard>();
            studentTable = globalEntities.Set<Student>();
        }

        public IList<Standard> GetAllStandards()
        {
            return standardTable.ToList();
        }

        public Standard GetStandardByID(int id)
        {
            return _standardRepository.GetById(id);
        }

        public Standard GetStandardByName(string standardName)
        {
            return _standardRepository.GetSingle(d => d.StandardName.Equals(standardName), d => d.Students);
        }

        public void AddStandard(Standard standard)
        {
            /* Validation and error handling omitted */
            _standardRepository.Insert(standard);
        }

        public void UpdateStandard(Standard standard)
        {
            /* Validation and error handling omitted */
            _standardRepository.Update(standard);
        }

        public void RemoveStandard(Standard standard)
        {
            /* Validation and error handling omitted */
            _standardRepository.Delete(standard);
        }

        public IQueryable<Student> GetStudentsByStandardId(int id)
        {
            return _studentRepository.SearchFor(a => a.StandardId == id);
        }

        public Student GetStudentByName(string studentName)
        {
            return _studentRepository.GetSingle(d => d.StudentName.Equals(studentName));
        }

        public IList<Student> GetAllStudents()
        {
            return studentTable.ToList();
        }

        public Student GetStudentByID(int id)
        {
            return _studentRepository.GetById(id);
        }

        public void AddStudent(Student student)
        {
            /* Validation and error handling omitted */
            _studentRepository.Insert(student);
        }

        public void UpdateStudent(Student student)
        {
            /* Validation and error handling omitted */
            _studentRepository.Update(student);
        }

        public void RemoveStudent(Student student)
        {
            /* Validation and error handling omitted */
            _studentRepository.Delete(student);
        }
    }
}
