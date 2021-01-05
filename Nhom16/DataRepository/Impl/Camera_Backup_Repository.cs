using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using DataRepository.Context;

namespace DataRepository.Impl
{
    public class Camera_Backup_Repository : IRepository<Camera_Backup>
    {
        private DataContext context;
        public Camera_Backup_Repository(DataContext context)
        {
            this.context = context;
        }

        public Camera_Backup_Repository()
        {
            context = new DataContext();
        }
        public void Create(Camera_Backup t)
        {
            throw new NotImplementedException();
        }

        public int Delete(Camera_Backup t)
        {
            throw new NotImplementedException();
        }

        public IList<Camera_Backup> Read()
        {
            return context.Camera_Backups.ToList();
        }

        public int Update(Camera_Backup t)
        {
            throw new NotImplementedException();
        }
    }
}
