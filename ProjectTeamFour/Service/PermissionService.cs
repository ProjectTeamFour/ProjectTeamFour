using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectTeamFour.Repositories;
using System.Data.Entity;
using ProjectTeamFour.Models;
using ProjectTeamFour.ViewModels;

namespace ProjectTeamFour.Service
{
    public class PermissionService
    {
        private readonly DbContext _context;
        private readonly BaseRepository _repository;
        public PermissionService()
        {
            _context = new ProjectContext();
            _repository = new BaseRepository(_context);
        }
        public IEnumerable<Permission> GetPermissions()
        {     
            return _repository.GetAll<Permission>();
        }
        public CheckPermissionViewModel CheckPermission(int memberId,int permissionId)
        {
            int mem_per = _repository.GetAll<Member>().FirstOrDefault(m => m.MemberId == memberId).Permission;
            string mem_perString = Convert.ToString(mem_per,2);
            int per_value = _repository.GetAll<Permission>().FirstOrDefault(m => m.PermissionId == permissionId).PermissionValue;
            string per_valueString = Convert.ToString(per_value, 2);
            CheckPermissionViewModel cv = new CheckPermissionViewModel()
            {
                MemberId = memberId,
                PermissionId = permissionId,
                Checked = false
            };
            if (per_value<=mem_per&&mem_perString[per_valueString.Length - 1] == '1')
            {
                cv.Checked = true;
            }
            return cv;
        }
        public string SetPermission(int memberId, int permissionId, bool check)
        {
            using (DbContextTransaction transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    int permissionValue = _repository.GetAll<Permission>().FirstOrDefault(p => p.PermissionId == permissionId).PermissionValue;
                    Member entity = _repository.GetAll<Member>().FirstOrDefault(p => p.MemberId == memberId);
                    if (check)
                    {
                        entity.Permission = entity.Permission + permissionValue;
                    }
                    else
                    {
                        entity.Permission = entity.Permission - permissionValue;
                    }
                    _repository.Update(entity);
                    transaction.Commit();
                    return entity.Permission.ToString();
                }
                catch(Exception ex)
                {
                    transaction.Rollback();
                    return ($"修改失敗:{ex.Message}");
                }
            }
        }
    }
}