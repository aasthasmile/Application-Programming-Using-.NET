using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mm.DataAccessLayer
{
    public interface IStandardRepository : IGenericDataRepository<Standard>
    {
    }

    public interface IStudentRepository : IGenericDataRepository<Student>
    {
    }

    public class StandardRepository : GenericDataRepository<Standard>, IStandardRepository
    {
        public StandardRepository()
            : base(new SchoolDBEntities())
        {
        }
    }

    public class StudentRepository : GenericDataRepository<Student>, IStudentRepository
    {
        private SchoolDBEntities studentEntity;
        private DbSet<Student> table = null;
        public StudentRepository(SchoolDBEntities entities)
            : base(entities)
        {
            studentEntity = entities;
            table = studentEntity.Set<Student>();
        }
    }
}
