using ProjectTeamFour.Models;
using ProjectTeamFour.Repositories;
using ProjectTeamFour.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjectTeamFour.Service
{
    public class MailService
    {

        private DbContext _context;
        private BaseRepository _repository;
        public MailService()
        {
            _context = new ProjectContext();
            _repository = new BaseRepository(_context);
        }

        //public OperationResult ResetPassWord(MailViewModel input)
        //{
        //    var result = new OperationResult();
        //    try
        //    {
        //        Member entity = _repository.GetAll<Member>().FirstOrDefault(m => m.MemberRegEmail == input.MemberRegEmail);
        //        if (input.MemberRegEmail == entity.MemberRegEmail)
        //        {
        //            entity.MemberPassword = input.MemberPassword;
        //        }
        //        else
        //        {
        //            result.IsSuccessful = false;
        //            return result;
        //        }
        //        _repository.Update(entity);
        //        result.IsSuccessful = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        result.DateTime = DateTime.Now;
        //        result.Exception = ex;
        //        result.IsSuccessful = false;
        //    }
        //    return result;
        //}


        //public OperationResult SaveResetCode(MemberViewModel input)
        //{
        //    var result = new OperationResult();
        //    try
        //    {
        //        Member entity = _repository.GetAll<Member>().FirstOrDefault(m => m.MemberId == input.MemberId);

        //        if (entity.MemberId == input.MemberId)
        //        {

        //            entity.ResetPasswordCode = input.ResetPasswordCode;
        //        }

        //        else
        //        {
        //            result.IsSuccessful = false;
        //            return result;
        //        }
        //        _repository.Update(entity);
        //        result.IsSuccessful = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        result.DateTime = DateTime.Now;
        //        result.Exception = ex;
        //        result.IsSuccessful = false;
        //    }
        //    return result;
        //}



    }
}